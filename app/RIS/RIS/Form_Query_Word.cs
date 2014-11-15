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
        private string connStr;
        private NpgsqlConnection conn;

        public Form_Query_Word(string connStr)
        {
            InitializeComponent();
            this.connStr = connStr;
            this.conn = new NpgsqlConnection(connStr);
            try
            {
                conn.Open();
            }
            catch
            {
                MessageBox.Show("Something wrong with connection");
                this.Close();
            }

            getFirmList();
            dataGridView_Data.AutoGenerateColumns = true;
        }

        private void getFirmList()
        {
            Stopwatch timer = new Stopwatch();
            System.Data.DataTable table = new System.Data.DataTable();

            NpgsqlCommand command = new NpgsqlCommand("query81", conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            timer.Start();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);

            da.Fill(table);

            comboBox_Firms.DataSource = table;
            comboBox_Firms.DisplayMember = "name";
            comboBox_Firms.ValueMember = "id";
            timer.Stop();
            double time = timer.ElapsedMilliseconds;
            toolStripStatusLabel.Text = Convert.ToString(table.Rows.Count) + " строк. Затрачено " + Convert.ToString(time) + " мсек.";
        }

        private void button_GetFirmList_Click(object sender, EventArgs e)
        {
            getFirmList();
        }

        private bool IsDate(string str)
        {
            DateTime myDate;
            if (DateTime.TryParse(str, out myDate))
                return true;
            return false;
        }
        
        private void button_GetLook_Click(object sender, EventArgs e)
        {
            Stopwatch timer = new Stopwatch();
            DataSet dataSet = new DataSet();
            System.Data.DataTable tableData = new System.Data.DataTable();
            System.Data.DataTable tableFirm = new System.Data.DataTable();

            string from = textBox_From.Text;
            string to = textBox_To.Text;

            if (!IsDate(from) || !IsDate(to))
            {
                MessageBox.Show("Incorrect dates");
                return;
            }

            string tmp = "select count(*) from sb.companies a where a.id = :id";
            NpgsqlCommand tmpcmd = new NpgsqlCommand(tmp, conn);
            tmpcmd.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(comboBox_Firms.SelectedValue);
            
            if ((long)tmpcmd.ExecuteScalar() == 0)
            {
                var cmdFirm = new Npgsql.NpgsqlCommand("query82dblink", conn);
                cmdFirm.CommandType = System.Data.CommandType.StoredProcedure;
                cmdFirm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(comboBox_Firms.SelectedValue);
                NpgsqlDataAdapter daFirm = new NpgsqlDataAdapter(cmdFirm);
                daFirm.Fill(tableFirm);
                dataGridView_Firm.DataSource = tableFirm;


                var cmdData = new Npgsql.NpgsqlCommand("query83dblink", conn);
                cmdData.CommandType = System.Data.CommandType.StoredProcedure;
                cmdData.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(comboBox_Firms.SelectedValue);
                cmdData.Parameters.Add("from", NpgsqlTypes.NpgsqlDbType.Date).Value = DateTime.Parse(from);
                cmdData.Parameters.Add("to", NpgsqlTypes.NpgsqlDbType.Date).Value = DateTime.Parse(to);
                timer.Start();
                NpgsqlDataAdapter daData = new NpgsqlDataAdapter(cmdData);
                daData.Fill(tableData);
                dataGridView_Data.DataSource = tableData;
                timer.Stop();
            }
            else
            {
                NpgsqlCommand cmdFirm = new NpgsqlCommand("query82", conn);
                cmdFirm.CommandType = System.Data.CommandType.StoredProcedure;
                cmdFirm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(comboBox_Firms.SelectedValue);
                NpgsqlDataAdapter daFirm = new NpgsqlDataAdapter(cmdFirm);
                daFirm.Fill(tableFirm);
                dataGridView_Firm.DataSource = tableFirm;
                NpgsqlCommand cmdData = new NpgsqlCommand("query83", conn);
                cmdData.CommandType = System.Data.CommandType.StoredProcedure;
                cmdData.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(comboBox_Firms.SelectedValue);
                cmdData.Parameters.Add("from", NpgsqlTypes.NpgsqlDbType.Date).Value = DateTime.Parse(from);
                cmdData.Parameters.Add("to", NpgsqlTypes.NpgsqlDbType.Date).Value = DateTime.Parse(to);
                timer.Start();
                NpgsqlDataAdapter daData = new NpgsqlDataAdapter(cmdData);
                daData.Fill(tableData);
                dataGridView_Data.DataSource = tableData;
                timer.Stop();
            }
            dataGridView_Firm.Columns["company_name"].HeaderCell.Value = "Компания";
            dataGridView_Firm.Columns["country_name"].HeaderCell.Value = "Страна";
            dataGridView_Firm.Columns["head_full_nam"].HeaderCell.Value = "Директор";
            dataGridView_Firm.Columns["phon"].HeaderCell.Value = "Телефон";
            dataGridView_Firm.Columns["addres"].HeaderCell.Value = "Адрес";
            dataGridView_Firm.Columns["bank_detail"].HeaderCell.Value = "Реквизиты";

            dataGridView_Data.Columns["category"].HeaderCell.Value = "Категория";
            dataGridView_Data.Columns["modell"].HeaderCell.Value = "Модель";
            dataGridView_Data.Columns["payment_method"].HeaderCell.Value = "Метод оплаты";
            dataGridView_Data.Columns["summ"].HeaderCell.Value = "Сумма";

            double time = timer.ElapsedMilliseconds;
            toolStripStatusLabel.Text = Convert.ToString(tableData.Rows.Count) + " строк. Затрачено " + Convert.ToString(time) + " мсек.";
        }

        private void button_GetWordReport_Click(object sender, EventArgs e)
        {
            if (dataGridView_Firm.RowCount == 0)
            {
                MessageBox.Show("Пожалуйста, выберите фирму и нажмите просмотр");
                return;
            }
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
            
            wordParagraph.Range.Font.Size = 14;
            wordParagraph.Range.Font.Name = "Times New Roman";
            wordParagraph.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;

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

            wordParagraph.Range.Font.Size = 10;
            Table wordtable = doc.Tables.Add(wordParagraph.Range, dataGridView_Data.Rows.Count + 1, dataGridView_Data.ColumnCount);
            wordtable.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
            wordtable.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleDouble;
            wordtable.Range.Paragraphs.SpaceAfter = 0;
            Range wordCellRange;

            for (int i = 0; i < dataGridView_Data.ColumnCount; i++)
            {
                wordCellRange = wordtable.Cell(1, i + 1).Range;
                wordCellRange.Text = dataGridView_Data.Columns[i].HeaderText;
            }
            wordtable.Rows[1].Range.Font.Bold = 1;

            for (int i = 0; i < dataGridView_Data.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView_Data.ColumnCount; j++)
                {
                    wordCellRange = wordtable.Cell(i + 2, j + 1).Range;
                    wordCellRange.Text = dataGridView_Data.Rows[i].Cells[j].Value.ToString();
                }
            }

            wordApp.Visible = true;
        }

        private void Form_Query_Word_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }

        private void comboBox_Firms_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }
    }
}
