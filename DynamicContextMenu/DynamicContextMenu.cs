using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using SharpShell.Attributes;
using SharpShell.SharpContextMenu;

namespace DynamicContextMenu {

  [ComVisible(true)]
  [COMServerAssociation(AssociationType.AllFiles)]
  [COMServerAssociation(AssociationType.Directory)]
  public class DynamicContextMenu : SharpContextMenu {

    private ContextMenuStrip m_Menu = new ContextMenuStrip();

    protected override bool CanShowMenu() {
      if (SelectedItemPaths.Count() != 1) return false;
      return GitUtils.isGitDir(SelectedItemPaths.First());
    }

    protected override ContextMenuStrip CreateMenu() {

      ToolStripMenuItem ctxMenu = new ToolStripMenuItem {
        Text = "MyBackup",
        Image = Properties.Resources.Folder_icon
      };

      ToolStripMenuItem backup = new ToolStripMenuItem {
        Text = "Backup manually",
        Image = Properties.Resources.Folder_icon
      };
      backup.Click += (o, e) => {
        
      };

      ToolStripMenuItem backupAll = new ToolStripMenuItem {
        Text = "Backup All",
        Image = Properties.Resources.Folder_icon
      };
      backupAll.Click += (o, e) => {

      };

      ToolStripMenuItem backupModified = new ToolStripMenuItem {
        Text = "Backup modified",
        Image = Properties.Resources.Folder_icon
      };
      backupModified.Click += (o, e) => {

      };

      ctxMenu.DropDownItems.Add(backup);
      ctxMenu.DropDownItems.Add(backupModified);
      ctxMenu.DropDownItems.Add(backupAll);

      m_Menu.Items.Clear();
      m_Menu.Items.Add(ctxMenu);

      return m_Menu;
    }

    private void UpdateMenu() {
      m_Menu.Dispose();
      m_Menu = CreateMenu();
    }
  }
}
