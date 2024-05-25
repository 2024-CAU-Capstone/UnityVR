using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

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

            foreach (var memo in MemoList)
            {
                MemoObject memoObject = new MemoObject
                {
                    IsMake = false,
                    detail = memo.detail,
                    file = memo.file,
                    fileFullPath = memo.fileFullPath,
                    LinkList = memo.GetLinkList(),
                    ProgramList = memo.GetProgramList(),
                    ProcessList = memo.GetProcessList(),
                    ScreenShotList = memo.GetScreenShotList(),
                    MemoTime = memo.GetMemoTime()
                };
                MemoTemp.Add(memoObject);
            }

            foreach (var schedule in ScheduleList)
            {
                ScheduleObject scheduleObject = new ScheduleObject
                {
                    IsMake = false,
                    detail = schedule.detail,
                    file = schedule.file,
                    fileFullPath = schedule.fileFullPath,
                    LinkList = schedule.GetLinkList(),
                    ProgramList = schedule.GetProgramList(),
                    ProcessList = schedule.GetProcessList(),
                    ScreenShotList = schedule.GetScreenShotList(),
                    ScheduleTime = schedule.GetScheduleTime(),
                    time = schedule.time,
                    alarmTime = schedule.alarmTime
                };
                ScheduleTemp.Add(scheduleObject);
            }

            string ScheduleJson = JsonSerializer.Serialize(ScheduleTemp);
            string MemoJson = JsonSerializer.Serialize(MemoTemp);
            File.WriteAllText("Schedule.json", ScheduleJson);
            File.WriteAllText("Memo.json", MemoJson);
        }
        public void LoadData(StartUI startUI)
        {
            List<MemoObject> MemoTemp = new List<MemoObject>();
            List<ScheduleObject> ScheduleTemp = new List<ScheduleObject>();
            string ScheduleJson = File.ReadAllText("Schedule.json");
            string MemoJson = File.ReadAllText("Memo.json");

            try
            {
                ScheduleJson = File.ReadAllText("Schedule.json");
                MemoJson = File.ReadAllText("Memo.json");
            }
            catch (Exception e)
            {
                if (e is FileNotFoundException) throw new Exception("파일을 찾지 못했습니다.");
                else throw new Exception("파일을 불러오는데 실패했습니다.");
            }

            MemoTemp = JsonSerializer.Deserialize<List<MemoObject>>(MemoJson);
            ScheduleTemp = JsonSerializer.Deserialize<List<ScheduleObject>>(ScheduleJson);

            foreach (var memo in MemoTemp)
            {
                Memo newMemo = new Memo(startUI);

                newMemo.detail = memo.detail;
                newMemo.file = memo.file;
                newMemo.fileFullPath = memo.fileFullPath;
                newMemo.SetLinkList(memo.LinkList);
                newMemo.SetProgramList(memo.ProgramList);
                newMemo.SetScreenShotList(memo.ScreenShotList);
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
                newSchedule.SetLinkList(schedule.LinkList);
                newSchedule.SetProgramList(schedule.ProgramList);
                newSchedule.SetScreenShotList(schedule.ScreenShotList);
                newSchedule.SetScheduleTime(schedule.ScheduleTime);
                newSchedule.time = schedule.time;
                newSchedule.alarmTime = schedule.alarmTime;
                newSchedule.SetIsMake(schedule.IsMake);

                startUI.AddSchedule(newSchedule);
            }
        }

        [Serializable]
        private class MemoObject
        {
            public bool IsMake;
            public string detail;
            public string file;
            public string fileFullPath;
            public List<string> LinkList;
            public List<string> ProgramList;
            public List<ProcessInfo> ProcessList;
            public List<Image> ScreenShotList;
            public DateTime MemoTime;
        }

        [Serializable]
        private class ScheduleObject
        {
            public bool IsMake;
            public string detail;
            public string file;
            public string fileFullPath;
            public List<string> LinkList;
            public List<string> ProgramList;
            public List<ProcessInfo> ProcessList;
            public List<Image> ScreenShotList;
            public DateTime ScheduleTime;
            public string time;
            public int alarmTime;
        }


    }
}
