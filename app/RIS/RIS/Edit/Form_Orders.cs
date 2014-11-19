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
        private DataTable dataTable_Orders;

        public Form_Orders(string connStr)
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

            this.dataTable_Orders = new DataTable();
            dataGridView_Orders.AutoGenerateColumns = true;
            GetGoods();
            GetClients();
            GetPaymentMethods();
            GetSaleTypes();

            RefreshData();
            dataGridView_Orders.DataSource = dataTable_Orders;
            //dataTable_Orders.Columns.Add("goods");
            //dataTable_Orders.Columns.Add("client");
            //dataTable_Orders.Columns.Add("payment_method");
            //dataTable_Orders.Columns.Add("sale_type");
            //dataGridView_Categories.Columns["id"].Visible = false;
            dataGridView_Orders.Columns["id"].HeaderText = "id";
            //dataGridView_Orders.Columns["goods_id"].Visible = false;
            //dataGridView_Orders.Columns["client_id"].Visible = false;
            //dataGridView_Orders.Columns["payment_method_id"].Visible = false;
            //dataGridView_Orders.Columns["sale_type_id"].Visible = false;

            dataGridView_Orders.Columns["on_sale_date"].HeaderText = "Дата продажи";
            dataGridView_Orders.Columns["sale_amount"].HeaderText = "Сумма покупки";

            //dataGridView_Orders.Columns["goods"].HeaderText = "Проданный товар";
            //dataGridView_Orders.Columns["client"].HeaderText = "Покупатель";
            //dataGridView_Orders.Columns["payment_method"].HeaderText = "Способ оплаты";
            //dataGridView_Orders.Columns["sale_type"].HeaderText = "Вид продажи";
            //dataGridView_Goods.Columns["details"].HeaderText = "Дополнительная информация о продаже";

          // SetGoods();
          // SetClients();
          //  SetPaymentMethods();
          //  SetSaleTypes();

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
                dataGridView_Orders["goods", i].Value = ((System.Data.DataRowView)comboBox_Goods.SelectedItem).Row["model"];
            }
            comboBox_Goods.SelectedIndex = 0;
        }

        private void GetGoods()
        {
            System.Data.DataTable table = new System.Data.DataTable();
            string query = "";
            switch (comboBox_Server.SelectedIndex)
            {
                case 0:
                    query = "SELECT * FROM public.dblink ('dbname=risbd6 host=students.ami.nstu.ru port=5432 user=risbd6 password=ris14bd6', " +
                            "'SELECT sa.goods_main.id, sa.goods_main.model FROM sa.goods_main' ) as goods (id integer, model text) ORDER BY 2; ";
                    break;
                case 1:
                    query = "SELECT sb.goods_main.id, sb.goods_main.model FROM sb.goods_main ORDER BY 2; ";
                    break;
            }
            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            try
            {
                da.Fill(table);
                comboBox_Goods.DataSource = table;
                comboBox_Goods.DisplayMember = "model";
                comboBox_Goods.ValueMember = "id";
            }
            catch
            {
                MessageBox.Show("Cannot perform getting data");
            }
        }

        private void SetClients()
        {
            for (int i = 0; i < dataGridView_Orders.RowCount; i++)
            {
                comboBox_Client.SelectedValue = (int)dataGridView_Orders["client_id", i].Value;
                dataGridView_Orders["client", i].Value = ((System.Data.DataRowView)comboBox_Client.SelectedItem).Row["fio"]; 
            }
            comboBox_Client.SelectedIndex = 0;
        }

        private void GetClients()
        {
            System.Data.DataTable table = new System.Data.DataTable();
            string query = "SELECT id, (surname ||' '|| name||' '||patronymic)as fio FROM sb.clients ORDER BY 2; ";
            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            try
            {
                da.Fill(table);
                comboBox_Client.DataSource = table;
                comboBox_Client.DisplayMember = "fio";
                comboBox_Client.ValueMember = "id";
            }
            catch
            {
                MessageBox.Show("Cannot perform getting data");
            }
        }

        private void SetPaymentMethods()
        {
            for (int i = 0; i < dataGridView_Orders.RowCount; i++)
            {
                comboBox_Payment_Method.SelectedValue = (int)dataGridView_Orders["payment_method_id", i].Value;
                dataGridView_Orders["payment_method", i].Value = ((System.Data.DataRowView)comboBox_Payment_Method.SelectedItem).Row["title"];
            }
            comboBox_Payment_Method.SelectedIndex = 0;
        }

        private void GetPaymentMethods()
        {
            System.Data.DataTable table = new System.Data.DataTable();
            string query = "SELECT id, title FROM sb.payment_methods ORDER BY 2; ";
            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            try
            {
                da.Fill(table);
                comboBox_Payment_Method.DataSource = table;
                comboBox_Payment_Method.DisplayMember = "title";
                comboBox_Payment_Method.ValueMember = "id";
            }
            catch
            {
                MessageBox.Show("Cannot perform getting data");
            }
        }

        private void SetSaleTypes()
        {
            for (int i = 0; i < dataGridView_Orders.RowCount; i++)
            {
                comboBox_Sale_Type.SelectedValue = (int)dataGridView_Orders["sale_type_id", i].Value;
                dataGridView_Orders["sale_type", i].Value = ((System.Data.DataRowView)comboBox_Sale_Type.SelectedItem).Row["title"];
            }
            comboBox_Sale_Type.SelectedIndex = 0;
        }

        private void GetSaleTypes()
        {
            System.Data.DataTable table = new System.Data.DataTable();
            string query = "SELECT id, title FROM sb.sale_types ORDER BY 2; ";
            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            try
            {
                da.Fill(table);
                comboBox_Sale_Type.DataSource = table;
                comboBox_Sale_Type.DisplayMember = "title";
                comboBox_Sale_Type.ValueMember = "id";
            }
            catch 
            {
                MessageBox.Show("Cannot perform getting data");
            }
        }

        private void RefreshData()
        {
            dataTable_Orders.Clear();
            string query = "";
            switch (comboBox_Server.SelectedIndex)
            {
                case 0:
                    query = "SELECT * FROM public.dblink ('dbname=risbd6 host=students.ami.nstu.ru port=5432 user=risbd6 password=ris14bd6', " +
                            "       'SELECT sa.orders_main.id, goods_id, client_id, on_sale_date, sale_amount, payment_method_id, sale_type_id " +
                            "        FROM sa.orders_main' ) " +
                            " as orders (id integer, goods_id integer, client_id integer, on_sale_date date, sale_amount numeric(12,2), payment_method_id integer, sale_type_id integer) ORDER BY 1";
                    break;
                case 1:
                    query = "SELECT sb.orders_main.id, goods_id, client_id, on_sale_date, sale_amount, payment_method_id, sale_type_id " +
                            "FROM sb.orders_main " +
                            "JOIN sb.orders_info on sb.orders_main.id = sb.orders_info.id ORDER BY 1";
                    break;
            }

            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            try
            {
                da.Fill(dataTable_Orders);
            }
            catch
            {
                MessageBox.Show("Cannot perform getting data");
            }
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

                    comboBox_Goods.SelectedValue = (int)dataGridView_Orders["goods_id", row].Value;
                    comboBox_Client.SelectedValue = (int)dataGridView_Orders["client_id", row].Value;

                    textBox_On_sale_date.Text = ((DateTime)dataGridView_Orders["on_sale_date", row].Value).ToShortDateString();
                    textBox_Sale_Amount.Text = ((Decimal)dataGridView_Orders["sale_amount", row].Value).ToString();

                    comboBox_Payment_Method.SelectedValue = (int)dataGridView_Orders["payment_method_id", row].Value;
                    comboBox_Sale_Type.SelectedValue = (int)dataGridView_Orders["sale_type_id", row].Value;

                    //richTextBox_Details.Text = (string)dataGridView_Goods["description", row].Value;
                }
            }
        }

        private bool IsEveryFieldCorrect()
        {
            string on_sale_date_str = textBox_On_sale_date.Text;
            string sale_amount_str = textBox_Sale_Amount.Text;

            //int goods_id = (int)comboBox_Goods.SelectedValue;
            //int client_id = (int)comboBox_Client.SelectedValue;
            //int payment_method_id = (int)comboBox_Payment_Method.SelectedValue;
            //int sale_type_id = (int)comboBox_Sale_Type.SelectedValue;

            //string details = richTextBox_Details.Text;

            if (on_sale_date_str == "")
            {
                MessageBox.Show("Введите дату покупки");
                return false;
            }
            DateTime on_sale_date;
            if (!DateTime.TryParse(on_sale_date_str, out on_sale_date))
            {
                MessageBox.Show("Неверная дата покупки");
                return false;
            }

            if (on_sale_date_str == "")
            {
                MessageBox.Show("Введите дату покупки");
                return false;
            }
            Decimal sale_amount;
            if (!Decimal.TryParse(sale_amount_str, out sale_amount))
            {
                MessageBox.Show("Неверная сумма покупки");
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

            string on_sale_date_str = textBox_On_sale_date.Text;
            string sale_amount_str = textBox_Sale_Amount.Text;
            DateTime on_sale_date = DateTime.Parse(on_sale_date_str);
            Decimal sale_amount = Decimal.Parse(sale_amount_str);

            int goods_id = (int)comboBox_Goods.SelectedValue;
            int client_id = (int)comboBox_Client.SelectedValue;
            int payment_method_id = (int)comboBox_Payment_Method.SelectedValue;
            int sale_type_id = (int)comboBox_Sale_Type.SelectedValue;

            string details = "";

            try
            {
                var cmdData = new Npgsql.NpgsqlCommand("func_orders_on_insert", conn);
                cmdData.CommandType = System.Data.CommandType.StoredProcedure;
                cmdData.Parameters.Add("goods_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = goods_id;
                cmdData.Parameters.Add("client_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = client_id;

                cmdData.Parameters.Add("on_sale_date", NpgsqlTypes.NpgsqlDbType.Date).Value = on_sale_date;
                cmdData.Parameters.Add("sale_amount", NpgsqlTypes.NpgsqlDbType.Numeric).Value = sale_amount;

                cmdData.Parameters.Add("payment_method_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = payment_method_id;
                cmdData.Parameters.Add("sale_type_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = sale_type_id;
                cmdData.Parameters.Add("details", NpgsqlTypes.NpgsqlDbType.Text).Value = details;

                cmdData.ExecuteNonQuery();
                MessageBox.Show("Заказ создан");
                RefreshData();
            }
            catch
            {
                MessageBox.Show("Smth wrong on orders insert");
            }


        }

        private void button_Change_Click(object sender, EventArgs e)
        {
            if (label_id.Text == "")
            {
                MessageBox.Show("Выберите заказ");
                return;
            }
            if (!IsEveryFieldCorrect())
            {
                return;
            }
            int order_id = Convert.ToInt32(label_id.Text);
            string on_sale_date_str = textBox_On_sale_date.Text;
            string sale_amount_str = textBox_Sale_Amount.Text;
            DateTime on_sale_date = DateTime.Parse(on_sale_date_str);
            Decimal sale_amount = Decimal.Parse(sale_amount_str);

            int goods_id = (int)comboBox_Goods.SelectedValue;
            int client_id = (int)comboBox_Client.SelectedValue;
            int payment_method_id = (int)comboBox_Payment_Method.SelectedValue;
            int sale_type_id = (int)comboBox_Sale_Type.SelectedValue;

            string details = "";
            try
            {
                var cmdData = new Npgsql.NpgsqlCommand("func_orders_on_update", conn);
                cmdData.CommandType = System.Data.CommandType.StoredProcedure;
                cmdData.Parameters.Add("order_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = order_id;

                cmdData.Parameters.Add("goods_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = goods_id;
                cmdData.Parameters.Add("client_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = client_id;

                cmdData.Parameters.Add("on_sale_date", NpgsqlTypes.NpgsqlDbType.Date).Value = on_sale_date;
                cmdData.Parameters.Add("sale_amount", NpgsqlTypes.NpgsqlDbType.Numeric).Value = sale_amount;

                cmdData.Parameters.Add("payment_method_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = payment_method_id;
                cmdData.Parameters.Add("sale_type_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = sale_type_id;
                cmdData.Parameters.Add("details", NpgsqlTypes.NpgsqlDbType.Text).Value = details;

                cmdData.ExecuteNonQuery();
                MessageBox.Show("Заказ изменен");
                RefreshData();
            }
            catch
            {
                MessageBox.Show("Smth wrong on orders update");
            }

        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (label_id.Text == "")
            {
                MessageBox.Show("Выберите заказ");
                return;
            }

            int order_id = Convert.ToInt32(label_id.Text);

            try
            {
                var cmdData = new Npgsql.NpgsqlCommand("func_orders_on_delete", conn);
                cmdData.CommandType = System.Data.CommandType.StoredProcedure;
                cmdData.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = order_id;
                cmdData.ExecuteNonQuery();
                MessageBox.Show("Заказ удален");
                RefreshData();
            }
            catch
            {
                MessageBox.Show("Smth wrong on orders delete");
            }

        }

        private void comboBox_Server_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetGoods();
            GetClients();
            GetPaymentMethods();
            GetSaleTypes();
            RefreshData();
            //SetGoods();
            //SetClients();
            //SetPaymentMethods();
            //SetSaleTypes();
        }

    }
}
