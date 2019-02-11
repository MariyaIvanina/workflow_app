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
            this.doneWorkDatagrid.Location = new System.Drawing.Point(25, 69);
            this.doneWorkDatagrid.Name = "doneWorkDatagrid";
            this.doneWorkDatagrid.ReadOnly = true;
            this.doneWorkDatagrid.Size = new System.Drawing.Size(797, 261);
            this.doneWorkDatagrid.TabIndex = 0;
            // 
            // WorkerNameLabel
            // 
            this.WorkerNameLabel.AutoSize = true;
            this.WorkerNameLabel.Location = new System.Drawing.Point(22, 13);
            this.WorkerNameLabel.Name = "WorkerNameLabel";
            this.WorkerNameLabel.Size = new System.Drawing.Size(35, 13);
            this.WorkerNameLabel.TabIndex = 1;
            this.WorkerNameLabel.Text = "label1";
            // 
            // WorkDateLabel
            // 
            this.WorkDateLabel.AutoSize = true;
            this.WorkDateLabel.Location = new System.Drawing.Point(22, 44);
            this.WorkDateLabel.Name = "WorkDateLabel";
            this.WorkDateLabel.Size = new System.Drawing.Size(35, 13);
            this.WorkDateLabel.TabIndex = 2;
            this.WorkDateLabel.Text = "label1";
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(735, 347);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(87, 23);
            this.confirmButton.TabIndex = 3;
            this.confirmButton.Text = "Подтвердить";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(636, 347);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 23);
            this.BackButton.TabIndex = 4;
            this.BackButton.Text = "Назад";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(241, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(571, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Данные суммы предоставлены для ознакомления. Точная информация о выплатах будет в" +
    " расчетных листах.";
            // 
            // ConfirmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 391);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.WorkDateLabel);
            this.Controls.Add(this.WorkerNameLabel);
            this.Controls.Add(this.doneWorkDatagrid);
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