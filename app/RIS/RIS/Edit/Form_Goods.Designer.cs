namespace RIS
{
    partial class Form_Goods
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
            this.dataGridView_Goods = new System.Windows.Forms.DataGridView();
            this.comboBox_Category = new System.Windows.Forms.ComboBox();
            this.comboBox_Company = new System.Windows.Forms.ComboBox();
            this.textBox_Model = new System.Windows.Forms.TextBox();
            this.textBox_Price = new System.Windows.Forms.TextBox();
            this.richTextBox_Description = new System.Windows.Forms.RichTextBox();
            this.button_Create = new System.Windows.Forms.Button();
            this.button_Change = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.label_id = new System.Windows.Forms.Label();
            this.comboBox_Server = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Goods)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Goods
            // 
            this.dataGridView_Goods.AllowUserToAddRows = false;
            this.dataGridView_Goods.AllowUserToDeleteRows = false;
            this.dataGridView_Goods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Goods.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Goods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Goods.Location = new System.Drawing.Point(12, 39);
            this.dataGridView_Goods.MultiSelect = false;
            this.dataGridView_Goods.Name = "dataGridView_Goods";
            this.dataGridView_Goods.ReadOnly = true;
            this.dataGridView_Goods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Goods.Size = new System.Drawing.Size(880, 271);
            this.dataGridView_Goods.TabIndex = 9;
            this.dataGridView_Goods.Tag = "9";
            this.dataGridView_Goods.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_Goods_CellMouseDown);
            // 
            // comboBox_Category
            // 
            this.comboBox_Category.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.comboBox_Category.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox_Category.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Category.FormattingEnabled = true;
            this.comboBox_Category.Location = new System.Drawing.Point(189, 342);
            this.comboBox_Category.Name = "comboBox_Category";
            this.comboBox_Category.Size = new System.Drawing.Size(201, 21);
            this.comboBox_Category.TabIndex = 1;
            this.comboBox_Category.Tag = "1";
            // 
            // comboBox_Company
            // 
            this.comboBox_Company.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.comboBox_Company.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox_Company.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Company.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Company.FormattingEnabled = true;
            this.comboBox_Company.Location = new System.Drawing.Point(396, 342);
            this.comboBox_Company.Name = "comboBox_Company";
            this.comboBox_Company.Size = new System.Drawing.Size(256, 21);
            this.comboBox_Company.TabIndex = 2;
            this.comboBox_Company.Tag = "2";
            // 
            // textBox_Model
            // 
            this.textBox_Model.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox_Model.Location = new System.Drawing.Point(189, 386);
            this.textBox_Model.Name = "textBox_Model";
            this.textBox_Model.Size = new System.Drawing.Size(143, 20);
            this.textBox_Model.TabIndex = 3;
            this.textBox_Model.Tag = "3";
            // 
            // textBox_Price
            // 
            this.textBox_Price.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox_Price.Location = new System.Drawing.Point(338, 386);
            this.textBox_Price.Name = "textBox_Price";
            this.textBox_Price.Size = new System.Drawing.Size(113, 20);
            this.textBox_Price.TabIndex = 4;
            this.textBox_Price.Tag = "4";
            // 
            // richTextBox_Description
            // 
            this.richTextBox_Description.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.richTextBox_Description.Location = new System.Drawing.Point(189, 427);
            this.richTextBox_Description.Name = "richTextBox_Description";
            this.richTextBox_Description.ReadOnly = true;
            this.richTextBox_Description.Size = new System.Drawing.Size(463, 52);
            this.richTextBox_Description.TabIndex = 5;
            this.richTextBox_Description.TabStop = false;
            this.richTextBox_Description.Tag = "5";
            this.richTextBox_Description.Text = "Описание не поддерживается ()";
            // 
            // button_Create
            // 
            this.button_Create.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_Create.Location = new System.Drawing.Point(696, 340);
            this.button_Create.Name = "button_Create";
            this.button_Create.Size = new System.Drawing.Size(75, 23);
            this.button_Create.TabIndex = 6;
            this.button_Create.Tag = "6";
            this.button_Create.Text = "Создать";
            this.button_Create.UseVisualStyleBackColor = true;
            this.button_Create.Click += new System.EventHandler(this.button_Create_Click);
            // 
            // button_Change
            // 
            this.button_Change.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_Change.Location = new System.Drawing.Point(696, 384);
            this.button_Change.Name = "button_Change";
            this.button_Change.Size = new System.Drawing.Size(75, 23);
            this.button_Change.TabIndex = 7;
            this.button_Change.Tag = "7";
            this.button_Change.Text = "Изменить";
            this.button_Change.UseVisualStyleBackColor = true;
            this.button_Change.Click += new System.EventHandler(this.button_Change_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_Delete.Location = new System.Drawing.Point(696, 425);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(75, 23);
            this.button_Delete.TabIndex = 8;
            this.button_Delete.Tag = "8";
            this.button_Delete.Text = "Удалить";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // label_id
            // 
            this.label_id.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label_id.AutoSize = true;
            this.label_id.Location = new System.Drawing.Point(142, 345);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(0, 13);
            this.label_id.TabIndex = 9;
            // 
            // comboBox_Server
            // 
            this.comboBox_Server.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Server.FormattingEnabled = true;
            this.comboBox_Server.Items.AddRange(new object[] {
            "Сервер А",
            "Сервер Б"});
            this.comboBox_Server.Location = new System.Drawing.Point(59, 12);
            this.comboBox_Server.Name = "comboBox_Server";
            this.comboBox_Server.Size = new System.Drawing.Size(201, 21);
            this.comboBox_Server.TabIndex = 0;
            this.comboBox_Server.Tag = "0";
            this.comboBox_Server.SelectionChangeCommitted += new System.EventHandler(this.comboBox_Server_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Сервер:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 326);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Категория";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(393, 326);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Компания";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(186, 370);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Модель";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(335, 370);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Цена";
            // 
            // Form_Goods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 513);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_Server);
            this.Controls.Add(this.label_id);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.button_Change);
            this.Controls.Add(this.button_Create);
            this.Controls.Add(this.richTextBox_Description);
            this.Controls.Add(this.textBox_Price);
            this.Controls.Add(this.textBox_Model);
            this.Controls.Add(this.comboBox_Company);
            this.Controls.Add(this.comboBox_Category);
            this.Controls.Add(this.dataGridView_Goods);
            this.Name = "Form_Goods";
            this.Text = "Редактирование товаров";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Goods_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Goods)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Goods;
        private System.Windows.Forms.ComboBox comboBox_Category;
        private System.Windows.Forms.ComboBox comboBox_Company;
        private System.Windows.Forms.TextBox textBox_Model;
        private System.Windows.Forms.TextBox textBox_Price;
        private System.Windows.Forms.RichTextBox richTextBox_Description;
        private System.Windows.Forms.Button button_Create;
        private System.Windows.Forms.Button button_Change;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Label label_id;
        private System.Windows.Forms.ComboBox comboBox_Server;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}