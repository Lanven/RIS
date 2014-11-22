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
    public partial class Form_Companies : Form
    {
        private string connStr;//строка подключения
        private NpgsqlConnection conn;//подключение
        //запросы на созданение, изменение, удаление
        private string funcCreate = "func_companies_on_insert";
        private string funcChange = "func_companies_on_update";
        private string funcDelete = "func_companies_on_delete";
        //запрос на получение данных в зависимости от сервера
        private string queryName = "get_companies_by_server";
        //таблица и колонки для грида
        private DataTable tableCompanies;
        List<TableColumn> columns = new List<TableColumn> {new TableColumn("id", "int", "id"),
                                                            new TableColumn("name", "text", "Название"),
                                                            new TableColumn("country", "text", "Страна"),
                                                            new TableColumn("country_id", "int", "country_id"),
                                                            new TableColumn("head_full_name", "text", "ФИО директора"),
                                                            new TableColumn("phone", "text", "Номер телефона"),
                                                            new TableColumn("address", "text", "Юридический адрес компании"),
                                                            new TableColumn("bank_details", "text", "Банковские реквизиты компании")};
        //запрос на получение данных в зависимости от сервера
        private string queryCountries = "get_list_countries_by_server";
        //таблица и колонки для комбобокса
        private DataTable tableCountries;
        List<TableColumn> members = new List<TableColumn> {new TableColumn("name", "text", "Название"),
                                                           new TableColumn("id", "int", "ИД")};
        //создание формы
        public Form_Companies(string connStr)
        {
            InitializeComponent();
            comboBox_Server.SelectedIndex = 0;

            this.connStr = connStr;
            this.conn = new NpgsqlConnection(connStr);
            //инициализация грида
            this.tableCompanies = new System.Data.DataTable();
            this.tableCountries = new System.Data.DataTable();

            try
            {
                Class_Helper.SetColumns(tableCompanies, dataGridView_Companies, columns);
                Class_Helper.SetMember(tableCountries, comboBox_Country, members, "name", "id");
            }
            catch (Exception ex)
            {
                throw new Exception("Can't init datagrid/combobox: " + ex.Message);
            }
            //задать отображаемые колнки в гриде
            //dataGridView_Categories.Columns["id"].Visible = false;
            dataGridView_Companies.Columns["country_id"].Visible = false;
        }
        //получить список стран
        private void GetCountries()
        {
            Cursor.Current = Cursors.WaitCursor;
            int server_id = comboBox_Server.SelectedIndex;
            List<Parameter> parameters = new List<Parameter> { new Parameter("id", "int", server_id) };
            string result = "";
            try
            {
                result = Class_Helper.ExecuteStoredQuery(conn, queryCountries, tableCountries, parameters);
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
        //Обновить отображаемые данные
        private void RefreshData()
        {
            string result = "";
            Cursor.Current = Cursors.WaitCursor;
            int server_id = comboBox_Server.SelectedIndex;
            List<Parameter> parameters = new List<Parameter> { new Parameter("id", "int", server_id) };

            try
            {
                result = Class_Helper.ExecuteStoredQuery(conn, queryName, tableCompanies, parameters);
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
        //щелчок по гриду - получение координат выбранной ячейки и перенос данных в поля
        private void dataGridView_Companies_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    int row = e.RowIndex;
                    int column = e.ColumnIndex;
                    DataGridViewCell clickedCell = (sender as DataGridView).Rows[row].Cells[column];
                    dataGridView_Companies.Rows[row].Selected = true;
                    label_id.Text = ((int)dataGridView_Companies["id", row].Value).ToString();

                    textBox_Name.Text = (string)dataGridView_Companies["name", row].Value;
                    textBox_Head_full_name.Text = (string)dataGridView_Companies["head_full_name", row].Value;
                    textBox_Phone.Text = (string)dataGridView_Companies["phone", row].Value;
                    textBox_Address.Text = (string)dataGridView_Companies["address", row].Value;
                    textBox_Bank_details.Text = (string)dataGridView_Companies["bank_details", row].Value;
                    comboBox_Country.SelectedValue = (int)dataGridView_Companies["country_id", row].Value;
                }
            }

        }
        //проверка введенных данных на корректность
        private bool IsEveryFieldCorrect()
        {
            string name = textBox_Name.Text;
            //string head_full_name = textBox_Head_full_name.Text;
            //string phone = textBox_Phone.Text;
            //string address = textBox_Address.Text;
            //string bank_details = textBox_Bank_details.Text;
            //int country_id = (int)comboBox_Country.SelectedValue;

            if (!Class_Helper.IsCorrect_String(name))
            {
                MessageBox.Show("Неверное название компании");
                return false;
            }
            if (comboBox_Country.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите страну");
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
            string name = textBox_Name.Text;
            string head_full_name = textBox_Head_full_name.Text;
            string phone = textBox_Phone.Text;
            string address = textBox_Address.Text;
            string bank_details = textBox_Bank_details.Text;
            int country_id = (int)comboBox_Country.SelectedValue;

            List<Parameter> parameters = new List<Parameter> { new Parameter("name", "text", name),
                                                                new Parameter("country_id", "int", country_id),
                                                                new Parameter("head_full_name", "text", head_full_name),
                                                                new Parameter("phone", "text", phone),
                                                                new Parameter("address", "text", address),
                                                                new Parameter("bank_details", "text", bank_details)};

            string result = "";
            try
            {
                result = Class_Helper.ExecuteFunction(conn, funcCreate, parameters);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                string error = "";
                //if (ex.Source == "Npgsql")
                //    if (((NpgsqlException)ex).Code == "P0001")
                //        error = "Категория уже существует";
                //    else
                error = "Smth wrong on company insert";
                MessageBox.Show(error);
                return;
            }
            Cursor.Current = Cursors.Default;
            toolStripStatusLabel.Text = "Компания создана. " + result;

        }

        private void button_Change_Click(object sender, EventArgs e)
        {
            if (label_id.Text == "")
            {
                MessageBox.Show("Выберите компанию");
                return;
            }
            if (!IsEveryFieldCorrect())
            {
                return;
            }
            Cursor.Current = Cursors.WaitCursor;

            int company_id = Convert.ToInt32(label_id.Text);
            string name = textBox_Name.Text;
            string head_full_name = textBox_Head_full_name.Text;
            string phone = textBox_Phone.Text;
            string address = textBox_Address.Text;
            string bank_details = textBox_Bank_details.Text;
            int country_id = (int)comboBox_Country.SelectedValue;

            List<Parameter> parameters = new List<Parameter> { new Parameter("id", "int", company_id),
                                                                new Parameter("name", "text", name),
                                                                new Parameter("country_id", "int", country_id),
                                                                new Parameter("head_full_name", "text", head_full_name),
                                                                new Parameter("phone", "text", phone),
                                                                new Parameter("address", "text", address),
                                                                new Parameter("bank_details", "text", bank_details)};
            string result = "";
            try
            {
                result = Class_Helper.ExecuteFunction(conn, funcChange, parameters);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                string error = "";
                //if (ex.Source == "Npgsql")
                //    if (((NpgsqlException)ex).Code == "P0001")
                //        error = "Категория уже существует";
                //    else
                error = "Smth wrong on company update";
                MessageBox.Show(error);
                return;
            }
            Cursor.Current = Cursors.Default;
            toolStripStatusLabel.Text = "Компания изменена. " + result;

        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (label_id.Text == "")
            {
                MessageBox.Show("Выберите компанию");
                return;
            }
            if (MessageBox.Show("Действительно удалить компанию (удалятся все связанные данные!)?",
                                    "Danger!",
                                    MessageBoxButtons.YesNo)
                                    == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            int country_id = Convert.ToInt32(label_id.Text);

            List<Parameter> parameters = new List<Parameter> { new Parameter("id", "int", country_id) };
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
                error = "Smth wrong on company delete";
                MessageBox.Show(error);
                return;
            }
            Cursor.Current = Cursors.Default;
            toolStripStatusLabel.Text = "Компания удалена. " + result;

        }
        //кнопка Обновить
        private void button_Refresh_Click(object sender, EventArgs e)
        {
            GetCountries();
            RefreshData();
        }
        //перед первым показом формы 
        private void Form_Companies_Shown(object sender, EventArgs e)
        {
            //получить список стран
            GetCountries();
        }
    }
}
