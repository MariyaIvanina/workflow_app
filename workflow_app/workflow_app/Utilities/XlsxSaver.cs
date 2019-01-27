using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using workflow_app.Entities;
using workflow_app.Configuration;

namespace workflow_app.Utilities
{
    class XlsxSaver
    {
        private void AddHeaderToXlsx(ExcelWorksheet newWorksheet)
        {
            var curRows = 1;
            newWorksheet.Cells[curRows, 1].Value = "Дата";
            newWorksheet.Cells[curRows, 2].Value = "Имя";
            newWorksheet.Cells[curRows, 3].Value = "Тип изделия";
            newWorksheet.Cells[curRows, 4].Value = "Подтип изделия";
            newWorksheet.Cells[curRows, 5].Value = "Наименование операции";
            newWorksheet.Cells[curRows, 6].Value = "Разряд";
            newWorksheet.Cells[curRows, 7].Value = "Время";
            newWorksheet.Cells[curRows, 8].Value = "Расценка";
            newWorksheet.Cells[curRows, 9].Value = "Количество";
            newWorksheet.Cells[curRows, 10].Value = "Комментарий";
        }
        private void CreateTabIfNotExists(string file, string password, string tabName)
        {
            if (!File.Exists(file))
            {
                throw new Exception("No such file");
            }
            using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(file), password))
            {
                var myWorksheet = xlPackage.Workbook.Worksheets.FirstOrDefault(x => x.Name == tabName); //select sheet here 
                if (myWorksheet == null)
                {
                    var newWorksheet = xlPackage.Workbook.Worksheets.Add(tabName);
                    AddHeaderToXlsx(newWorksheet);
                    xlPackage.Save();
                }
            }
        }

        private void AddEntryToXlsx(string file, string password, string tabName, List<DoneWork> works)
        {
            CreateTabIfNotExists(file, password, tabName);
            using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(file), password))
            {
                var myWorksheet = xlPackage.Workbook.Worksheets.FirstOrDefault(x => x.Name == tabName); //select sheet here 
                if (myWorksheet != null)
                {
                    var curRows = myWorksheet.Dimension.End.Row + 1;
                    foreach (var work in works) {
                        myWorksheet.Cells[curRows, 1].Value = work.WorkDate.ToString("dd.MM.yyyy");
                        myWorksheet.Cells[curRows, 2].Value = work.WorkerName;
                        myWorksheet.Cells[curRows, 3].Value = work.ProductType;
                        myWorksheet.Cells[curRows, 4].Value = work.ProductSubType;
                        myWorksheet.Cells[curRows, 5].Value = work.WorkType;
                        myWorksheet.Cells[curRows, 6].Value = work.Rank;
                        myWorksheet.Cells[curRows, 7].Value = work.Norm;
                        myWorksheet.Cells[curRows, 8].Value = work.Price;
                        myWorksheet.Cells[curRows, 9].Value = work.WorkQuantity;
                        myWorksheet.Cells[curRows, 10].Value = work.Remarks;
                        ++curRows;
                    }
                    xlPackage.Save();
                }
            }
        }

        public void DoneWorkSaver(string user, string password, List<DoneWork> works)
        {
            string filePath = AppConfig.GetUserResultFile(user);
            if (works.Count == 0)
            {
                return;
            }
            string month = works[0].WorkDate.Month.ToString();
            string year = works[0].WorkDate.Year.ToString();
            string tab = month + "." + year;
            AddEntryToXlsx(filePath, password, tab, works);
        }
    }
}
