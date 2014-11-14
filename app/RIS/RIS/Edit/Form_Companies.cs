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
        private string connStr;
        private NpgsqlConnection conn;
        private DataTable dataTable_Companies;

        public Form_Companies(string connStr)
        {
            InitializeComponent();
            comboBox_Server.SelectedIndex = 0;

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

            this.dataTable_Companies = new DataTable();
            dataGridView_Companies.AutoGenerateColumns = true;         
            GetCountries();         
            RefreshData();
            dataGridView_Companies.DataSource = dataTable_Companies;
            dataTable_Companies.Columns.Add("country");
            //dataGridView_Categories.Columns["id"].Visible = false;
            dataGridView_Companies.Columns["id"].HeaderText = "id";
            dataGridView_Companies.Columns["name"].HeaderText = "Название";
            dataGridView_Companies.Columns["country"].HeaderText = "Страна";
            dataGridView_Companies.Columns["country_id"].Visible = false;
            dataGridView_Companies.Columns["head_full_name"].HeaderText = "ФИО директора";
            dataGridView_Companies.Columns["phone"].HeaderText = "Номер телефона";
            dataGridView_Companies.Columns["address"].HeaderText = "Юридический адрес компании";
            dataGridView_Companies.Columns["bank_details"].HeaderText = "Банковские реквизиты компании";
          
            SetCountries();
        }

        private void SetCountries()
        {
            for(int i = 0; i < dataGridView_Companies.RowCount; i++)
            {
                comboBox_Country.SelectedValue = (int)dataGridView_Companies["country_id", i].Value;
                dataGridView_Companies["country", i].Value = ((System.Data.DataRowView)comboBox_Country.SelectedItem).Row["name"];
            }
            comboBox_Country.SelectedIndex = 0;
        }

        private void GetCountries()
        {
            string query = "";
            switch (comboBox_Server.SelectedIndex)
            {
                case 0:
                    query = "SELECT * FROM public.dblink ('dbname=risbd6 host=students.ami.nstu.ru port=5432 user=risbd6 password=ris14bd6', " +
                            "        'SELECT sa.countries.id, sa.countries.name FROM sa.countries' ) as countries (id integer, name text) ORDER BY 2; ";
                    break;
                case 1:
                    query = "SELECT sb.countries.id, sb.countries.name FROM sb.countries ORDER BY 2; ";
                    break;
            }
            System.Data.DataTable table = new System.Data.DataTable();      
   
            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            da.Fill(table);
            comboBox_Country.DataSource = table;
            comboBox_Country.DisplayMember = "name";
            comboBox_Country.ValueMember = "id";
        }

        private void RefreshData()
        {
            dataTable_Companies.Clear();
            string query = "";
            switch (comboBox_Server.SelectedIndex)
            {
                case 0:
                    query = "SELECT * FROM public.dblink ('dbname=risbd6 host=students.ami.nstu.ru port=5432 user=risbd6 password=ris14bd6', " +
                            "        'SELECT * FROM sa.companies' ) as companies (id integer, name text, country_id integer, head_full_name text, phone text, address text, bank_details text) ORDER BY 1";
                    break;
                case 1:
                    query = "SELECT * FROM sb.companies ORDER BY 1";
                    break;
            }

            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            da.Fill(dataTable_Companies);
        }

        private void Form_Companies_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }

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

        private bool IsEveryFieldCorrect()
        {
            string name = textBox_Name.Text;
            //string head_full_name = textBox_Head_full_name.Text;
            //string phone = textBox_Phone.Text;
            //string address = textBox_Address.Text;
            //string bank_details = textBox_Bank_details.Text;
            int country_id = (int)comboBox_Country.SelectedValue;

            if (name == "")
            {
                MessageBox.Show("Введите название компании");
                return false;
            }
            if (country_id <= 0)
            {
                MessageBox.Show("Неверная страна");
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

            string name = textBox_Name.Text;
            string head_full_name = textBox_Head_full_name.Text;
            string phone = textBox_Phone.Text;
            string address = textBox_Address.Text;
            string bank_details = textBox_Bank_details.Text;
            int country_id = (int)comboBox_Country.SelectedValue;

            try
            {
                var cmdData = new Npgsql.NpgsqlCommand("func_companies_on_insert", conn);
                cmdData.CommandType = System.Data.CommandType.StoredProcedure;
                cmdData.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Text).Value = name;
                cmdData.Parameters.Add("country_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = country_id;
                cmdData.Parameters.Add("head_full_name", NpgsqlTypes.NpgsqlDbType.Text).Value = head_full_name;
                cmdData.Parameters.Add("phone", NpgsqlTypes.NpgsqlDbType.Text).Value = phone;
                cmdData.Parameters.Add("address", NpgsqlTypes.NpgsqlDbType.Text).Value = address;
                cmdData.Parameters.Add("bank_details", NpgsqlTypes.NpgsqlDbType.Text).Value = bank_details;
                                
                cmdData.ExecuteNonQuery();
                MessageBox.Show("Компания создана");
                RefreshData();
                SetCountries();
            }
            catch
            {
                MessageBox.Show("Smth wrong on company insert");
            }
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
            int company_id = Convert.ToInt32(label_id.Text);
            string name = textBox_Name.Text;
            string head_full_name = textBox_Head_full_name.Text;
            string phone = textBox_Phone.Text;
            string address = textBox_Address.Text;
            string bank_details = textBox_Bank_details.Text;
            int country_id = (int)comboBox_Country.SelectedValue;
            try
            {
                var cmdData = new Npgsql.NpgsqlCommand("func_companies_on_update", conn);
                cmdData.CommandType = System.Data.CommandType.StoredProcedure;
                cmdData.Parameters.Add("company_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = company_id;
                cmdData.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Text).Value = name;
                cmdData.Parameters.Add("country_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = country_id;
                cmdData.Parameters.Add("head_full_name", NpgsqlTypes.NpgsqlDbType.Text).Value = head_full_name;
                cmdData.Parameters.Add("phone", NpgsqlTypes.NpgsqlDbType.Text).Value = phone;
                cmdData.Parameters.Add("address", NpgsqlTypes.NpgsqlDbType.Text).Value = address;
                cmdData.Parameters.Add("bank_details", NpgsqlTypes.NpgsqlDbType.Text).Value = bank_details;
                
                cmdData.ExecuteNonQuery();
                MessageBox.Show("Компания изменена");
                RefreshData();
                SetCountries();
            }
            catch
            {
                MessageBox.Show("Smth wrong on company update");
            }
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

            int country_id = Convert.ToInt32(label_id.Text);

            try
            {
                var cmdData = new Npgsql.NpgsqlCommand("func_companies_on_delete", conn);
                cmdData.CommandType = System.Data.CommandType.StoredProcedure;
                cmdData.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = country_id;
                cmdData.ExecuteNonQuery();
                MessageBox.Show("Компания удалена");
                RefreshData();
                SetCountries();
            }
            catch
            {
                MessageBox.Show("Smth wrong on company delete");
            }

        }

        private void comboBox_Server_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCountries();
            RefreshData();
            SetCountries();
        }

    }
}
