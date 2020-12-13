using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BackupTool {
  static class Program {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args) {
      if (args.Length != 3) return;
      string backupTool = args[0];
      string backupTypeStr = args[1].ToLower();
      string dir = args[2];
      int backupType = BackupForm.BACKUP_TYPE_ALL;

      switch (backupTypeStr) {
        case "all":      backupType = BackupForm.BACKUP_TYPE_ALL; break;
        case "modified": backupType = BackupForm.BACKUP_TYPE_MODIFIED; break;
        case "manually": backupType = BackupForm.BACKUP_TYPE_MANUALLY; break;
      }

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new BackupForm(backupTool, backupType, dir));
    }
  }
}
