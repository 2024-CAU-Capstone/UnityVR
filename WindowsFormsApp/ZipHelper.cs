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
        private string currentRoute = @".\";
        public void CreateFromDirectory(string directoryName, bool isSchedule, FilePathTracker fp)
        {

            Directory.CreateDirectory(programRoute);
            Directory.CreateDirectory(Path.Combine(programRoute, "SaveFiles"));
            if (isSchedule)
            {
                individualRoute = Path.Combine(individualRoute, "schedule_zip");
                Directory.CreateDirectory(individualRoute);
                Directory.CreateDirectory(Path.Combine(programRoute, "Schedule"));
                File.Copy(directoryName,
                    Path.Combine(Path.Combine(programRoute, "Schedule"), Path.GetFileName(directoryName)), true);
                
            }
            else
            {
                individualRoute = Path.Combine(individualRoute, "memo_zip");
                Directory.CreateDirectory(individualRoute);
                Directory.CreateDirectory(Path.Combine(programRoute, "Memo"));
                File.Copy(directoryName, 
                    Path.Combine(Path.Combine(programRoute, "Memo"), Path.GetFileName(directoryName)), true);
            }
            Directory.CreateDirectory(Path.Combine(individualRoute, "SaveFiles"));
            for (int i = 0; i < fp.GetFiles().Count; i++)
            {
                File.Copy(fp.GetFiles()[i],
                    Path.Combine(Path.Combine(programRoute, "SaveFiles"), Path.GetFileName(fp.GetFiles()[i])), true);
                File.Copy(fp.GetFiles()[i],
                    Path.Combine(Path.Combine(individualRoute, "SaveFiles"), Path.GetFileName(fp.GetFiles()[i])), true);
            }
            File.Copy(directoryName, Path.Combine(individualRoute, Path.GetFileName(directoryName)), true);
            CopyDirectory(Directory.GetParent(Directory.GetParent(directoryName).FullName).FullName, programRoute);
            ZipFile.CreateFromDirectory(individualRoute, Path.GetFileName(individualRoute) + ".zip");
            ZipFile.CreateFromDirectory(programRoute, Path.Combine(currentRoute, "window_snapshot_program.zip"));
            Directory.Delete(individualRoute, true);
            Directory.Delete(programRoute, true);

        }

        public static void CopyDirectory(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);

            string[] files = Directory.GetFiles(sourceFolder);
            string[] folders = Directory.GetDirectories(sourceFolder);

            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                if (!name.Equals("mail.txt") && !name.Equals("mail"))
                    File.Copy(file, dest);
            }

            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                if (!name.Equals("Memo") && !name.Equals("Schedule") && !name.Equals("window_snapshot_program") 
                        && !name.Equals("memo_zip") && !name.Equals("schedule.zip")) 
                    CopyDirectory(folder, dest);
            }
        }
    }
}
