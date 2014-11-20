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
    public partial class Form_Goods : Form
    {
        private string connStr;
        private NpgsqlConnection conn;
        private string funcCreate = "func_goods_on_insert";
        private string funcChange = "func_goods_on_update";
        private string funcDelete = "func_goods_on_delete";

        private DataTable tableGoods;
        private string queryName = "get_goods_by_server";
        List<TableColumn> columns = new List<TableColumn> {new TableColumn("id", "int", "id"),
                                                            new TableColumn("category_id", "int", "category_id"),
                                                            new TableColumn("category", "text", "Категория"),
                                                            new TableColumn("company_id", "int", "company_id"),
                                                            new TableColumn("company", "text", "Компания"),
                                                            new TableColumn("model", "text", "Модель товара"),
                                                            new TableColumn("price", "num", "Цена")};
        private DataTable tableCategories;
        private string queryCategories = "get_all_categories";
        List<TableColumn> membersCategories = new List<TableColumn> {new TableColumn("title", "text", "Название"),
                                                           new TableColumn("id", "int", "ИД")};

        private DataTable tableCompanies;
        private string queryCompanies = "get_list_companies_by_server";
        List<TableColumn> membersCompanies = new List<TableColumn> {new TableColumn("name", "text", "Название"),
                                                           new TableColumn("id", "int", "ИД")};

        public Form_Goods(string connStr)
        {
            InitializeComponent();
            comboBox_Server.SelectedIndex = 0;

            this.connStr = connStr;
            this.conn = new NpgsqlConnection(connStr);

            this.tableGoods = new System.Data.DataTable();
            this.tableCategories = new System.Data.DataTable();
            this.tableCompanies = new System.Data.DataTable();

            try
            {
                Class_Helper.SetColumns(tableGoods, dataGridView_Goods, columns);
                Class_Helper.SetMember(tableCategories, comboBox_Category, membersCategories, "title", "id");
                Class_Helper.SetMember(tableCompanies, comboBox_Company, membersCompanies, "name", "id");
            }
            catch (Exception ex)
            {
                throw new Exception("Can't init datagrid/combobox: " + ex.Message);
            } 

            //dataGridView_Categories.Columns["id"].Visible = false;
            //dataGridView_Goods.Columns["category_id"].Visible = false;
            //dataGridView_Goods.Columns["company_id"].Visible = false;
        }

        private void GetCategories()
        {
            Cursor.Current = Cursors.WaitCursor;
            string result = "";
            try
            {
                result = Class_Helper.ExecuteStoredQuery(conn, queryCategories, tableCategories);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;
            }
            Cursor.Current = Cursors.Default;
            toolStripStatusLabel.Text = result;
        }

        private void GetCompanies()
        {
            Cursor.Current = Cursors.WaitCursor;
            int server_id = comboBox_Server.SelectedIndex;
            List<Parameter> parameters = new List<Parameter> { new Parameter("id", "int", server_id) };
            string result = "";
            try
            {
                result = Class_Helper.ExecuteStoredQuery(conn, queryCompanies, tableCompanies, parameters);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;
            }
            Cursor.Current = Cursors.Default;
            toolStripStatusLabel.Text = result;
        }

        private void RefreshData()
        {
            string result = "";
            Cursor.Current = Cursors.WaitCursor;
            int server_id = comboBox_Server.SelectedIndex;
            List<Parameter> parameters = new List<Parameter> { new Parameter("id", "int", server_id) };

            try
            {
                result = Class_Helper.ExecuteStoredQuery(conn, queryName, tableGoods, parameters);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;
            }
            Cursor.Current = Cursors.Default;
            toolStripStatusLabel.Text = result;
        }

        private void dataGridView_Goods_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    int row = e.RowIndex;
                    int column = e.ColumnIndex;
                    DataGridViewCell clickedCell = (sender as DataGridView).Rows[row].Cells[column];
                    dataGridView_Goods.Rows[row].Selected = true;
                    label_id.Text = ((int)dataGridView_Goods["id", row].Value).ToString();

                    comboBox_Category.SelectedValue = (int)dataGridView_Goods["category_id", row].Value;
                    comboBox_Company.SelectedValue = (int)dataGridView_Goods["company_id", row].Value;

                    textBox_Model.Text = (string)dataGridView_Goods["model", row].Value;
                    textBox_Price.Text = ((Decimal)dataGridView_Goods["price", row].Value).ToString();

                    //richTextBox_Description.Text = (string)dataGridView_Goods["description", row].Value;                    
                }
            }
        }

        private bool IsEveryFieldCorrect()
        {
            string model = textBox_Model.Text;
            string price_str = textBox_Price.Text;

            //int category_id = (int)comboBox_Category.SelectedValue;
            //int company_id = (int)comboBox_Company.SelectedValue;

            //string description = richTextBox_Description.Text;

            if (model == "")
            {
                MessageBox.Show("Введите название модели товара");
                return false;
            }
            Decimal price;
            if (price_str != "")
                if (!Decimal.TryParse(price_str, out price))
                {
                    MessageBox.Show("Неверная цена");
                    return false;
                }
            return true;
        }

        private void button_Create_Click(object sender, EventArgs e)
        {
            if (!IsEveryFieldCorrect())
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            string model = textBox_Model.Text;
            string price_str = textBox_Price.Text;
            Decimal price = Decimal.Parse(price_str);

            int category_id = (int)comboBox_Category.SelectedValue;
            int company_id = (int)comboBox_Company.SelectedValue;

            string details = ""; //richTextBox_Description.Text;

            List<Parameter> parameters = new List<Parameter> { new Parameter("category_id", "int", category_id),
                                                                new Parameter("company_id", "int", company_id),
                                                                new Parameter("model", "text", model),
                                                                new Parameter("price", "num", price),
                                                                new Parameter("details", "text", details)};

            string result = "";
            try
            {
                result = Class_Helper.ExecuteFunction(conn, funcCreate, parameters);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                string error = "";
                //if (ex.Source == "Npgsql")
                //    if (((NpgsqlException)ex).Code == "P0001")
                //        error = "Категория уже существует";
                //    else
                error = "Smth wrong on goods insert";
                MessageBox.Show(error);
                return;
            }
            Cursor.Current = Cursors.Default;
            toolStripStatusLabel.Text = "Товар создан. " + result;
        }

        private void button_Change_Click(object sender, EventArgs e)
        {
            if (label_id.Text == "")
            {
                MessageBox.Show("Выберите товар");
                return;
            }
            if (!IsEveryFieldCorrect())
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            int goods_id = Convert.ToInt32(label_id.Text);
            string model = textBox_Model.Text;
            string price_str = textBox_Price.Text;
            Decimal price = Decimal.Parse(price_str);

            int category_id = (int)comboBox_Category.SelectedValue;
            int company_id = (int)comboBox_Company.SelectedValue;

            string details = ""; //richTextBox_Description.Text;

            List<Parameter> parameters = new List<Parameter> { new Parameter("id", "int", goods_id),
                                                                new Parameter("category_id", "int", category_id),
                                                                new Parameter("company_id", "int", company_id),
                                                                new Parameter("model", "text", model),
                                                                new Parameter("price", "num", price),
                                                                new Parameter("details", "text", details)};
            string result = "";
            try
            {
                result = Class_Helper.ExecuteFunction(conn, funcChange, parameters);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                string error = "";
                //if (ex.Source == "Npgsql")
                //    if (((NpgsqlException)ex).Code == "P0001")
                //        error = "Категория уже существует";
                //    else
                error = "Smth wrong on goods update";
                MessageBox.Show(error);
                return;
            }
            Cursor.Current = Cursors.Default;
            toolStripStatusLabel.Text = "Товар изменен. " + result;

        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (label_id.Text == "")
            {
                MessageBox.Show("Выберите товар");
                return;
            }
            if (MessageBox.Show("Действительно удалить товар (удалятся все связанные данные!)?",
                                    "Danger!",
                                    MessageBoxButtons.YesNo)
                                    == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            int goods_id = Convert.ToInt32(label_id.Text);

            List<Parameter> parameters = new List<Parameter> { new Parameter("id", "int", goods_id) };
            string result = "";
            try
            {
                result = Class_Helper.ExecuteFunction(conn, funcDelete, parameters);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                string error = "";
                //if (ex.Source == "Npgsql")
                //    if (((NpgsqlException)ex).Code == "P0001")
                //        error = "Категория уже существует";
                //    else
                error = "Smth wrong on goods delete";
                MessageBox.Show(error);
                return;
            }
            Cursor.Current = Cursors.Default;
            toolStripStatusLabel.Text = "Товар удален. " + result;
        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            GetCategories();
            GetCompanies();
            RefreshData();
        }
    }
}
