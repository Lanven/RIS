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
        NpgsqlConnection conn;
        public Form_Query_4(NpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            dataGridView_Countries.AutoGenerateColumns = true;
        }

        private void button_Get_Click(object sender, EventArgs e)
        {
            Stopwatch timer = new Stopwatch();

            DataSet dataSetClients = new DataSet();
            DataTable table = new DataTable();
            
            string query = "SELECT name, summa "+
                            "FROM sa.countries " +
                            "ORDER BY summa DESC NULLS LAST, name ASC";

            NpgsqlCommand command = new NpgsqlCommand(query, conn);

            timer.Start();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);

            da.Fill(table);

            dataGridView_Countries.DataSource = table;
            timer.Stop();
            double time = timer.ElapsedMilliseconds;
            toolStripStatusLabel.Text = Convert.ToString(table.Rows.Count) + " строк. Затрачено " + Convert.ToString(time) + " мсек.";
        }

    }
}
