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
using System.Globalization;
using Microsoft.Office.Interop.Excel;

namespace RIS
{
    public partial class Form_Query_Excel : Form
    {
        private string connStr;//строка подключения
        private NpgsqlConnection conn;//подключение
        private System.Data.DataTable tableFirms;//таблица для комбобокса "Список фирм"
        private string queryFirms = "query91";//запрос для получения списка фирм
        //колонки в таблице
        List<TableColumn> members = new List<TableColumn> {new TableColumn("name", "text", "Название"),
                                                           new TableColumn("id", "int", "ИД")};
        private System.Data.DataTable tableData;//таблица для грида "Данные о фирме"
        private string queryData = "query92";//запрос для получения данных
        //колонки в таблице
        List<TableColumn> columns = new List<TableColumn> {new TableColumn("surnam", "text", "Фамилия"),
                                                           new TableColumn("nam", "text", "Имя"),
                                                           new TableColumn("patronymi", "text", "Отчество"),
                                                           new TableColumn("birthdat", "date", "Дата рождения"),
                                                           new TableColumn("passport_serie", "text", "Серия паспорта"),
                                                           new TableColumn("passport_numbe", "text", "Номер паспорта"),
                                                           new TableColumn("summ", "num", "Сумма")};
       //Инициализация формы
        public Form_Query_Excel(string connStr)
        {
            InitializeComponent();
            this.connStr = connStr;
            this.conn = new NpgsqlConnection(connStr);

            //инициализация комбобокса и грида
            this.tableFirms = new System.Data.DataTable();
            this.tableData = new System.Data.DataTable();
            try
            {
                Class_Helper.SetColumns(tableData, dataGridView_Data, columns);
                Class_Helper.SetMember(tableFirms, comboBox_Firms, members, "name", "id");
            }
            catch (Exception ex)
            {
                throw new Exception("Can't init datagrid/combobox: " + ex.Message);
            }        
        }
        //получение списка фирм
        private void getFirmList()
        {
            Cursor.Current = Cursors.WaitCursor;
            string result = "";
            try
            {
                result = Class_Helper.ExecuteStoredQuery(conn, queryFirms, tableFirms);
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
        //нажатие Фирмы для получения списка фирм
        private void button_GetFirmList_Click(object sender, EventArgs e)
        {
            getFirmList();
        }
        //является ли строка записью даты
        private bool IsDate(string str)
        {
            DateTime myDate;
            if (DateTime.TryParse(str, out myDate))
                return true;
            return false;
        }
        //получить данные о выбранной фирме
        private void button_GetLook_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //ид фирмы из списка
            if (comboBox_Firms.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите фирму");
                return;
            }
            int firmID = Convert.ToInt32(comboBox_Firms.SelectedValue);
            //введенные даты и проверка
            string fromStr = maskedTextBox_From.Text;
            string toStr = maskedTextBox_To.Text;

            if (!IsDate(fromStr) || !IsDate(toStr))
            {
                MessageBox.Show("Неверные даты");
                return;
            }
            DateTime from = DateTime.Parse(fromStr);
            DateTime to = DateTime.Parse(toStr);
            /**************************************/
            label5.Text = fromStr;
            label6.Text = toStr;
            label7.Text = ((System.Data.DataRowView)comboBox_Firms.SelectedItem).Row["name"].ToString();
            /**************************************/
            //запрос для получения данных
            List<Parameter> parameters = new List<Parameter> { new Parameter("id", "int", firmID),
                                                                new Parameter("from", "date", from),
                                                                new Parameter("to", "date", to)};
            string result = "";
            try
            {
                result = Class_Helper.ExecuteStoredQuery(conn, queryData, tableData, parameters);
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
        //Вывести данные в отчет Excel
        private void button_GetExcelReport_Click(object sender, EventArgs e)
        {
            string from = label5.Text;
            string to = label6.Text;
            string name = label7.Text;

            if (name == "")
            {
                MessageBox.Show("Пожалуйста, введите данные и нажмите просмотр");
                return;
            }
            //создание документа
            Microsoft.Office.Interop.Excel.Application excelApp;
            excelApp = new Microsoft.Office.Interop.Excel.Application();

            Workbook excelWorkBook;
            Worksheet excelWorkSheet;
            excelWorkBook = excelApp.Workbooks.Add();
            excelWorkSheet = (Worksheet)excelWorkBook.Worksheets[1];
            //сосавление заголовка
            excelApp.Cells[1, 1] = "Фирма:";
            excelWorkSheet.Cells[1, 1].Font.Bold = true;//жирный шрифт
            excelWorkSheet.Range["B1:G1"].Merge();//объеденить ячейки
            excelApp.Cells[1, 2] = name;
            excelWorkSheet.Cells[1, 2].Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;//выравнивание по центру
            excelWorkSheet.Cells[1, 2].Font.Bold = true;
            excelWorkSheet.Cells[1, 2].Font.Size = 16;//размер шрифта

            excelApp.Cells[2, 1] = "Период:";
            excelWorkSheet.Cells[2, 1].Font.Bold = true;
            excelApp.Cells[2, 2] = from;
            excelApp.Cells[2, 3] = to;
            
            //создание таблицы с данными
            int num = 4;
            for (int i = 0; i < dataGridView_Data.ColumnCount; i++)
            {
                excelApp.Cells[num, i + 1] = dataGridView_Data.Columns[i].HeaderText;
            }
            excelWorkSheet.Cells[num, 1].EntireRow.Font.Bold = true; 
            num++;

            for (int i = 0; i < dataGridView_Data.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView_Data.ColumnCount; j++)
                {
                    excelApp.Cells[num + i, j + 1] = dataGridView_Data.Rows[i].Cells[j].Value;
                }
            }
            //обводка полученной таблицы
            //выравнивание ширины
            excelWorkSheet.Range["A4:G" + Convert.ToString(dataGridView_Data.Rows.Count + num - 1)].Borders.LineStyle = XlLineStyle.xlContinuous;
            excelWorkSheet.Range["A4:G" + Convert.ToString(dataGridView_Data.Rows.Count + num - 1)].Columns.AutoFit();
            //excelApp.Columns.AutoFit();
            excelApp.Visible = true;//показать юзеру полученный документ
        }
    }
}
