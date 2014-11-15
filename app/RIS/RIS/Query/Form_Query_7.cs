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
    public partial class Form_Query_7 : Form
    {
        private string connStr;
        private NpgsqlConnection conn;

        public Form_Query_7(string connStr)
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

            dataGridView_Clients.AutoGenerateColumns = true;
        }

        private void button_Get_Click(object sender, EventArgs e)
        {
            try
            { 
                Stopwatch timer = new Stopwatch();
                DataTable table = new DataTable();

                NpgsqlCommand command = new NpgsqlCommand("query07", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                timer.Start();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
                da.Fill(table);
                timer.Stop();
                dataGridView_Clients.DataSource = table;
                dataGridView_Clients.Columns["surnam"].HeaderCell.Value = "Фамилия";
                dataGridView_Clients.Columns["nam"].HeaderCell.Value = "Имя";
                dataGridView_Clients.Columns["patronymi"].HeaderCell.Value = "Отчество";
                dataGridView_Clients.Columns["birthdat"].HeaderCell.Value = "Дата рождения";
                dataGridView_Clients.Columns["passport_serie"].HeaderCell.Value = "Серия паспорта";
                dataGridView_Clients.Columns["passport_numbe"].HeaderCell.Value = "Номер паспорта";
                dataGridView_Clients.Columns["issue_dat"].HeaderCell.Value = "Дата выдачи";
                dataGridView_Clients.Columns["issue_departmen"].HeaderCell.Value = "Отделение выдачи";

                double time = timer.ElapsedMilliseconds;
                toolStripStatusLabel.Text = Convert.ToString(table.Rows.Count) + " строк. Затрачено " + Convert.ToString(time) + " мсек.";
            }
            catch
            {
                MessageBox.Show("Smth wrong during query 7");
            }
        }

        private void Form_Query_7_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }
    }
}
