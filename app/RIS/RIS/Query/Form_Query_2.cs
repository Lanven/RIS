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
    public partial class Form_Query_2 : Form
    {
        private string connStr;//строка подключения
        private NpgsqlConnection conn;//подключение
        //таблица, запрос и колонки для грида
        private DataTable table;
        private string queryName = "query02";
        List <TableColumn> columns = new List<TableColumn> {new TableColumn("sale_date", "date", "Дата продажи"),
                                                            new TableColumn("category", "text", "Категория"),
                                                            new TableColumn("company", "text", "Компания"),
                                                            new TableColumn("modell", "text", "Модель"),
                                                            new TableColumn("country", "text", "Страна"),
                                                            new TableColumn("payment_method", "text", "Способ оплаты"),
                                                            new TableColumn("sale_type", "text", "Тип продажи"),
                                                            new TableColumn("summa", "num", "Сумма")};
        //создание формы       
        public Form_Query_2(string connStr)
        {
            InitializeComponent();
            this.connStr = connStr;
            this.conn = new NpgsqlConnection(connStr);
            //инициализация грида
            this.table = new DataTable();
            try
            {
                Class_Helper.SetColumns(table, dataGridView_Orders, columns);
            }
            catch (Exception ex)
            { 
                throw new Exception("Can't init datagrid: " + ex.Message);
            }
        }
        //кнопка запроса
        //получение с формы необходимых параметров для запроса
        //составление списка параметров
        //выполнение запроса
        private void button_Get_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int month = (int)numericUpDown_Month.Value;

            List<Parameter> parameters = new List<Parameter> { new Parameter("month", "int", month) };

            string result = "";
            try
            {
                result = Class_Helper.ExecuteStoredQuery(conn, queryName, table, parameters);
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
    }
}
