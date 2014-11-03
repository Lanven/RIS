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
        NpgsqlConnection conn;
        public Form_Query_5(NpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            dataGridView_Firms.AutoGenerateColumns = true;
        }

        private void button_Get_Click(object sender, EventArgs e)
        {
            Stopwatch timer = new Stopwatch();

            int month = (int)numericUpDown_Month.Value;
            DataSet dataSetClients = new DataSet();
            DataTable table = new DataTable();

            string query = "SELECT sa.companies.name, sa.countries.name, s.summa " +
                            "FROM (select id, summa FROM sa.companies_monthly WHERE month = :month) s " +
                            "JOIN sa.companies ON sa.companies.id = s.id " +
                            "JOIN sa.countries ON sa.countries.id = sa.companies.country_id " +
                            "ORDER BY summa DESC, sa.companies.name ASC";

            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            command.Parameters.Add("month", NpgsqlTypes.NpgsqlDbType.Integer).Value = month;

            timer.Start();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);

            da.Fill(table);

            dataGridView_Firms.DataSource = table;
            timer.Stop();
            double time = timer.ElapsedMilliseconds;
            toolStripStatusLabel.Text = Convert.ToString(table.Rows.Count) + " строк. Затрачено " + Convert.ToString(time) + " мсек.";
        }
    }
}
