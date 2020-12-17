
namespace BackupTool {
  partial class BackupForm {
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
      this.components = new System.ComponentModel.Container();
      this.m_ListView = new System.Windows.Forms.ListView();
      this.m_ColSelected = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.m_ColName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.m_ColDateModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.m_ColType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.m_ColSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.m_BtnBackup = new System.Windows.Forms.Button();
      this.m_BtnCancel = new System.Windows.Forms.Button();
      this.m_ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.m_CtxMenuGitDiff = new System.Windows.Forms.ToolStripMenuItem();
      this.m_CtxMenuBCompDiff = new System.Windows.Forms.ToolStripMenuItem();
      this.m_LblIgnoreDeleted = new System.Windows.Forms.Label();
      this.m_ContextMenuStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // m_ListView
      // 
      this.m_ListView.CheckBoxes = true;
      this.m_ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_ColSelected,
            this.m_ColName,
            this.m_ColDateModified,
            this.m_ColType,
            this.m_ColSize});
      this.m_ListView.FullRowSelect = true;
      this.m_ListView.GridLines = true;
      this.m_ListView.HideSelection = false;
      this.m_ListView.Location = new System.Drawing.Point(12, 13);
      this.m_ListView.Name = "m_ListView";
      this.m_ListView.Size = new System.Drawing.Size(776, 449);
      this.m_ListView.TabIndex = 0;
      this.m_ListView.UseCompatibleStateImageBehavior = false;
      this.m_ListView.View = System.Windows.Forms.View.Details;
      this.m_ListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListView_MouseClick);
      // 
      // m_ColSelected
      // 
      this.m_ColSelected.Text = "";
      this.m_ColSelected.Width = 30;
      // 
      // m_ColName
      // 
      this.m_ColName.Text = "Name";
      this.m_ColName.Width = 256;
      // 
      // m_ColDateModified
      // 
      this.m_ColDateModified.Text = "Date Modified";
      this.m_ColDateModified.Width = 128;
      // 
      // m_ColType
      // 
      this.m_ColType.DisplayIndex = 4;
      this.m_ColType.Text = "Type";
      this.m_ColType.Width = 64;
      // 
      // m_ColSize
      // 
      this.m_ColSize.DisplayIndex = 3;
      this.m_ColSize.Text = "Size";
      this.m_ColSize.Width = 128;
      // 
      // m_BtnBackup
      // 
      this.m_BtnBackup.Location = new System.Drawing.Point(612, 469);
      this.m_BtnBackup.Name = "m_BtnBackup";
      this.m_BtnBackup.Size = new System.Drawing.Size(75, 25);
      this.m_BtnBackup.TabIndex = 1;
      this.m_BtnBackup.Text = "&Backup";
      this.m_BtnBackup.UseVisualStyleBackColor = true;
      this.m_BtnBackup.Click += new System.EventHandler(this.BtnBackup_Click);
      // 
      // m_BtnCancel
      // 
      this.m_BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.m_BtnCancel.Location = new System.Drawing.Point(703, 469);
      this.m_BtnCancel.Name = "m_BtnCancel";
      this.m_BtnCancel.Size = new System.Drawing.Size(75, 25);
      this.m_BtnCancel.TabIndex = 2;
      this.m_BtnCancel.Text = "&Cancel";
      this.m_BtnCancel.UseVisualStyleBackColor = true;
      this.m_BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
      // 
      // m_ContextMenuStrip
      // 
      this.m_ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_CtxMenuGitDiff,
            this.m_CtxMenuBCompDiff});
      this.m_ContextMenuStrip.Name = "m_ContextMenuStrip";
      this.m_ContextMenuStrip.Size = new System.Drawing.Size(233, 48);
      // 
      // m_CtxMenuGitDiff
      // 
      this.m_CtxMenuGitDiff.Name = "m_CtxMenuGitDiff";
      this.m_CtxMenuGitDiff.Size = new System.Drawing.Size(232, 22);
      this.m_CtxMenuGitDiff.Text = "Show diff by";
      // 
      // m_CtxMenuBCompDiff
      // 
      this.m_CtxMenuBCompDiff.Name = "m_CtxMenuBCompDiff";
      this.m_CtxMenuBCompDiff.Size = new System.Drawing.Size(232, 22);
      this.m_CtxMenuBCompDiff.Text = "Show diff by BeyondCompare";
      // 
      // m_LblIgnoreDeleted
      // 
      this.m_LblIgnoreDeleted.AutoSize = true;
      this.m_LblIgnoreDeleted.Location = new System.Drawing.Point(12, 475);
      this.m_LblIgnoreDeleted.Name = "m_LblIgnoreDeleted";
      this.m_LblIgnoreDeleted.Size = new System.Drawing.Size(178, 13);
      this.m_LblIgnoreDeleted.TabIndex = 3;
      this.m_LblIgnoreDeleted.Text = "!!!Deleted items will not be backup!!!";
      this.m_LblIgnoreDeleted.Visible = false;
      // 
      // BackupForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.m_BtnCancel;
      this.ClientSize = new System.Drawing.Size(800, 505);
      this.Controls.Add(this.m_LblIgnoreDeleted);
      this.Controls.Add(this.m_BtnCancel);
      this.Controls.Add(this.m_BtnBackup);
      this.Controls.Add(this.m_ListView);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.MaximizeBox = false;
      this.Name = "BackupForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Backup";
      this.m_ContextMenuStrip.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ListView m_ListView;
    private System.Windows.Forms.Button m_BtnBackup;
    private System.Windows.Forms.Button m_BtnCancel;
    private System.Windows.Forms.ColumnHeader m_ColSelected;
    private System.Windows.Forms.ColumnHeader m_ColName;
    private System.Windows.Forms.ColumnHeader m_ColDateModified;
    private System.Windows.Forms.ColumnHeader m_ColSize;
    private System.Windows.Forms.ColumnHeader m_ColType;
    private System.Windows.Forms.ContextMenuStrip m_ContextMenuStrip;
    private System.Windows.Forms.ToolStripMenuItem m_CtxMenuGitDiff;
    private System.Windows.Forms.ToolStripMenuItem m_CtxMenuBCompDiff;
    private System.Windows.Forms.Label m_LblIgnoreDeleted;
  }
}

