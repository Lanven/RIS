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
    public partial class Form_Goods : Form
    {
        private string connStr;
        private NpgsqlConnection conn;
        private DataTable dataTable_Goods;

        public Form_Goods(string connStr)
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

            this.dataTable_Goods = new DataTable();
            dataGridView_Goods.AutoGenerateColumns = true;
            GetCategories();
            GetCompanies();
            RefreshData();
            dataGridView_Goods.DataSource = dataTable_Goods;
            dataTable_Goods.Columns.Add("category");
            dataTable_Goods.Columns.Add("company");
            //dataGridView_Categories.Columns["id"].Visible = false;
            dataGridView_Goods.Columns["id"].HeaderText = "id";
            dataGridView_Goods.Columns["category_id"].Visible = false;
            dataGridView_Goods.Columns["company_id"].Visible = false;
            dataGridView_Goods.Columns["category"].HeaderText = "Категория";
            dataGridView_Goods.Columns["company"].HeaderText = "Компания";
            dataGridView_Goods.Columns["model"].HeaderText = "Модель товара";
            dataGridView_Goods.Columns["price"].HeaderText = "Цена";
            //dataGridView_Goods.Columns["description"].HeaderText = "Описание товара";

            SetCategories();
            SetCompanies();
        }

        private void SetCategories()
        {
            for (int i = 0; i < dataGridView_Goods.RowCount; i++)
            {
                comboBox_Category.SelectedValue = (int)dataGridView_Goods["category_id", i].Value;
                dataGridView_Goods["category", i].Value = ((System.Data.DataRowView)comboBox_Category.SelectedItem).Row["title"];
            }
            comboBox_Category.SelectedIndex = 0;
        }

        private void GetCategories()
        {
            System.Data.DataTable table = new System.Data.DataTable();
            string query = "SELECT id, title FROM sb.categories ORDER BY 2; ";
            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            da.Fill(table);
            comboBox_Category.DataSource = table;
            comboBox_Category.DisplayMember = "title";
            comboBox_Category.ValueMember = "id";
        }

        private void SetCompanies()
        {
            for (int i = 0; i < dataGridView_Goods.RowCount; i++)
            {
                comboBox_Company.SelectedValue = (int)dataGridView_Goods["company_id", i].Value;
                dataGridView_Goods["company", i].Value = ((System.Data.DataRowView)comboBox_Company.SelectedItem).Row["name"];
            }
            comboBox_Company.SelectedIndex = 0;
        }

        private void GetCompanies()
        {
            System.Data.DataTable table = new System.Data.DataTable();
            string query = "";
            switch (comboBox_Server.SelectedIndex)
            {
                case 0:
                    query = "SELECT * FROM public.dblink ('dbname=risbd6 host=students.ami.nstu.ru port=5432 user=risbd6 password=ris14bd6', " +
                            "'SELECT sa.companies.id, sa.companies.name FROM sa.companies' ) as companies (id integer, name text) ORDER BY 2; ";
                    break;
                case 1:
                    query = "SELECT sb.companies.id, sb.companies.name FROM sb.companies ORDER BY 2; ";
                    break;
            }
            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            da.Fill(table);
            comboBox_Company.DataSource = table;
            comboBox_Company.DisplayMember = "name";
            comboBox_Company.ValueMember = "id";
        }

        private void RefreshData()
        {
            dataTable_Goods.Clear();
            string query = "";
            switch (comboBox_Server.SelectedIndex)
            {
                case 0:
                    query = "SELECT * FROM public.dblink ('dbname=risbd6 host=students.ami.nstu.ru port=5432 user=risbd6 password=ris14bd6', " +
                            "       'SELECT sa.goods_main.id, category_id, company_id, model, price " +
                            "        FROM sa.goods_main " +
                            "        JOIN sa.goods_info on sa.goods_main.id = sa.goods_info.id' ) " +
                            " as goods (id integer, category_id integer, company_id integer, model text, price numeric(12,2)) ORDER BY 1";
                    break;
                case 1:
                    query = "SELECT sb.goods_main.id, category_id, company_id, model, price " +
                            "FROM sb.goods_main " +
                            "JOIN sb.goods_info on sb.goods_main.id = sb.goods_info.id ORDER BY 1";
                    break;
            }

            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            da.Fill(dataTable_Goods);
        }

        private void Form_Goods_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }

        private void dataGridView_Goods_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    int row = e.RowIndex;
                    int column = e.ColumnIndex;
                    DataGridViewCell clickedCell = (sender as DataGridView).Rows[row].Cells[column];
                    dataGridView_Goods.Rows[row].Selected = true;
                    label_id.Text = ((int)dataGridView_Goods["id", row].Value).ToString();

                    comboBox_Category.SelectedValue = (int)dataGridView_Goods["category_id", row].Value;
                    comboBox_Company.SelectedValue = (int)dataGridView_Goods["company_id", row].Value;

                    textBox_Model.Text = (string)dataGridView_Goods["model", row].Value;
                    textBox_Price.Text = ((Decimal)dataGridView_Goods["price", row].Value).ToString();

                    //richTextBox_Description.Text = (string)dataGridView_Goods["description", row].Value;                    
                }
            }
        }

        private bool IsEveryFieldCorrect()
        {
            string model = textBox_Model.Text;
            string price_str = textBox_Price.Text;

            //int category_id = (int)comboBox_Category.SelectedValue;
            //int company_id = (int)comboBox_Company.SelectedValue;

            //string details = richTextBox_Description.Text;

            if (model == "")
            {
                MessageBox.Show("Введите название модели товара");
                return false;
            }
            Decimal price;
            if (price_str != "")
                if (!Decimal.TryParse(price_str, out price))
                {
                    MessageBox.Show("Неверная цена");
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

            string model = textBox_Model.Text;
            string price_str = textBox_Price.Text;
            Decimal price = Decimal.Parse(price_str);

            int category_id = (int)comboBox_Category.SelectedValue;
            int company_id = (int)comboBox_Company.SelectedValue;

            string details = ""; //richTextBox_Description.Text;

            try
            {
                var cmdData = new Npgsql.NpgsqlCommand("func_goods_on_insert", conn);
                cmdData.CommandType = System.Data.CommandType.StoredProcedure;
                cmdData.Parameters.Add("category_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = category_id;
                cmdData.Parameters.Add("company_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = company_id;
                cmdData.Parameters.Add("model", NpgsqlTypes.NpgsqlDbType.Text).Value = model;
                cmdData.Parameters.Add("price", NpgsqlTypes.NpgsqlDbType.Numeric).Value = price;
                cmdData.Parameters.Add("details", NpgsqlTypes.NpgsqlDbType.Text).Value = details;

                cmdData.ExecuteNonQuery();
                MessageBox.Show("Товар создан");
                RefreshData();
                SetCategories();
                SetCompanies();
            }
            catch
            {
                MessageBox.Show("Smth wrong on goods insert");
            }

        }

        private void button_Change_Click(object sender, EventArgs e)
        {
            if (label_id.Text == "")
            {
                MessageBox.Show("Выберите товар");
                return;
            }
            if (!IsEveryFieldCorrect())
            {
                return;
            }
            int goods_id = Convert.ToInt32(label_id.Text);
            string model = textBox_Model.Text;
            string price_str = textBox_Price.Text;
            Decimal price = Decimal.Parse(price_str);

            int category_id = (int)comboBox_Category.SelectedValue;
            int company_id = (int)comboBox_Company.SelectedValue;

            string details = ""; //richTextBox_Description.Text;
            try
            {
                var cmdData = new Npgsql.NpgsqlCommand("func_goods_on_update", conn);
                cmdData.CommandType = System.Data.CommandType.StoredProcedure;
                cmdData.Parameters.Add("goods_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = goods_id;
                cmdData.Parameters.Add("category_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = category_id;
                cmdData.Parameters.Add("company_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = company_id;
                cmdData.Parameters.Add("model", NpgsqlTypes.NpgsqlDbType.Text).Value = model;
                cmdData.Parameters.Add("price", NpgsqlTypes.NpgsqlDbType.Numeric).Value = price;
                cmdData.Parameters.Add("details", NpgsqlTypes.NpgsqlDbType.Text).Value = details;

                cmdData.ExecuteNonQuery();
                MessageBox.Show("Товар изменен");
                RefreshData();
                SetCategories();
                SetCompanies();
            }
            catch
            {
                MessageBox.Show("Smth wrong on goods update");
            }

        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (label_id.Text == "")
            {
                MessageBox.Show("Выберите товар");
                return;
            }
            if (MessageBox.Show("Действительно удалить товар (удалятся все связанные данные!)?",
                                    "Danger!",
                                    MessageBoxButtons.YesNo)
                                    == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            int goods_id = Convert.ToInt32(label_id.Text);

            try
            {
                var cmdData = new Npgsql.NpgsqlCommand("func_goods_on_delete", conn);
                cmdData.CommandType = System.Data.CommandType.StoredProcedure;
                cmdData.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = goods_id;
                cmdData.ExecuteNonQuery();
                MessageBox.Show("Товар удален");
                RefreshData();
                SetCategories();
                SetCompanies(); ;
            }
            catch
            {
                MessageBox.Show("Smth wrong on goods delete");
            }
        }

        private void comboBox_Server_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCategories();
            GetCompanies();
            RefreshData();
            SetCategories();
            SetCompanies();
        }
    }
}
