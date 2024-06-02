using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
using System.IO;
using Windows.Media.AppRecording;

namespace WindowsFormsApp
{
    public partial class ObjectSerialization : Form
    {
        private List<Memo> MemoList;
        private List<Schedule> ScheduleList;
        public ObjectSerialization(List<Memo> memo, List<Schedule> schedules)
        {
            InitializeComponent();
            MemoList = memo;
            ScheduleList = schedules;
        }

        public void SaveData()
        {
            List<MemoObject> MemoTemp = new List<MemoObject>();
            List<ScheduleObject> ScheduleTemp = new List<ScheduleObject>();
            if (!System.IO.Directory.Exists("Memo"))
            {
                System.IO.Directory.CreateDirectory("Memo");
            }
            if (!Directory.Exists("Schedule"))
            {
                System.IO.Directory.CreateDirectory("Schedule");
            }
            foreach (var memo in MemoList)
            {
                List<string> ScreenShots = memo.GetScreenShotSerial();
                /*
                foreach (Image screenshot in memo.GetScreenShotList())
                {
                    MemoryStream ms = new MemoryStream();
                    screenshot.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    ScreenShots.Add(Convert.ToBase64String(ms.ToArray()));
                    //ms.Close();
                }
                */
                MemoObject memoObject = new MemoObject
                {
                    IsMake = false,
                    detail = memo.detail,
                    file = memo.file,
                    fileFullPath = memo.fileFullPath,
                    LinkList = memo.GetLinkList(),
                    ProgramList = memo.GetProgramList(),
                    ProcessList = memo.GetProcessList(),
                    ScreenShotList = ScreenShots,
                    MemoTime = memo.GetMemoTime(),
                    savePath = memo.BuildPath(),
                    saveProcessText = memo.applicationName,
                };
                MemoTemp.Add(memoObject);
            }

            foreach (var schedule in ScheduleList)
            {
                List<string> ScreenShots = new List<string>();
                /*
                foreach (Image screenshot in schedule.GetScreenShotList())
                {
                    MemoryStream ms = new MemoryStream();
                    screenshot.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    ScreenShots.Add(Convert.ToBase64String(ms.GetBuffer()));
                }*/
                ScheduleObject scheduleObject = new ScheduleObject
                {
                    IsMake = false,
                    detail = schedule.detail,
                    file = schedule.file,
                    fileFullPath = schedule.fileFullPath,
                    LinkList = schedule.GetLinkList(),
                    ProgramList = schedule.GetProgramList(),
                    ProcessList = schedule.GetProcessList(),
                    ScreenShotList = ScreenShots,
                    ScheduleTime = schedule.GetScheduleTime(),
                    time = schedule.time,
                    alarmTime = schedule.alarmTime,
                    savePath = schedule.BuildPath(),
                    saveProcessText = schedule.applicationName
                };
                ScheduleTemp.Add(scheduleObject);
            }
            /**
            string ScheduleJson = JsonSerializer.Serialize(ScheduleTemp);
            string MemoJson = JsonSerializer.Serialize(MemoTemp);
            File.WriteAllText("Schedule.json", ScheduleJson);
            File.WriteAllText("Memo.json", MemoJson);
            **/
            foreach (var schedule in ScheduleTemp)
            {
                string schejson = JsonSerializer.Serialize(schedule);
                File.WriteAllText(schedule.savePath, schejson);
            }
            foreach (var memo in MemoTemp)
            {
                string memojson = JsonSerializer.Serialize(memo);
                File.WriteAllText(memo.savePath, memojson);
            }
        }
        public void LoadData(StartUI startUI)
        {
            List<MemoObject> MemoTemp = new List<MemoObject>();
            List<ScheduleObject> ScheduleTemp = new List<ScheduleObject>();
            string ScheduleJson;// = File.ReadAllText(@".\Schedule.json");
            string MemoJson;// = File.ReadAllText(@".\Memo.json");
            DirectoryInfo memodir = new DirectoryInfo("Memo");
            DirectoryInfo schedir = new DirectoryInfo("Schedule");
            foreach (FileInfo file in memodir.GetFiles())
            {
                MemoJson = File.ReadAllText(file.FullName);
                MemoTemp.Add(JsonSerializer.Deserialize<MemoObject>(MemoJson));
            }
            foreach (FileInfo file in schedir.GetFiles())
            {
                ScheduleJson = File.ReadAllText(file.FullName);
                ScheduleTemp.Add(JsonSerializer.Deserialize<ScheduleObject>(ScheduleJson));
            }
            /*
            try
            {
                ScheduleJson = File.ReadAllText(@".\Schedule.json");
                MemoJson = File.ReadAllText(@".\Memo.json");
            }
            catch (Exception e)
            {
                return;
                if (e is FileNotFoundException) throw new Exception("파일을 찾지 못했습니다.");
                else throw new Exception("파일을 불러오는데 실패했습니다.");
            }
            
            MemoTemp = JsonSerializer.Deserialize<List<MemoObject>>(MemoJson);
            ScheduleTemp = JsonSerializer.Deserialize<List<ScheduleObject>>(ScheduleJson);
            */
            foreach (var memo in MemoTemp)
            {
                Memo newMemo = new Memo(startUI);

                newMemo.detail = memo.detail;
                newMemo.file = memo.file;
                newMemo.fileFullPath = memo.fileFullPath;
                newMemo.SetLinkList(memo.LinkList);
                newMemo.SetProgramList(memo.ProgramList);
                newMemo.SetScreenShotList(memo.ScreenShotList);
                newMemo.SetProcessList(memo.ProcessList);
                newMemo.SetMemoTime(memo.MemoTime);
                newMemo.SetIsMake(memo.IsMake);

                startUI.AddMemo(newMemo);
            }
            foreach (var schedule in ScheduleTemp)
            {
                Schedule newSchedule = new Schedule(startUI);

                newSchedule.detail = schedule.detail;
                newSchedule.file = schedule.file;
                newSchedule.fileFullPath = schedule.fileFullPath;
                newSchedule.applicationName = schedule.saveProcessText;
                newSchedule.SetLinkList(schedule.LinkList);
                newSchedule.SetProgramList(schedule.ProgramList);
                newSchedule.SetScreenShotList(schedule.ScreenShotList);
                newSchedule.SetProcessList(schedule.ProcessList);
                newSchedule.SetScheduleTime(schedule.ScheduleTime);
                newSchedule.time = schedule.time;
                newSchedule.alarmTime = schedule.alarmTime;
                newSchedule.SetIsMake(schedule.IsMake);

                startUI.AddSchedule(newSchedule);
            }
        }

        [Serializable]
        public class MemoObject
        {
            public bool IsMake { get; set; }
            public string detail { get; set; }
            public string file { get; set; }
            public string fileFullPath { get; set; }
            public List<string> LinkList {  get; set; }
            public List<string> ProgramList {  get; set; }
            public List<ProcessInfo> ProcessList { get; set; }
            public List<string> ScreenShotList { get; set; }
            public DateTime MemoTime {  get; set; }
            public string savePath { get; set; }
            public string saveProcessText { get; set; }
        }

        [Serializable]
        public class ScheduleObject
        {
            public bool IsMake { get; set; }
            public string detail { get; set; }
            public string file { get; set; }
            public string fileFullPath { get; set; }
            public List<string> LinkList { get; set; }
            public List<string> ProgramList { get; set; }
            public List<ProcessInfo> ProcessList { get; set; }
            public List<string> ScreenShotList { get; set; }
            public DateTime ScheduleTime { get; set; }
            public string time { get; set; }
            public int alarmTime { get; set; }
            public string savePath { get; set; }
            public string saveProcessText { get; set; }

        }


    }
}
