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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Orders)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Orders
            // 
            this.dataGridView_Orders.AllowUserToAddRows = false;
            this.dataGridView_Orders.AllowUserToDeleteRows = false;
            this.dataGridView_Orders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Orders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Orders.Location = new System.Drawing.Point(12, 45);
            this.dataGridView_Orders.Name = "dataGridView_Orders";
            this.dataGridView_Orders.ReadOnly = true;
            this.dataGridView_Orders.Size = new System.Drawing.Size(904, 326);
            this.dataGridView_Orders.TabIndex = 0;
            this.dataGridView_Orders.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_Orders_CellMouseDown);
            // 
            // comboBox_Goods
            // 
            this.comboBox_Goods.FormattingEnabled = true;
            this.comboBox_Goods.Location = new System.Drawing.Point(203, 407);
            this.comboBox_Goods.Name = "comboBox_Goods";
            this.comboBox_Goods.Size = new System.Drawing.Size(98, 21);
            this.comboBox_Goods.TabIndex = 1;
            // 
            // comboBox_Client
            // 
            this.comboBox_Client.FormattingEnabled = true;
            this.comboBox_Client.Location = new System.Drawing.Point(307, 407);
            this.comboBox_Client.Name = "comboBox_Client";
            this.comboBox_Client.Size = new System.Drawing.Size(254, 21);
            this.comboBox_Client.TabIndex = 2;
            // 
            // textBox_On_sale_date
            // 
            this.textBox_On_sale_date.Location = new System.Drawing.Point(567, 407);
            this.textBox_On_sale_date.Name = "textBox_On_sale_date";
            this.textBox_On_sale_date.Size = new System.Drawing.Size(109, 20);
            this.textBox_On_sale_date.TabIndex = 3;
            // 
            // textBox_Sale_Amount
            // 
            this.textBox_Sale_Amount.Location = new System.Drawing.Point(529, 450);
            this.textBox_Sale_Amount.Name = "textBox_Sale_Amount";
            this.textBox_Sale_Amount.Size = new System.Drawing.Size(147, 20);
            this.textBox_Sale_Amount.TabIndex = 4;
            // 
            // comboBox_Payment_Method
            // 
            this.comboBox_Payment_Method.FormattingEnabled = true;
            this.comboBox_Payment_Method.Location = new System.Drawing.Point(366, 449);
            this.comboBox_Payment_Method.Name = "comboBox_Payment_Method";
            this.comboBox_Payment_Method.Size = new System.Drawing.Size(157, 21);
            this.comboBox_Payment_Method.TabIndex = 5;
            // 
            // comboBox_Sale_Type
            // 
            this.comboBox_Sale_Type.FormattingEnabled = true;
            this.comboBox_Sale_Type.Location = new System.Drawing.Point(203, 449);
            this.comboBox_Sale_Type.Name = "comboBox_Sale_Type";
            this.comboBox_Sale_Type.Size = new System.Drawing.Size(157, 21);
            this.comboBox_Sale_Type.TabIndex = 6;
            // 
            // richTextBox_Details
            // 
            this.richTextBox_Details.Location = new System.Drawing.Point(203, 493);
            this.richTextBox_Details.Name = "richTextBox_Details";
            this.richTextBox_Details.ReadOnly = true;
            this.richTextBox_Details.Size = new System.Drawing.Size(314, 69);
            this.richTextBox_Details.TabIndex = 7;
            this.richTextBox_Details.Text = "Не поддерживается ()";
            // 
            // button_Create
            // 
            this.button_Create.Location = new System.Drawing.Point(716, 405);
            this.button_Create.Name = "button_Create";
            this.button_Create.Size = new System.Drawing.Size(75, 23);
            this.button_Create.TabIndex = 8;
            this.button_Create.Text = "Создать";
            this.button_Create.UseVisualStyleBackColor = true;
            // 
            // button_Change
            // 
            this.button_Change.Location = new System.Drawing.Point(716, 448);
            this.button_Change.Name = "button_Change";
            this.button_Change.Size = new System.Drawing.Size(75, 23);
            this.button_Change.TabIndex = 9;
            this.button_Change.Text = "Изменить";
            this.button_Change.UseVisualStyleBackColor = true;
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(716, 493);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(75, 23);
            this.button_Delete.TabIndex = 10;
            this.button_Delete.Text = "Удалить";
            this.button_Delete.UseVisualStyleBackColor = true;
            // 
            // label_id
            // 
            this.label_id.AutoSize = true;
            this.label_id.Location = new System.Drawing.Point(147, 410);
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
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Сервер А",
            "Сервер Б"});
            this.comboBox1.Location = new System.Drawing.Point(69, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(193, 21);
            this.comboBox1.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 391);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Товар";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(304, 391);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Клиент";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(567, 391);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Дата продажи";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(203, 433);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Вид продажи";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(363, 433);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Метод оплаты";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(526, 433);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Сумма покупки";
            // 
            // Form_Orders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 586);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Orders_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Orders)).EndInit();
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
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}