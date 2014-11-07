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
    public partial class Form_Add_Category : Form
    {
        NpgsqlConnection conn;
        public Form_Add_Category(NpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            if (textBox_Name.Text == "")
            {
                MessageBox.Show("Введите название");
                return;
            }
            /*
            string query = "INSERT INTO sb.categories(title) VALUES(:title)";

            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.Add("title", NpgsqlTypes.NpgsqlDbType.Text).Value = textBox_Name.Text;
            cmd.ExecuteNonQuery();
              */
        }
    }
}
