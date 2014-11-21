namespace RIS
{
    partial class Form_Orders
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
            this.dataGridView_Orders = new System.Windows.Forms.DataGridView();
            this.comboBox_Goods = new System.Windows.Forms.ComboBox();
            this.comboBox_Client = new System.Windows.Forms.ComboBox();
            this.textBox_On_sale_date = new System.Windows.Forms.TextBox();
            this.textBox_Sale_Amount = new System.Windows.Forms.TextBox();
            this.comboBox_Payment_Method = new System.Windows.Forms.ComboBox();
            this.comboBox_Sale_Type = new System.Windows.Forms.ComboBox();
            this.richTextBox_Details = new System.Windows.Forms.RichTextBox();
            this.button_Create = new System.Windows.Forms.Button();
            this.button_Change = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.label_id = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Server = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button_Refresh = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Orders)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.dataGridView_Orders.Location = new System.Drawing.Point(12, 45);
            this.dataGridView_Orders.MultiSelect = false;
            this.dataGridView_Orders.Name = "dataGridView_Orders";
            this.dataGridView_Orders.ReadOnly = true;
            this.dataGridView_Orders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Orders.Size = new System.Drawing.Size(904, 310);
            this.dataGridView_Orders.TabIndex = 11;
            this.dataGridView_Orders.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_Orders_CellMouseDown);
            // 
            // comboBox_Goods
            // 
            this.comboBox_Goods.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.comboBox_Goods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Goods.FormattingEnabled = true;
            this.comboBox_Goods.Location = new System.Drawing.Point(203, 386);
            this.comboBox_Goods.Name = "comboBox_Goods";
            this.comboBox_Goods.Size = new System.Drawing.Size(98, 21);
            this.comboBox_Goods.TabIndex = 1;
            // 
            // comboBox_Client
            // 
            this.comboBox_Client.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.comboBox_Client.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Client.FormattingEnabled = true;
            this.comboBox_Client.Location = new System.Drawing.Point(307, 386);
            this.comboBox_Client.Name = "comboBox_Client";
            this.comboBox_Client.Size = new System.Drawing.Size(254, 21);
            this.comboBox_Client.TabIndex = 2;
            // 
            // textBox_On_sale_date
            // 
            this.textBox_On_sale_date.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox_On_sale_date.Location = new System.Drawing.Point(567, 386);
            this.textBox_On_sale_date.Name = "textBox_On_sale_date";
            this.textBox_On_sale_date.Size = new System.Drawing.Size(109, 20);
            this.textBox_On_sale_date.TabIndex = 3;
            // 
            // textBox_Sale_Amount
            // 
            this.textBox_Sale_Amount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox_Sale_Amount.Location = new System.Drawing.Point(529, 429);
            this.textBox_Sale_Amount.Name = "textBox_Sale_Amount";
            this.textBox_Sale_Amount.Size = new System.Drawing.Size(147, 20);
            this.textBox_Sale_Amount.TabIndex = 6;
            // 
            // comboBox_Payment_Method
            // 
            this.comboBox_Payment_Method.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.comboBox_Payment_Method.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Payment_Method.FormattingEnabled = true;
            this.comboBox_Payment_Method.Location = new System.Drawing.Point(366, 428);
            this.comboBox_Payment_Method.Name = "comboBox_Payment_Method";
            this.comboBox_Payment_Method.Size = new System.Drawing.Size(157, 21);
            this.comboBox_Payment_Method.TabIndex = 5;
            // 
            // comboBox_Sale_Type
            // 
            this.comboBox_Sale_Type.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.comboBox_Sale_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Sale_Type.FormattingEnabled = true;
            this.comboBox_Sale_Type.Location = new System.Drawing.Point(203, 428);
            this.comboBox_Sale_Type.Name = "comboBox_Sale_Type";
            this.comboBox_Sale_Type.Size = new System.Drawing.Size(157, 21);
            this.comboBox_Sale_Type.TabIndex = 4;
            // 
            // richTextBox_Details
            // 
            this.richTextBox_Details.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.richTextBox_Details.Location = new System.Drawing.Point(203, 472);
            this.richTextBox_Details.Name = "richTextBox_Details";
            this.richTextBox_Details.ReadOnly = true;
            this.richTextBox_Details.Size = new System.Drawing.Size(473, 69);
            this.richTextBox_Details.TabIndex = 7;
            this.richTextBox_Details.TabStop = false;
            this.richTextBox_Details.Text = "Не поддерживается ()";
            // 
            // button_Create
            // 
            this.button_Create.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_Create.Location = new System.Drawing.Point(716, 384);
            this.button_Create.Name = "button_Create";
            this.button_Create.Size = new System.Drawing.Size(75, 23);
            this.button_Create.TabIndex = 8;
            this.button_Create.Text = "Создать";
            this.button_Create.UseVisualStyleBackColor = true;
            this.button_Create.Click += new System.EventHandler(this.button_Create_Click);
            // 
            // button_Change
            // 
            this.button_Change.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_Change.Location = new System.Drawing.Point(716, 427);
            this.button_Change.Name = "button_Change";
            this.button_Change.Size = new System.Drawing.Size(75, 23);
            this.button_Change.TabIndex = 9;
            this.button_Change.Text = "Изменить";
            this.button_Change.UseVisualStyleBackColor = true;
            this.button_Change.Click += new System.EventHandler(this.button_Change_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_Delete.Location = new System.Drawing.Point(716, 472);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(75, 23);
            this.button_Delete.TabIndex = 10;
            this.button_Delete.Text = "Удалить";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // label_id
            // 
            this.label_id.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label_id.AutoSize = true;
            this.label_id.Location = new System.Drawing.Point(147, 389);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(0, 13);
            this.label_id.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Сервер:";
            // 
            // comboBox_Server
            // 
            this.comboBox_Server.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Server.FormattingEnabled = true;
            this.comboBox_Server.Items.AddRange(new object[] {
            "Сервер А",
            "Сервер Б"});
            this.comboBox_Server.Location = new System.Drawing.Point(69, 12);
            this.comboBox_Server.Name = "comboBox_Server";
            this.comboBox_Server.Size = new System.Drawing.Size(193, 21);
            this.comboBox_Server.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 370);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Товар";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(304, 370);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Клиент";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(567, 370);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Дата продажи";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(203, 412);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Вид продажи";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(363, 412);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Метод оплаты";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(526, 412);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Сумма покупки";
            // 
            // button_Refresh
            // 
            this.button_Refresh.Location = new System.Drawing.Point(841, 10);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(75, 23);
            this.button_Refresh.TabIndex = 20;
            this.button_Refresh.Text = "Обновить";
            this.button_Refresh.UseVisualStyleBackColor = true;
            this.button_Refresh.Click += new System.EventHandler(this.button_Refresh_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 564);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(928, 22);
            this.statusStrip1.TabIndex = 21;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // Form_Orders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 586);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button_Refresh);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_Server);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_id);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.button_Change);
            this.Controls.Add(this.button_Create);
            this.Controls.Add(this.richTextBox_Details);
            this.Controls.Add(this.comboBox_Sale_Type);
            this.Controls.Add(this.comboBox_Payment_Method);
            this.Controls.Add(this.textBox_Sale_Amount);
            this.Controls.Add(this.textBox_On_sale_date);
            this.Controls.Add(this.comboBox_Client);
            this.Controls.Add(this.comboBox_Goods);
            this.Controls.Add(this.dataGridView_Orders);
            this.Name = "Form_Orders";
            this.Text = "Редактирование заказов";
            this.Shown += new System.EventHandler(this.Form_Orders_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Orders)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Orders;
        private System.Windows.Forms.ComboBox comboBox_Goods;
        private System.Windows.Forms.ComboBox comboBox_Client;
        private System.Windows.Forms.TextBox textBox_On_sale_date;
        private System.Windows.Forms.TextBox textBox_Sale_Amount;
        private System.Windows.Forms.ComboBox comboBox_Payment_Method;
        private System.Windows.Forms.ComboBox comboBox_Sale_Type;
        private System.Windows.Forms.RichTextBox richTextBox_Details;
        private System.Windows.Forms.Button button_Create;
        private System.Windows.Forms.Button button_Change;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Label label_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Server;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_Refresh;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}