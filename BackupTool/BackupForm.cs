using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

    private int m_BackupType = BACKUP_TYPE_MANUALLY;
    public BackupForm(int backupType) {
      InitializeComponent();

      setUpListView(backupType);
      
      //ListViewItem item = new ListViewItem();
      //item.SubItems.Add("A");
      //item.SubItems.Add("A");
      //item.SubItems.Add("D");
      //item.SubItems.Add("D");
      //item.SubItems.Add("AD");

      //m_ListView.Items.Add(item);
    }


    private void setUpListView(int backupType) { 
      string testDir = @"D:\Dev\code\go\src\mynet";
      
      m_ListView.Items.Clear();

      switch (backupType) { 
        case BACKUP_TYPE_ALL:
          DirectoryInfo di = new DirectoryInfo(testDir);
          DirectoryInfo[] dirs = di.GetDirectories();
          foreach (DirectoryInfo dirInfo in dirs) {
            ListViewItem item = new ListViewItem();
            item.Checked = true;
            item.SubItems.Add(dirInfo.Name);
            item.SubItems.Add(dirInfo.LastWriteTimeUtc.ToString("yyyy/MM/dd HH:mm"));
            item.SubItems.Add("Folder");
            item.SubItems.Add("");
            m_ListView.Items.Add(item);
          }

          FileInfo[] files = di.GetFiles();
          foreach (FileInfo fileInfo in files) {
            ListViewItem item = new ListViewItem();
            item.Checked = true;
            item.SubItems.Add(fileInfo.Name);
            item.SubItems.Add(fileInfo.LastWriteTimeUtc.ToString("yyyy/MM/dd HH:mm"));
            item.SubItems.Add("File");
            item.SubItems.Add(fileInfo.Length + "");
            m_ListView.Items.Add(item);
          }
          break;
      }
      
    }

    private void BtnCancel_Click(object sender, EventArgs e) {
      Close();
    }
  }
}
