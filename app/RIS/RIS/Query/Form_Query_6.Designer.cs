namespace RIS
{
    partial class Form_Query_6
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Get = new System.Windows.Forms.Button();
            this.numericUpDown_Month = new System.Windows.Forms.NumericUpDown();
            this.dataGridView_Orders = new System.Windows.Forms.DataGridView();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Month)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Orders)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 424);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(946, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "За указанный месяц получить список продаж тех товаров,\r\nкоторые производятся росс" +
    "ийскими фирмами";
            // 
            // button_Get
            // 
            this.button_Get.Location = new System.Drawing.Point(415, 40);
            this.button_Get.Name = "button_Get";
            this.button_Get.Size = new System.Drawing.Size(75, 23);
            this.button_Get.TabIndex = 2;
            this.button_Get.Text = "Список";
            this.button_Get.UseVisualStyleBackColor = true;
            this.button_Get.Click += new System.EventHandler(this.button_Get_Click);
            // 
            // numericUpDown_Month
            // 
            this.numericUpDown_Month.Location = new System.Drawing.Point(415, 12);
            this.numericUpDown_Month.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDown_Month.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Month.Name = "numericUpDown_Month";
            this.numericUpDown_Month.Size = new System.Drawing.Size(75, 20);
            this.numericUpDown_Month.TabIndex = 3;
            this.numericUpDown_Month.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dataGridView_Orders
            // 
            this.dataGridView_Orders.AllowUserToAddRows = false;
            this.dataGridView_Orders.AllowUserToDeleteRows = false;
            this.dataGridView_Orders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Orders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Orders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Orders.Location = new System.Drawing.Point(12, 69);
            this.dataGridView_Orders.Name = "dataGridView_Orders";
            this.dataGridView_Orders.ReadOnly = true;
            this.dataGridView_Orders.Size = new System.Drawing.Size(922, 340);
            this.dataGridView_Orders.TabIndex = 4;
            // 
            // Form_Query_6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 446);
            this.Controls.Add(this.dataGridView_Orders);
            this.Controls.Add(this.numericUpDown_Month);
            this.Controls.Add(this.button_Get);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form_Query_6";
            this.Text = "Запрос 6";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Query_6_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Month)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Orders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Get;
        private System.Windows.Forms.NumericUpDown numericUpDown_Month;
        private System.Windows.Forms.DataGridView dataGridView_Orders;

    }
}