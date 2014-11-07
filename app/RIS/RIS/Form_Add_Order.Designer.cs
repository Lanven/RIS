namespace RIS
{
    partial class Form_Add_Order
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.richTextBox_Details = new System.Windows.Forms.RichTextBox();
            this.dateTimePicker_OnSaleDate = new System.Windows.Forms.DateTimePicker();
            this.comboBox_SaleType = new System.Windows.Forms.ComboBox();
            this.comboBox_PaymentMethod = new System.Windows.Forms.ComboBox();
            this.textBox_SaleAmount = new System.Windows.Forms.TextBox();
            this.textBox_Client = new System.Windows.Forms.TextBox();
            this.button_SearchClient = new System.Windows.Forms.Button();
            this.textBox_Goods = new System.Windows.Forms.TextBox();
            this.button_SearchGoods = new System.Windows.Forms.Button();
            this.button_AddOrder = new System.Windows.Forms.Button();
            this.textBox_ClientId = new System.Windows.Forms.TextBox();
            this.textBox_GoodsId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Клиент";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Товар";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Сумма покупки";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Способ оплаты";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 264);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Вид продажи";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 298);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Дата продажи";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 342);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Доп. информация";
            // 
            // richTextBox_Details
            // 
            this.richTextBox_Details.Location = new System.Drawing.Point(131, 342);
            this.richTextBox_Details.Name = "richTextBox_Details";
            this.richTextBox_Details.Size = new System.Drawing.Size(404, 96);
            this.richTextBox_Details.TabIndex = 7;
            this.richTextBox_Details.Text = "";
            // 
            // dateTimePicker_OnSaleDate
            // 
            this.dateTimePicker_OnSaleDate.Location = new System.Drawing.Point(131, 298);
            this.dateTimePicker_OnSaleDate.Name = "dateTimePicker_OnSaleDate";
            this.dateTimePicker_OnSaleDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_OnSaleDate.TabIndex = 8;
            // 
            // comboBox_SaleType
            // 
            this.comboBox_SaleType.FormattingEnabled = true;
            this.comboBox_SaleType.Location = new System.Drawing.Point(131, 261);
            this.comboBox_SaleType.Name = "comboBox_SaleType";
            this.comboBox_SaleType.Size = new System.Drawing.Size(200, 21);
            this.comboBox_SaleType.TabIndex = 9;
            // 
            // comboBox_PaymentMethod
            // 
            this.comboBox_PaymentMethod.FormattingEnabled = true;
            this.comboBox_PaymentMethod.Location = new System.Drawing.Point(131, 225);
            this.comboBox_PaymentMethod.Name = "comboBox_PaymentMethod";
            this.comboBox_PaymentMethod.Size = new System.Drawing.Size(200, 21);
            this.comboBox_PaymentMethod.TabIndex = 10;
            // 
            // textBox_SaleAmount
            // 
            this.textBox_SaleAmount.Location = new System.Drawing.Point(131, 166);
            this.textBox_SaleAmount.Name = "textBox_SaleAmount";
            this.textBox_SaleAmount.Size = new System.Drawing.Size(200, 20);
            this.textBox_SaleAmount.TabIndex = 11;
            // 
            // textBox_Client
            // 
            this.textBox_Client.Location = new System.Drawing.Point(131, 27);
            this.textBox_Client.Name = "textBox_Client";
            this.textBox_Client.ReadOnly = true;
            this.textBox_Client.Size = new System.Drawing.Size(404, 20);
            this.textBox_Client.TabIndex = 12;
            // 
            // button_SearchClient
            // 
            this.button_SearchClient.Location = new System.Drawing.Point(131, 53);
            this.button_SearchClient.Name = "button_SearchClient";
            this.button_SearchClient.Size = new System.Drawing.Size(75, 23);
            this.button_SearchClient.TabIndex = 13;
            this.button_SearchClient.Text = "Поиск";
            this.button_SearchClient.UseVisualStyleBackColor = true;
            this.button_SearchClient.Click += new System.EventHandler(this.button_SearchClient_Click);
            // 
            // textBox_Goods
            // 
            this.textBox_Goods.Location = new System.Drawing.Point(131, 101);
            this.textBox_Goods.Name = "textBox_Goods";
            this.textBox_Goods.ReadOnly = true;
            this.textBox_Goods.Size = new System.Drawing.Size(404, 20);
            this.textBox_Goods.TabIndex = 14;
            // 
            // button_SearchGoods
            // 
            this.button_SearchGoods.Location = new System.Drawing.Point(131, 127);
            this.button_SearchGoods.Name = "button_SearchGoods";
            this.button_SearchGoods.Size = new System.Drawing.Size(75, 23);
            this.button_SearchGoods.TabIndex = 15;
            this.button_SearchGoods.Text = "Поиск";
            this.button_SearchGoods.UseVisualStyleBackColor = true;
            this.button_SearchGoods.Click += new System.EventHandler(this.button_SearchGoods_Click);
            // 
            // button_AddOrder
            // 
            this.button_AddOrder.Location = new System.Drawing.Point(238, 457);
            this.button_AddOrder.Name = "button_AddOrder";
            this.button_AddOrder.Size = new System.Drawing.Size(75, 23);
            this.button_AddOrder.TabIndex = 16;
            this.button_AddOrder.Text = "Добавить";
            this.button_AddOrder.UseVisualStyleBackColor = true;
            this.button_AddOrder.Click += new System.EventHandler(this.button_AddOrder_Click);
            // 
            // textBox_ClientId
            // 
            this.textBox_ClientId.Location = new System.Drawing.Point(61, 27);
            this.textBox_ClientId.Name = "textBox_ClientId";
            this.textBox_ClientId.Size = new System.Drawing.Size(49, 20);
            this.textBox_ClientId.TabIndex = 17;
            // 
            // textBox_GoodsId
            // 
            this.textBox_GoodsId.Location = new System.Drawing.Point(61, 101);
            this.textBox_GoodsId.Name = "textBox_GoodsId";
            this.textBox_GoodsId.Size = new System.Drawing.Size(49, 20);
            this.textBox_GoodsId.TabIndex = 18;
            // 
            // Form_Add_Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 498);
            this.Controls.Add(this.textBox_GoodsId);
            this.Controls.Add(this.textBox_ClientId);
            this.Controls.Add(this.button_AddOrder);
            this.Controls.Add(this.button_SearchGoods);
            this.Controls.Add(this.textBox_Goods);
            this.Controls.Add(this.button_SearchClient);
            this.Controls.Add(this.textBox_Client);
            this.Controls.Add(this.textBox_SaleAmount);
            this.Controls.Add(this.comboBox_PaymentMethod);
            this.Controls.Add(this.comboBox_SaleType);
            this.Controls.Add(this.dateTimePicker_OnSaleDate);
            this.Controls.Add(this.richTextBox_Details);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form_Add_Order";
            this.Text = "Добавить новую продажу";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox richTextBox_Details;
        private System.Windows.Forms.DateTimePicker dateTimePicker_OnSaleDate;
        private System.Windows.Forms.ComboBox comboBox_SaleType;
        private System.Windows.Forms.ComboBox comboBox_PaymentMethod;
        private System.Windows.Forms.TextBox textBox_SaleAmount;
        private System.Windows.Forms.TextBox textBox_Client;
        private System.Windows.Forms.Button button_SearchClient;
        private System.Windows.Forms.TextBox textBox_Goods;
        private System.Windows.Forms.Button button_SearchGoods;
        private System.Windows.Forms.Button button_AddOrder;
        private System.Windows.Forms.TextBox textBox_ClientId;
        private System.Windows.Forms.TextBox textBox_GoodsId;
    }
}