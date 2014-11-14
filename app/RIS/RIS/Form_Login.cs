using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace RIS
{
    public partial class Form_Login : Form
    {
        public string server { get; set; }
        public int servId { get; set; }
        public string login { get; set; }
        //public string database { get; set; }
        public string connStr { get; set; }

        public Form_Login()
        {
            InitializeComponent();
        }

        private void button_LogIn_Click(object sender, EventArgs e)
        {
            this.login = textBox_Login.Text;
            string password = textBox_Password.Text;
            int serv = comboBox_Server.SelectedIndex;
            switch (serv)
            {
                case 0:
                    this.servId = 0;
                    this.server = "students.ami.nstu.ru";
                    break;
                case 1:
                    this.servId = 1;
                    this.server = "127.0.0.1";
                    break;
                default:
                    comboBox_Server.BackColor = Color.Crimson;
                    return;
            }
            this.connStr = "Server=" + server + ";Database=risbd6;User Id=" + login + ";Password=" + password + ";";
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(connStr);
                conn.Open();
                this.DialogResult = DialogResult.OK;
                conn.Close();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Неверный логин/пароль.");
            }
        }
    }
}
