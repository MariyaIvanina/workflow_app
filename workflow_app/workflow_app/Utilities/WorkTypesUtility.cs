using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace workflow_app.Utilities
{
    public class WorkTypesUtility
    {
        private struct fileWithData
        {
            public string path;
            public string tabName;

            public fileWithData(string pth, string tab)
            {
                path = pth;
                tabName = tab;
            }
        }

        private List<PaimentEntry> allEntries;

        private List<fileWithData> loadFilesList()
        {
            List<fileWithData> res = new List<fileWithData>();
            string path = @"files\norms\";
            if (Directory.Exists(path))
            {
                DirectoryInfo d = new DirectoryInfo(path);//Assuming Test is your Folder
                FileInfo[] Files = d.GetFiles("*.xlsx"); //Getting Text files
                foreach (FileInfo file in Files)
                {
                    res.Add(new fileWithData(path + file, "ЗП Цнс"));
                }
            }
            return res;
        }

        private void loadAllEntries()
        {
            List<fileWithData> files = loadFilesList();
            foreach (var file in files)
            {
                FilePaimentParser parser = new FilePaimentParser(file.path, file.tabName);
                List<PaimentEntry> curEntries = parser.getEntries();
                allEntries.AddRange(curEntries);
            }
        }
        public WorkTypesUtility()
        {
            allEntries = new List<PaimentEntry>();
            loadAllEntries();
        }

        public List<string> getTypes()
        {
            List<string> res = new List<string>();
            HashSet<string> hash = new HashSet<string>();
            foreach (var entry in allEntries)
            {
                if (!hash.Contains(entry.Type))
                {
                    hash.Add(entry.Type);
                    res.Add(entry.Type);
                }
            }
            return res;
        }

        public List<string> getSubtypesByType(string type)
        {
            List<string> res = new List<string>();
            HashSet<string> hash = new HashSet<string>();
            foreach (var entry in allEntries)
            {
                if (entry.Type != type)
                {
                    continue;
                }
                if (!hash.Contains(entry.SubType))
                {
                    hash.Add(entry.SubType);
                    res.Add(entry.SubType);
                }
            }
            return res;
        }

        public List<string> getWorkTypes(string type, string subtype)
        {
            List<string> res = new List<string>();
            HashSet<string> hash = new HashSet<string>();
            foreach (var entry in allEntries)
            {
                if (entry.Type != type || entry.SubType != subtype)
                {
                    continue;
                }
                if (!hash.Contains(entry.WorkName))
                {
                    hash.Add(entry.WorkName);
                    res.Add(entry.WorkName);
                }
            }
            return res;
        }

        public float getPrice(string type, string subtype, string workType)
        {
            foreach (var entry in allEntries)
            {
                if (entry.Type != type || entry.SubType != subtype || entry.WorkName != workType)
                {
                    continue;
                }
                return entry.Price;
            }
            return 0;
        }

        public float getNorm(string type, string subtype, string workType)
        {
            foreach (var entry in allEntries)
            {
                if (entry.Type != type || entry.SubType != subtype || entry.WorkName != workType)
                {
                    continue;
                }
                return entry.Norm;
            }
            return 0;
        }
        public int getRank(string type, string subtype, string workType)
        {
            foreach (var entry in allEntries)
            {
                if (entry.Type != type || entry.SubType != subtype || entry.WorkName != workType)
                {
                    continue;
                }
                return entry.Rank;
            }
            return 0;
        }
    }
}
