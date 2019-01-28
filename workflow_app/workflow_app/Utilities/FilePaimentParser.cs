using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using System.IO;

namespace workflow_app.Utilities
{
    public class FilePaimentParser
    {
        private string path;
        private string tabName;
        List<PaimentEntry> listOfEntries;
        public FilePaimentParser(string mpath, string mtabName)
        {
            path = mpath;
            tabName = mtabName;
        }

        public List<PaimentEntry> getEntries()
        {
            listOfEntries = new List<PaimentEntry>();
            loadFile();
            return listOfEntries;
        }

        public class Pair<T, U>
        {
            public Pair()
            {
            }

            public Pair(T first, U second)
            {
                this.First = first;
                this.Second = second;
            }

            public T First { get; set; }
            public U Second { get; set; }
        };

        private void loadFile()
        {
            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (ExcelPackage xlPackage = new ExcelPackage(fileStream))
                {
                    foreach (var myWorksheet in xlPackage.Workbook.Worksheets)
                    {
                        //var myWorksheet = xlPackage.Workbook.Worksheets.FirstOrDefault(x => x.Name == tabName); //select sheet here 
                        List<Pair<int, int>> worksInd = new List<Pair<int, int>>();
                        List<Pair<int, int>> typesInd = new List<Pair<int, int>>();
                        if (!myWorksheet.Name.StartsWith(tabName))
                        {
                            continue;
                        }
                        var totalRows = myWorksheet.Dimension.End.Row;
                        var totalColumns = myWorksheet.Dimension.End.Column;

                        var sb = new StringBuilder(); //this is your your data 
                        for (int rowNum = 1; rowNum <= totalRows; rowNum++) //selet starting row here 
                        {
                            for (int colNum = 1; colNum <= totalColumns; ++colNum)
                            {
                                var curColor = myWorksheet.Cells[rowNum, colNum].Style.Fill.BackgroundColor.Rgb;
                                if (curColor != null && curColor != "FFFFFFFF")
                                {
                                    if (curColor == "FFFFFF00")
                                    {
                                        if (myWorksheet.Cells[rowNum, colNum].Text.Length > 0)
                                            typesInd.Add(new Pair<int, int>(rowNum, colNum));
                                    }
                                    else if (curColor == "FFFF0000")
                                    {
                                        if (myWorksheet.Cells[rowNum, colNum].Text.Length > 0)
                                            worksInd.Add(new Pair<int, int>(rowNum, colNum));
                                    }
                                }
                            }
                        }

                        foreach (var type in typesInd)
                        {
                            foreach (var works in worksInd)
                            {
                                Pair<int, int> normPos = new Pair<int, int>(works.First, type.Second);
                                Pair<int, int> pricePos = new Pair<int, int>(works.First, type.Second + 1);
                                if (myWorksheet.Cells[normPos.First, normPos.Second].Text.Length == 0) continue;

                                string typeStr = myWorksheet.Cells[type.First, type.Second].Text;
                                string workStr = myWorksheet.Cells[works.First, works.Second].Text;
                                string trimedType = typeStr.Trim();
                                int index = trimedType.IndexOf(' ');
                                string tp = trimedType;
                                string subtype = "";
                                if (index != -1)
                                {
                                    tp = trimedType.Substring(0, index);
                                    subtype = trimedType.Substring(index + 1);
                                }

                                float norm = 0;
                                float price = 0;
                                int rank = 0;
                                try
                                {
                                    norm = float.Parse(myWorksheet.Cells[normPos.First, normPos.Second].Text);
                                }
                                catch (Exception)
                                {

                                }
                                try
                                {
                                    price = float.Parse(myWorksheet.Cells[pricePos.First, pricePos.Second].Text);
                                }
                                catch (Exception)
                                {

                                }

                                try
                                {
                                    rank = int.Parse(myWorksheet.Cells[works.First, works.Second + 1].Text);
                                }
                                catch (Exception)
                                {

                                }
                                listOfEntries.Add(new PaimentEntry(tp, subtype, workStr, norm, price, rank));
                            }
                        }
                    }
                }
            }
        }
    }
}
