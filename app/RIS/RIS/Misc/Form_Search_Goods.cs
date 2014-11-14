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
    public partial class Form_Search_Goods : Form
    {
        NpgsqlConnection conn;
        public string title { get; set; }
        public int id { get; set; }

        public Form_Search_Goods(NpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            string str = "%" + textBox_Search.Text + "%";
            DataSet dataSet = new DataSet();
            System.Data.DataTable table = new System.Data.DataTable();
            string query = "SELECT id, title FROM sb.categories WHERE lower(title) LIKE lower(:str); ";
            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            command.Parameters.Add("str", NpgsqlTypes.NpgsqlDbType.Text).Value = str;

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            da.Fill(table);
            comboBox_Select.DataSource = table;
            comboBox_Select.DisplayMember = "title";
            comboBox_Select.ValueMember = "id";
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(comboBox_Select.SelectedValue);
            title = comboBox_Select.Text;
            this.Close();
        }
    }
}
