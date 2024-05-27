using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    public class PreserveProcess
    {
        private static List<String> fileNames;
        //하드 코드 해야만하는 예외 프로세스 (일부 시스템 프로그램들)
        private static String[] exclude =
        {
            "TextInputHost",
            "SystemSettings",
            "ApplicationFrameHost",
            "Explorer",
        };
        //호출 순간의 윈도우를 가진 프로세스를 반환, 원리는 MainWindowsHandle이 존재한다면 윈도우가 존재한다고 판단.
        public static List<ProcessInfo> GetWindowedProcesses()
        {
            List<ProcessInfo> processes = new List<ProcessInfo>();
            Process[] openProcesses = Process.GetProcesses();
            bool isExclude = false;
            foreach (Process process in openProcesses)
            {
                if (process.MainWindowHandle != IntPtr.Zero)
                {
                    foreach (String name in exclude)
                    {
                        if (String.Compare(process.ProcessName, name) == 0)
                        {
                            isExclude = true;
                            break;
                        }
                    }
                    if (isExclude)
                    {
                        isExclude = false;
                        continue;
                    }
                    processes.Add(new ProcessInfo(process));
                }
            }
            List<string> explorerPaths = ExplorerPathExtract.OpenPaths();
            foreach (string path in explorerPaths)
            {
                processes.Add(new ProcessInfo(path));
            }
            return processes;
        }
        //현 순간 열려있는 프로세스의 "프로세스명" 반환. 특성상 영어로 반환할 수 밖에 없다.
        public static List<String> RetrieveProcessNames()
        {
            List<String> processNames = new List<String>();
            foreach (ProcessInfo process in GetWindowedProcesses())
            {
                if (process.Name.ToLower().Equals("explorer"))
                {
                    processNames.Add(process.ExplorerPath);
                }
                else
                {
                    processNames.Add(process.Name);
                }
            }
            return processNames;
        }
        //현 순간의 프로세스들을 호출한 파일명들을 저장 RetrieveProcessNames과 함께 쓸것을 추천하며, 항상 RecallProcesses 이전에 호출한다. (null 에러 발생)
        /*
        public static void FreezeProcesses()
        {
            fileNames = new List<String>();
            foreach (Process process in GetWindowedProcesses())
            {
                fileNames.Add(process.MainModule.FileName);
            }
        }
        //보존 해둔 프로세스를 다시 불러오기.
        public static void RecallProcesses()
        {
            foreach (String fileName in fileNames)
            {
                Process.Start(fileName);
            }
        }
        //TODO: Serialize를 이용하여 어플리케이션의 종료 후에도 불러오기가 가능하도록 하기.
        */
    }
}
