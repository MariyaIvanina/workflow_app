using System;
using System.Collections.Generic;
using System.IO;
using workflow_app.Configuration;

namespace workflow_app.Utilities
{
    public class Worker
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public Worker(string name, bool isActive)
        {
            Name = name;
            IsActive = isActive;
        }
    }

    public class WorkerNamesUtility
    {
        public List<Worker> GetWorkers()
        {
            string filePath = AppConfig.GetUsersNameFile();
            List<Worker> res = new List<Worker>();
            if (File.Exists(filePath))
            {
                string line;
                using (StreamReader file = new StreamReader(filePath))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        if (File.Exists(AppConfig.GetUserResultFile(line)))
                        {
                            res.Add(new Worker(line, true));
                        }
                        else
                        {
                            res.Add(new Worker(line, false));
                        }
                    }
                }
            }
            return res;
        }
    }
}
