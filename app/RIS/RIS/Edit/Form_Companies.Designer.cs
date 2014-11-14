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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Companies)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Companies
            // 
            this.dataGridView_Companies.AllowUserToAddRows = false;
            this.dataGridView_Companies.AllowUserToDeleteRows = false;
            this.dataGridView_Companies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Companies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Companies.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_Companies.Name = "dataGridView_Companies";
            this.dataGridView_Companies.ReadOnly = true;
            this.dataGridView_Companies.Size = new System.Drawing.Size(965, 339);
            this.dataGridView_Companies.TabIndex = 0;
            this.dataGridView_Companies.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_Companies_CellMouseDown);
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(279, 374);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(206, 20);
            this.textBox_Name.TabIndex = 1;
            // 
            // label_id
            // 
            this.label_id.AutoSize = true;
            this.label_id.Location = new System.Drawing.Point(230, 377);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(0, 13);
            this.label_id.TabIndex = 2;
            // 
            // textBox_Head_full_name
            // 
            this.textBox_Head_full_name.Location = new System.Drawing.Point(279, 400);
            this.textBox_Head_full_name.Name = "textBox_Head_full_name";
            this.textBox_Head_full_name.Size = new System.Drawing.Size(206, 20);
            this.textBox_Head_full_name.TabIndex = 3;
            // 
            // textBox_Phone
            // 
            this.textBox_Phone.Location = new System.Drawing.Point(279, 426);
            this.textBox_Phone.Name = "textBox_Phone";
            this.textBox_Phone.Size = new System.Drawing.Size(132, 20);
            this.textBox_Phone.TabIndex = 4;
            // 
            // textBox_Address
            // 
            this.textBox_Address.Location = new System.Drawing.Point(417, 426);
            this.textBox_Address.Name = "textBox_Address";
            this.textBox_Address.Size = new System.Drawing.Size(229, 20);
            this.textBox_Address.TabIndex = 5;
            // 
            // textBox_Bank_details
            // 
            this.textBox_Bank_details.Location = new System.Drawing.Point(279, 452);
            this.textBox_Bank_details.Name = "textBox_Bank_details";
            this.textBox_Bank_details.Size = new System.Drawing.Size(367, 20);
            this.textBox_Bank_details.TabIndex = 6;
            // 
            // comboBox_Country
            // 
            this.comboBox_Country.FormattingEnabled = true;
            this.comboBox_Country.Location = new System.Drawing.Point(491, 373);
            this.comboBox_Country.Name = "comboBox_Country";
            this.comboBox_Country.Size = new System.Drawing.Size(155, 21);
            this.comboBox_Country.TabIndex = 7;
            // 
            // button_Create
            // 
            this.button_Create.Location = new System.Drawing.Point(307, 478);
            this.button_Create.Name = "button_Create";
            this.button_Create.Size = new System.Drawing.Size(75, 23);
            this.button_Create.TabIndex = 8;
            this.button_Create.Text = "Создать";
            this.button_Create.UseVisualStyleBackColor = true;
            // 
            // button_Change
            // 
            this.button_Change.Location = new System.Drawing.Point(427, 478);
            this.button_Change.Name = "button_Change";
            this.button_Change.Size = new System.Drawing.Size(75, 23);
            this.button_Change.TabIndex = 9;
            this.button_Change.Text = "Изменить";
            this.button_Change.UseVisualStyleBackColor = true;
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(542, 478);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(75, 23);
            this.button_Delete.TabIndex = 10;
            this.button_Delete.Text = "Удалить";
            this.button_Delete.UseVisualStyleBackColor = true;
            // 
            // Form_Companies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 518);
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
    }
}