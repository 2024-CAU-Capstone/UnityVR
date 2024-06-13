using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments.DataProvider;
using System.Diagnostics;
using System.Text.Json.Serialization;
using System.IO;

namespace WindowsFormsApp
{
    [Serializable]
    public class ProcessInfo
    {
        private string _Name;
        private string _Path;
        private string _ExplorerPath;
        private List<string> _Urls;
        private ProcessType _ProcessType;
        public ProcessInfo(System.Diagnostics.Process p)
        {
            _ProcessType = ProcessType.Program;
            _Name = p.ProcessName;
            _Path = p.MainModule.FileName;
            _ExplorerPath = _Path;
        }
        public ProcessInfo(string path)
        {
            _ProcessType = ProcessType.Explorer;
            _Name = "explorer";
            _Path = path;
            _ExplorerPath = path;
        }
        public ProcessInfo(string type, string path)
        {
            _ProcessType = ProcessType.Document;
            _Name = type;
            _Path = path;
        }
        public ProcessInfo(List<string> urls)
        {
            _ProcessType = ProcessType.Url;
            _Name = "msedge";
            _Path = "msedge.exe";
            _Urls = urls;
        }
        [JsonConstructor]
        public ProcessInfo(string name, string path, string explorerPath, ProcessType procType, List<string> urls)
        {
            ProcType = procType;
            Name = name;
            Path = path;
            ExplorerPath = explorerPath;
            Urls = urls;
        }
        public void Run()
        {
            List<Process> processes = new List<Process>();
            Process p = new Process();
            switch (_ProcessType)
            {
                case ProcessType.Program:
                    p.StartInfo = new ProcessStartInfo(_Path);
                    processes.Add(p);
                    break;
                case ProcessType.Explorer:
                    p = new Process();
                    p.StartInfo = new ProcessStartInfo(_Path)
                    {
                        UseShellExecute = true,
                    };
                    processes.Add(p);
                    break;
                case ProcessType.Document:
                    p = new Process();
                    if (File.Exists(_Path))
                    {
                        p.StartInfo = new ProcessStartInfo(_Path)
                        {
                            UseShellExecute = true,
                        };
                    } 
                    else
                    {
                        string[] temp = _Path.Split("\\");
                        string filename = temp[temp.Length - 1];
                        string newpath = "SaveFiles\\" + filename;
                        if (File.Exists(@".\" + newpath))
                        {
                            p.StartInfo = new ProcessStartInfo(@".\" + newpath)
                            {
                                UseShellExecute = true,
                            };
                        }
                    }
                    processes.Add(p);
                    break;
                case ProcessType.Url:
                    foreach (string url in _Urls)
                    {
                        p = new Process();
                        p.StartInfo = new ProcessStartInfo(url)
                        {
                            UseShellExecute = true
                        };
                        processes.Add(p);
                    }
                    break;
            }
            foreach (Process process in processes)
            {
                process.Start();
            }
        }
        public string Name { get { return _Name; } private set { _Name = value; } }
        public string Path { get { return _Path; } private set { _Path = value; } }
        public string ExplorerPath { get { return _ExplorerPath; } private set { _ExplorerPath = value; } }
        public ProcessType ProcType { get { return _ProcessType; } private set { _ProcessType = value; } }
        public List<string> Urls { get { return _Urls; } private set { _Urls = value; } }
        public enum ProcessType
        {
            Program,
            Explorer,
            Document,
            Url
        }
    }
}
