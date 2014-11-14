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
using System.Diagnostics;

namespace RIS
{
    public partial class Form_Clients : Form
    {
        private string connStr;
        private NpgsqlConnection conn;

        public Form_Clients(string connStr)
        {
            InitializeComponent();
            this.connStr = connStr;
            this.conn = new NpgsqlConnection(connStr);
            try
            {
                conn.Open();
            }
            catch
            {
                MessageBox.Show("Something wrong with connection");
                this.Close();
            }
            dataGridView_Clients.AutoGenerateColumns = true;

            RefreshData();
            //dataGridView_Categories.Columns["id"].Visible = false;
            dataGridView_Clients.Columns["id"].HeaderText = "id";
            dataGridView_Clients.Columns["surname"].HeaderText = "Фамилия";
            dataGridView_Clients.Columns["name"].HeaderText = "Имя";
            dataGridView_Clients.Columns["patronymic"].HeaderText = "Отчество";
            dataGridView_Clients.Columns["birthdate"].HeaderText = "Дата рождения";
            dataGridView_Clients.Columns["phone"].HeaderText = "Номер телефона";
            dataGridView_Clients.Columns["email"].HeaderText = "Адрес электронной почты";
            dataGridView_Clients.Columns["address"].HeaderText = "Адрес доставки";
            dataGridView_Clients.Columns["passport_series"].HeaderText = "Серия паспорта";
            dataGridView_Clients.Columns["passport_number"].HeaderText = "Номер паспорта";
            dataGridView_Clients.Columns["issue_date"].HeaderText = "Дата выдачи паспорта";
            dataGridView_Clients.Columns["issue_department"].HeaderText = "Код подразделения, выдавшего паспорт";
        }

        private void RefreshData()
        {
            DataTable table = new DataTable();

            string query = "SELECT a.id, surname, name, patronymic, birthdate, " +
                            "phone, email, address, passport_series, passport_number, issue_date, issue_department " +
                            "FROM ( " +
                            "    SELECT id, phone, email, address FROM public.dblink ('dbname=risbd6 host=students.ami.nstu.ru port=5432 user=risbd6 password=ris14bd6', " +
                            "        'SELECT sa.clients.id, sa.clients.phone, sa.clients.email, sa.clients.address " +
                            "        FROM sa.clients' ) as cli (id integer, phone text, email text, address text) " +
                            "     ) a " +
                            "JOIN sb.clients on a.id = sb.clients.id";
            
            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            da.Fill(table);
            dataGridView_Clients.DataSource = table;
        }

        private void Form_Clients_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }

        private void dataGridView_Clients_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    int row = e.RowIndex;
                    int column = e.ColumnIndex;
                    DataGridViewCell clickedCell = (sender as DataGridView).Rows[row].Cells[column];
                    dataGridView_Clients.Rows[row].Selected = true;
                    label_id.Text = ((int)dataGridView_Clients["id", row].Value).ToString();

                    textBox_Surname.Text = (string)dataGridView_Clients["surname", row].Value;
                    textBox_Name.Text = (string)dataGridView_Clients["name", row].Value;
                    textBox_Patronymic.Text = (string)dataGridView_Clients["patronymic", row].Value;
                    textBox_Birthdate.Text = ((DateTime)dataGridView_Clients["birthdate", row].Value).ToShortDateString();
                    textBox_Phone.Text = (string)dataGridView_Clients["phone", row].Value;
                    textBox_Email.Text = (string)dataGridView_Clients["email", row].Value;
                    textBox_Address.Text = (string)dataGridView_Clients["address", row].Value;
                    textBox_Passport_series.Text = (string)dataGridView_Clients["passport_series", row].Value;
                    textBox_Passport_number.Text = (string)dataGridView_Clients["passport_number", row].Value;
                    textBox_Issue_date.Text = ((DateTime)dataGridView_Clients["issue_date", row].Value).ToShortDateString();
                    textBox_Issue_department.Text = (string)dataGridView_Clients["issue_department", row].Value;



                    //textBox_Title.Text = (string)dataGridView_Clients["title", row].Value;
                    //label_id.Text = ((int)dataGridView_Clients["id", row].Value).ToString();
                }
            }
        }
    
        
    
    
    
    }
}
