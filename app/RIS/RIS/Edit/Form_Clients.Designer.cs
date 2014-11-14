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
            this.button_Search = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Clients)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Clients
            // 
            this.dataGridView_Clients.AllowUserToAddRows = false;
            this.dataGridView_Clients.AllowUserToDeleteRows = false;
            this.dataGridView_Clients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Clients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Clients.Location = new System.Drawing.Point(12, 13);
            this.dataGridView_Clients.Name = "dataGridView_Clients";
            this.dataGridView_Clients.ReadOnly = true;
            this.dataGridView_Clients.Size = new System.Drawing.Size(1094, 365);
            this.dataGridView_Clients.TabIndex = 0;
            this.dataGridView_Clients.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_Clients_CellMouseDown);
            // 
            // label_id
            // 
            this.label_id.AutoSize = true;
            this.label_id.Location = new System.Drawing.Point(191, 400);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(0, 13);
            this.label_id.TabIndex = 1;
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(259, 397);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(171, 20);
            this.textBox_Name.TabIndex = 2;
            // 
            // textBox_Surname
            // 
            this.textBox_Surname.Location = new System.Drawing.Point(436, 397);
            this.textBox_Surname.Name = "textBox_Surname";
            this.textBox_Surname.Size = new System.Drawing.Size(171, 20);
            this.textBox_Surname.TabIndex = 3;
            // 
            // textBox_Patronymic
            // 
            this.textBox_Patronymic.Location = new System.Drawing.Point(613, 397);
            this.textBox_Patronymic.Name = "textBox_Patronymic";
            this.textBox_Patronymic.Size = new System.Drawing.Size(171, 20);
            this.textBox_Patronymic.TabIndex = 4;
            // 
            // textBox_Birthdate
            // 
            this.textBox_Birthdate.Location = new System.Drawing.Point(790, 397);
            this.textBox_Birthdate.Name = "textBox_Birthdate";
            this.textBox_Birthdate.Size = new System.Drawing.Size(171, 20);
            this.textBox_Birthdate.TabIndex = 5;
            // 
            // textBox_Phone
            // 
            this.textBox_Phone.Location = new System.Drawing.Point(259, 423);
            this.textBox_Phone.Name = "textBox_Phone";
            this.textBox_Phone.Size = new System.Drawing.Size(171, 20);
            this.textBox_Phone.TabIndex = 6;
            // 
            // textBox_Email
            // 
            this.textBox_Email.Location = new System.Drawing.Point(436, 423);
            this.textBox_Email.Name = "textBox_Email";
            this.textBox_Email.Size = new System.Drawing.Size(171, 20);
            this.textBox_Email.TabIndex = 7;
            // 
            // textBox_Address
            // 
            this.textBox_Address.Location = new System.Drawing.Point(613, 423);
            this.textBox_Address.Name = "textBox_Address";
            this.textBox_Address.Size = new System.Drawing.Size(348, 20);
            this.textBox_Address.TabIndex = 8;
            // 
            // textBox_Passport_series
            // 
            this.textBox_Passport_series.Location = new System.Drawing.Point(259, 449);
            this.textBox_Passport_series.Name = "textBox_Passport_series";
            this.textBox_Passport_series.Size = new System.Drawing.Size(171, 20);
            this.textBox_Passport_series.TabIndex = 9;
            // 
            // textBox_Passport_number
            // 
            this.textBox_Passport_number.Location = new System.Drawing.Point(436, 449);
            this.textBox_Passport_number.Name = "textBox_Passport_number";
            this.textBox_Passport_number.Size = new System.Drawing.Size(171, 20);
            this.textBox_Passport_number.TabIndex = 10;
            // 
            // textBox_Issue_date
            // 
            this.textBox_Issue_date.Location = new System.Drawing.Point(613, 449);
            this.textBox_Issue_date.Name = "textBox_Issue_date";
            this.textBox_Issue_date.Size = new System.Drawing.Size(171, 20);
            this.textBox_Issue_date.TabIndex = 11;
            // 
            // textBox_Issue_department
            // 
            this.textBox_Issue_department.Location = new System.Drawing.Point(790, 449);
            this.textBox_Issue_department.Name = "textBox_Issue_department";
            this.textBox_Issue_department.Size = new System.Drawing.Size(171, 20);
            this.textBox_Issue_department.TabIndex = 12;
            // 
            // button_Create
            // 
            this.button_Create.Location = new System.Drawing.Point(295, 475);
            this.button_Create.Name = "button_Create";
            this.button_Create.Size = new System.Drawing.Size(135, 23);
            this.button_Create.TabIndex = 13;
            this.button_Create.Text = "Создать";
            this.button_Create.UseVisualStyleBackColor = true;
            // 
            // button_Change
            // 
            this.button_Change.Location = new System.Drawing.Point(461, 475);
            this.button_Change.Name = "button_Change";
            this.button_Change.Size = new System.Drawing.Size(146, 23);
            this.button_Change.TabIndex = 14;
            this.button_Change.Text = "Изменить";
            this.button_Change.UseVisualStyleBackColor = true;
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(638, 475);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(146, 23);
            this.button_Delete.TabIndex = 15;
            this.button_Delete.Text = "Удалить";
            this.button_Delete.UseVisualStyleBackColor = true;
            // 
            // button_Search
            // 
            this.button_Search.Location = new System.Drawing.Point(1004, 421);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(75, 23);
            this.button_Search.TabIndex = 16;
            this.button_Search.Text = "Поиск";
            this.button_Search.UseVisualStyleBackColor = true;
            // 
            // Form_Clients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 529);
            this.Controls.Add(this.button_Search);
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
        private System.Windows.Forms.Button button_Search;
    }
}