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

        public Form_Companies(string connStr)
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
            dataGridView_Companies.AutoGenerateColumns = true;


            
            GetCountries();
            
            RefreshData();

            

            //dataGridView_Categories.Columns["id"].Visible = false;
            dataGridView_Companies.Columns["id"].HeaderText = "id";
            dataGridView_Companies.Columns["name"].HeaderText = "Название";
            dataGridView_Companies.Columns.Add("country", "Страна");
            dataGridView_Companies.Columns["country_id"].Visible = false;
            dataGridView_Companies.Columns["head_full_name"].HeaderText = "ФИО директора";
            dataGridView_Companies.Columns["phone"].HeaderText = "Номер телефона";
            dataGridView_Companies.Columns["address"].HeaderText = "Юридический адрес компании";
            dataGridView_Companies.Columns["bank_details"].HeaderText = "Банковские реквизиты компании";

            SetCountries();
        }

        private void SetCountries()
        {
           
            int country_id = dataGridView_Companies.Columns["country_id"].Index;
            int country = dataGridView_Companies.Columns["country"].Index;
            for(int i = 0; i < dataGridView_Companies.RowCount; i++)
                dataGridView_Companies.Rows[i].Cells[country].Value = "321";


        }

        private void GetCountries()
        {
            System.Data.DataTable table = new System.Data.DataTable();
            string query = "SELECT id, name FROM ( " +
                                        "    SELECT * FROM public.dblink ('dbname=risbd6 host=students.ami.nstu.ru port=5432 user=risbd6 password=ris14bd6', " +
                                        "        'SELECT sa.countries.id, sa.countries.name " +
                                        "        FROM sa.countries' ) as companies (id integer, name text) " +
                                        "    UNION " +
                                        "    SELECT sb.countries.id, sb.countries.name " +
                                        "    FROM sb.countries) a " +
                                        "ORDER BY 2; ";
            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            da.Fill(table);
            comboBox_Country.DataSource = table;
            comboBox_Country.DisplayMember = "name";
            comboBox_Country.ValueMember = "id";
            
        }

        private void RefreshData()
        {
            DataTable table = new DataTable();

            string query = "SELECT * FROM ( " +
                            "    SELECT * FROM public.dblink ('dbname=risbd6 host=students.ami.nstu.ru port=5432 user=risbd6 password=ris14bd6', " +
                            "        'SELECT * " +
                            "        FROM sa.companies' ) as companies (id integer, name text, country_id integer, head_full_name text, phone text, address text, bank_details text) " +
                            "    UNION " +
                            "    SELECT * " +
                            "    FROM sb.companies) a";

            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            da.Fill(table);
            dataGridView_Companies.DataSource = table;
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
                    

                    //textBox_Title.Text = (string)dataGridView_Clients["title", row].Value;
                    //label_id.Text = ((int)dataGridView_Clients["id", row].Value).ToString();
                }
            }

        }




    }
}
