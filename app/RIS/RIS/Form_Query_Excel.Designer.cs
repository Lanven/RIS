namespace RIS
{
    partial class Form_Query_Excel
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
            this.button_GetFirmList = new System.Windows.Forms.Button();
            this.dataGridView_Data = new System.Windows.Forms.DataGridView();
            this.button_GetExcelReport = new System.Windows.Forms.Button();
            this.button_GetLook = new System.Windows.Forms.Button();
            this.textBox_To = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_From = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_Firms = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_GetFirmList
            // 
            this.button_GetFirmList.Location = new System.Drawing.Point(417, 55);
            this.button_GetFirmList.Name = "button_GetFirmList";
            this.button_GetFirmList.Size = new System.Drawing.Size(127, 23);
            this.button_GetFirmList.TabIndex = 23;
            this.button_GetFirmList.Text = "Фирмы";
            this.button_GetFirmList.UseVisualStyleBackColor = true;
            this.button_GetFirmList.Click += new System.EventHandler(this.button_GetFirmList_Click);
            // 
            // dataGridView_Data
            // 
            this.dataGridView_Data.AllowUserToAddRows = false;
            this.dataGridView_Data.AllowUserToDeleteRows = false;
            this.dataGridView_Data.AllowUserToOrderColumns = true;
            this.dataGridView_Data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Data.Location = new System.Drawing.Point(15, 121);
            this.dataGridView_Data.Name = "dataGridView_Data";
            this.dataGridView_Data.ReadOnly = true;
            this.dataGridView_Data.Size = new System.Drawing.Size(671, 341);
            this.dataGridView_Data.TabIndex = 22;
            // 
            // button_GetExcelReport
            // 
            this.button_GetExcelReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_GetExcelReport.Location = new System.Drawing.Point(559, 468);
            this.button_GetExcelReport.Name = "button_GetExcelReport";
            this.button_GetExcelReport.Size = new System.Drawing.Size(127, 23);
            this.button_GetExcelReport.TabIndex = 21;
            this.button_GetExcelReport.Text = "Вывести в отчет";
            this.button_GetExcelReport.UseVisualStyleBackColor = true;
            this.button_GetExcelReport.Click += new System.EventHandler(this.button_GetExcelReport_Click);
            // 
            // button_GetLook
            // 
            this.button_GetLook.Location = new System.Drawing.Point(417, 92);
            this.button_GetLook.Name = "button_GetLook";
            this.button_GetLook.Size = new System.Drawing.Size(127, 23);
            this.button_GetLook.TabIndex = 20;
            this.button_GetLook.Text = "Просмотр";
            this.button_GetLook.UseVisualStyleBackColor = true;
            this.button_GetLook.Click += new System.EventHandler(this.button_GetLook_Click);
            // 
            // textBox_To
            // 
            this.textBox_To.Location = new System.Drawing.Point(276, 94);
            this.textBox_To.Name = "textBox_To";
            this.textBox_To.Size = new System.Drawing.Size(135, 20);
            this.textBox_To.TabIndex = 19;
            this.textBox_To.Text = "2014-12-31";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(251, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "по";
            // 
            // textBox_From
            // 
            this.textBox_From.Location = new System.Drawing.Point(122, 94);
            this.textBox_From.Name = "textBox_From";
            this.textBox_From.Size = new System.Drawing.Size(123, 20);
            this.textBox_From.TabIndex = 17;
            this.textBox_From.Text = "2014-01-01";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Период времени: с";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Фирма:";
            // 
            // comboBox_Firms
            // 
            this.comboBox_Firms.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox_Firms.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Firms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Firms.FormattingEnabled = true;
            this.comboBox_Firms.Location = new System.Drawing.Point(65, 57);
            this.comboBox_Firms.Name = "comboBox_Firms";
            this.comboBox_Firms.Size = new System.Drawing.Size(346, 21);
            this.comboBox_Firms.TabIndex = 14;
            this.comboBox_Firms.SelectionChangeCommitted += new System.EventHandler(this.comboBox_Firms_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(399, 39);
            this.label1.TabIndex = 13;
            this.label1.Text = "Для любой заданной фирмы сформировать в виде Word-документа отчёт,\r\nвключающий да" +
    "нные о ней и таблицу со списком поставляемых ею товаров,\r\nпроданных за заданный " +
    "период времени.";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 508);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(703, 22);
            this.statusStrip1.TabIndex = 25;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(568, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 26;
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(568, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 27;
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(615, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 28;
            this.label7.Visible = false;
            // 
            // Form_Query_Excel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 530);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button_GetFirmList);
            this.Controls.Add(this.dataGridView_Data);
            this.Controls.Add(this.button_GetExcelReport);
            this.Controls.Add(this.button_GetLook);
            this.Controls.Add(this.textBox_To);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_From);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_Firms);
            this.Controls.Add(this.label1);
            this.Name = "Form_Query_Excel";
            this.Text = "Формирование Excel-отчета";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Query_Excel_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_GetFirmList;
        private System.Windows.Forms.DataGridView dataGridView_Data;
        private System.Windows.Forms.Button button_GetExcelReport;
        private System.Windows.Forms.Button button_GetLook;
        private System.Windows.Forms.TextBox textBox_To;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_From;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_Firms;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}