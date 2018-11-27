namespace COMP2614Assign06
{
    partial class MainForm
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
            this.dataGridViewClient = new System.Windows.Forms.DataGridView();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.checkBoxConfirmDelete = new System.Windows.Forms.CheckBox();
            this.labelTotalYtdSales = new System.Windows.Forms.Label();
            this.labelCreditHoldCount = new System.Windows.Forms.Label();
            this.labelRecordCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClient)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewClient
            // 
            this.dataGridViewClient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClient.Location = new System.Drawing.Point(41, 33);
            this.dataGridViewClient.MultiSelect = false;
            this.dataGridViewClient.Name = "dataGridViewClient";
            this.dataGridViewClient.ReadOnly = true;
            this.dataGridViewClient.RowTemplate.Height = 24;
            this.dataGridViewClient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewClient.Size = new System.Drawing.Size(1216, 623);
            this.dataGridViewClient.TabIndex = 0;
            this.dataGridViewClient.DoubleClick += new System.EventHandler(this.dataGridViewClient_DoubleClick);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(1081, 682);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 6;
            this.buttonEdit.Text = "&Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(977, 682);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 5;
            this.buttonAdd.Text = "&Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(1182, 682);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // checkBoxConfirmDelete
            // 
            this.checkBoxConfirmDelete.AutoSize = true;
            this.checkBoxConfirmDelete.Location = new System.Drawing.Point(804, 684);
            this.checkBoxConfirmDelete.Name = "checkBoxConfirmDelete";
            this.checkBoxConfirmDelete.Size = new System.Drawing.Size(134, 21);
            this.checkBoxConfirmDelete.TabIndex = 4;
            this.checkBoxConfirmDelete.Text = "Confirm Deletion";
            this.checkBoxConfirmDelete.UseVisualStyleBackColor = true;
            // 
            // labelTotalYtdSales
            // 
            this.labelTotalYtdSales.AutoSize = true;
            this.labelTotalYtdSales.Location = new System.Drawing.Point(38, 685);
            this.labelTotalYtdSales.Name = "labelTotalYtdSales";
            this.labelTotalYtdSales.Size = new System.Drawing.Size(112, 17);
            this.labelTotalYtdSales.TabIndex = 1;
            this.labelTotalYtdSales.Text = "<TotalYtdSales>";
            // 
            // labelCreditHoldCount
            // 
            this.labelCreditHoldCount.AutoSize = true;
            this.labelCreditHoldCount.Location = new System.Drawing.Point(283, 685);
            this.labelCreditHoldCount.Name = "labelCreditHoldCount";
            this.labelCreditHoldCount.Size = new System.Drawing.Size(127, 17);
            this.labelCreditHoldCount.TabIndex = 2;
            this.labelCreditHoldCount.Text = "<CreditHoldCount>";
            // 
            // labelRecordCount
            // 
            this.labelRecordCount.AutoSize = true;
            this.labelRecordCount.Location = new System.Drawing.Point(489, 685);
            this.labelRecordCount.Name = "labelRecordCount";
            this.labelRecordCount.Size = new System.Drawing.Size(107, 17);
            this.labelRecordCount.TabIndex = 3;
            this.labelRecordCount.Text = "<RecordCount>";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 728);
            this.Controls.Add(this.labelRecordCount);
            this.Controls.Add(this.labelCreditHoldCount);
            this.Controls.Add(this.labelTotalYtdSales);
            this.Controls.Add(this.checkBoxConfirmDelete);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.dataGridViewClient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Binding";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewClient;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.CheckBox checkBoxConfirmDelete;
        private System.Windows.Forms.Label labelTotalYtdSales;
        private System.Windows.Forms.Label labelCreditHoldCount;
        private System.Windows.Forms.Label labelRecordCount;
    }
}

