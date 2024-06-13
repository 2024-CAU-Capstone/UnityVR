using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHDocVw;
using Windows.Win32.UI.Shell;

namespace WindowsFormsApp
{
    internal class ExplorerPathExtract
    {
        public static List<string> OpenPaths()
        {
            List<string> ret = new List<string>();
            try
            {
                ShellWindows shell = new SHDocVw.ShellWindows();

                foreach (InternetExplorer window in shell)
                {
                    IShellFolderViewDual2 doc = (IShellFolderViewDual2)window.Document;
                    string[] patharray = doc.FocusedItem.Path.ToString().Split("\\");
                    patharray = patharray.Take(patharray.Count() - 1).ToArray();
                    ret.Add(string.Join("\\", patharray));
                }
            }
            catch { }
            return ret;
        }
    }
}
