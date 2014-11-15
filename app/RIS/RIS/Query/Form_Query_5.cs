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
    public partial class Form_Query_5 : Form
    {
        private string connStr;
        private NpgsqlConnection conn;

        public Form_Query_5(string connStr)
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

            dataGridView_Firms.AutoGenerateColumns = true;
        }

        private void button_Get_Click(object sender, EventArgs e)
        {
            try
            {
                Stopwatch timer = new Stopwatch();

                int month = (int)numericUpDown_Month.Value;
                DataTable table = new DataTable();
                NpgsqlCommand command = new NpgsqlCommand("query05", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("month", NpgsqlTypes.NpgsqlDbType.Integer).Value = month;
                timer.Start();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
                da.Fill(table);
                timer.Stop();
                dataGridView_Firms.DataSource = table;

                dataGridView_Firms.Columns["company"].HeaderCell.Value = "Компания";
                dataGridView_Firms.Columns["country"].HeaderCell.Value = "Страна";
                dataGridView_Firms.Columns["summ"].HeaderCell.Value = "Сумма продажи";

                double time = timer.ElapsedMilliseconds;
                toolStripStatusLabel.Text = Convert.ToString(table.Rows.Count) + " строк. Затрачено " + Convert.ToString(time) + " мсек.";
            }
            catch
            {
                MessageBox.Show("Smth wrong durng query 5");
            }
        }

        private void Form_Query_5_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.conn.Close();
        }
    }
}
