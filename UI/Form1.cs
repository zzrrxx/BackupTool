using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace UI {
  public partial class Form1 : Form {
    private const string DYNAMIC_CONTEXT_MENU_PATH = "DynamicContextMenu.dll";
    private const string BACKUP_TOOL_REGISTRY_KEY  = "MyBackupTool";

    public Form1() {
      InitializeComponent();
      this.Icon = Icon.FromHandle(Properties.Resources.Backup.GetHicon());

      if (!LoadConfig()) {
        m_TextBoxGitPath.Text = GetGitPath();
        m_TextBoxSvnPath.Text = GetSvnPath();
        m_TextBoxBeyondCompPath.Text = GetBeyondComparePath();
      }
    }

    private void BtnSelectGit_Click(object sender, EventArgs e) {
      using (OpenFileDialog dialog = new OpenFileDialog()) {
        dialog.InitialDirectory = "C:\\";
        if (dialog.ShowDialog() == DialogResult.OK) {
          m_TextBoxGitPath.Text = dialog.FileName;
        }
      }
    }

    private void BtnSelectSvn_Click(object sender, EventArgs e) {
      using (OpenFileDialog dialog = new OpenFileDialog()) {
        dialog.InitialDirectory = "C:\\";
        if (dialog.ShowDialog() == DialogResult.OK) {
          m_TextBoxSvnPath.Text = dialog.FileName;
        }
      }
    }

    private void BtnSelectBeyondComp_Click(object sender, EventArgs e) {
      using (OpenFileDialog dialog = new OpenFileDialog()) {
        dialog.InitialDirectory = "C:\\";
        if (dialog.ShowDialog() == DialogResult.OK) {
          m_TextBoxBeyondCompPath.Text = dialog.FileName;
        }
      }
    }

    private void BtnSelectBackupFolder_Click(object sender, EventArgs e) {
      using (FolderBrowserDialog dialog = new FolderBrowserDialog()) {
        dialog.Description = "Select the folder to store backup files";
        dialog.ShowNewFolderButton = true;
        if (dialog.ShowDialog() == DialogResult.OK) {
          m_TextBoxBackupPath.Text = dialog.SelectedPath;
        }
      }
    }

    private void btnInstall_Click(object sender, EventArgs e) {
      if (!CheckConfig()) return;
      SaveConfig();

      string regAsm = GetRegAsmPath();
      if (regAsm.Length == 0) {
        MessageBox.Show("Cannot find a RegAsm.exe");
        return;
      }
      int exitCode = runCommand(regAsm, "/codebase " + DYNAMIC_CONTEXT_MENU_PATH);
      if (exitCode == 0) {
        MessageBox.Show("Install successfully");
      } else {
        MessageBox.Show("Failed to install context menu: " + exitCode);
      }
    }
    private void btnUninstall_Click(object sender, EventArgs e) {
      string regAsm = GetRegAsmPath();
      if (regAsm.Length == 0) {
        MessageBox.Show("Cannot find a RegAsm.exe");
        return;
      }
      int exitCode = runCommand(regAsm, "/u " + DYNAMIC_CONTEXT_MENU_PATH);
      if (exitCode == 0) {
        MessageBox.Show("Uninstall successfully");
      } else {
        MessageBox.Show("Failed to uninstall context menu: " + exitCode);
      }
    }

    private void BtnOK_Click(object sender, EventArgs e) {
      Close();
    }

    private bool CheckConfig() {
      if (!m_TextBoxGitPath.Text.EndsWith(".exe") && !m_TextBoxSvnPath.Text.EndsWith(".exe")) {
        MessageBox.Show("At least one of the SVN or Git should be set");
        return false;
      }
      // Beyond compare is not required
      if (!Directory.Exists(m_TextBoxBackupPath.Text)) {
        MessageBox.Show("Backup folder doesn't exist");
        return false;
      }
      // Ensure we have the write permission
      string testFolderName = Path.Combine(m_TextBoxBackupPath.Text, Guid.NewGuid().ToString());
      try {
        Directory.CreateDirectory(testFolderName);
      } catch (Exception ex) {
        MessageBox.Show("Invalid backup folder: Failed to write to the folder with the error: " + ex.Message);
        return false;
      } finally {
        if (Directory.Exists(testFolderName)) {
          try { Directory.Delete(testFolderName); } catch (Exception) { }
        }
      }
      return true;
    }
    private void SaveConfig() {
      try {
        Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\" + BACKUP_TOOL_REGISTRY_KEY, false);
        RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\" + BACKUP_TOOL_REGISTRY_KEY);

        key.SetValue("Git", m_TextBoxGitPath.Text);
        key.SetValue("Svn", m_TextBoxSvnPath.Text);
        key.SetValue("BeyondCompare", m_TextBoxBeyondCompPath.Text);
        key.SetValue("BackupFolder", m_TextBoxBackupPath.Text);
        key.SetValue("Bin", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

        key.Close();
      } catch (Exception ex) {
        MessageBox.Show("Failed to save the configuration: " + ex.Message);
      }
    }
    private bool LoadConfig() {
      try {
        RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\" + BACKUP_TOOL_REGISTRY_KEY);
        if (key == null) return false;

        m_TextBoxGitPath.Text = (string) key.GetValue("Git");
        m_TextBoxSvnPath.Text = (string) key.GetValue("Svn");
        m_TextBoxBeyondCompPath.Text = (string) key.GetValue("BeyondCompare");
        m_TextBoxBackupPath.Text = (string) key.GetValue("BackupFolder");
      } catch (Exception) {
        return false;
      }
      return true;
    }

    private string GetRegAsmPath() {
      DirectoryInfo netDir = null;
      if (Environment.Is64BitOperatingSystem) {
        netDir = new DirectoryInfo("C:\\Windows\\Microsoft.NET\\Framework64");
      } else {
        netDir = new DirectoryInfo("C:\\Windows\\Microsoft.NET\\Framework");
      }
      if (netDir.Exists) {
        DirectoryInfo[] netVerDirs = netDir.GetDirectories();
        foreach (DirectoryInfo curVerDir in netVerDirs) {
          FileInfo[] files = curVerDir.GetFiles("*.exe");
          foreach (FileInfo fi in files) {
            if (fi.Name.ToLower().Equals("regasm.exe")) return fi.FullName;
          }
        }
      }
      return "";
    }
    private string GetGitPath() { 
      string envPath = Environment.GetEnvironmentVariable("PATH");
      if (envPath.Length == 0) return "";

      string[] comps = envPath.Split(new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);
      foreach (string c in comps) {
        string normalizedPath = c.ToLower().Replace("\\", "/");
        if (normalizedPath.EndsWith("git/cmd")) {
          string gitExePath = Path.Combine(c, "git.exe");
          if (File.Exists(gitExePath)) return gitExePath;
        }
      }
      return "Not founded";
    }
    private string GetSvnPath() {
      string envPath = Environment.GetEnvironmentVariable("PATH");
      if (envPath.Length == 0) return "";

      string[] comps = envPath.Split(new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);
      foreach (string c in comps) {
        string normalizedPath = c.ToLower().Replace("\\", "/");
        if (normalizedPath.EndsWith("bin")) {
          string svnExePath = Path.Combine(c, "svn.exe");
          if (File.Exists(svnExePath)) return svnExePath;
        }
      }
      return "Not founded";
    }
    private string GetBeyondComparePath() { 
      DriveInfo[] drives = DriveInfo.GetDrives();
      foreach (DriveInfo d in drives) { 
        string path = string.Format("{0}Program Files\\Beyond Compare 4\\BCompare.exe", d.Name);
        if (File.Exists(path)) return path;
      }
      return "Not founded";
    }

    #region UTILS
    private static int runCommand(string exe, string args) {
      StringBuilder sb = new StringBuilder();
      Process process = new Process();
      process.StartInfo.RedirectStandardError = true;
      process.StartInfo.RedirectStandardOutput = true;
      process.StartInfo.FileName = exe;
      process.StartInfo.Arguments = args;
      process.StartInfo.UseShellExecute = false;
      process.OutputDataReceived += (o, e) => {
        if (e.Data != null) sb.AppendLine(e.Data);
#if DEBUG
        Console.WriteLine(e.Data);
#endif
      };
      process.ErrorDataReceived += (o, e) => {
        if (e.Data != null) sb.AppendLine(e.Data);
#if DEBUG
        Console.WriteLine(e.Data);
#endif
      };
      process.Start();
      process.BeginErrorReadLine();
      process.BeginOutputReadLine();

      process.WaitForExit();
      return process.ExitCode;
    }
    #endregion

  }
}
