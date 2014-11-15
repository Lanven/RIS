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
    public partial class Form_Query_4 : Form
    {
        private string connStr;
        private NpgsqlConnection conn;

        public Form_Query_4(string connStr)
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

            dataGridView_Countries.AutoGenerateColumns = true;
        }

        private void button_Get_Click(object sender, EventArgs e)
        {
            try
            {
                Stopwatch timer = new Stopwatch();
                DataTable table = new DataTable();

                NpgsqlCommand command = new NpgsqlCommand("query04", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                timer.Start();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
                da.Fill(table);
                timer.Stop();
                dataGridView_Countries.DataSource = table;
                dataGridView_Countries.Columns["nam"].HeaderCell.Value = "Страна";
                dataGridView_Countries.Columns["summ"].HeaderCell.Value = "Сумма продаж";
                double time = timer.ElapsedMilliseconds;
                toolStripStatusLabel.Text = Convert.ToString(table.Rows.Count) + " строк. Затрачено " + Convert.ToString(time) + " мсек.";
            }
            catch
            {
                MessageBox.Show("Smth wrong during query 4");
            }
        }

        private void Form_Query_4_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }

    }
}
