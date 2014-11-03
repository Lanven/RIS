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

namespace RIS
{
    public partial class Form_Main : Form
    {
        public NpgsqlConnection conn;
        public int serv;//можно получить из конекшена вообщет

        private void SetMenuStates(int server)
        {
            bool state = server == 0;
            запрос2ToolStripMenuItem.Enabled = state;
            запрос3ToolStripMenuItem.Enabled = state;
            запрос4ToolStripMenuItem.Enabled = state;
            запрос5ToolStripMenuItem.Enabled = state;
            запрос6ToolStripMenuItem.Enabled = !state;
            запрос7ToolStripMenuItem.Enabled = !state;

            wordToolStripMenuItem.Enabled = !state;
            excelToolStripMenuItem.Enabled = !state;
        }

        public Form_Main()
        {
            InitializeComponent();
            Form_Login Login_Form = new Form_Login(this);
            Login_Form.ShowDialog();
            SetMenuStates(serv);
            toolStripStatusLabel_Main.Text = "Подключено к " + conn.Host + ". ДБ: " + conn.Database;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_About AbouthForm = new Form_About();
            AbouthForm.ShowDialog();
        }

        private void запрос2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Query_2 QueryForm = new Form_Query_2(conn);
            QueryForm.Show();
        }

        private void запрос5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Query_5 QueryForm = new Form_Query_5(conn);
            QueryForm.Show();
        }

        private void запрос3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Query_3 QueryForm = new Form_Query_3(conn);
            QueryForm.Show();
        }

        private void запрос4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Query_4 QueryForm = new Form_Query_4(conn);
            QueryForm.Show();
        }


    }
}
