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
    public partial class Form_Query_6 : Form
    {
        NpgsqlConnection conn;
        public Form_Query_6(NpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            dataGridView_Orders.AutoGenerateColumns = true;
        }

        private void button_Get_Click(object sender, EventArgs e)
        {
            Stopwatch timer = new Stopwatch();

            int month = (int)numericUpDown_Month.Value;
            DataSet dataSetClients = new DataSet();
            DataTable table = new DataTable();

            string query = "SELECT on_sale_date, title, comp_id.id, model, sale_amount " +
                            "FROM (SELECT id FROM sb.companies) comp_id " +
                            "JOIN sb.goods_main ON sb.goods_main.company_id = comp_id.id " +
                            "JOIN sb.orders_main ON sb.orders_main.goods_id = sb.goods_main.id " +
                            "JOIN sb.categories ON sb.categories.id = sb.goods_main.category_id " +
                            "WHERE month = :month " +
                            "ORDER BY 1,2,3,4,5";

            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            command.Parameters.Add("month", NpgsqlTypes.NpgsqlDbType.Integer).Value = month;

            timer.Start();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);

            da.Fill(table);

            dataGridView_Orders.DataSource = table;
            timer.Stop();
            double time = timer.ElapsedMilliseconds;
            toolStripStatusLabel.Text = Convert.ToString(table.Rows.Count) + " строк. Затрачено " + Convert.ToString(time) + " мсек.";
        }
    }
}
