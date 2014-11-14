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
    public partial class Form_Orders : Form
    {
        private string connStr;
        private NpgsqlConnection conn;
        DataTable table;

        public Form_Orders(string connStr)
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

            this.table = new DataTable();
            dataGridView_Orders.AutoGenerateColumns = true;
            GetGoods();
            GetClients();
            GetPaymentMethods();
            GetSaleTypes();

            RefreshData();
            dataGridView_Orders.DataSource = table;
            table.Columns.Add("goods");
            table.Columns.Add("client");
            table.Columns.Add("payment_method");
            table.Columns.Add("sale_type");
            //dataGridView_Categories.Columns["id"].Visible = false;
            dataGridView_Orders.Columns["id"].HeaderText = "id";
            dataGridView_Orders.Columns["goods_id"].Visible = false;
            dataGridView_Orders.Columns["client_id"].Visible = false;
            dataGridView_Orders.Columns["payment_method_id"].Visible = false;
            dataGridView_Orders.Columns["sale_type_id"].Visible = false;

            dataGridView_Orders.Columns["on_sale_date"].HeaderText = "Дата продажи";
            dataGridView_Orders.Columns["sale_amount"].HeaderText = "Сумма покупки";

            dataGridView_Orders.Columns["goods"].HeaderText = "Проданный товар";
            dataGridView_Orders.Columns["client"].HeaderText = "Покупатель";
            dataGridView_Orders.Columns["payment_method"].HeaderText = "Способ оплаты";
            dataGridView_Orders.Columns["sale_type"].HeaderText = "Вид продажи";
            //dataGridView_Goods.Columns["details"].HeaderText = "Дополнительная информация о продаже";

            SetGoods();
            SetClients();
            SetPaymentMethods();
            SetSaleTypes();

        }
       
        private void Form_Orders_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }

        private void SetGoods()
        {
            for (int i = 0; i < dataGridView_Orders.RowCount; i++)
            {
                comboBox_Goods.SelectedValue = (int)dataGridView_Orders["goods_id", i].Value;
                dataGridView_Orders["goods", i].Value = ((System.Data.DataRowView)comboBox_Goods.SelectedItem).Row["title"]; /**alert**/
            }
            comboBox_Goods.SelectedIndex = 0;
        }

        private void GetGoods()
        {
            System.Data.DataTable table = new System.Data.DataTable();
            string query = "SELECT id, title FROM sb.categories ORDER BY 2; ";
            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            da.Fill(table);
            comboBox_Goods.DataSource = table;
            comboBox_Goods.DisplayMember = "title";
            comboBox_Goods.ValueMember = "id";
        }

        private void SetClients()
        {
            for (int i = 0; i < dataGridView_Orders.RowCount; i++)
            {
                comboBox_Client.SelectedValue = (int)dataGridView_Orders["client_id", i].Value;
                dataGridView_Orders["client", i].Value = ((System.Data.DataRowView)comboBox_Client.SelectedItem).Row["title"]; /**alert**/
            }
            comboBox_Client.SelectedIndex = 0;
        }

        private void GetClients()
        {
            System.Data.DataTable table = new System.Data.DataTable();
            string query = "SELECT id, title FROM sb.categories ORDER BY 2; ";
            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            da.Fill(table);
            comboBox_Client.DataSource = table;
            comboBox_Client.DisplayMember = "title";
            comboBox_Client.ValueMember = "id";
        }

        private void SetPaymentMethods()
        {
            for (int i = 0; i < dataGridView_Orders.RowCount; i++)
            {
                comboBox_Payment_Method.SelectedValue = (int)dataGridView_Orders["payment_method_id", i].Value;
                dataGridView_Orders["payment_method", i].Value = ((System.Data.DataRowView)comboBox_Payment_Method.SelectedItem).Row["title"];/**alert**/
            }
            comboBox_Payment_Method.SelectedIndex = 0;
        }

        private void GetPaymentMethods()
        {
            System.Data.DataTable table = new System.Data.DataTable();
            string query = "SELECT id, title FROM sb.categories ORDER BY 2; ";
            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            da.Fill(table);
            comboBox_Payment_Method.DataSource = table;
            comboBox_Payment_Method.DisplayMember = "title";
            comboBox_Payment_Method.ValueMember = "id";
        }

        private void SetSaleTypes()
        {
            for (int i = 0; i < dataGridView_Orders.RowCount; i++)
            {
                comboBox_Sale_Type.SelectedValue = (int)dataGridView_Orders["sale_type_id", i].Value;
                dataGridView_Orders["sale_type", i].Value = ((System.Data.DataRowView)comboBox_Sale_Type.SelectedItem).Row["title"];/**alert**/
            }
            comboBox_Sale_Type.SelectedIndex = 0;
        }

        private void GetSaleTypes()
        {
            System.Data.DataTable table = new System.Data.DataTable();
            string query = "SELECT id, title FROM sb.categories ORDER BY 2; ";
            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            da.Fill(table);
            comboBox_Sale_Type.DataSource = table;
            comboBox_Sale_Type.DisplayMember = "title";
            comboBox_Sale_Type.ValueMember = "id";
        }

        private void RefreshData() /**alert**/
        {
            table.Clear();
            string query = "SELECT * FROM ( " +
                            "    SELECT * FROM public.dblink ('dbname=risbd6 host=students.ami.nstu.ru port=5432 user=risbd6 password=ris14bd6', " +
                            "        'SELECT sa.goods_main.id, category_id, company_id, model, price " +
                            "        FROM sa.goods_main " +
                            "        JOIN sa.goods_info on sa.goods_main.id = sa.goods_info.id' ) " +
                            " as goods (id integer, category_id integer, company_id integer, model text, price numeric(12,2)) " +
                            "    UNION " +
                            "    SELECT sb.goods_main.id, category_id, company_id, model, price " +
                            "    FROM sb.goods_main " +
                            "    JOIN sb.goods_info on sb.goods_main.id = sb.goods_info.id ) a ORDER BY 1";

            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            da.Fill(table);
        }

        private void dataGridView_Orders_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    int row = e.RowIndex;
                    int column = e.ColumnIndex;
                    DataGridViewCell clickedCell = (sender as DataGridView).Rows[row].Cells[column];
                    dataGridView_Orders.Rows[row].Selected = true;
                    label_id.Text = ((int)dataGridView_Orders["id", row].Value).ToString();

                    //comboBox_Category.SelectedValue = (int)dataGridView_Orders["category_id", row].Value;
                    //comboBox_Company.SelectedValue = (int)dataGridView_Orders["company_id", row].Value;

                    //textBox_Model.Text = (string)dataGridView_Orders["model", row].Value;
                    //textBox_Price.Text = ((Decimal)dataGridView_Orders["price", row].Value).ToString();

                    //richTextBox_Description.Text = (string)dataGridView_Goods["description", row].Value;                    


                    //textBox_Title.Text = (string)dataGridView_Clients["title", row].Value;
                    //label_id.Text = ((int)dataGridView_Clients["id", row].Value).ToString();
                }
            }
        }







    }
}
