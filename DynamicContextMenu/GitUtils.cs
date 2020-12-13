using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DynamicContextMenu {
  class GitUtils {

    public static bool isGitDir(string path) {

      DirectoryInfo di = new DirectoryInfo(path);
      DirectoryInfo[] dirInfos = di.GetDirectories(".git");
      if (dirInfos.Length > 0) return true;

      if (di.Parent == null) return false;
      return isGitDir(di.Parent.FullName);
    }
  }
}
