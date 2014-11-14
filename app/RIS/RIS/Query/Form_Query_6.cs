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
        private string connStr;
        private NpgsqlConnection conn;

        public Form_Query_6(string connStr)
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

            dataGridView_Orders.AutoGenerateColumns = true;
        }

        private void button_Get_Click(object sender, EventArgs e)
        {
            Stopwatch timer = new Stopwatch();

            int month = (int)numericUpDown_Month.Value;
            DataTable table = new DataTable();
            NpgsqlCommand command = new NpgsqlCommand("query06", conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("month", NpgsqlTypes.NpgsqlDbType.Integer).Value = month;
            timer.Start();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            da.Fill(table);
            timer.Stop();
            dataGridView_Orders.DataSource = table;
            dataGridView_Orders.Columns["sale_date"].HeaderCell.Value = "Дата продажи";
            dataGridView_Orders.Columns["titl"].HeaderCell.Value = "Категория";
            dataGridView_Orders.Columns["compid"].HeaderCell.Value = "ИД компании";
            dataGridView_Orders.Columns["modell"].HeaderCell.Value = "Модель";
            dataGridView_Orders.Columns["summa"].HeaderCell.Value = "Сумма";

            double time = timer.ElapsedMilliseconds;
            toolStripStatusLabel.Text = Convert.ToString(table.Rows.Count) + " строк. Затрачено " + Convert.ToString(time) + " мсек.";
        }

        private void Form_Query_6_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }
    }
}
