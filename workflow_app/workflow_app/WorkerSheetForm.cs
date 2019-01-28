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
    public partial class WorkerSheetForm : Form
    {
        private String workerName;
        private String password;
        private List<DoneWork> doneWorks = new List<DoneWork>();
        private Control[] controlsToDisable;
        private WorkTypesUtility workTypesUtility = new WorkTypesUtility();

        public WorkerSheetForm(String workerName, String password)
        {
            InitializeComponent();
            this.workerName = workerName;
            this.password = password;
            workerNameLabel.Text = workerName;
            SetupDataGridView();
            controlsToDisable = new Control[] { productSubtypeCombobox, workTypeCombobox, workQuantityTextbox, addButton};
            PopulateDataGridView();
            ClearData();
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen; 
        }

        private void PopulateDropdown(ComboBox comboBox, List<String> source)
        {
            comboBox.DataSource = source;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.SelectedIndex = -1;
            comboBox.Enabled = true;
        }

        private void ChangeControlsEnability(Control[] controls, bool enabled)
        {
            foreach(var control in controls)
            {
                control.Enabled = enabled;
            }
        }

        private void SetupDataGridView()
        {
            doneWorksTable.ColumnCount = 5;

            doneWorksTable.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            doneWorksTable.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            doneWorksTable.ColumnHeadersDefaultCellStyle.Font =
                new Font(doneWorksTable.Font, FontStyle.Bold);

            doneWorksTable.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            doneWorksTable.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            doneWorksTable.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            doneWorksTable.GridColor = Color.Black;
            doneWorksTable.RowHeadersVisible = false;
            doneWorksTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            doneWorksTable.Columns[0].Name = "Тип изделия";
            doneWorksTable.Columns[1].Name = "Подтип изделия";
            doneWorksTable.Columns[2].Name = "Наименование операции";
            doneWorksTable.Columns[3].Name = "Количество";
            doneWorksTable.Columns[4].Name = "Комментарий";

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = "delete_column";
            deleteButtonColumn.Text = "Удалить";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            
            if (doneWorksTable.Columns["delete_column"] == null)
            {
                doneWorksTable.Columns.Add(deleteButtonColumn);
            }
            deleteButtonColumn.HeaderText = "";

            doneWorksTable.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            doneWorksTable.MultiSelect = false;

            doneWorksTable.CellClick += doneWorksTable_CellClick; 
        }

        private void doneWorksTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == doneWorksTable.Columns["delete_column"].Index)
            {
                if (doneWorksTable.SelectedRows.Count > 0)
                {
                    int selectedIndex = doneWorksTable.SelectedRows[0].Index;
                    doneWorksTable.Rows.RemoveAt(selectedIndex);
                    doneWorks.RemoveAt(selectedIndex);
                }
            }
        }

        private void PopulateDataGridView()
        {
            doneWorksTable.Rows.Clear();
            foreach(DoneWork work in doneWorks)
            {
                doneWorksTable.Rows.Add(new object[]{ work.ProductType, work.ProductSubType, work.WorkType, 
            work.WorkQuantity, work.Remarks, String.Empty });
            }
            
        }

        private void productTypeCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string productType = productTypeCombobox.SelectedItem as String;
            PopulateDropdown(productSubtypeCombobox, workTypesUtility.getSubtypesByType(productType));
            productSubtypeCombobox.Enabled = productTypeCombobox.SelectedIndex != -1;
        }

        private void productSubtypeCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string productType = productTypeCombobox.SelectedItem as String;
            string productSubType = productSubtypeCombobox.SelectedItem as String;
            PopulateDropdown(workTypeCombobox, workTypesUtility.getWorkTypes(productType, productSubType));
            workTypeCombobox.Enabled = productSubtypeCombobox.SelectedIndex != -1;
        }

        private void workTypeCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            workQuantityTextbox.Enabled = workTypeCombobox.SelectedIndex != -1;
            if(!workQuantityTextbox.Enabled)
            {
                workQuantityTextbox.Text = String.Empty;
            }
        }

        private double GetAmount()
        {
            string quantity = workQuantityTextbox.Text.Trim();
            quantity = quantity.Replace(".", ",");
            double amount;
            double.TryParse(quantity, out amount);
            return amount;
        }

        private void workQuantityTextbox_TextChanged(object sender, EventArgs e)
        {
            addButton.Enabled = workQuantityTextbox.Text.Trim().Length > 0 && GetAmount() > 0;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            String productType = productTypeCombobox.SelectedItem as String;
            String productSubtype = productSubtypeCombobox.SelectedItem as String;
            String workType = workTypeCombobox.SelectedItem as String;
            doneWorks.Add(new DoneWork
            {
                ProductType = productType,
                ProductSubType = productSubtype,
                WorkType = workType,
                WorkQuantity = GetAmount(),
                Norm = workTypesUtility.getNorm(productType, productSubtype, workType),
                Price = workTypesUtility.getPrice(productType, productSubtype, workType),
                Rank = workTypesUtility.getRank(productType, productSubtype, workType),
                Remarks = RemarkTextbox.Text.Trim(),
                WorkerName = workerName,
                WorkDate = DateTime.Now.Date
            });
            PopulateDataGridView();
            ClearData();
            RemarkCheckbox.Checked = false;
        }

        private void ClearData()
        {
            PopulateDropdown(productTypeCombobox, workTypesUtility.getTypes());
            ChangeControlsEnability(controlsToDisable, false);
            RemarkTextbox.Text = String.Empty;
            RemarkTextbox.Visible = false;
        }

        private void RemarkCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            ClearData();
            RemarkTextbox.Visible = RemarkCheckbox.Checked;
        }

        private void RemarkTextbox_TextChanged(object sender, EventArgs e)
        {
            addButton.Enabled = RemarkTextbox.Text.Trim().Length > 0;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            ConfirmForm confirmForm = new ConfirmForm(workerName, password, DateTime.Now, doneWorks);
            confirmForm.ParentDialogForm = this;
            this.Visible = false;
            confirmForm.ShowDialog();
        }
    }
}
