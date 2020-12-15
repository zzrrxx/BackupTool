﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using SharpShell.Attributes;
using SharpShell.SharpContextMenu;

namespace DynamicContextMenu {

  [ComVisible(true)]
  [COMServerAssociation(AssociationType.Directory)]
  public class DynamicContextMenu : SharpContextMenu {
    
    private const string BACKUP_TOOL_REGISTRY_KEY  = "MyBackupTool";
    private const string BACKUP_TOOL               = "BackupTool.exe";

    private ContextMenuStrip m_Menu = new ContextMenuStrip();

    protected override bool CanShowMenu() {
      if (SelectedItemPaths.Count() != 1) return false;
      return GitUtils.isGitDir(SelectedItemPaths.First());
    }

    protected override ContextMenuStrip CreateMenu() {

      ToolStripMenuItem ctxMenu = new ToolStripMenuItem {
        Text = "MyBackup",
        Image = new Bitmap(Properties.Resources.Backup, new Size(16, 16))
      };

      ToolStripMenuItem backup = new ToolStripMenuItem {
        Text = "Backup manually",
      };
      backup.Click += (o, e) => {
        string workDir = SelectedItemPaths.First();
        bool isGit = GitUtils.isGitDir(workDir);
        if (isGit) {
          CallBackupTool("git manually " + workDir);
        }
      };

      ToolStripMenuItem backupAll = new ToolStripMenuItem {
        Text = "Backup All",
      };
      backupAll.Click += (o, e) => {
        string workDir = SelectedItemPaths.First();
        bool isGit = GitUtils.isGitDir(workDir);
        if (isGit) {
          CallBackupTool("git all " + workDir);
        }
      };

      ToolStripMenuItem backupModified = new ToolStripMenuItem {
        Text = "Backup modified",
      };
      backupModified.Click += (o, e) => {
        string workDir = SelectedItemPaths.First();
        bool isGit = GitUtils.isGitDir(workDir);
        if (isGit) {
          CallBackupTool("git modified " + workDir);
        }
      };

      ctxMenu.DropDownItems.Add(backup);
      ctxMenu.DropDownItems.Add(backupModified);
      ctxMenu.DropDownItems.Add(backupAll);

      m_Menu.Items.Clear();
      m_Menu.Items.Add(ctxMenu);

      return m_Menu;
    }

    private void CallBackupTool(string args) {

      string bin = "";
      try {
        RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\" + BACKUP_TOOL_REGISTRY_KEY);
        bin = (string)key.GetValue("Bin");
      } catch (Exception ex) {
        MessageBox.Show(ex.Message);
      }

      Process process = new Process();
      process.StartInfo.WorkingDirectory = bin;
      process.StartInfo.FileName = BACKUP_TOOL;
      process.StartInfo.Arguments = args;
      process.StartInfo.UseShellExecute = true;
      bool ret = process.Start();
      if (!ret) {
        MessageBox.Show("Failed to invoke " + BACKUP_TOOL);
      }
    }
  }
}
