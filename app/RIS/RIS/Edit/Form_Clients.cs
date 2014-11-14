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


        private bool IsEveryFieldCorrect()
        {
            string surname = textBox_Surname.Text;
            string name = textBox_Name.Text;
            string patronymic = textBox_Patronymic.Text;

            //string phone = textBox_Phone.Text;
            //string email = textBox_Email.Text;
            //string address = textBox_Address.Text;

            string passport_series = textBox_Passport_series.Text;
            string passport_number = textBox_Passport_number.Text;

            string issue_date_str = textBox_Issue_date.Text;
            //string issue_department = textBox_Issue_department.Text;

            string birthdate_str = textBox_Birthdate.Text;

            if (surname == "")
            {
                MessageBox.Show("Введите фамилию");
                return false;
            }
            if (name == "")
            {
                MessageBox.Show("Введите имя");
                return false;
            }
            if (patronymic == "")
            {
                MessageBox.Show("Введите отчество");
                return false;
            }
            if (birthdate_str == "")
            {
                MessageBox.Show("Введите дату рождения");
                return false;
            }
            DateTime birthdate;
            if (!DateTime.TryParse(birthdate_str, out birthdate))
            {
                MessageBox.Show("Неверная дата рождения");
                return false;
            }
            if (passport_series == "")
            {
                MessageBox.Show("Введите серию паспорта");
                return false;
            }
            if (passport_number == "")
            {
                MessageBox.Show("Введите номер паспорта");
                return false;
            }
            DateTime issue_date;
            if (issue_date_str != "")
                if (!DateTime.TryParse(issue_date_str, out issue_date))
                {
                    MessageBox.Show("Неверная дата выдачи");
                    return false;
                }
            
            return true;
        }

        private void button_Create_Click(object sender, EventArgs e)
        {
            if (!IsEveryFieldCorrect())
            {
                return;
            }

            string surname = textBox_Surname.Text;
            string name = textBox_Name.Text;
            string patronymic = textBox_Patronymic.Text;

            string phone = textBox_Phone.Text;
            string email = textBox_Email.Text;
            string address = textBox_Address.Text;

            string passport_series = textBox_Passport_series.Text;
            string passport_number = textBox_Passport_number.Text;

            string issue_date_str = textBox_Issue_date.Text;
            DateTime issue_date = DateTime.Parse(issue_date_str);
            string issue_department = textBox_Issue_department.Text;

            string birthdate_str = textBox_Birthdate.Text;
            DateTime birthdate = DateTime.Parse(birthdate_str);
            
            string tmp = "select count(*) from sb.clients a where a.passport_series LIKE :passport_series AND a.passport_number LIKE :passport_number";
            NpgsqlCommand tmpcmd = new NpgsqlCommand(tmp, conn);
            tmpcmd.Parameters.Add("passport_series", NpgsqlTypes.NpgsqlDbType.Text).Value = passport_series;
            tmpcmd.Parameters.Add("passport_number", NpgsqlTypes.NpgsqlDbType.Text).Value = passport_number;

            if ((long)tmpcmd.ExecuteScalar() == 0)
            {
                try
                {
                    var cmdData = new Npgsql.NpgsqlCommand("func_clients_on_insert", conn);
                    cmdData.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdData.Parameters.Add("surname", NpgsqlTypes.NpgsqlDbType.Text).Value = surname;
                    cmdData.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Text).Value = name;
                    cmdData.Parameters.Add("patronymic", NpgsqlTypes.NpgsqlDbType.Text).Value = patronymic;
                    cmdData.Parameters.Add("birthdate", NpgsqlTypes.NpgsqlDbType.Date).Value = birthdate;
                    cmdData.Parameters.Add("phone", NpgsqlTypes.NpgsqlDbType.Text).Value = phone;
                    cmdData.Parameters.Add("email", NpgsqlTypes.NpgsqlDbType.Text).Value = email;
                    cmdData.Parameters.Add("address", NpgsqlTypes.NpgsqlDbType.Text).Value = address;
                    cmdData.Parameters.Add("passport_series", NpgsqlTypes.NpgsqlDbType.Text).Value = passport_series;
                    cmdData.Parameters.Add("passport_number", NpgsqlTypes.NpgsqlDbType.Text).Value = passport_number;
                    cmdData.Parameters.Add("issue_date", NpgsqlTypes.NpgsqlDbType.Date).Value = issue_date;
                    cmdData.Parameters.Add("issue_department", NpgsqlTypes.NpgsqlDbType.Text).Value = issue_department;
                    
                    cmdData.ExecuteNonQuery();
                    MessageBox.Show("Клиент создан");
                    RefreshData();
                }
                catch
                {
                    MessageBox.Show("Smth wrong on client insert");
                }
            }
            else
            {
                MessageBox.Show("Клиент с такими паспортными данными уже существует");
            }
        }

        private void button_Change_Click(object sender, EventArgs e)
        {
            if (label_id.Text == "")
            {
                MessageBox.Show("Выберите клиента");
                return;
            }
            if (!IsEveryFieldCorrect())
            {
                return;
            }

            string surname = textBox_Surname.Text;
            string name = textBox_Name.Text;
            string patronymic = textBox_Patronymic.Text;

            string phone = textBox_Phone.Text;
            string email = textBox_Email.Text;
            string address = textBox_Address.Text;

            string passport_series = textBox_Passport_series.Text;
            string passport_number = textBox_Passport_number.Text;

            string issue_date_str = textBox_Issue_date.Text;
            DateTime issue_date = DateTime.Parse(issue_date_str);
            string issue_department = textBox_Issue_department.Text;

            string birthdate_str = textBox_Birthdate.Text;
            DateTime birthdate = DateTime.Parse(birthdate_str);

            int client_id = Convert.ToInt32(label_id.Text);

            string tmp = "select count(*) from sb.clients a where a.passport_series LIKE :passport_series AND a.passport_number LIKE :passport_number AND a.id <> :id";
            NpgsqlCommand tmpcmd = new NpgsqlCommand(tmp, conn);
            tmpcmd.Parameters.Add("passport_series", NpgsqlTypes.NpgsqlDbType.Text).Value = passport_series;
            tmpcmd.Parameters.Add("passport_number", NpgsqlTypes.NpgsqlDbType.Text).Value = passport_number;
            tmpcmd.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = client_id;

            if ((long)tmpcmd.ExecuteScalar() == 0)
            {
                try
                {
                    var cmdData = new Npgsql.NpgsqlCommand("func_clients_on_update", conn);
                    cmdData.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdData.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = client_id;
                    cmdData.Parameters.Add("surname", NpgsqlTypes.NpgsqlDbType.Text).Value = surname;
                    cmdData.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Text).Value = name;
                    cmdData.Parameters.Add("patronymic", NpgsqlTypes.NpgsqlDbType.Text).Value = patronymic;
                    cmdData.Parameters.Add("birthdate", NpgsqlTypes.NpgsqlDbType.Date).Value = birthdate;
                    cmdData.Parameters.Add("phone", NpgsqlTypes.NpgsqlDbType.Text).Value = phone;
                    cmdData.Parameters.Add("email", NpgsqlTypes.NpgsqlDbType.Text).Value = email;
                    cmdData.Parameters.Add("address", NpgsqlTypes.NpgsqlDbType.Text).Value = address;
                    cmdData.Parameters.Add("passport_series", NpgsqlTypes.NpgsqlDbType.Text).Value = passport_series;
                    cmdData.Parameters.Add("passport_number", NpgsqlTypes.NpgsqlDbType.Text).Value = passport_number;
                    cmdData.Parameters.Add("issue_date", NpgsqlTypes.NpgsqlDbType.Date).Value = issue_date;
                    cmdData.Parameters.Add("issue_department", NpgsqlTypes.NpgsqlDbType.Text).Value = issue_department;
                    cmdData.ExecuteNonQuery();
                    MessageBox.Show("Клиент изменен");
                    RefreshData();
                }
                catch
                {
                    MessageBox.Show("Smth wrong on client update");
                }
            }
            else
            {
                MessageBox.Show("Клиент с такими данными уже существует");
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (label_id.Text == "")
            {
                MessageBox.Show("Выберите клиента");
                return;
            }
            if (MessageBox.Show("Действительно удалить клиента (удалятся все связанные данные!)?",
                                    "Danger!",
                                    MessageBoxButtons.YesNo)
                                    == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            int client_id = Convert.ToInt32(label_id.Text);

            try
            {
                var cmdData = new Npgsql.NpgsqlCommand("func_clients_on_delete", conn);
                cmdData.CommandType = System.Data.CommandType.StoredProcedure;
                cmdData.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = client_id;
                cmdData.ExecuteNonQuery();
                MessageBox.Show("Клиент удален");
                RefreshData();
            }
            catch
            {
                MessageBox.Show("Smth wrong on client delete");
            }
        }
    
    
    }
}
