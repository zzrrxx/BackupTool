using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BackupTool {
  public partial class BackupForm : Form {
    public const int BACKUP_TYPE_MANUALLY = 0;
    public const int BACKUP_TYPE_MODIFIED = 1;
    public const int BACKUP_TYPE_ALL      = 2;

    private const string BACKUP_TOOL_REGISTRY_KEY = "MyBackupTool";

    private string m_Git = "";
    private string m_Svn = "";
    private string m_BeyondCompare = "";
    private string m_BackupFolder = "";

    public BackupForm(string backupTool, int backupType, string dir) {
      InitializeComponent();
      SetUpListView(backupTool, backupType, dir);
    }


    private void SetUpListView(string backupTool, int backupType, string dir) { 
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
          DirectoryInfo di = new DirectoryInfo(dir);
          DirectoryInfo[] dirs = di.GetDirectories();
          foreach (DirectoryInfo dirInfo in dirs) {
            ListViewItem item = new ListViewItem();
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
              SetupGitModifiedListView(dir);
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
      ListViewItem item = new ListViewItem();
      string name = entry.Substring(3);
      bool isDir = entry.EndsWith("/");
      bool isModified = entry.StartsWith(" M ");
      item.Checked = isModified;
      if (isDir) {
        DirectoryInfo dirInfo = new DirectoryInfo(Path.Combine(dir, name));
        item.SubItems.Add(name.Remove(name.Length - 1));
        item.SubItems.Add(dirInfo.LastWriteTimeUtc.ToString("yyyy/MM/dd HH:mm"));
        item.SubItems.Add("Folder");
        item.SubItems.Add("");
      } else {
        FileInfo fileInfo = new FileInfo(Path.Combine(dir, name));
        item.SubItems.Add(name);
        item.SubItems.Add(fileInfo.LastWriteTimeUtc.ToString("yyyy/MM/dd HH:mm"));
        item.SubItems.Add("File");
        item.SubItems.Add(fileInfo.Length + "");
      }
      return item;
    }

    private void BtnCancel_Click(object sender, EventArgs e) {
      Close();
    }

    private void LoadConfig() {
      // thrown all exception out, so we can show an error message box
      RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\" + BACKUP_TOOL_REGISTRY_KEY);
      if (key == null) throw new Exception("Registry key is missing");

      m_Git = (string)key.GetValue("Git");
      m_Svn = (string)key.GetValue("Svn");
      m_BeyondCompare = (string)key.GetValue("BeyondCompare");
      m_BackupFolder = (string)key.GetValue("BackupFolder");

      if (!Directory.Exists(m_BackupFolder)) throw new Exception("Backup folder is missing");
    }

    class ListViewFileTypeSorter : IComparer {
      public int Compare(object x, object y) {
        ListViewItem item1 = (ListViewItem)x;
        ListViewItem item2 = (ListViewItem)y;
        return item1.SubItems[3].Text.CompareTo(item2.SubItems[3].Text) * -1; // Folder first
      }
    }
  }
}
