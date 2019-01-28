using System;
using System.Collections.Generic;
using System.Windows.Forms;
using workflow_app.Utilities;
using workflow_app.Configuration;

namespace workflow_app
{
    public partial class LoginForm : Form
    {
        private WorkerNamesUtility workerNamesUtility = new WorkerNamesUtility();
        private List<Worker> workers;
        private String passwordAdmin = "123456";

        public LoginForm()
        {
            InitializeComponent();
            InitializeWorkersDropdown();
            SetPasswordVisible(false);
            loginButton.Enabled = false;
            passwordTextBox.PasswordChar = '*';
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen; 
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
            workersDropdown.DisplayMember = "Name";
            workersDropdown.SelectedIndex = -1;
            workersDropdown.DropDownStyle = ComboBoxStyle.DropDownList;
            workersDropdown.SelectedIndexChanged += new System.EventHandler(this.WorkersDropdown_SelectedIndexChanged);
        }

        private void WorkersDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            Worker selectedEmployee = (Worker)comboBox.SelectedItem;
            if(selectedEmployee != null && workersDropdown.SelectedIndex >= 0)
            {
                loginButton.Enabled = selectedEmployee.IsActive;
                SetPasswordVisible(selectedEmployee.IsActive);
                errorLabel.Text = selectedEmployee.IsActive ? String.Empty : "Пользователь не активирован. Обратитесь к начальнику цеха.";
            }
            passwordTextBox.Text = String.Empty;
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            loginButton.Enabled = passwordTextBox.Text.Trim().Length > 0;
        }

        private void LoginButtonClicked(object sender, EventArgs e)
        {
            Worker selectedEmployee = (Worker)workersDropdown.SelectedItem;
            string clearPassword = passwordTextBox.Text.Trim() + AppConfig.GetPwdSuffix();
            errorLabel.Text = PasswordChecker.VerifyPassword(selectedEmployee.Name, clearPassword) == CheckerVerdict.OK? String.Empty: "Пароль неправильный.";
            if (String.IsNullOrEmpty(errorLabel.Text))
            {
                WorkerSheetForm workerSheet = new WorkerSheetForm(selectedEmployee.Name, clearPassword);
                this.Visible = false;
                workerSheet.ShowDialog();
                this.Close();
            }
            passwordTextBox.Text = String.Empty;
        }

        private void PasswordTextBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.LoginButtonClicked(sender, e);
            }
        }
    }
}
