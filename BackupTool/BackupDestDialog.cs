using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BackupTool {
  public partial class BackupDestDialog : Form {

    private string m_InitBackupTo = "";


    public BackupDestDialog() {
      InitializeComponent();
    }

    public bool UseTimestamp {
      get { return m_ChkUseTimestamp.Checked;  }
      set { 
        m_ChkUseTimestamp.Checked = value;

        if (value) {
          string subFolder = DateTime.UtcNow.ToString("yyyy_MM_dd_HH_mm_ss");
          BackupTo = System.IO.Path.Combine(m_InitBackupTo, subFolder);
        } else {
          BackupTo = m_InitBackupTo;
        }
      }
    }

    public bool DontAskMeAgain {
      get { return m_ChkDontAskAgain.Checked; }
      set { m_ChkDontAskAgain.Checked= value; }
    }

    public string InitialBackupTo {
      get { return m_InitBackupTo; }
      set { 
        m_InitBackupTo = value;
        BackupTo = value;
      }
    }

    public string BackupTo {
      get         { return m_TextBoxBackupTo.Text;  }
      private set { m_TextBoxBackupTo.Text = value; }
    }

    private void BtnOK_Click(object sender, EventArgs e) {
      DialogResult = DialogResult.OK;
      Close();
    }

    private void BtnCancel_Click(object sender, EventArgs e) {
      DialogResult = DialogResult.Cancel;
      Close();
    }

    private void BtnBrowser_Click(object sender, EventArgs e) {
      using (FolderBrowserDialog dialog = new FolderBrowserDialog()) {
        dialog.SelectedPath = m_TextBoxBackupTo.Text;
        dialog.Description = "Select a path to backup your files";
        if (dialog.ShowDialog() == DialogResult.OK) {
          BackupTo = dialog.SelectedPath;
        }
      }
    }

    private void ChkUseTimestamp_CheckedChanged(object sender, EventArgs e) {
      UseTimestamp = m_ChkUseTimestamp.Checked;
    }

    private void ChkDontAskAgain_CheckedChanged(object sender, EventArgs e) {
      DontAskMeAgain = m_ChkDontAskAgain.Checked;
    }
  }
}
