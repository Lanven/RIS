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
    public partial class Form_Query_2 : Form
    {

        NpgsqlConnection conn;
        public Form_Query_2(NpgsqlConnection conn)
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

            string query = "SELECT ords.on_sale_date, sa.categories.title, companies.name, model, " +
                                "countries.name, payment_methods.title, sale_types.title, ords.sale_amount " +
                            "from (SELECT on_sale_date,sale_amount,goods_id,payment_method_id,sale_type_id " +
                                "FROM sa.orders_main " +
                                "WHERE month = :month and sale_amount <= 1000) ords " +
                            "join sa.goods_main on ords.goods_id = goods_main.id " +
                            "join sa.payment_methods on ords.payment_method_id = sa.payment_methods.id " +
                            "join sa.sale_types on ords.sale_type_id = sa.sale_types.id " +
                            "join sa.companies on sa.goods_main.company_id = sa.companies.id " +
                            "join sa.countries on sa.companies.country_id = sa.countries.id " +
                            "join sa.categories on sa.goods_main.category_id = sa.categories.id " +
                            "order by 5, 1, 2, 3, 4, 7, 6, 8";

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
