using System.Linq;

namespace LeoConsole_apkg {
  public class ApkgIntegrity {
    public static bool CheckPkgConflicts(string[] files, string savePath) {
      IList<string> installed;
      try {
        installed = InstalledFiles(savePath);
      } catch (Exception e) {
        ApkgOutput.MessageErr1("error loading installed files: " + e.Message);
        return false;
      }
      foreach (string file in files) {
        if (installed.Contains(file)) {
          return false;
        }
      }
      return true;
    }

    public static void Register(string p, string pVersion, string[] f, string savePath) {
      ApkgOutput.MessageSuc0("registering package " + p + " v" + pVersion);
      Directory.CreateDirectory(
          Path.Join(savePath, "var", "apkg", "installed", p)
          );
      File.WriteAllLines(
          Path.Join(savePath, "var", "apkg", "installed", p, "files"), f
          );
      string[] cont = {pVersion};
      File.WriteAllLines(
          Path.Join(savePath, "var", "apkg", "installed", p, "version"), cont
          );
    }

    public static void Unregister(string p, string savePath) {
      ApkgUtils.DeleteDirectory(
          Path.Join(savePath, "var", "apkg", "installed", p)
          );
    }

    public static IList<string> InstalledFiles(string savePath) {
      string databaseFolder = Path.Join(savePath, "var", "apkg", "installed");
      IList<string> res = Enumerable.Empty<string>().ToList();
      foreach (string p in Directory.GetDirectories(databaseFolder)) {
        foreach (string i in File.ReadLines(Path.Join(p, "files"))) {
          res.Add(i);
        }
      }
      return res;
    }
  }
}

// vim: tabstop=2 softtabstop=2 shiftwidth=2 expandtab
