using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using workflow_app.Entities;
using workflow_app.Utilities;

namespace workflow_app
{
    public partial class ConfirmForm : Form
    {
        private XlsxSaver xlsxSaver = new XlsxSaver();
        private List<DoneWork>  doneWorks;
        private String password;
        private String userName;
        public ConfirmForm(String workerName, String password, DateTime workDate, List<DoneWork> doneWorks)
        {
            InitializeComponent();
            WorkDateLabel.Text = workDate.ToString();
            WorkerNameLabel.Text = workerName;
            this.doneWorks = doneWorks;
            this.password = password;
            this.userName = workerName;
            SetupDataGridView();
            PopulateDataGridView();
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen; 
        }

        public Form ParentDialogForm { get; set; }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            xlsxSaver.DoneWorkSaver(userName, password, doneWorks);
            LoginForm loginForm = new LoginForm();
            this.Visible = false;
            loginForm.ShowDialog();
            this.Close();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            ParentDialogForm.Visible = true;
            this.Close();
        }

        private void SetupDataGridView()
        {
            doneWorkDatagrid.ColumnCount = 7;

            doneWorkDatagrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            doneWorkDatagrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            doneWorkDatagrid.ColumnHeadersDefaultCellStyle.Font =
                new Font(doneWorkDatagrid.Font, FontStyle.Bold);

            doneWorkDatagrid.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            doneWorkDatagrid.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            doneWorkDatagrid.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            doneWorkDatagrid.GridColor = Color.Black;
            doneWorkDatagrid.RowHeadersVisible = false;
            doneWorkDatagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            doneWorkDatagrid.Columns[0].Name = "Тип изделия";
            doneWorkDatagrid.Columns[1].Name = "Подтип изделия";
            doneWorkDatagrid.Columns[2].Name = "Наименование операции";
            doneWorkDatagrid.Columns[3].Name = "Количество";
            doneWorkDatagrid.Columns[4].Name = "Комментарий";
            doneWorkDatagrid.Columns[5].Name = "Расценка";
            doneWorkDatagrid.Columns[6].Name = "Сумма";

            doneWorkDatagrid.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            doneWorkDatagrid.MultiSelect = false;
        }

        private void PopulateDataGridView()
        {
            doneWorkDatagrid.Rows.Clear();
            double totalSum = 0;
            foreach (DoneWork work in doneWorks)
            {
                double workSum = Math.Round(work.Price * work.WorkQuantity, 7);
                totalSum += workSum;
                doneWorkDatagrid.Rows.Add(new object[]{ work.ProductType, work.ProductSubType, work.WorkType, 
                        work.WorkQuantity, work.Remarks, work.Price,  workSum});
            }
            doneWorkDatagrid.Rows.Add(new object[]{ String.Empty, String.Empty, String.Empty, 
                       String.Empty, String.Empty, "Итого:",  totalSum});
        }
    }
}
