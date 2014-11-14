namespace RIS
{
    partial class Form_Countries
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
            this.dataGridView_Countries = new System.Windows.Forms.DataGridView();
            this.label_id = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.button_Create = new System.Windows.Forms.Button();
            this.button_Change = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.label_ServerB = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Countries)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Countries
            // 
            this.dataGridView_Countries.AllowUserToAddRows = false;
            this.dataGridView_Countries.AllowUserToDeleteRows = false;
            this.dataGridView_Countries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Countries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Countries.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_Countries.Name = "dataGridView_Countries";
            this.dataGridView_Countries.ReadOnly = true;
            this.dataGridView_Countries.Size = new System.Drawing.Size(383, 246);
            this.dataGridView_Countries.TabIndex = 0;
            this.dataGridView_Countries.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_Countries_CellMouseDown);
            // 
            // label_id
            // 
            this.label_id.AutoSize = true;
            this.label_id.Location = new System.Drawing.Point(90, 285);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(0, 13);
            this.label_id.TabIndex = 1;
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(142, 282);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(253, 20);
            this.textBox_Name.TabIndex = 2;
            // 
            // button_Create
            // 
            this.button_Create.Location = new System.Drawing.Point(142, 326);
            this.button_Create.Name = "button_Create";
            this.button_Create.Size = new System.Drawing.Size(75, 23);
            this.button_Create.TabIndex = 3;
            this.button_Create.Text = "Создать";
            this.button_Create.UseVisualStyleBackColor = true;
            this.button_Create.Click += new System.EventHandler(this.button_Create_Click);
            // 
            // button_Change
            // 
            this.button_Change.Location = new System.Drawing.Point(232, 326);
            this.button_Change.Name = "button_Change";
            this.button_Change.Size = new System.Drawing.Size(75, 23);
            this.button_Change.TabIndex = 4;
            this.button_Change.Text = "Изменить";
            this.button_Change.UseVisualStyleBackColor = true;
            this.button_Change.Click += new System.EventHandler(this.button_Change_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Enabled = false;
            this.button_Delete.Location = new System.Drawing.Point(320, 326);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(75, 23);
            this.button_Delete.TabIndex = 5;
            this.button_Delete.Text = "Удалить";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // label_ServerB
            // 
            this.label_ServerB.AutoSize = true;
            this.label_ServerB.Location = new System.Drawing.Point(41, 331);
            this.label_ServerB.Name = "label_ServerB";
            this.label_ServerB.Size = new System.Drawing.Size(49, 13);
            this.label_ServerB.TabIndex = 6;
            this.label_ServerB.Text = "label_RF";
            // 
            // Form_Countries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 372);
            this.Controls.Add(this.label_ServerB);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.button_Change);
            this.Controls.Add(this.button_Create);
            this.Controls.Add(this.textBox_Name);
            this.Controls.Add(this.label_id);
            this.Controls.Add(this.dataGridView_Countries);
            this.Name = "Form_Countries";
            this.Text = "Редактирование стран";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Countries_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Countries)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Countries;
        private System.Windows.Forms.Label label_id;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Button button_Create;
        private System.Windows.Forms.Button button_Change;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Label label_ServerB;
    }
}