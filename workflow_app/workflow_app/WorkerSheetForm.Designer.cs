namespace workflow_app
{
    partial class WorkerSheetForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.workerNameLabel = new System.Windows.Forms.Label();
            this.productTypeCombobox = new System.Windows.Forms.ComboBox();
            this.productTypeLabel = new System.Windows.Forms.Label();
            this.productSubtypeCombobox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.workTypeCombobox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.workQuantityTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.doneWorksTable = new System.Windows.Forms.DataGridView();
            this.confirmButton = new System.Windows.Forms.Button();
            this.RemarkCheckbox = new System.Windows.Forms.CheckBox();
            this.RemarkTextbox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.doneWorksTable)).BeginInit();
            this.SuspendLayout();
            // 
            // workerNameLabel
            // 
            this.workerNameLabel.AutoSize = true;
            this.workerNameLabel.Location = new System.Drawing.Point(12, 9);
            this.workerNameLabel.Name = "workerNameLabel";
            this.workerNameLabel.Size = new System.Drawing.Size(35, 13);
            this.workerNameLabel.TabIndex = 0;
            this.workerNameLabel.Text = "Name";
            // 
            // productTypeCombobox
            // 
            this.productTypeCombobox.FormattingEnabled = true;
            this.productTypeCombobox.Location = new System.Drawing.Point(12, 61);
            this.productTypeCombobox.Name = "productTypeCombobox";
            this.productTypeCombobox.Size = new System.Drawing.Size(154, 21);
            this.productTypeCombobox.TabIndex = 1;
            this.productTypeCombobox.SelectedIndexChanged += new System.EventHandler(this.productTypeCombobox_SelectedIndexChanged);
            // 
            // productTypeLabel
            // 
            this.productTypeLabel.AutoSize = true;
            this.productTypeLabel.Location = new System.Drawing.Point(12, 45);
            this.productTypeLabel.Name = "productTypeLabel";
            this.productTypeLabel.Size = new System.Drawing.Size(71, 13);
            this.productTypeLabel.TabIndex = 2;
            this.productTypeLabel.Text = "Тип изделия";
            // 
            // productSubtypeCombobox
            // 
            this.productSubtypeCombobox.FormattingEnabled = true;
            this.productSubtypeCombobox.Location = new System.Drawing.Point(172, 61);
            this.productSubtypeCombobox.Name = "productSubtypeCombobox";
            this.productSubtypeCombobox.Size = new System.Drawing.Size(161, 21);
            this.productSubtypeCombobox.TabIndex = 3;
            this.productSubtypeCombobox.SelectedIndexChanged += new System.EventHandler(this.productSubtypeCombobox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(169, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Подтип изделия";
            // 
            // workTypeCombobox
            // 
            this.workTypeCombobox.FormattingEnabled = true;
            this.workTypeCombobox.Location = new System.Drawing.Point(339, 61);
            this.workTypeCombobox.Name = "workTypeCombobox";
            this.workTypeCombobox.Size = new System.Drawing.Size(316, 21);
            this.workTypeCombobox.TabIndex = 5;
            this.workTypeCombobox.SelectedIndexChanged += new System.EventHandler(this.workTypeCombobox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(336, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Тип работ";
            // 
            // workQuantityTextbox
            // 
            this.workQuantityTextbox.Location = new System.Drawing.Point(661, 61);
            this.workQuantityTextbox.Name = "workQuantityTextbox";
            this.workQuantityTextbox.Size = new System.Drawing.Size(127, 20);
            this.workQuantityTextbox.TabIndex = 7;
            this.workQuantityTextbox.TextChanged += new System.EventHandler(this.workQuantityTextbox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(658, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Количество";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(713, 89);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 9;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Список добавленных работ";
            // 
            // doneWorksTable
            // 
            this.doneWorksTable.AllowUserToAddRows = false;
            this.doneWorksTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.doneWorksTable.Location = new System.Drawing.Point(18, 247);
            this.doneWorksTable.Name = "doneWorksTable";
            this.doneWorksTable.ReadOnly = true;
            this.doneWorksTable.Size = new System.Drawing.Size(770, 187);
            this.doneWorksTable.TabIndex = 11;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(703, 454);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(85, 23);
            this.confirmButton.TabIndex = 12;
            this.confirmButton.Text = "Подтвердить";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // RemarkCheckbox
            // 
            this.RemarkCheckbox.AutoSize = true;
            this.RemarkCheckbox.Location = new System.Drawing.Point(12, 89);
            this.RemarkCheckbox.Name = "RemarkCheckbox";
            this.RemarkCheckbox.Size = new System.Drawing.Size(209, 17);
            this.RemarkCheckbox.TabIndex = 13;
            this.RemarkCheckbox.Text = "Указать работу в свободной форме";
            this.RemarkCheckbox.UseVisualStyleBackColor = true;
            this.RemarkCheckbox.CheckedChanged += new System.EventHandler(this.RemarkCheckbox_CheckedChanged);
            // 
            // RemarkTextbox
            // 
            this.RemarkTextbox.Location = new System.Drawing.Point(12, 112);
            this.RemarkTextbox.Multiline = true;
            this.RemarkTextbox.Name = "RemarkTextbox";
            this.RemarkTextbox.Size = new System.Drawing.Size(643, 79);
            this.RemarkTextbox.TabIndex = 14;
            this.RemarkTextbox.TextChanged += new System.EventHandler(this.RemarkTextbox_TextChanged);
            // 
            // WorkerSheetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 501);
            this.Controls.Add(this.RemarkTextbox);
            this.Controls.Add(this.RemarkCheckbox);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.workQuantityTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.workTypeCombobox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.productSubtypeCombobox);
            this.Controls.Add(this.productTypeLabel);
            this.Controls.Add(this.productTypeCombobox);
            this.Controls.Add(this.workerNameLabel);
            this.Controls.Add(this.doneWorksTable);
            this.Name = "WorkerSheetForm";
            this.Text = "Ввод проделанных работ";
            ((System.ComponentModel.ISupportInitialize)(this.doneWorksTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label workerNameLabel;
        private System.Windows.Forms.ComboBox productTypeCombobox;
        private System.Windows.Forms.Label productTypeLabel;
        private System.Windows.Forms.ComboBox productSubtypeCombobox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox workTypeCombobox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox workQuantityTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView doneWorksTable;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.CheckBox RemarkCheckbox;
        private System.Windows.Forms.TextBox RemarkTextbox;
    }
}