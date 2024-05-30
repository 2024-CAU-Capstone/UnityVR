using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Win32.UI.WindowsAndMessaging;
using Windows.Win32;
using Windows.Win32.Foundation;
using System.Windows.Automation;

namespace WindowsFormsApp
{
    internal class BrowserUrlExtract
    {
        public static List<string> OpenUrls()
        {
            List<string> urls = new List<string>();
            Process[] processEdge = Process.GetProcessesByName("msedge");
            foreach (Process process in processEdge)
            {
                WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
                PInvoke.GetWindowPlacement((HWND)process.MainWindowHandle, ref placement);
                if (placement.showCmd == SHOW_WINDOW_CMD.SW_SHOWMINIMIZED)
                {
                    PInvoke.ShowWindow((HWND)process.MainWindowHandle, SHOW_WINDOW_CMD.SW_RESTORE);
                }
                PInvoke.SetForegroundWindow((HWND)process.MainWindowHandle);
                System.Threading.Thread.Sleep(200);
                SendKeys.SendWait("^1");

                if (process.MainWindowHandle == IntPtr.Zero)
                {
                    continue;
                }
                string TabUrl = string.Empty;
                AutomationElement root = AutomationElement.FromHandle(process.MainWindowHandle);
                Condition condTabItem = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.TabItem);
                foreach (AutomationElement tabitem in root.FindAll(TreeScope.Subtree, condTabItem))
                {
                    System.Threading.Thread.Sleep(50);
                    //var Collection = root.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
                    var SearchBar = root.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, "주소 표시줄 및 검색 창"));
                    //var SearchBar = root.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, "주소창 및 검색창"));
                    TabUrl = (string)SearchBar.GetCurrentPropertyValue(ValuePatternIdentifiers.ValueProperty);
                    urls.Add(TabUrl);
                    PInvoke.SetForegroundWindow((HWND)process.MainWindowHandle);
                    SendKeys.SendWait("^{TAB}"); // change focus to next tab
                }
                PInvoke.ShowWindow((HWND)process.MainWindowHandle, SHOW_WINDOW_CMD.SW_SHOWMINIMIZED);
            }
            return urls;
        }
    }
}
