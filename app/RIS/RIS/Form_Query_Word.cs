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
using Microsoft.Office.Interop.Word;

namespace RIS
{
    public partial class Form_Query_Word : Form
    {
        private string connStr;//строка подключения
        private NpgsqlConnection conn;//подключение

        //для комбобокса Список фирм 
        private System.Data.DataTable tableFirms;
        private string queryFirms = "query81";
        List<TableColumn> members = new List<TableColumn> {new TableColumn("name", "text", "Название"),
                                                           new TableColumn("id", "int", "ИД")};
        //для грида Инфо о компании
        private System.Data.DataTable tableInfo;
        private string queryInfo = "query82";
        List<TableColumn> columnsInfo = new List<TableColumn> {new TableColumn("company_name", "text", "Компания"),
                                                               new TableColumn("country_name", "text", "Страна"),
                                                               new TableColumn("head_full_nam", "text", "Директор"),
                                                               new TableColumn("phon", "text", "Телефон"),
                                                               new TableColumn("addres", "text", "Адрес"),
                                                               new TableColumn("bank_detail", "text", "Реквизиты")};
        //для грида Данные компании
        private System.Data.DataTable tableData;
        private string queryData = "query83";
        List<TableColumn> columnsData = new List<TableColumn> {new TableColumn("category", "text", "Категория"),
                                                               new TableColumn("modell", "text", "Модель"),
                                                               new TableColumn("payment_method", "text", "Метод оплаты"),
                                                               new TableColumn("summ", "num", "Сумма")};
        //инициализация формы
        public Form_Query_Word(string connStr)
        {
            InitializeComponent();
            this.connStr = connStr;
            this.conn = new NpgsqlConnection(connStr);
            //инициализация гридов и комбобокса
            this.tableFirms = new System.Data.DataTable();
            this.tableInfo = new System.Data.DataTable();
            this.tableData = new System.Data.DataTable();
            try
            {
                Class_Helper.SetColumns(tableData, dataGridView_Data, columnsData);
                Class_Helper.SetColumns(tableInfo, dataGridView_Firm, columnsInfo);
                Class_Helper.SetMember(tableFirms, comboBox_Firms, members, "name", "id");
            }
            catch (Exception ex)
            {
                throw new Exception("Can't init datagrid/combobox: " + ex.Message);
            }        

        }
        //получение Списка фирм
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
            toolStripStatusLabel_1.Text = result;
        }
        //кнопка Фирмы
        private void button_GetFirmList_Click(object sender, EventArgs e)
        {
            getFirmList();
        }
        //проверка, является ли строка датой
        private bool IsDate(string str)
        {
            DateTime myDate;
            if (DateTime.TryParse(str, out myDate))
                return true;
            return false;
        }
        //кнопка Просмотр
        private void button_GetLook_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //ид фирмы
            if (comboBox_Firms.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите фирму");
                return;
            }
            int firmID = Convert.ToInt32(comboBox_Firms.SelectedValue);
            //даты и проверка
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
            //запрос для получения Инфо о фирме
            List<Parameter> parametersInfo = new List<Parameter> { new Parameter("id", "int", firmID)};
            string resultInfo = "";
            try
            {
                resultInfo = Class_Helper.ExecuteStoredQuery(conn, queryInfo, tableInfo, parametersInfo);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;
            }

            toolStripStatusLabel_1.Text = resultInfo;

            ////////////////////////////////////
            //запрос для получения Данных фирмы
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
            toolStripStatusLabel_2.Text = result;
        }
        //вывод данных в Ворд
        private void button_GetWordReport_Click(object sender, EventArgs e)
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
            Microsoft.Office.Interop.Word.Application wordApp;
            object objStart, objEnd;
            Range rngBold;
            wordApp = new Microsoft.Office.Interop.Word.Application();
            
            Paragraph wordParagraph;
            Paragraphs wordParagraphs;
            Document doc = new Document();
            doc = wordApp.Documents.Add();
            wordParagraphs = doc.Paragraphs;
            wordParagraph = (Paragraph)wordParagraphs[1];

            //задание стиля шапки
            wordParagraph.Range.Paragraphs.SpaceAfter = 0;//междустрочный
            wordParagraph.Range.Font.Size = 14;//размер шрифта
            wordParagraph.Range.Font.Name = "Times New Roman";//шрифт
            wordParagraph.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;//выравнивание

            //вывод пункта, значения, выделение названия пункта жирным шрифтом, новый абзац
            wordParagraph.Range.Text = "Фирма: " + dataGridView_Firm.Rows[0].Cells[0].Value;
            objStart = wordParagraph.Range.Start;
            objEnd = wordParagraph.Range.Start + wordParagraph.Range.Text.IndexOf(":");
            rngBold = doc.Range(ref objStart, ref objEnd);
            rngBold.Bold = 1;
            doc.Paragraphs.Add();

            wordParagraph.Range.Text = "Страна: " + dataGridView_Firm.Rows[0].Cells[1].Value;
            objStart = wordParagraph.Range.Start;
            objEnd = wordParagraph.Range.Start + wordParagraph.Range.Text.IndexOf(":");
            rngBold = doc.Range(ref objStart, ref objEnd);
            rngBold.Bold = 1;
            doc.Paragraphs.Add();

            wordParagraph.Range.Text = "Директор: " + dataGridView_Firm.Rows[0].Cells[2].Value;
            objStart = wordParagraph.Range.Start;
            objEnd = wordParagraph.Range.Start + wordParagraph.Range.Text.IndexOf(":");
            rngBold = doc.Range(ref objStart, ref objEnd);
            rngBold.Bold = 1;
            doc.Paragraphs.Add();

            wordParagraph.Range.Text = "Телефон: " + dataGridView_Firm.Rows[0].Cells[3].Value;
            objStart = wordParagraph.Range.Start;
            objEnd = wordParagraph.Range.Start + wordParagraph.Range.Text.IndexOf(":");
            rngBold = doc.Range(ref objStart, ref objEnd);
            rngBold.Bold = 1;
            doc.Paragraphs.Add();

            wordParagraph.Range.Text = "Адрес: " + dataGridView_Firm.Rows[0].Cells[4].Value;
            objStart = wordParagraph.Range.Start;
            objEnd = wordParagraph.Range.Start + wordParagraph.Range.Text.IndexOf(":");
            rngBold = doc.Range(ref objStart, ref objEnd);
            rngBold.Bold = 1;
            doc.Paragraphs.Add();

            wordParagraph.Range.Text = "Банковские реквизиты: " + dataGridView_Firm.Rows[0].Cells[5].Value;
            objStart = wordParagraph.Range.Start;
            objEnd = wordParagraph.Range.Start + wordParagraph.Range.Text.IndexOf(":");
            rngBold = doc.Range(ref objStart, ref objEnd);
            rngBold.Bold = 1;
            doc.Paragraphs.Add();
            doc.Paragraphs.Add();

            //создание таблицы
            wordParagraph.Range.Font.Size = 10;
            Table wordtable = doc.Tables.Add(wordParagraph.Range, dataGridView_Data.Rows.Count + 1, dataGridView_Data.ColumnCount);
            //задание стиля границ
            wordtable.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
            wordtable.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleDouble;
            wordtable.Range.Paragraphs.SpaceAfter = 0;
            Range wordCellRange;
            //шапка таблицы
            for (int i = 0; i < dataGridView_Data.ColumnCount; i++)
            {
                wordCellRange = wordtable.Cell(1, i + 1).Range;
                wordCellRange.Text = dataGridView_Data.Columns[i].HeaderText;
            }
            wordtable.Rows[1].Range.Font.Bold = 1;
            //заполнение данными
            for (int i = 0; i < dataGridView_Data.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView_Data.ColumnCount; j++)
                {
                    wordCellRange = wordtable.Cell(i + 2, j + 1).Range;
                    wordCellRange.Text = dataGridView_Data.Rows[i].Cells[j].Value.ToString();
                }
            }

            wordApp.Visible = true;//показать юзеру составленный документ
        }
    }
}
