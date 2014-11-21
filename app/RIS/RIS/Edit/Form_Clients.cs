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
        private DataTable table;
        private string queryName = "get_all_clients";
        private string funcCreate = "func_clients_on_insert";
        private string funcChange = "func_clients_on_update";
        private string funcDelete = "func_clients_on_delete";
        List<TableColumn> columns = new List<TableColumn> {new TableColumn("id", "int", "id"),
                                                            new TableColumn("surname", "text", "Фамилия"),
                                                            new TableColumn("name", "text", "Имя"),
                                                            new TableColumn("patronymic", "text", "Отчество"),
                                                            new TableColumn("birthdate", "date", "Дата рождения"),
                                                            new TableColumn("phone", "text", "Номер телефона"),
                                                            new TableColumn("email", "text", "Адрес электронной почты"),
                                                            new TableColumn("address", "text", "Адрес доставки"),
                                                            new TableColumn("passport_series", "text", "Серия паспорта"),
                                                            new TableColumn("passport_number", "text", "Номер паспорта"),
                                                            new TableColumn("issue_date", "date", "Дата выдачи паспорта"),
                                                            new TableColumn("issue_department", "text", "Код подразделения, выдавшего паспорт")};


        public Form_Clients(string connStr)
        {
            InitializeComponent();
            this.connStr = connStr;
            this.conn = new NpgsqlConnection(connStr);
            this.table = new DataTable();

            try
            {
                Class_Helper.SetColumns(table, dataGridView_Clients, columns);
            }
            catch (Exception ex)
            {
                throw new Exception("Can't init datagrid: " + ex.Message);
            }

            //dataGridView_Categories.Columns["id"].Visible = false;
        }

        private void RefreshData()
        {
            string result = "";
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                result = Class_Helper.ExecuteStoredQuery(conn, queryName, table);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;
            }
            Cursor.Current = Cursors.Default;
            toolStripStatusLabel.Text = result;
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


            if (!Class_Helper.IsCorrect_String(surname))
            {
                MessageBox.Show("Неверная фамилия");
                return false;
            }
            if (!Class_Helper.IsCorrect_String(name))
            {
                MessageBox.Show("Неверное имя");
                return false;
            }
            if (!Class_Helper.IsCorrect_String(patronymic))
            {
                MessageBox.Show("Неверное отчество");
                return false;
            }
            if (!Class_Helper.IsCorrect_Date(birthdate_str))
            {
                MessageBox.Show("Неверная дата рождения");
                return false;
            }
            if (!Class_Helper.IsCorrect_String(passport_series))
            {
                MessageBox.Show("Неверная серия паспорта");
                return false;
            }
            if (!Class_Helper.IsCorrect_String(passport_number))
            {
                MessageBox.Show("Неверный номер паспорта");
                return false;
            }
            if (!Class_Helper.IsCorrect_Date(issue_date_str))
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

            Cursor.Current = Cursors.WaitCursor;

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
            
            List<Parameter> parameters = new List<Parameter> { new Parameter("surname", "text", surname),
                                                                new Parameter("name", "text", name),
                                                                new Parameter("patronymic", "text", patronymic),
                                                                new Parameter("birthdate", "date", birthdate),
                                                                new Parameter("phone", "text", phone),
                                                                new Parameter("email", "text", email),
                                                                new Parameter("address", "text", address),
                                                                new Parameter("passport_series", "text", passport_series),
                                                                new Parameter("passport_number", "text", passport_number),
                                                                new Parameter("issue_date", "date", issue_date),
                                                                new Parameter("issue_department", "text", issue_department)};

            string result = "";
            try
            {
                result = Class_Helper.ExecuteFunction(conn, funcCreate, parameters);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                string error = "";
                if (ex.Source == "Npgsql")
                    if (((NpgsqlException)ex).Code == "P0001")
                        error = "Клиент уже существует";
                    else
                        error = "Smth wrong on client insert";
                MessageBox.Show(error);
                return;
            }
            Cursor.Current = Cursors.Default;
            toolStripStatusLabel.Text = "Клиент создан. " + result;
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
            Cursor.Current = Cursors.WaitCursor;

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

            List<Parameter> parameters = new List<Parameter> { new Parameter("id", "int", client_id),
                                                                new Parameter("surname", "text", surname),
                                                                new Parameter("name", "text", name),
                                                                new Parameter("patronymic", "text", patronymic),
                                                                new Parameter("birthdate", "date", birthdate),
                                                                new Parameter("phone", "text", phone),
                                                                new Parameter("email", "text", email),
                                                                new Parameter("address", "text", address),
                                                                new Parameter("passport_series", "text", passport_series),
                                                                new Parameter("passport_number", "text", passport_number),
                                                                new Parameter("issue_date", "date", issue_date),
                                                                new Parameter("issue_department", "text", issue_department)};

            string result = "";
            try
            {
                result = Class_Helper.ExecuteFunction(conn, funcChange, parameters);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                string error = "";
                if (ex.Source == "Npgsql")
                    if (((NpgsqlException)ex).Code == "P0001")
                        error = "Клиент уже существует";
                    else
                        error = "Smth wrong on client update";
                MessageBox.Show(error);
                return;
            }
            Cursor.Current = Cursors.Default;
            toolStripStatusLabel.Text = "Клиент изменен. " + result;
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

            Cursor.Current = Cursors.WaitCursor;

            int client_id = Convert.ToInt32(label_id.Text);

            List<Parameter> parameters = new List<Parameter> { new Parameter("id", "int", client_id) };
            string result = "";
            try
            {
                result = Class_Helper.ExecuteFunction(conn, funcDelete, parameters);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                string error = "";
                //if (ex.Source == "Npgsql")
                //    if (((NpgsqlException)ex).Code == "P0001")
                //        error = "Категория уже существует";
                //    else
                error = "Smth wrong on client delete";
                MessageBox.Show(error);
                return;
            }
            Cursor.Current = Cursors.Default;
            toolStripStatusLabel.Text = "Клиент удален. " + result;
        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
    
    
    }
}
