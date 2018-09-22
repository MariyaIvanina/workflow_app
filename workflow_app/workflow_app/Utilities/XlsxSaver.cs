using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using System.IO;
using workflow_app.Entities;

namespace workflow_app.Utilities
{
    class XlsxSaver
    {
        private void addHeaderToXlsx(ExcelWorksheet newWorksheet)
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
        private void createFileWithTabIfNotExists(string file, string tabName)
        {
            if (!File.Exists(file))
            {
                using (ExcelPackage excel = new ExcelPackage())
                {
                    var newWorksheet = excel.Workbook.Worksheets.Add(tabName);
                    addHeaderToXlsx(newWorksheet);
                    FileInfo excelFile = new FileInfo(file);
                    excel.SaveAs(excelFile);
                }
                return;
            }
            using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(file)))
            {
                var myWorksheet = xlPackage.Workbook.Worksheets.FirstOrDefault(x => x.Name == tabName); //select sheet here 
                if (myWorksheet == null)
                {
                    var newWorksheet = xlPackage.Workbook.Worksheets.Add(tabName);
                    addHeaderToXlsx(newWorksheet);
                    xlPackage.Save();
                }
            }
        }

        private void addEntryToXlsx(string file, string tabName, DoneWork work)
        {
            createFileWithTabIfNotExists(file, tabName);
            using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(file)))
            {
                var myWorksheet = xlPackage.Workbook.Worksheets.FirstOrDefault(x => x.Name == tabName); //select sheet here 
                if (myWorksheet != null)
                {
                    var curRows = myWorksheet.Dimension.End.Row + 1;
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
                    xlPackage.Save();
                }
            }
        }

        public void doneWorkSaver(List<DoneWork> works)
        {
            string path = @"files\results\";
            string computerName = System.Environment.MachineName;
            foreach (var work in works)
            {
                string month = work.WorkDate.Month.ToString();
                string year = work.WorkDate.Year.ToString();
                string tab = month + "." + year;
                string fileName = computerName + ".xlsx";
                System.IO.Directory.CreateDirectory(path);
                addEntryToXlsx(path + fileName, tab, work);
            }
        }
    }
}
