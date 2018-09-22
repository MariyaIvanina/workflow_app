using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OfficeOpenXml;
using System.IO;
using workflow_app.Utilities;

namespace workflow_app
{
    public partial class LoginForm : Form
    {
        private WorkerNamesUtility workerNamesUtility = new WorkerNamesUtility();
        private List<string> workers;
        private String passwordAdmin = "123456";

        public LoginForm()
        {
            InitializeComponent();
            InitializeWorkersDropdown();
            SetPasswordVisible(false);
            loginButton.Enabled = false;
            passwordTextBox.PasswordChar = '*';
        }

        private void SetPasswordVisible(bool visible)
        {
            passwordTextBox.Visible = visible;
            passwordLabel.Visible = visible;
        }

        private void InitializeWorkersDropdown()
        {
            workers = workerNamesUtility.GetWorkers();
            workersDropdown.DataSource = workers;
            workersDropdown.SelectedIndex = -1;
            workersDropdown.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void WorkersDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selectedEmployee = (string)comboBox.SelectedItem;
            SetPasswordVisible(selectedEmployee == workerNamesUtility.AdminName);
            loginButton.Enabled = selectedEmployee != workerNamesUtility.AdminName;
            errorLabel.Text = String.Empty;
            passwordTextBox.Text = String.Empty;
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            loginButton.Enabled = passwordTextBox.Text.Trim().Length > 0;
        }

        private void LoginButtonClicked(object sender, EventArgs e)
        {
            string selectedEmployee = (string)workersDropdown.SelectedItem;
            if(selectedEmployee == workerNamesUtility.AdminName)
            {
                errorLabel.Text = passwordTextBox.Text != passwordAdmin ? "Пароль неправильный." : String.Empty;
                passwordTextBox.Text = String.Empty;
            }
            if(String.IsNullOrEmpty(errorLabel.Text))
            {
                WorkerSheetForm workerSheet = new WorkerSheetForm(selectedEmployee);
                this.Visible = false;
                workerSheet.ShowDialog();
                this.Close();
            }
        }
    }
}
