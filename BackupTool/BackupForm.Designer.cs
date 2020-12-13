
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
      this.m_ListView = new System.Windows.Forms.ListView();
      this.m_ColSelected = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.m_ColName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.m_ColDateModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.m_ColType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.m_ColSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.m_BtnBackup = new System.Windows.Forms.Button();
      this.m_BtnCancel = new System.Windows.Forms.Button();
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
      this.m_ListView.Location = new System.Drawing.Point(12, 12);
      this.m_ListView.Name = "m_ListView";
      this.m_ListView.Size = new System.Drawing.Size(776, 415);
      this.m_ListView.TabIndex = 0;
      this.m_ListView.UseCompatibleStateImageBehavior = false;
      this.m_ListView.View = System.Windows.Forms.View.Details;
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
      this.m_BtnBackup.Location = new System.Drawing.Point(612, 433);
      this.m_BtnBackup.Name = "m_BtnBackup";
      this.m_BtnBackup.Size = new System.Drawing.Size(75, 23);
      this.m_BtnBackup.TabIndex = 1;
      this.m_BtnBackup.Text = "&Backup";
      this.m_BtnBackup.UseVisualStyleBackColor = true;
      // 
      // m_BtnCancel
      // 
      this.m_BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.m_BtnCancel.Location = new System.Drawing.Point(703, 433);
      this.m_BtnCancel.Name = "m_BtnCancel";
      this.m_BtnCancel.Size = new System.Drawing.Size(75, 23);
      this.m_BtnCancel.TabIndex = 2;
      this.m_BtnCancel.Text = "&Cancel";
      this.m_BtnCancel.UseVisualStyleBackColor = true;
      this.m_BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
      // 
      // BackupForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.m_BtnCancel;
      this.ClientSize = new System.Drawing.Size(800, 466);
      this.Controls.Add(this.m_BtnCancel);
      this.Controls.Add(this.m_BtnBackup);
      this.Controls.Add(this.m_ListView);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.MaximizeBox = false;
      this.Name = "BackupForm";
      this.Text = "Backup";
      this.ResumeLayout(false);

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
  }
}

