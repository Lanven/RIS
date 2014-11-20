using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace RIS
{
    public partial class Form_Main : Form
    {
        [DllImport("Math.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double Add(double a, double b);
        [DllImport("Math.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double Subtract(double a, double b);
        [DllImport("Math.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double Multiply(double a, double b);
        private string connStr;
        private bool show;

        public Form_Main()
        {
            InitializeComponent();
            this.Hide();
            show = false;
            beforeEnter();
        }

        private void Form_Main_Shown(object sender, EventArgs e)
        {
            if (show == false)
                this.Close();
        }
        private void Form_Main_VisibleChanged(object sender, EventArgs e)
        {
            if (show == false)
                this.Close();
        }

        private void beforeEnter()
        {
            Form_Login Login_Form = new Form_Login();
            var res = Login_Form.ShowDialog();
            if (res == DialogResult.OK)
            {
                string server = Login_Form.server;
                int servId = Login_Form.servId;
                string login = Login_Form.login;
                connStr = Login_Form.connStr;
                toolStripStatusLabel_Main.Text = "Подключено к " + server + ". Login: " + login;
                SetMenuStates(servId);
                show = true;
            }
            else
            {
                show = false;
            }
            this.Show();
        }

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

            данныеToolStripMenuItem.Enabled = !state;
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            show = false;
            beforeEnter();
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
            try
            {
                Form_Query_2 QueryForm = new Form_Query_2(connStr);
                QueryForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void запрос3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form_Query_3 QueryForm = new Form_Query_3(connStr);
                QueryForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void запрос4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form_Query_4 QueryForm = new Form_Query_4(connStr);
                QueryForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void запрос5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form_Query_5 QueryForm = new Form_Query_5(connStr);
                QueryForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void запрос6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form_Query_6 QueryForm = new Form_Query_6(connStr);
                QueryForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void запрос7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form_Query_7 QueryForm = new Form_Query_7(connStr);
                QueryForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form_Query_Word QueryForm = new Form_Query_Word(connStr);
                QueryForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form_Query_Excel QueryForm = new Form_Query_Excel(connStr);
                QueryForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void категорииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form_Categories QueryForm = new Form_Categories(connStr);
                QueryForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void страныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form_Countries QueryForm = new Form_Countries(connStr);
                QueryForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form_Clients QueryForm = new Form_Clients(connStr);
                QueryForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void компанииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form_Companies QueryForm = new Form_Companies(connStr);
                QueryForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void товарыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form_Goods QueryForm = new Form_Goods(connStr);
                QueryForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void заказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form_Orders QueryForm = new Form_Orders(connStr);
                QueryForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = (int)numericUpDown1.Value;
            int b = (int)numericUpDown2.Value;

            textBox1.Text = Convert.ToString(Add(a, b));
        }
    }
}
