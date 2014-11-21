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
    public partial class Form_Orders : Form
    {
        private string connStr;
        private NpgsqlConnection conn;
        private string funcCreate = "func_orders_on_insert";
        private string funcChange = "func_orders_on_update";
        private string funcDelete = "func_orders_on_delete";

        private DataTable tableOrders;
        private string queryName = "get_orders_by_server";
        List<TableColumn> columns = new List<TableColumn> {new TableColumn("id", "int", "id"),
                                                            new TableColumn("goods_id", "int", "goods_id"),
                                                            new TableColumn("goods", "text", "Товар"),
                                                            new TableColumn("client_id", "int", "client_id"),
                                                            new TableColumn("client", "text", "Клиент"),
                                                            new TableColumn("on_sale_date", "date", "Дата продажи"),
                                                            new TableColumn("sale_amount", "num", "Сумма"),
                                                            new TableColumn("payment_method_id", "int", "payment_method_id"),
                                                            new TableColumn("payment_method", "text", "Способ оплаты"),
                                                            new TableColumn("sale_type_id", "int", "sale_type_id"),
                                                            new TableColumn("sale_type", "text", "Вид продажи")};
        private DataTable tableGoods;
        private string queryGoods = "get_list_goods_by_server";
        List<TableColumn> membersGoods = new List<TableColumn> {new TableColumn("model", "text", "Название"),
                                                           new TableColumn("id", "int", "ИД")};

        private DataTable tableClients;
        private string queryClients = "get_list_clients";
        List<TableColumn> membersClients = new List<TableColumn> {new TableColumn("fullname", "text", "ФИО"),
                                                           new TableColumn("id", "int", "ИД")};

        private DataTable tableSaleTypes;
        private string querySaleTypes = "get_all_sale_types";
        List<TableColumn> membersSaleTypes = new List<TableColumn> {new TableColumn("title", "text", "Название"),
                                                           new TableColumn("id", "int", "ИД")};

        private DataTable tablePaymentMethods;
        private string queryPaymentMethods = "get_all_payment_methods";
        List<TableColumn> membersPaymentMethods = new List<TableColumn> {new TableColumn("title", "text", "Название"),
                                                           new TableColumn("id", "int", "ИД")};

        public Form_Orders(string connStr)
        {
            InitializeComponent();
            comboBox_Server.SelectedIndex = 0;

            this.connStr = connStr;
            this.conn = new NpgsqlConnection(connStr);

            this.tableOrders = new System.Data.DataTable();
            this.tableGoods = new System.Data.DataTable();
            this.tableClients = new System.Data.DataTable();
            this.tableSaleTypes = new System.Data.DataTable();
            this.tablePaymentMethods = new System.Data.DataTable();

            try
            {
                Class_Helper.SetColumns(tableOrders, dataGridView_Orders, columns);
                Class_Helper.SetMember(tableGoods, comboBox_Goods, membersGoods, "model", "id");
                Class_Helper.SetMember(tableClients, comboBox_Client, membersClients, "fullname", "id");
                Class_Helper.SetMember(tableSaleTypes, comboBox_Sale_Type, membersSaleTypes, "title", "id");
                Class_Helper.SetMember(tablePaymentMethods, comboBox_Payment_Method, membersPaymentMethods, "title", "id");
            }
            catch (Exception ex)
            {
                throw new Exception("Can't init datagrid/combobox: " + ex.Message);
            } 
            //dataGridView_Categories.Columns["id"].Visible = false;
            dataGridView_Orders.Columns["goods_id"].Visible = false;
            dataGridView_Orders.Columns["client_id"].Visible = false;
            dataGridView_Orders.Columns["payment_method_id"].Visible = false;
            dataGridView_Orders.Columns["sale_type_id"].Visible = false;

        }

        private void GetGoods()
        {
            Cursor.Current = Cursors.WaitCursor;
            int server_id = comboBox_Server.SelectedIndex;
            List<Parameter> parameters = new List<Parameter> { new Parameter("id", "int", server_id) };
            string result = "";
            try
            {
                result = Class_Helper.ExecuteStoredQuery(conn, queryGoods, tableGoods, parameters);
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

        private void GetClients()
        {
            Cursor.Current = Cursors.WaitCursor;
            string result = "";
            try
            {
                result = Class_Helper.ExecuteStoredQuery(conn, queryClients, tableClients);
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

        private void GetPaymentMethods()
        {
            Cursor.Current = Cursors.WaitCursor;
            string result = "";
            try
            {
                result = Class_Helper.ExecuteStoredQuery(conn, queryPaymentMethods, tablePaymentMethods);
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

        private void GetSaleTypes()
        {
            Cursor.Current = Cursors.WaitCursor;
            string result = "";
            try
            {
                result = Class_Helper.ExecuteStoredQuery(conn, querySaleTypes, tableSaleTypes);
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
                result = Class_Helper.ExecuteStoredQuery(conn, queryName, tableOrders, parameters);
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

        private void dataGridView_Orders_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    int row = e.RowIndex;
                    int column = e.ColumnIndex;
                    DataGridViewCell clickedCell = (sender as DataGridView).Rows[row].Cells[column];
                    dataGridView_Orders.Rows[row].Selected = true;
                    label_id.Text = ((int)dataGridView_Orders["id", row].Value).ToString();

                    comboBox_Goods.SelectedValue = (int)dataGridView_Orders["goods_id", row].Value;
                    comboBox_Client.SelectedValue = (int)dataGridView_Orders["client_id", row].Value;

                    textBox_On_sale_date.Text = ((DateTime)dataGridView_Orders["on_sale_date", row].Value).ToShortDateString();
                    textBox_Sale_Amount.Text = ((Decimal)dataGridView_Orders["sale_amount", row].Value).ToString();

                    comboBox_Payment_Method.SelectedValue = (int)dataGridView_Orders["payment_method_id", row].Value;
                    comboBox_Sale_Type.SelectedValue = (int)dataGridView_Orders["sale_type_id", row].Value;

                    //richTextBox_Details.Text = (string)dataGridView_Goods["description", row].Value;
                }
            }
        }

        private bool IsEveryFieldCorrect()
        {
            string on_sale_date_str = textBox_On_sale_date.Text;
            string sale_amount_str = textBox_Sale_Amount.Text;

            //int goods_id = (int)comboBox_Goods.SelectedValue;
            //int client_id = (int)comboBox_Client.SelectedValue;
            //int payment_method_id = (int)comboBox_Payment_Method.SelectedValue;
            //int sale_type_id = (int)comboBox_Sale_Type.SelectedValue;

            //string details = richTextBox_Details.Text;
            if (!Class_Helper.IsCorrect_Date(on_sale_date_str))
            {
                MessageBox.Show("Неверная дата покупки");
                return false;
            }

            if (!Class_Helper.IsCorrect_Decimal(sale_amount_str))
            {
                MessageBox.Show("Неверная сумма покупки");
                return false;
            }

            if (comboBox_Client.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите клиента");
                return false;
            }
            if (comboBox_Goods.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите модель товара");
                return false;
            }
            if (comboBox_Payment_Method.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите способ оплаты");
                return false;
            }
            if (comboBox_Sale_Type.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите тип продажи");
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
            string on_sale_date_str = textBox_On_sale_date.Text;
            string sale_amount_str = textBox_Sale_Amount.Text;
            DateTime on_sale_date = DateTime.Parse(on_sale_date_str);
            Decimal sale_amount = Decimal.Parse(sale_amount_str);

            int goods_id = (int)comboBox_Goods.SelectedValue;
            int client_id = (int)comboBox_Client.SelectedValue;
            int payment_method_id = (int)comboBox_Payment_Method.SelectedValue;
            int sale_type_id = (int)comboBox_Sale_Type.SelectedValue;

            string details = "";

            List<Parameter> parameters = new List<Parameter> { new Parameter("goods_id", "int", goods_id),
                                                                new Parameter("client_id", "int", client_id),
                                                                new Parameter("on_sale_date", "date", on_sale_date),
                                                                new Parameter("sale_amount", "num", sale_amount),
                                                                new Parameter("payment_method_id", "int", payment_method_id),
                                                                new Parameter("sale_type_id", "int", sale_type_id),
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
                error = "Smth wrong on orders insert";
                MessageBox.Show(error);
                return;
            }
            Cursor.Current = Cursors.Default;
            toolStripStatusLabel.Text = "Заказ создан. " + result;

        }

        private void button_Change_Click(object sender, EventArgs e)
        {
            if (label_id.Text == "")
            {
                MessageBox.Show("Выберите заказ");
                return;
            }
            if (!IsEveryFieldCorrect())
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            int order_id = Convert.ToInt32(label_id.Text);
            string on_sale_date_str = textBox_On_sale_date.Text;
            string sale_amount_str = textBox_Sale_Amount.Text;
            DateTime on_sale_date = DateTime.Parse(on_sale_date_str);
            Decimal sale_amount = Decimal.Parse(sale_amount_str);

            int goods_id = (int)comboBox_Goods.SelectedValue;
            int client_id = (int)comboBox_Client.SelectedValue;
            int payment_method_id = (int)comboBox_Payment_Method.SelectedValue;
            int sale_type_id = (int)comboBox_Sale_Type.SelectedValue;

            string details = "";

            List<Parameter> parameters = new List<Parameter> { new Parameter("order_id", "int", order_id),
                                                                new Parameter("goods_id", "int", goods_id),
                                                                new Parameter("client_id", "int", client_id),
                                                                new Parameter("on_sale_date", "date", on_sale_date),
                                                                new Parameter("sale_amount", "num", sale_amount),
                                                                new Parameter("payment_method_id", "int", payment_method_id),
                                                                new Parameter("sale_type_id", "int", sale_type_id),
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
                error = "Smth wrong on orders update";
                MessageBox.Show(error);
                return;
            }
            Cursor.Current = Cursors.Default;
            toolStripStatusLabel.Text = "Заказ изменен. " + result;

        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (label_id.Text == "")
            {
                MessageBox.Show("Выберите заказ");
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            int order_id = Convert.ToInt32(label_id.Text);

            List<Parameter> parameters = new List<Parameter> { new Parameter("id", "int", order_id) };
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
                error = "Smth wrong on orders delete";
                MessageBox.Show(error);
                return;
            }
            Cursor.Current = Cursors.Default;
            toolStripStatusLabel.Text = "Заказ удален. " + result;
        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            GetGoods();
            GetClients();
            GetPaymentMethods();
            GetSaleTypes();
            RefreshData();
        }

        private void Form_Orders_Shown(object sender, EventArgs e)
        {
            GetGoods();
            GetClients();
            GetPaymentMethods();
            GetSaleTypes();
        }

    }
}
