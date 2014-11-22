using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Diagnostics;

namespace RIS
{
    //структура для элемента параметра
    public struct Parameter
    {
        public string name;//имя
        public string type;//тип
        public object value;//значение
        public Parameter(string name, string type, object value)
        {
            this.name = name;
            this.type = type;
            this.value = value;
        }
    };
    //структура для колонки таблицы
    public struct TableColumn
    {
        public string name;//имя
        public string type;//тип
        public string title;//отображаемое навание
        public TableColumn(string name, string type, string title)
        {
            this.name = name;
            this.type = type;
            this.title = title;
        }
    };
    class Class_Helper
    {
        //связывание DataTable для DatagridView
        public static void SetColumns(DataTable table, DataGridView dataGridView, List <TableColumn> columns)
        {
            dataGridView.DataSource = table;//связывание таблицы и грида
            //создание колонок в таблице
            if (columns != null)
            {
                foreach (var column in columns)
                {
                    switch (column.type)
                    {
                        case "int":
                            table.Columns.Add(column.name, typeof(System.Int32));
                            break;
                        case "text":
                            table.Columns.Add(column.name, typeof(System.String));
                            break;
                        case "date":
                            table.Columns.Add(column.name, typeof(System.DateTime));
                            break;
                        case "num":
                            table.Columns.Add(column.name, typeof(System.Decimal));
                            break;
                        default:
                            throw new Exception("Unknown parameter type");
                    }
                    //задание отображаемых имен в гриде
                    dataGridView.Columns[column.name].HeaderCell.Value = column.title;
                }
            }
        }
        //связывание DataTable и ComboBox
        public static void SetMember(DataTable table, ComboBox comboBox, List<TableColumn> columns, string displayMember, string valueMember)
        {
            comboBox.DataSource = table;//связывание таблицы и комбобокса
            //задание колонок в таблице
            if (columns != null)
            {
                foreach (var column in columns)
                {
                    switch (column.type)
                    {
                        case "int":
                            table.Columns.Add(column.name, typeof(System.Int32));
                            break;
                        case "text":
                            table.Columns.Add(column.name, typeof(System.String));
                            break;
                        case "date":
                            table.Columns.Add(column.name, typeof(System.DateTime));
                            break;
                        case "num":
                            table.Columns.Add(column.name, typeof(System.Decimal));
                            break;
                        default:
                            throw new Exception("Unknown parameter type");
                    }
                }
                //задание отображаемого и связанного значений в комбобоксе
                comboBox.DisplayMember = displayMember;
                comboBox.ValueMember = valueMember;
            }
        }
        //выполнение хранимого запроса
        public static string ExecuteStoredQuery(NpgsqlConnection conn, string queryName, DataTable table, List <Parameter> parameters = null)
        {
            Stopwatch timer = new Stopwatch();
            double time = 0.0;
            string result = "";
            table.Clear();
            //////////////////////////////////
            NpgsqlCommand command = new NpgsqlCommand(queryName, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            //заполнение параметров
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    switch (param.type)
                    {
                        case "int":
                            command.Parameters.Add(param.name, NpgsqlTypes.NpgsqlDbType.Integer).Value = (int)param.value;
                            break;
                        case "text":
                            command.Parameters.Add(param.name, NpgsqlTypes.NpgsqlDbType.Text).Value = (string)param.value;
                            break;
                        case "date":
                            command.Parameters.Add(param.name, NpgsqlTypes.NpgsqlDbType.Date).Value = (DateTime)param.value;
                            break;
                        case "num":
                            command.Parameters.Add(param.name, NpgsqlTypes.NpgsqlDbType.Numeric).Value = (decimal)param.value;
                            break;
                        default:
                            throw new Exception("Unknown parameter type");
                    }
                }
            }
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(command);
            //////////////////////////////////
            //открыть соединение
            try
            {
                conn.Open();
            }
            catch
            {
                throw new Exception("Can't open a connection");
            }
            //////////////////////////////////
            //выполнение запроса - данные записываются в таблицу
            try
            {
                timer.Start();
                dataAdapter.Fill(table);
                timer.Stop();
            }
            catch 
            {
                conn.Close();
                throw new Exception("Something has gone wrong on executing query '" + queryName + "'");
            }
            conn.Close();
            time = timer.ElapsedMilliseconds;
            //возвратить строку результат
            result = Convert.ToString(table.Rows.Count) + " строк. Затрачено " + Convert.ToString(time) + " мсек.";
            return result;
        }
        //выполнение хранимой функции
        public static string ExecuteFunction(NpgsqlConnection conn, string funcName, List<Parameter> parameters = null)
        {
            Stopwatch timer = new Stopwatch();
            double time = 0.0;
            string result = "";
            int rowsAffected = 0;
            //////////////////////////////////
            NpgsqlCommand command = new NpgsqlCommand(funcName, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            //заполнение параметров
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    switch (param.type)
                    {
                        case "int":
                            command.Parameters.Add(param.name, NpgsqlTypes.NpgsqlDbType.Integer).Value = (int)param.value;
                            break;
                        case "text":
                            command.Parameters.Add(param.name, NpgsqlTypes.NpgsqlDbType.Text).Value = (string)param.value;
                            break;
                        case "date":
                            command.Parameters.Add(param.name, NpgsqlTypes.NpgsqlDbType.Date).Value = (DateTime)param.value;
                            break;
                        case "num":
                            command.Parameters.Add(param.name, NpgsqlTypes.NpgsqlDbType.Numeric).Value = (decimal)param.value;
                            break;
                        default:
                            throw new Exception("Unknown parameter type");
                    }
                }
            }
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(command);
            //////////////////////////////////
            //открыть соединение
            try
            {
                conn.Open();
            }
            catch
            {
                throw new Exception("Can't open a connection");
            }
            //////////////////////////////////
            //запрос - выолнение функции
            try
            {
                timer.Start();
                rowsAffected = command.ExecuteNonQuery();
                timer.Stop();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw;
                //throw new Exception("Something has gone wrong on executing '" + funcName + "'");
            }
            conn.Close();
            time = timer.ElapsedMilliseconds;
            //result = Convert.ToString(rowsAffected) + " строк. Затрачено " + Convert.ToString(time) + " мсек.";
            //вернуть строку результат
            result = "Затрачено " + Convert.ToString(time) + " мсек.";
            return result;
        }
        //проверка является ли строка датой
        public static bool IsCorrect_Date(string dateStr)
        {
            DateTime date;
            return DateTime.TryParse(dateStr, out date);
        }
        //проверка корректна ли строка (не пуста)
        public static bool IsCorrect_String(string str)
        {
            if (str == "")
                return false;
            return true;
        }
        //провека является ли строка дробным числом
        public static bool IsCorrect_Decimal(string decimStr)
        {
            Decimal decim;
            return Decimal.TryParse(decimStr, out decim);
        }
    }
}
