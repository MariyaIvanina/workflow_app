using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace workflow_app.Utilities
{
    public class WorkerNamesUtility
    {
        public String AdminName
        {
            get
            {
                return "Admin";
            }
        }

        public List<string> GetWorkers()
        {
            string path = @"files\";
            string fileName = "users.txt";
            List<string> res = new List<string>();
            if (File.Exists(path + fileName))
            {
                string line;
                System.IO.StreamReader file =
                        new System.IO.StreamReader(path + fileName);
                while ((line = file.ReadLine()) != null)
                {
                    res.Add(line);
                }
            }
            return res;
        }
    }
}
