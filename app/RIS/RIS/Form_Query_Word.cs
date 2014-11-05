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
        NpgsqlConnection conn;

        public Form_Query_Word(NpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            dataGridView_Data.AutoGenerateColumns = true;
        }

        private void button_GetFirmList_Click(object sender, EventArgs e)
        {
            Stopwatch timer = new Stopwatch();

            DataSet dataSet = new DataSet();
            System.Data.DataTable table = new System.Data.DataTable();

            string query = "SELECT * FROM (" +
	                       "     SELECT * " +
                           "     FROM public.dblink ('dbname=risbd6 host=students.ami.nstu.ru port=5432 user=risbd6 password=ris14bd6', " +
                           "     'SELECT sa.companies.id, sa.companies.name" +
                           " FROM sa.companies' ) as companies (id integer, name text)" +
                           " UNION" +
                           " SELECT sb.companies.id, sb.companies.name" + 
                           " FROM sb.companies) a" + 
                           " ORDER BY 2";

            NpgsqlCommand command = new NpgsqlCommand(query, conn);

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

        private bool checkIsDate(string str)
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
            System.Data.DataTable table = new System.Data.DataTable();
            System.Data.DataTable tableFirm = new System.Data.DataTable();

            string from = textBox_From.Text;
            string to = textBox_To.Text;

            if (!checkIsDate(from) || !checkIsDate(to))
            {
                MessageBox.Show("Incorrect");
                return;
            }

            string tmp = "select count(*) from sb.companies a where a.id = :id";
            NpgsqlCommand tmpcommand = new NpgsqlCommand(tmp, conn);
            tmpcommand.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(comboBox_Firms.SelectedValue);
            
            string query, firm;
            if ((long)tmpcommand.ExecuteScalar() == 0)
            {
                var cmd = new Npgsql.NpgsqlCommand("query82", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(comboBox_Firms.SelectedValue);
                NpgsqlDataAdapter da0 = new NpgsqlDataAdapter(cmd);
                da0.Fill(tableFirm);
                dataGridView_Firm.DataSource = tableFirm;

                var cmd1 = new Npgsql.NpgsqlCommand("query83", conn);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                cmd1.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(comboBox_Firms.SelectedValue);
                cmd1.Parameters.Add("from", NpgsqlTypes.NpgsqlDbType.Date).Value = DateTime.Parse(from);
                cmd1.Parameters.Add("to", NpgsqlTypes.NpgsqlDbType.Date).Value = DateTime.Parse(to);
                timer.Start();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd1);
                da.Fill(table);
                dataGridView_Data.DataSource = table;
                timer.Stop();
            }
            else
            {
                firm = "SELECT sb.companies.name, sb.countries.name as country, head_full_name, phone, address, bank_details  " +
                        "FROM sb.companies " +
                        "JOIN sb.countries ON sb.countries.id = sb.companies.country_id " +
                        "WHERE sb.companies.id = :id";
                query = "SELECT sb.categories.title, good.model, sb.payment_methods.title, sum(sale_amount) " +
                        "FROM (SELECT id, category_id, model FROM sb.goods_main WHERE company_id = :id) as good " +
                        "JOIN sb.categories ON sb.categories.id = good.category_id " +
                        "JOIN sb.orders_main ON sb.orders_main.goods_id = good.id " +
                        "JOIN sb.payment_methods ON sb.payment_methods.id = sb.orders_main.payment_method_id  " +
                        "WHERE on_sale_date BETWEEN :from and :to " +
                        "GROUP BY sb.categories.title, good.model, sb.payment_methods.title " +
                        "ORDER BY 4 DESC, 1 ASC ";
                NpgsqlCommand commandFirm = new NpgsqlCommand(firm, conn);
                commandFirm.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(comboBox_Firms.SelectedValue);
                NpgsqlDataAdapter da1 = new NpgsqlDataAdapter(commandFirm);
                da1.Fill(tableFirm);
                dataGridView_Firm.DataSource = tableFirm;
                NpgsqlCommand command = new NpgsqlCommand(query, conn);
                command.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(comboBox_Firms.SelectedValue);
                command.Parameters.Add("from", NpgsqlTypes.NpgsqlDbType.Date).Value = DateTime.Parse(from);
                command.Parameters.Add("to", NpgsqlTypes.NpgsqlDbType.Date).Value = DateTime.Parse(to);
                timer.Start();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
                da.Fill(table);
                dataGridView_Data.DataSource = table;
                timer.Stop();
            }

            double time = timer.ElapsedMilliseconds;
            toolStripStatusLabel.Text = Convert.ToString(table.Rows.Count) + " строк. Затрачено " + Convert.ToString(time) + " мсек.";
        }

        private void button_GetWordReport_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word.Application wordApp;
            wordApp = new Microsoft.Office.Interop.Word.Application();
            wordApp.Visible = true;
            Paragraph wordParagraph;
            Paragraphs wordParagraphs;
            Document doc = new Document();
            doc = wordApp.Documents.Add();
            wordParagraphs = doc.Paragraphs;
            wordParagraph = (Paragraph)wordParagraphs[1];
            //Меняем характеристики текста и параграфа
            wordParagraph.Range.Font.Size = 14;
            wordParagraph.Range.Font.Name = "Times New Roman";
            wordParagraph.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;

            wordParagraph.Range.Text = "Фирма: " + dataGridView_Firm.Rows[0].Cells[0].Value;
            doc.Paragraphs.Add();
            wordParagraph.Range.Text = "Страна: " + dataGridView_Firm.Rows[0].Cells[1].Value;
            doc.Paragraphs.Add();
            wordParagraph.Range.Text = "Директор: " + dataGridView_Firm.Rows[0].Cells[2].Value;
            doc.Paragraphs.Add();
            wordParagraph.Range.Text = "Телефон: " + dataGridView_Firm.Rows[0].Cells[3].Value;
            doc.Paragraphs.Add();
            wordParagraph.Range.Text = "Адрес: " + dataGridView_Firm.Rows[0].Cells[4].Value;
            doc.Paragraphs.Add();
            wordParagraph.Range.Text = "Банковские реквизиты: " + dataGridView_Firm.Rows[0].Cells[5].Value;

            doc.Paragraphs.Add();
            Table wordtable = doc.Tables.Add(wordParagraph.Range, dataGridView_Data.Rows.Count + 1, dataGridView_Data.ColumnCount);
            Range wordCellRange;

            for (int i = 0; i < dataGridView_Data.ColumnCount; i++)
            {
                wordCellRange = wordtable.Cell(1, i + 1).Range;
                wordCellRange.Text = dataGridView_Data.Columns[i].HeaderText;
            }

            for (int i = 0; i < dataGridView_Data.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView_Data.ColumnCount; j++)
                {
                    wordCellRange = wordtable.Cell(i + 2, j + 1).Range;
                    wordCellRange.Text = dataGridView_Data.Rows[i].Cells[j].Value.ToString();
                }
            }
        }
    }
}
