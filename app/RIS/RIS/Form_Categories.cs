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
    public partial class Form_Categories : Form
    {
        NpgsqlConnection conn;
        public Form_Categories(NpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;

            DataSet dataSetClients = new DataSet();
            DataTable table = new DataTable();
            string query = "SELECT * from sb.categories";

            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            da.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
