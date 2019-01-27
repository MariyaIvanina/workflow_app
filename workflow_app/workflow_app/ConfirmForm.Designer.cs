namespace workflow_app
{
    partial class ConfirmForm
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
            this.doneWorkDatagrid = new System.Windows.Forms.DataGridView();
            this.WorkerNameLabel = new System.Windows.Forms.Label();
            this.WorkDateLabel = new System.Windows.Forms.Label();
            this.confirmButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.doneWorkDatagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // doneWorkDatagrid
            // 
            this.doneWorkDatagrid.AllowUserToAddRows = false;
            this.doneWorkDatagrid.AllowUserToDeleteRows = false;
            this.doneWorkDatagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.doneWorkDatagrid.Location = new System.Drawing.Point(33, 109);
            this.doneWorkDatagrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.doneWorkDatagrid.Name = "doneWorkDatagrid";
            this.doneWorkDatagrid.ReadOnly = true;
            this.doneWorkDatagrid.Size = new System.Drawing.Size(1466, 642);
            this.doneWorkDatagrid.TabIndex = 0;
            // 
            // WorkerNameLabel
            // 
            this.WorkerNameLabel.AutoSize = true;
            this.WorkerNameLabel.Location = new System.Drawing.Point(33, 20);
            this.WorkerNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.WorkerNameLabel.Name = "WorkerNameLabel";
            this.WorkerNameLabel.Size = new System.Drawing.Size(51, 20);
            this.WorkerNameLabel.TabIndex = 1;
            this.WorkerNameLabel.Text = "label1";
            // 
            // WorkDateLabel
            // 
            this.WorkDateLabel.AutoSize = true;
            this.WorkDateLabel.Location = new System.Drawing.Point(33, 68);
            this.WorkDateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.WorkDateLabel.Name = "WorkDateLabel";
            this.WorkDateLabel.Size = new System.Drawing.Size(51, 20);
            this.WorkDateLabel.TabIndex = 2;
            this.WorkDateLabel.Text = "label1";
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(1368, 794);
            this.confirmButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(130, 35);
            this.confirmButton.TabIndex = 3;
            this.confirmButton.Text = "Подтвердить";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(1212, 794);
            this.BackButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(112, 35);
            this.BackButton.TabIndex = 4;
            this.BackButton.Text = "Назад";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(362, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Данные суммы предоставлены для ознакомления. Точная информация о выплатах будет в расчетных листах.";
            // 
            // ConfirmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1544, 848);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.WorkDateLabel);
            this.Controls.Add(this.WorkerNameLabel);
            this.Controls.Add(this.doneWorkDatagrid);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ConfirmForm";
            this.Text = "ConfirmForm";
            ((System.ComponentModel.ISupportInitialize)(this.doneWorkDatagrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView doneWorkDatagrid;
        private System.Windows.Forms.Label WorkerNameLabel;
        private System.Windows.Forms.Label WorkDateLabel;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label label1;
    }
}