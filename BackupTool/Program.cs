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
      string cmd = args.Length == 0 ? "" : args[0];
      switch (cmd) {
        case "modified":
          break;

        default:
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);
          Application.Run(new BackupForm(BackupForm.BACKUP_TYPE_ALL));
          break;
      }
    }
  }
}
