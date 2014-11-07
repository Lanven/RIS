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
    public partial class Form_Add_Order : Form
    {
        NpgsqlConnection conn;

        private void FillPaymentMethods()
        {
            DataSet dataSet = new DataSet();
            System.Data.DataTable table = new System.Data.DataTable();

            string query = "SELECT * FROM sb.payment_methods";

            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            da.Fill(table);
            comboBox_PaymentMethod.DataSource = table;
            comboBox_PaymentMethod.DisplayMember = "title";
            comboBox_PaymentMethod.ValueMember = "id";
        }

        private void FillSaleTypes()
        {
            DataSet dataSet = new DataSet();
            System.Data.DataTable table = new System.Data.DataTable();
            string query = "SELECT * FROM sb.sale_types";
            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            da.Fill(table);
            comboBox_SaleType.DataSource = table;
            comboBox_SaleType.DisplayMember = "title";
            comboBox_SaleType.ValueMember = "id";
        }
        
        public Form_Add_Order(NpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;

            FillPaymentMethods();
            FillSaleTypes();
        }

        private void button_SearchClient_Click(object sender, EventArgs e)
        {
            Form_Search_Client form = new Form_Search_Client(conn);
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                string client = form.name;//values preserved after close
                int client_id = form.id;
                this.textBox_Client.Text = client;
                this.textBox_ClientId.Text = Convert.ToString(client_id);
            }
        }

        private void button_SearchGoods_Click(object sender, EventArgs e)
        {
            Form_Search_Goods form = new Form_Search_Goods(conn);
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                string goods = form.title;//values preserved after close
                int goods_id = form.id;
                this.textBox_Goods.Text = goods;
                this.textBox_GoodsId.Text = Convert.ToString(goods_id);
            }
        }

        private void button_AddOrder_Click(object sender, EventArgs e)
        {
            int payment_method_id = Convert.ToInt32(comboBox_PaymentMethod.SelectedValue);
            int sale_type_id = Convert.ToInt32(comboBox_SaleType.SelectedValue);
            DateTime on_sale_date = dateTimePicker_OnSaleDate.Value.Date;
            decimal sale_amount = Convert.ToDecimal(textBox_SaleAmount.Text);
            string details = richTextBox_Details.Text;

            int goods_id = Convert.ToInt32(textBox_GoodsId.Text);
            int client_id = Convert.ToInt32(textBox_ClientId.Text);
            
            var cmd = new Npgsql.NpgsqlCommand("initial.func_orders_on_insert", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("goods_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = goods_id;
            cmd.Parameters.Add("client_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = client_id;
            cmd.Parameters.Add("on_sale_date", NpgsqlTypes.NpgsqlDbType.Date).Value = on_sale_date;
            cmd.Parameters.Add("sale_amount", NpgsqlTypes.NpgsqlDbType.Numeric).Value = sale_amount;
            cmd.Parameters.Add("payment_method_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = payment_method_id;
            cmd.Parameters.Add("sale_type_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = sale_type_id;
            cmd.Parameters.Add("details", NpgsqlTypes.NpgsqlDbType.Text).Value = details;
            
            cmd.ExecuteNonQuery();
        }
    }
}
