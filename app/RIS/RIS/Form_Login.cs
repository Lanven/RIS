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
        Form_Main mainForm;
        public Form_Login(Form_Main mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void button_LogIn_Click(object sender, EventArgs e)
        {
            string login = textBox_Login.Text;
            string password = textBox_Password.Text;
            int serv = comboBox_Server.SelectedIndex;
            string server;
            switch (serv)
            {
                case 0:
                    server = "students.ami.nstu.ru";
                    break;
                case 1:
                    server = "127.0.0.1";
                    break;
                default:
                    comboBox_Server.BackColor = Color.Crimson;
                    return;
            }
            string connString;
            connString = "Server=" + server + ";Database=risbd6;User Id=" + login + ";Password=" + password + ";";
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(connString);
                conn.Open();
                mainForm.conn = conn;
                mainForm.serv = serv;
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Smth has gone wrong!");
            }
        }
    }
}
