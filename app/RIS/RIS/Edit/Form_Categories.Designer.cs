﻿namespace RIS
{
    partial class Form_Categories
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
            this.dataGridView_Categories = new System.Windows.Forms.DataGridView();
            this.label_id = new System.Windows.Forms.Label();
            this.textBox_Title = new System.Windows.Forms.TextBox();
            this.button_Create = new System.Windows.Forms.Button();
            this.button_Change = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Categories)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Categories
            // 
            this.dataGridView_Categories.AllowUserToAddRows = false;
            this.dataGridView_Categories.AllowUserToDeleteRows = false;
            this.dataGridView_Categories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Categories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Categories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Categories.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_Categories.MultiSelect = false;
            this.dataGridView_Categories.Name = "dataGridView_Categories";
            this.dataGridView_Categories.ReadOnly = true;
            this.dataGridView_Categories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Categories.Size = new System.Drawing.Size(416, 270);
            this.dataGridView_Categories.TabIndex = 0;
            this.dataGridView_Categories.Tag = "4";
            this.dataGridView_Categories.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_Categories_CellMouseDown);
            // 
            // label_id
            // 
            this.label_id.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label_id.AutoSize = true;
            this.label_id.Location = new System.Drawing.Point(37, 322);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(0, 13);
            this.label_id.TabIndex = 1;
            // 
            // textBox_Title
            // 
            this.textBox_Title.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox_Title.Location = new System.Drawing.Point(68, 319);
            this.textBox_Title.Name = "textBox_Title";
            this.textBox_Title.Size = new System.Drawing.Size(298, 20);
            this.textBox_Title.TabIndex = 2;
            this.textBox_Title.Tag = "0";
            // 
            // button_Create
            // 
            this.button_Create.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_Create.Location = new System.Drawing.Point(68, 345);
            this.button_Create.Name = "button_Create";
            this.button_Create.Size = new System.Drawing.Size(75, 23);
            this.button_Create.TabIndex = 3;
            this.button_Create.Tag = "1";
            this.button_Create.Text = "Создать";
            this.button_Create.UseVisualStyleBackColor = true;
            this.button_Create.Click += new System.EventHandler(this.button_Create_Click);
            // 
            // button_Change
            // 
            this.button_Change.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_Change.Location = new System.Drawing.Point(182, 345);
            this.button_Change.Name = "button_Change";
            this.button_Change.Size = new System.Drawing.Size(75, 23);
            this.button_Change.TabIndex = 4;
            this.button_Change.Tag = "2";
            this.button_Change.Text = "Изменить";
            this.button_Change.UseVisualStyleBackColor = true;
            this.button_Change.Click += new System.EventHandler(this.button_Change_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_Delete.Location = new System.Drawing.Point(291, 345);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(75, 23);
            this.button_Delete.TabIndex = 5;
            this.button_Delete.Tag = "3";
            this.button_Delete.Text = "Удалить";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 303);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Название категории";
            // 
            // Form_Categories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 382);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.button_Change);
            this.Controls.Add(this.button_Create);
            this.Controls.Add(this.textBox_Title);
            this.Controls.Add(this.label_id);
            this.Controls.Add(this.dataGridView_Categories);
            this.Name = "Form_Categories";
            this.Text = "Редактирование категорий";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Categories_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Categories)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Categories;
        private System.Windows.Forms.Label label_id;
        private System.Windows.Forms.TextBox textBox_Title;
        private System.Windows.Forms.Button button_Create;
        private System.Windows.Forms.Button button_Change;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Label label1;
    }
}