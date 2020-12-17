
namespace UI {
  partial class Form1 {
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
      this.m_BtnInstall = new System.Windows.Forms.Button();
      this.m_BtnUninstall = new System.Windows.Forms.Button();
      this.m_LblGitPath = new System.Windows.Forms.Label();
      this.m_TextBoxGitPath = new System.Windows.Forms.TextBox();
      this.m_BtnSelectGit = new System.Windows.Forms.Button();
      this.m_BtnSelectBeyondComp = new System.Windows.Forms.Button();
      this.m_TextBoxBeyondCompPath = new System.Windows.Forms.TextBox();
      this.m_LblComparePath = new System.Windows.Forms.Label();
      this.m_BtnSelectBackupFolder = new System.Windows.Forms.Button();
      this.m_TextBoxBackupPath = new System.Windows.Forms.TextBox();
      this.m_LblBackupFolder = new System.Windows.Forms.Label();
      this.m_BtnSelectSvn = new System.Windows.Forms.Button();
      this.m_TextBoxSvnPath = new System.Windows.Forms.TextBox();
      this.m_LblSvnPath = new System.Windows.Forms.Label();
      this.m_BtnOK = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // m_BtnInstall
      // 
      this.m_BtnInstall.Location = new System.Drawing.Point(241, 171);
      this.m_BtnInstall.Name = "m_BtnInstall";
      this.m_BtnInstall.Size = new System.Drawing.Size(75, 25);
      this.m_BtnInstall.TabIndex = 0;
      this.m_BtnInstall.Text = "&Install";
      this.m_BtnInstall.UseVisualStyleBackColor = true;
      this.m_BtnInstall.Click += new System.EventHandler(this.btnInstall_Click);
      // 
      // m_BtnUninstall
      // 
      this.m_BtnUninstall.Location = new System.Drawing.Point(322, 171);
      this.m_BtnUninstall.Name = "m_BtnUninstall";
      this.m_BtnUninstall.Size = new System.Drawing.Size(75, 25);
      this.m_BtnUninstall.TabIndex = 1;
      this.m_BtnUninstall.Text = "&Uninstall";
      this.m_BtnUninstall.UseVisualStyleBackColor = true;
      this.m_BtnUninstall.Click += new System.EventHandler(this.btnUninstall_Click);
      // 
      // m_LblGitPath
      // 
      this.m_LblGitPath.AutoSize = true;
      this.m_LblGitPath.Location = new System.Drawing.Point(10, 35);
      this.m_LblGitPath.Name = "m_LblGitPath";
      this.m_LblGitPath.Size = new System.Drawing.Size(23, 13);
      this.m_LblGitPath.TabIndex = 2;
      this.m_LblGitPath.Text = "Git:";
      // 
      // m_TextBoxGitPath
      // 
      this.m_TextBoxGitPath.Location = new System.Drawing.Point(111, 31);
      this.m_TextBoxGitPath.Name = "m_TextBoxGitPath";
      this.m_TextBoxGitPath.Size = new System.Drawing.Size(286, 20);
      this.m_TextBoxGitPath.TabIndex = 3;
      // 
      // m_BtnSelectGit
      // 
      this.m_BtnSelectGit.Location = new System.Drawing.Point(403, 29);
      this.m_BtnSelectGit.Name = "m_BtnSelectGit";
      this.m_BtnSelectGit.Size = new System.Drawing.Size(75, 25);
      this.m_BtnSelectGit.TabIndex = 4;
      this.m_BtnSelectGit.Text = "Browser...";
      this.m_BtnSelectGit.UseVisualStyleBackColor = true;
      this.m_BtnSelectGit.Click += new System.EventHandler(this.BtnSelectGit_Click);
      // 
      // m_BtnSelectBeyondComp
      // 
      this.m_BtnSelectBeyondComp.Location = new System.Drawing.Point(403, 92);
      this.m_BtnSelectBeyondComp.Name = "m_BtnSelectBeyondComp";
      this.m_BtnSelectBeyondComp.Size = new System.Drawing.Size(75, 25);
      this.m_BtnSelectBeyondComp.TabIndex = 7;
      this.m_BtnSelectBeyondComp.Text = "Browser...";
      this.m_BtnSelectBeyondComp.UseVisualStyleBackColor = true;
      this.m_BtnSelectBeyondComp.Click += new System.EventHandler(this.BtnSelectBeyondComp_Click);
      // 
      // m_TextBoxBeyondCompPath
      // 
      this.m_TextBoxBeyondCompPath.Location = new System.Drawing.Point(111, 94);
      this.m_TextBoxBeyondCompPath.Name = "m_TextBoxBeyondCompPath";
      this.m_TextBoxBeyondCompPath.Size = new System.Drawing.Size(286, 20);
      this.m_TextBoxBeyondCompPath.TabIndex = 6;
      // 
      // m_LblComparePath
      // 
      this.m_LblComparePath.AutoSize = true;
      this.m_LblComparePath.Location = new System.Drawing.Point(10, 98);
      this.m_LblComparePath.Name = "m_LblComparePath";
      this.m_LblComparePath.Size = new System.Drawing.Size(90, 13);
      this.m_LblComparePath.TabIndex = 5;
      this.m_LblComparePath.Text = "Beyond compare:";
      // 
      // m_BtnSelectBackupFolder
      // 
      this.m_BtnSelectBackupFolder.Location = new System.Drawing.Point(403, 124);
      this.m_BtnSelectBackupFolder.Name = "m_BtnSelectBackupFolder";
      this.m_BtnSelectBackupFolder.Size = new System.Drawing.Size(75, 25);
      this.m_BtnSelectBackupFolder.TabIndex = 10;
      this.m_BtnSelectBackupFolder.Text = "Browser...";
      this.m_BtnSelectBackupFolder.UseVisualStyleBackColor = true;
      this.m_BtnSelectBackupFolder.Click += new System.EventHandler(this.BtnSelectBackupFolder_Click);
      // 
      // m_TextBoxBackupPath
      // 
      this.m_TextBoxBackupPath.Location = new System.Drawing.Point(111, 124);
      this.m_TextBoxBackupPath.Name = "m_TextBoxBackupPath";
      this.m_TextBoxBackupPath.Size = new System.Drawing.Size(286, 20);
      this.m_TextBoxBackupPath.TabIndex = 9;
      // 
      // m_LblBackupFolder
      // 
      this.m_LblBackupFolder.AutoSize = true;
      this.m_LblBackupFolder.Location = new System.Drawing.Point(10, 127);
      this.m_LblBackupFolder.Name = "m_LblBackupFolder";
      this.m_LblBackupFolder.Size = new System.Drawing.Size(79, 13);
      this.m_LblBackupFolder.TabIndex = 8;
      this.m_LblBackupFolder.Text = "Backup Folder:";
      // 
      // m_BtnSelectSvn
      // 
      this.m_BtnSelectSvn.Location = new System.Drawing.Point(403, 61);
      this.m_BtnSelectSvn.Name = "m_BtnSelectSvn";
      this.m_BtnSelectSvn.Size = new System.Drawing.Size(75, 25);
      this.m_BtnSelectSvn.TabIndex = 13;
      this.m_BtnSelectSvn.Text = "Browser...";
      this.m_BtnSelectSvn.UseVisualStyleBackColor = true;
      this.m_BtnSelectSvn.Click += new System.EventHandler(this.BtnSelectSvn_Click);
      // 
      // m_TextBoxSvnPath
      // 
      this.m_TextBoxSvnPath.Location = new System.Drawing.Point(111, 63);
      this.m_TextBoxSvnPath.Name = "m_TextBoxSvnPath";
      this.m_TextBoxSvnPath.Size = new System.Drawing.Size(286, 20);
      this.m_TextBoxSvnPath.TabIndex = 12;
      // 
      // m_LblSvnPath
      // 
      this.m_LblSvnPath.AutoSize = true;
      this.m_LblSvnPath.Location = new System.Drawing.Point(10, 66);
      this.m_LblSvnPath.Name = "m_LblSvnPath";
      this.m_LblSvnPath.Size = new System.Drawing.Size(32, 13);
      this.m_LblSvnPath.TabIndex = 11;
      this.m_LblSvnPath.Text = "SVN:";
      // 
      // m_BtnOK
      // 
      this.m_BtnOK.Location = new System.Drawing.Point(403, 171);
      this.m_BtnOK.Name = "m_BtnOK";
      this.m_BtnOK.Size = new System.Drawing.Size(75, 25);
      this.m_BtnOK.TabIndex = 14;
      this.m_BtnOK.Text = "&OK";
      this.m_BtnOK.UseVisualStyleBackColor = true;
      this.m_BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(490, 209);
      this.Controls.Add(this.m_BtnOK);
      this.Controls.Add(this.m_BtnSelectSvn);
      this.Controls.Add(this.m_TextBoxSvnPath);
      this.Controls.Add(this.m_LblSvnPath);
      this.Controls.Add(this.m_BtnSelectBackupFolder);
      this.Controls.Add(this.m_TextBoxBackupPath);
      this.Controls.Add(this.m_LblBackupFolder);
      this.Controls.Add(this.m_BtnSelectBeyondComp);
      this.Controls.Add(this.m_TextBoxBeyondCompPath);
      this.Controls.Add(this.m_LblComparePath);
      this.Controls.Add(this.m_BtnSelectGit);
      this.Controls.Add(this.m_TextBoxGitPath);
      this.Controls.Add(this.m_LblGitPath);
      this.Controls.Add(this.m_BtnUninstall);
      this.Controls.Add(this.m_BtnInstall);
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Backup Configuration";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button m_BtnInstall;
    private System.Windows.Forms.Button m_BtnUninstall;
    private System.Windows.Forms.Label m_LblGitPath;
    private System.Windows.Forms.TextBox m_TextBoxGitPath;
    private System.Windows.Forms.Button m_BtnSelectGit;
    private System.Windows.Forms.Button m_BtnSelectBeyondComp;
    private System.Windows.Forms.TextBox m_TextBoxBeyondCompPath;
    private System.Windows.Forms.Label m_LblComparePath;
    private System.Windows.Forms.Button m_BtnSelectBackupFolder;
    private System.Windows.Forms.TextBox m_TextBoxBackupPath;
    private System.Windows.Forms.Label m_LblBackupFolder;
    private System.Windows.Forms.Button m_BtnSelectSvn;
    private System.Windows.Forms.TextBox m_TextBoxSvnPath;
    private System.Windows.Forms.Label m_LblSvnPath;
    private System.Windows.Forms.Button m_BtnOK;
  }
}

