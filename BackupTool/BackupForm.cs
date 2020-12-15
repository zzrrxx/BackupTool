using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace BackupTool {
  public partial class BackupForm : Form {
    public const int BACKUP_TYPE_MANUALLY = 0;
    public const int BACKUP_TYPE_MODIFIED = 1;
    public const int BACKUP_TYPE_ALL      = 2;

    private const string BACKUP_TOOL_REGISTRY_KEY = "MyBackupTool";

    // Configs
    private string m_Git           = "";
    private string m_Svn           = "";
    private string m_BeyondCompare = "";
    private string m_BackupFolder  = "";
    private bool   m_UseTimestamp  = false;
    private bool   m_DontAskAgain  = false;

    private string m_WorkDir       = "";

    public BackupForm(string backupTool, int backupType, string dir) {
      InitializeComponent();

      m_WorkDir = dir;
      SetUpListView(backupTool, backupType);
    }


    private void SetUpListView(string backupTool, int backupType) { 
      m_ListView.Items.Clear();

      // Although it's stupid to load the registry every time, but we can avoid detecting the registry changed event.
      try {
        LoadConfig();
      } catch (Exception ex) {
        MessageBox.Show("Failed to load the configuration: " + ex.Message);
        return;
      }

      switch (backupType) {
        case BACKUP_TYPE_MANUALLY:
          goto case BACKUP_TYPE_ALL;

        case BACKUP_TYPE_ALL: {
          bool itemChecked = backupType == BACKUP_TYPE_ALL;
          DirectoryInfo di = new DirectoryInfo(m_WorkDir);
          DirectoryInfo[] dirs = di.GetDirectories();
          foreach (DirectoryInfo dirInfo in dirs) {
            ListViewItem item = new ListViewItem();
            item.Tag = dirInfo;
            item.Checked = itemChecked;
            item.SubItems.Add(dirInfo.Name);
            item.SubItems.Add(dirInfo.LastWriteTimeUtc.ToString("yyyy/MM/dd HH:mm"));
            item.SubItems.Add("Folder");
            item.SubItems.Add("");
            m_ListView.Items.Add(item);
          }

          FileInfo[] files = di.GetFiles();
          foreach (FileInfo fileInfo in files) {
            ListViewItem item = new ListViewItem();
            item.Tag = fileInfo;
            item.Checked = itemChecked;
            item.SubItems.Add(fileInfo.Name);
            item.SubItems.Add(fileInfo.LastWriteTimeUtc.ToString("yyyy/MM/dd HH:mm"));
            item.SubItems.Add("File");
            item.SubItems.Add(fileInfo.Length + "");
            m_ListView.Items.Add(item);
          }
          break;
        }

        case BACKUP_TYPE_MODIFIED: {
            if (backupTool.ToLower() == "git") { 
              SetupGitModifiedListView(m_WorkDir);
            } else if (backupTool.ToLower() == "svn") {
              
            }
            break;
          }
      }
      
    }

    private void SetupGitModifiedListView(string dir) {
      StringBuilder standardOutput = new StringBuilder();
      StringBuilder standardError  = new StringBuilder();

      Process process = new Process();
      process.StartInfo.WorkingDirectory = dir;
      process.StartInfo.RedirectStandardError = true;
      process.StartInfo.RedirectStandardOutput = true;
      process.StartInfo.FileName = m_Git;
      process.StartInfo.Arguments = "status -s";
      process.StartInfo.UseShellExecute = false;
      process.OutputDataReceived += (o, e) => {
        if (e.Data != null) standardOutput.AppendLine(e.Data);
      };
      process.ErrorDataReceived += (o, e) => {
        if (e.Data != null) standardError.AppendLine(e.Data);
      };
      process.Start();
      process.BeginErrorReadLine();
      process.BeginOutputReadLine();

      process.WaitForExit();
      if (process.ExitCode == 0) {
        string[] entries = standardOutput.ToString().Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        m_ListView.Groups.Add(new ListViewGroup("Versioned"));
        m_ListView.Groups.Add(new ListViewGroup("Unversioned"));
        foreach (string entry in entries) {
          ListViewItem item = GenGitListViewItem(dir, entry);
          if (item == null) continue;

          if (item.Checked) item.Group = m_ListView.Groups[0];
          else              item.Group = m_ListView.Groups[1];
          m_ListView.Items.Add(item);
        }

        m_ListView.ListViewItemSorter = new ListViewFileTypeSorter();
        m_ListView.Sort();

      } else {
        MessageBox.Show("Failed to list modified files: error code: " + process.ExitCode + ", error message: " + standardError.ToString());
      }
    }
    private ListViewItem GenGitListViewItem(string dir, string entry) {
      string name = entry.Substring(3);
      if (name.StartsWith("..") || entry.StartsWith(" D ")) return null; // ignore the modified files in parent folders and deleted files
      bool isDir = entry.EndsWith("/");
      bool isModified = entry.StartsWith(" M ");

      ListViewItem item = new ListViewItem();
      item.Checked = isModified;
      if (isDir) {
        DirectoryInfo dirInfo = new DirectoryInfo(Path.Combine(dir, name));
        item.Tag = dirInfo;
        item.SubItems.Add(name.Remove(name.Length - 1));
        item.SubItems.Add(dirInfo.LastWriteTimeUtc.ToString("yyyy/MM/dd HH:mm"));
        item.SubItems.Add("Folder");
        item.SubItems.Add("");
      } else {
        FileInfo fileInfo = new FileInfo(Path.Combine(dir, name));
        item.Tag = fileInfo;
        item.SubItems.Add(name);
        item.SubItems.Add(fileInfo.LastWriteTimeUtc.ToString("yyyy/MM/dd HH:mm"));
        item.SubItems.Add("File");
        item.SubItems.Add(fileInfo.Length + "");
      }
      return item;
    }

    private void BtnBackup_Click(object sender, EventArgs e) {
      string backFolderName = Path.GetFileName(m_WorkDir);
      string backupTo = Path.Combine(m_BackupFolder, backFolderName);

      if (!m_DontAskAgain) {
        using (BackupDestDialog dialog = new BackupDestDialog()) {
          dialog.InitialBackupTo = backupTo; // set InitBackupTo first, so the UseTimestamp can modify it in BackupDestDialog
          dialog.UseTimestamp = m_UseTimestamp;
          if (dialog.ShowDialog() == DialogResult.OK) {
            m_DontAskAgain = dialog.DontAskMeAgain;
            m_UseTimestamp = dialog.UseTimestamp;

            try {
              RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\" + BACKUP_TOOL_REGISTRY_KEY, true);
              key.SetValue("UseTimestamp", m_UseTimestamp ? 1 : 0);
              key.SetValue("DontAskMeAgain", m_DontAskAgain ? 1 : 0);
              key.Close();
            } catch (Exception ex) {
              MessageBox.Show("Failed to store the backup configuration: " + ex.Message);
              return;
            }

            backupTo = dialog.BackupTo;
          } else {
            return;
          }
        }
      }

      try {

        Directory.CreateDirectory(backupTo);

        // Start to backup file
        List<string> srcs = new List<string>();
        List<string> dsts = new List<string>();
        foreach (ListViewItem item in m_ListView.Items) {
          if (!item.Checked) continue;

          if (item.Tag is DirectoryInfo) {
            List<DirectoryInfo> dirInfos = new List<DirectoryInfo>();
            DirectoryInfo curDirInfo = (DirectoryInfo) item.Tag;

            dirInfos.Add(curDirInfo);
            while (dirInfos.Count > 0) {
              DirectoryInfo dirInfo = dirInfos[0];
              dirInfos.RemoveAt(0);

              FileInfo[] fileInfos = dirInfo.GetFiles();
              foreach (FileInfo fi in fileInfos) {
                srcs.Add(fi.FullName);
                dsts.Add(Path.Combine(backupTo, GetRelativePath(m_WorkDir, fi.FullName)));
              }

              dirInfos.AddRange(dirInfo.GetDirectories());
            }
          } else {
            string sourcePath = ((FileInfo) item.Tag).FullName;
            srcs.Add(sourcePath);
            dsts.Add(Path.Combine(backupTo, GetRelativePath(m_WorkDir, sourcePath)));
          }
        }

        string src = "";
        string dst = "";
        for (int i = 0; i < srcs.Count; i++) {
          src += (srcs[i] + "\0");
          dst += (dsts[i] + "\0");
        }

        Shell.ShFile.wFunc = Shell.FO_Func.FO_COPY;
        Shell.ShFile.pFrom = src + "\0";
        Shell.ShFile.pTo = dst + "\0";
        Shell.ShFile.fFlags = (ushort) (Shell.FILEOP_FLAGS.FOF_NOCONFIRMMKDIR | Shell.FILEOP_FLAGS.FOF_MULTIDESTFILES);
        int result = Shell.SHFileOperation(ref Shell.ShFile);
        if (Shell.ShFile.fAnyOperationsAborted) throw new Exception("Operation aborted");
        if (result != 0) throw new Exception("Failed to back up files with error code: " + result);

        MessageBox.Show("Backup successfully\n\nBackup path: " + backupTo);

      } catch (Exception ex) {
        // clean the backup folder if we failed
        if (Directory.Exists(backupTo)) {
          Directory.Delete(backupTo, true);
        }

        MessageBox.Show(ex.Message);
      }
    }

    private void BtnCancel_Click(object sender, EventArgs e) {
      Close();
    }

    private void LoadConfig() {
      // thrown all exception out, so we can show an error message box
      RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\" + BACKUP_TOOL_REGISTRY_KEY);
      if (key == null) throw new Exception("Registry key is missing");

      m_Git = (string)key.GetValue("Git");
      m_Svn = (string)key.GetValue("Svn");
      m_BeyondCompare = (string)key.GetValue("BeyondCompare");
      m_BackupFolder = (string)key.GetValue("BackupFolder");

      if (!Directory.Exists(m_BackupFolder)) throw new Exception("Backup folder is missing");

      object useTimestamp = key.GetValue("UseTimestamp");
      object dontAskAgain = key.GetValue("DontAskMeAgain");
      m_UseTimestamp = useTimestamp != null && (int)useTimestamp == 1;
      m_DontAskAgain = dontAskAgain != null && (int)dontAskAgain == 1;
    }

    // https://stackoverflow.com/questions/703281/getting-path-relative-to-the-current-working-directory
    private string GetRelativePath(string folder, string sub) {
      Uri pathUri = new Uri(sub);
      // Folders must end in a slash
      if (!folder.EndsWith(Path.DirectorySeparatorChar.ToString())) {
        folder += Path.DirectorySeparatorChar;
      }
      Uri folderUri = new Uri(folder);
      return Uri.UnescapeDataString(folderUri.MakeRelativeUri(pathUri).ToString().Replace('/', Path.DirectorySeparatorChar));
    }

    class ListViewFileTypeSorter : IComparer {
      public int Compare(object x, object y) {
        ListViewItem item1 = (ListViewItem)x;
        ListViewItem item2 = (ListViewItem)y;
        return item1.SubItems[3].Text.CompareTo(item2.SubItems[3].Text) * -1; // Folder first
      }
    }
  }


  internal class Shell {

    public enum FO_Func: uint {
      FO_COPY   = 0x0002,
      FO_DELETE = 0x0003,
      FO_MOVE   = 0x0001,
      FO_RENAME = 0x0004,
    }
    public enum FILEOP_FLAGS: short {
      FOF_MULTIDESTFILES        = 0x0001,
      FOF_CONFIRMMOUSE          = 0x0002,
      FOF_SILENT                = 0x0044,
      FOF_RENAMEONCOLLISION     = 0x0008,
      FOF_NOCONFIRMATION        = 0x10,
      FOF_WANTMAPPINGHANDLE     = 0x0020,
      FOF_ALLOWUNDO             = 0x40,
      FOF_FILESONLY             = 0x0080,
      FOF_SIMPLEPROGRESS        = 0x0100,
      FOF_NOCONFIRMMKDIR        = 0x0200,
      FOF_NOERRORUI             = 0x0400,
      FOF_NOCOPYSECURITYATTRIBS = 0x0800,
      FOF_NORECURSION           = 0x1000
    }

    public struct SHFILEOPSTRUCT {
      public IntPtr hwnd;
      public FO_Func wFunc;
      [MarshalAs(UnmanagedType.LPWStr)]
      public string pFrom;
      [MarshalAs(UnmanagedType.LPWStr)]
      public string pTo;
      public ushort fFlags;
      public bool fAnyOperationsAborted;
      public IntPtr hNameMappings;
      [MarshalAs(UnmanagedType.LPWStr)]
      public string lpszProgressTitle;
    }

    [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
    public static extern int SHFileOperation([In] ref SHFILEOPSTRUCT lpFileOp);

    public static SHFILEOPSTRUCT ShFile;

  }
}
