namespace RIS
{
    partial class Form_Clients
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
            this.dataGridView_Clients = new System.Windows.Forms.DataGridView();
            this.label_id = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.textBox_Surname = new System.Windows.Forms.TextBox();
            this.textBox_Patronymic = new System.Windows.Forms.TextBox();
            this.textBox_Birthdate = new System.Windows.Forms.TextBox();
            this.textBox_Phone = new System.Windows.Forms.TextBox();
            this.textBox_Email = new System.Windows.Forms.TextBox();
            this.textBox_Address = new System.Windows.Forms.TextBox();
            this.textBox_Passport_series = new System.Windows.Forms.TextBox();
            this.textBox_Passport_number = new System.Windows.Forms.TextBox();
            this.textBox_Issue_date = new System.Windows.Forms.TextBox();
            this.textBox_Issue_department = new System.Windows.Forms.TextBox();
            this.button_Create = new System.Windows.Forms.Button();
            this.button_Change = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Clients)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Clients
            // 
            this.dataGridView_Clients.AllowUserToAddRows = false;
            this.dataGridView_Clients.AllowUserToDeleteRows = false;
            this.dataGridView_Clients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Clients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView_Clients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Clients.Location = new System.Drawing.Point(12, 13);
            this.dataGridView_Clients.MultiSelect = false;
            this.dataGridView_Clients.Name = "dataGridView_Clients";
            this.dataGridView_Clients.ReadOnly = true;
            this.dataGridView_Clients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Clients.Size = new System.Drawing.Size(1013, 386);
            this.dataGridView_Clients.TabIndex = 14;
            this.dataGridView_Clients.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_Clients_CellMouseDown);
            // 
            // label_id
            // 
            this.label_id.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label_id.AutoSize = true;
            this.label_id.Location = new System.Drawing.Point(22, 435);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(0, 13);
            this.label_id.TabIndex = 1;
            // 
            // textBox_Name
            // 
            this.textBox_Name.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox_Name.Location = new System.Drawing.Point(245, 432);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(171, 20);
            this.textBox_Name.TabIndex = 1;
            // 
            // textBox_Surname
            // 
            this.textBox_Surname.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox_Surname.Location = new System.Drawing.Point(68, 432);
            this.textBox_Surname.Name = "textBox_Surname";
            this.textBox_Surname.Size = new System.Drawing.Size(171, 20);
            this.textBox_Surname.TabIndex = 0;
            // 
            // textBox_Patronymic
            // 
            this.textBox_Patronymic.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox_Patronymic.Location = new System.Drawing.Point(422, 432);
            this.textBox_Patronymic.Name = "textBox_Patronymic";
            this.textBox_Patronymic.Size = new System.Drawing.Size(171, 20);
            this.textBox_Patronymic.TabIndex = 2;
            // 
            // textBox_Birthdate
            // 
            this.textBox_Birthdate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox_Birthdate.Location = new System.Drawing.Point(599, 432);
            this.textBox_Birthdate.Name = "textBox_Birthdate";
            this.textBox_Birthdate.Size = new System.Drawing.Size(171, 20);
            this.textBox_Birthdate.TabIndex = 3;
            // 
            // textBox_Phone
            // 
            this.textBox_Phone.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox_Phone.Location = new System.Drawing.Point(68, 480);
            this.textBox_Phone.Name = "textBox_Phone";
            this.textBox_Phone.Size = new System.Drawing.Size(171, 20);
            this.textBox_Phone.TabIndex = 4;
            // 
            // textBox_Email
            // 
            this.textBox_Email.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox_Email.Location = new System.Drawing.Point(245, 480);
            this.textBox_Email.Name = "textBox_Email";
            this.textBox_Email.Size = new System.Drawing.Size(171, 20);
            this.textBox_Email.TabIndex = 5;
            // 
            // textBox_Address
            // 
            this.textBox_Address.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox_Address.Location = new System.Drawing.Point(422, 480);
            this.textBox_Address.Name = "textBox_Address";
            this.textBox_Address.Size = new System.Drawing.Size(348, 20);
            this.textBox_Address.TabIndex = 6;
            // 
            // textBox_Passport_series
            // 
            this.textBox_Passport_series.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox_Passport_series.Location = new System.Drawing.Point(68, 525);
            this.textBox_Passport_series.Name = "textBox_Passport_series";
            this.textBox_Passport_series.Size = new System.Drawing.Size(171, 20);
            this.textBox_Passport_series.TabIndex = 7;
            // 
            // textBox_Passport_number
            // 
            this.textBox_Passport_number.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox_Passport_number.Location = new System.Drawing.Point(245, 525);
            this.textBox_Passport_number.Name = "textBox_Passport_number";
            this.textBox_Passport_number.Size = new System.Drawing.Size(171, 20);
            this.textBox_Passport_number.TabIndex = 8;
            // 
            // textBox_Issue_date
            // 
            this.textBox_Issue_date.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox_Issue_date.Location = new System.Drawing.Point(422, 525);
            this.textBox_Issue_date.Name = "textBox_Issue_date";
            this.textBox_Issue_date.Size = new System.Drawing.Size(171, 20);
            this.textBox_Issue_date.TabIndex = 9;
            // 
            // textBox_Issue_department
            // 
            this.textBox_Issue_department.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox_Issue_department.Location = new System.Drawing.Point(599, 525);
            this.textBox_Issue_department.Name = "textBox_Issue_department";
            this.textBox_Issue_department.Size = new System.Drawing.Size(171, 20);
            this.textBox_Issue_department.TabIndex = 10;
            // 
            // button_Create
            // 
            this.button_Create.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_Create.Location = new System.Drawing.Point(838, 430);
            this.button_Create.Name = "button_Create";
            this.button_Create.Size = new System.Drawing.Size(135, 23);
            this.button_Create.TabIndex = 11;
            this.button_Create.Text = "Создать";
            this.button_Create.UseVisualStyleBackColor = true;
            this.button_Create.Click += new System.EventHandler(this.button_Create_Click);
            // 
            // button_Change
            // 
            this.button_Change.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_Change.Location = new System.Drawing.Point(838, 478);
            this.button_Change.Name = "button_Change";
            this.button_Change.Size = new System.Drawing.Size(135, 23);
            this.button_Change.TabIndex = 12;
            this.button_Change.Text = "Изменить";
            this.button_Change.UseVisualStyleBackColor = true;
            this.button_Change.Click += new System.EventHandler(this.button_Change_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_Delete.Location = new System.Drawing.Point(838, 523);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(135, 23);
            this.button_Delete.TabIndex = 13;
            this.button_Delete.Text = "Удалить";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 416);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Фамилия";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(242, 416);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Имя";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(419, 416);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Отчество";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(596, 416);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Дата рождения";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 464);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Телефон";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(242, 464);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Емэйл";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(419, 464);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Адрес";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(65, 509);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Серия паспорта";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(242, 509);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Номер паспорта";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(419, 509);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Дата выдачи";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(596, 509);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Отделение выдачи";
            // 
            // Form_Clients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 564);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.button_Change);
            this.Controls.Add(this.button_Create);
            this.Controls.Add(this.textBox_Issue_department);
            this.Controls.Add(this.textBox_Issue_date);
            this.Controls.Add(this.textBox_Passport_number);
            this.Controls.Add(this.textBox_Passport_series);
            this.Controls.Add(this.textBox_Address);
            this.Controls.Add(this.textBox_Email);
            this.Controls.Add(this.textBox_Phone);
            this.Controls.Add(this.textBox_Birthdate);
            this.Controls.Add(this.textBox_Patronymic);
            this.Controls.Add(this.textBox_Surname);
            this.Controls.Add(this.textBox_Name);
            this.Controls.Add(this.label_id);
            this.Controls.Add(this.dataGridView_Clients);
            this.Name = "Form_Clients";
            this.Text = "Редактирование клиентов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Clients_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Clients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Clients;
        private System.Windows.Forms.Label label_id;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.TextBox textBox_Surname;
        private System.Windows.Forms.TextBox textBox_Patronymic;
        private System.Windows.Forms.TextBox textBox_Birthdate;
        private System.Windows.Forms.TextBox textBox_Phone;
        private System.Windows.Forms.TextBox textBox_Email;
        private System.Windows.Forms.TextBox textBox_Address;
        private System.Windows.Forms.TextBox textBox_Passport_series;
        private System.Windows.Forms.TextBox textBox_Passport_number;
        private System.Windows.Forms.TextBox textBox_Issue_date;
        private System.Windows.Forms.TextBox textBox_Issue_department;
        private System.Windows.Forms.Button button_Create;
        private System.Windows.Forms.Button button_Change;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}