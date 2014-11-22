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
        //поля для данных, получаемых в главной форме
        public string server { get; set; }
        public int servId { get; set; }
        public string login { get; set; }
        //public string database { get; set; }
        public string connStr { get; set; }

        //инициализация формы
        public Form_Login()
        {
            InitializeComponent();
            comboBox_Server.SelectedIndex = 1;//поставить сервер по умолчанию
        }
        //кнопка Войти
        private void button_LogIn_Click(object sender, EventArgs e)
        {
            //Получение логина, пароля, выбранного сервера
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
                    return;
            }
            //составление строки подключения
            this.connStr = "Server=" + server + ";Database=risbd6;User Id=" + login + ";Password=" + password + ";";
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            //попытка подключения к базе с введенными данными
            //если получилось - закрываемся
            //данные можно будет получить из главной формы
            try
            {
                conn.Open();
                this.DialogResult = DialogResult.OK;
                conn.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                string error = "";
                if (ex.Source == "Npgsql")
                    if (((NpgsqlException)ex).Code == "28000" || ((NpgsqlException)ex).Code == "28P01")
                        error = "Неверный логин/пароль";
                    else
                        error = ex.Message;
                MessageBox.Show(error);
            }
        }
    }
}
