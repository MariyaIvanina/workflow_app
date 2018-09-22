using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace workflow_app.Utilities
{
    public class PaimentEntry
    {
        private string type;
        private string subType;
        private string workName;
        private float price;
        private float norm;
        private int rank;

        public PaimentEntry(string mtype, string msubType, string mworkName, float mnorm, float mprice, int rank)
        {
            type = mtype;
            subType = msubType;
            workName = mworkName;
            price = mprice;
            norm = mnorm;
            this.rank = rank;
        }

        public int Rank
        {
            get { return rank; }
        }

        public float Price
        {
            get { return price; }
        }

        public float Norm
        {
            get { return norm; }
        }

        public string Type
        {
            get { return type; }
        }

        public string SubType
        {
            get { return subType; }
        }

        public string WorkName
        {
            get { return workName; }
        }

        public override string ToString()
        {
            return type + " | " + subType + " | " + workName + " | " + rank.ToString() + " | " + norm.ToString() + " | " + price.ToString();
        }
    }
}
