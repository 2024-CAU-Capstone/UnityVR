using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    public class ZipHelper
    {
        private string programRoute = @".\window_snapshot_program";
        private string individualRoute = @".\";
        public void CreateFromDirectory(string directoryName)
        {
            Directory.CreateDirectory(programRoute);
            if (directoryName.Contains("Schedule"))
            {
                individualRoute = Path.Combine(individualRoute, "schedule_zip");
                Directory.CreateDirectory(individualRoute);
                Directory.CreateDirectory(Path.Combine(programRoute, "Schedule"));
            }
            else
            {
                individualRoute = Path.Combine(individualRoute, "memo_zip");
                Directory.CreateDirectory(individualRoute);
                Directory.CreateDirectory(Path.Combine(programRoute, "Memo"));
            }
            foreach (string file in Directory.GetFiles(Directory.GetCurrentDirectory()))
            {
                string name = Path.GetFileName(file);
            }
        }
    }
}
