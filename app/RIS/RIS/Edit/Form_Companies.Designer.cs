namespace RIS
{
    partial class Form_Companies
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
            this.dataGridView_Companies = new System.Windows.Forms.DataGridView();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.label_id = new System.Windows.Forms.Label();
            this.textBox_Head_full_name = new System.Windows.Forms.TextBox();
            this.textBox_Phone = new System.Windows.Forms.TextBox();
            this.textBox_Address = new System.Windows.Forms.TextBox();
            this.textBox_Bank_details = new System.Windows.Forms.TextBox();
            this.comboBox_Country = new System.Windows.Forms.ComboBox();
            this.button_Create = new System.Windows.Forms.Button();
            this.button_Change = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.comboBox_Server = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Companies)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Companies
            // 
            this.dataGridView_Companies.AllowUserToAddRows = false;
            this.dataGridView_Companies.AllowUserToDeleteRows = false;
            this.dataGridView_Companies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Companies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView_Companies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Companies.Location = new System.Drawing.Point(12, 39);
            this.dataGridView_Companies.MultiSelect = false;
            this.dataGridView_Companies.Name = "dataGridView_Companies";
            this.dataGridView_Companies.ReadOnly = true;
            this.dataGridView_Companies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Companies.Size = new System.Drawing.Size(796, 312);
            this.dataGridView_Companies.TabIndex = 11;
            this.dataGridView_Companies.Tag = "10";
            this.dataGridView_Companies.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_Companies_CellMouseDown);
            // 
            // textBox_Name
            // 
            this.textBox_Name.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox_Name.Location = new System.Drawing.Point(65, 393);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(206, 20);
            this.textBox_Name.TabIndex = 1;
            this.textBox_Name.Tag = "1";
            // 
            // label_id
            // 
            this.label_id.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label_id.AutoSize = true;
            this.label_id.Location = new System.Drawing.Point(240, 376);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(0, 13);
            this.label_id.TabIndex = 2;
            // 
            // textBox_Head_full_name
            // 
            this.textBox_Head_full_name.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox_Head_full_name.Location = new System.Drawing.Point(438, 393);
            this.textBox_Head_full_name.Name = "textBox_Head_full_name";
            this.textBox_Head_full_name.Size = new System.Drawing.Size(206, 20);
            this.textBox_Head_full_name.TabIndex = 3;
            this.textBox_Head_full_name.Tag = "3";
            // 
            // textBox_Phone
            // 
            this.textBox_Phone.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox_Phone.Location = new System.Drawing.Point(65, 438);
            this.textBox_Phone.Name = "textBox_Phone";
            this.textBox_Phone.Size = new System.Drawing.Size(132, 20);
            this.textBox_Phone.TabIndex = 4;
            this.textBox_Phone.Tag = "4";
            // 
            // textBox_Address
            // 
            this.textBox_Address.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox_Address.Location = new System.Drawing.Point(203, 438);
            this.textBox_Address.Name = "textBox_Address";
            this.textBox_Address.Size = new System.Drawing.Size(229, 20);
            this.textBox_Address.TabIndex = 5;
            this.textBox_Address.Tag = "5";
            // 
            // textBox_Bank_details
            // 
            this.textBox_Bank_details.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox_Bank_details.Location = new System.Drawing.Point(65, 485);
            this.textBox_Bank_details.Name = "textBox_Bank_details";
            this.textBox_Bank_details.Size = new System.Drawing.Size(579, 20);
            this.textBox_Bank_details.TabIndex = 6;
            this.textBox_Bank_details.Tag = "6";
            // 
            // comboBox_Country
            // 
            this.comboBox_Country.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.comboBox_Country.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox_Country.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Country.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Country.FormattingEnabled = true;
            this.comboBox_Country.Location = new System.Drawing.Point(277, 392);
            this.comboBox_Country.Name = "comboBox_Country";
            this.comboBox_Country.Size = new System.Drawing.Size(155, 21);
            this.comboBox_Country.TabIndex = 2;
            this.comboBox_Country.Tag = "2";
            // 
            // button_Create
            // 
            this.button_Create.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_Create.Location = new System.Drawing.Point(682, 390);
            this.button_Create.Name = "button_Create";
            this.button_Create.Size = new System.Drawing.Size(75, 23);
            this.button_Create.TabIndex = 7;
            this.button_Create.Tag = "7";
            this.button_Create.Text = "Создать";
            this.button_Create.UseVisualStyleBackColor = true;
            this.button_Create.Click += new System.EventHandler(this.button_Create_Click);
            // 
            // button_Change
            // 
            this.button_Change.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_Change.Location = new System.Drawing.Point(682, 435);
            this.button_Change.Name = "button_Change";
            this.button_Change.Size = new System.Drawing.Size(75, 23);
            this.button_Change.TabIndex = 8;
            this.button_Change.Tag = "8";
            this.button_Change.Text = "Изменить";
            this.button_Change.UseVisualStyleBackColor = true;
            this.button_Change.Click += new System.EventHandler(this.button_Change_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_Delete.Location = new System.Drawing.Point(682, 482);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(75, 23);
            this.button_Delete.TabIndex = 9;
            this.button_Delete.Tag = "9";
            this.button_Delete.Text = "Удалить";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // comboBox_Server
            // 
            this.comboBox_Server.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox_Server.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Server.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Server.FormattingEnabled = true;
            this.comboBox_Server.Items.AddRange(new object[] {
            "Сервер А",
            "Сервер Б"});
            this.comboBox_Server.Location = new System.Drawing.Point(65, 12);
            this.comboBox_Server.Name = "comboBox_Server";
            this.comboBox_Server.Size = new System.Drawing.Size(196, 21);
            this.comboBox_Server.TabIndex = 0;
            this.comboBox_Server.Tag = "0";
            this.comboBox_Server.SelectionChangeCommitted += new System.EventHandler(this.comboBox_Server_SelectionChangeCommitted);
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
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 376);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Название компании";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(274, 376);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Страна";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(435, 376);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "ФИО директора";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 422);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Телефон";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(200, 422);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Адрес";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(62, 469);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Реквизиты";
            // 
            // Form_Companies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 518);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_Server);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.button_Change);
            this.Controls.Add(this.button_Create);
            this.Controls.Add(this.comboBox_Country);
            this.Controls.Add(this.textBox_Bank_details);
            this.Controls.Add(this.textBox_Address);
            this.Controls.Add(this.textBox_Phone);
            this.Controls.Add(this.textBox_Head_full_name);
            this.Controls.Add(this.label_id);
            this.Controls.Add(this.textBox_Name);
            this.Controls.Add(this.dataGridView_Companies);
            this.Name = "Form_Companies";
            this.Text = "Редактирование компаний";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Companies_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Companies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Companies;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Label label_id;
        private System.Windows.Forms.TextBox textBox_Head_full_name;
        private System.Windows.Forms.TextBox textBox_Phone;
        private System.Windows.Forms.TextBox textBox_Address;
        private System.Windows.Forms.TextBox textBox_Bank_details;
        private System.Windows.Forms.ComboBox comboBox_Country;
        private System.Windows.Forms.Button button_Create;
        private System.Windows.Forms.Button button_Change;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.ComboBox comboBox_Server;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}