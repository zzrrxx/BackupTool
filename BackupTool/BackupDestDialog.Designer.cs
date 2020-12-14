
namespace BackupTool {
  partial class BackupDestDialog {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.m_TextBoxBackupTo = new System.Windows.Forms.TextBox();
      this.m_LblBackupTo = new System.Windows.Forms.Label();
      this.m_ChkUseTimestamp = new System.Windows.Forms.CheckBox();
      this.m_ChkDontAskAgain = new System.Windows.Forms.CheckBox();
      this.m_BtnBrowser = new System.Windows.Forms.Button();
      this.m_BtnOK = new System.Windows.Forms.Button();
      this.m_BtnCancel = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // m_TextBoxBackupTo
      // 
      this.m_TextBoxBackupTo.Enabled = false;
      this.m_TextBoxBackupTo.Location = new System.Drawing.Point(83, 34);
      this.m_TextBoxBackupTo.Name = "m_TextBoxBackupTo";
      this.m_TextBoxBackupTo.Size = new System.Drawing.Size(360, 21);
      this.m_TextBoxBackupTo.TabIndex = 0;
      // 
      // m_LblBackupTo
      // 
      this.m_LblBackupTo.AutoSize = true;
      this.m_LblBackupTo.Location = new System.Drawing.Point(10, 37);
      this.m_LblBackupTo.Name = "m_LblBackupTo";
      this.m_LblBackupTo.Size = new System.Drawing.Size(65, 12);
      this.m_LblBackupTo.TabIndex = 1;
      this.m_LblBackupTo.Text = "&Backup To:";
      // 
      // m_ChkUseTimestamp
      // 
      this.m_ChkUseTimestamp.AutoSize = true;
      this.m_ChkUseTimestamp.Location = new System.Drawing.Point(12, 72);
      this.m_ChkUseTimestamp.Name = "m_ChkUseTimestamp";
      this.m_ChkUseTimestamp.Size = new System.Drawing.Size(102, 16);
      this.m_ChkUseTimestamp.TabIndex = 2;
      this.m_ChkUseTimestamp.Text = "Use &Timestamp";
      this.m_ChkUseTimestamp.UseVisualStyleBackColor = true;
      this.m_ChkUseTimestamp.CheckedChanged += new System.EventHandler(this.ChkUseTimestamp_CheckedChanged);
      // 
      // m_ChkDontAskAgain
      // 
      this.m_ChkDontAskAgain.AutoSize = true;
      this.m_ChkDontAskAgain.Location = new System.Drawing.Point(12, 94);
      this.m_ChkDontAskAgain.Name = "m_ChkDontAskAgain";
      this.m_ChkDontAskAgain.Size = new System.Drawing.Size(132, 16);
      this.m_ChkDontAskAgain.TabIndex = 4;
      this.m_ChkDontAskAgain.Text = "Don\'t ask me again";
      this.m_ChkDontAskAgain.UseVisualStyleBackColor = true;
      this.m_ChkDontAskAgain.CheckedChanged += new System.EventHandler(this.ChkDontAskAgain_CheckedChanged);
      // 
      // m_BtnBrowser
      // 
      this.m_BtnBrowser.Location = new System.Drawing.Point(449, 33);
      this.m_BtnBrowser.Name = "m_BtnBrowser";
      this.m_BtnBrowser.Size = new System.Drawing.Size(75, 23);
      this.m_BtnBrowser.TabIndex = 5;
      this.m_BtnBrowser.Text = "&Browser...";
      this.m_BtnBrowser.UseVisualStyleBackColor = true;
      this.m_BtnBrowser.Click += new System.EventHandler(this.BtnBrowser_Click);
      // 
      // m_BtnOK
      // 
      this.m_BtnOK.Location = new System.Drawing.Point(368, 90);
      this.m_BtnOK.Name = "m_BtnOK";
      this.m_BtnOK.Size = new System.Drawing.Size(75, 23);
      this.m_BtnOK.TabIndex = 6;
      this.m_BtnOK.Text = "&OK";
      this.m_BtnOK.UseVisualStyleBackColor = true;
      this.m_BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
      // 
      // m_BtnCancel
      // 
      this.m_BtnCancel.Location = new System.Drawing.Point(449, 90);
      this.m_BtnCancel.Name = "m_BtnCancel";
      this.m_BtnCancel.Size = new System.Drawing.Size(75, 23);
      this.m_BtnCancel.TabIndex = 7;
      this.m_BtnCancel.Text = "&Cancel";
      this.m_BtnCancel.UseVisualStyleBackColor = true;
      this.m_BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
      // 
      // BackupDestDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(536, 125);
      this.Controls.Add(this.m_BtnCancel);
      this.Controls.Add(this.m_BtnOK);
      this.Controls.Add(this.m_BtnBrowser);
      this.Controls.Add(this.m_ChkDontAskAgain);
      this.Controls.Add(this.m_ChkUseTimestamp);
      this.Controls.Add(this.m_LblBackupTo);
      this.Controls.Add(this.m_TextBoxBackupTo);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "BackupDestDialog";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "BackupDestDialog";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox m_TextBoxBackupTo;
    private System.Windows.Forms.Label m_LblBackupTo;
    private System.Windows.Forms.CheckBox m_ChkUseTimestamp;
    private System.Windows.Forms.CheckBox m_ChkDontAskAgain;
    private System.Windows.Forms.Button m_BtnBrowser;
    private System.Windows.Forms.Button m_BtnOK;
    private System.Windows.Forms.Button m_BtnCancel;
  }
}