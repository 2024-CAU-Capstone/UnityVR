using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments.DataProvider;

namespace WindowsFormsApp
{
    internal class ProcessInfo
    {
        private string _Name;
        private string _Path;
        private string _ExplorerPath;
        public ProcessInfo(System.Diagnostics.Process p)
        {
            _Name = p.ProcessName;
            _Path = p.MainModule.FileName;
            _ExplorerPath = _Path;
        }
        public ProcessInfo(string path)
        {
            _Name = "explorer";
            _Path = "explorer.exe";
            _ExplorerPath = path;
        }

        public string Name { get { return _Name; } }
        public string Path { get { return _Path; } }
        public string ExplorerPath { get { return _ExplorerPath; } }
    }
}
