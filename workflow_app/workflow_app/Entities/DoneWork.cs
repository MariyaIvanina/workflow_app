using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace workflow_app.Entities
{
    public class DoneWork
    {
        public String WorkerName { get; set; }
        public DateTime WorkDate { get; set; }
        public String ProductType { get; set; }
        public String ProductSubType { get; set; }
        public String WorkType { get; set; }
        public double WorkQuantity { get; set; }
        public int Rank { get; set; }

        public float Price { get; set; }

        public float Norm { get; set; }

        public String Remarks { get; set; }
    }
}
