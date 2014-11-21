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
    public struct Parameter
    {
        public string name;
        public string type;
        public object value;
        public Parameter(string name, string type, object value)
        {
            this.name = name;
            this.type = type;
            this.value = value;
        }
    };
    public struct TableColumn
    {
        public string name;
        public string type;
        public string title;
        public TableColumn(string name, string type, string title)
        {
            this.name = name;
            this.type = type;
            this.title = title;
        }
    };
    class Class_Helper
    {
        public static void SetColumns(DataTable table, DataGridView dataGridView, List <TableColumn> columns)
        {
            dataGridView.DataSource = table;
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
                    dataGridView.Columns[column.name].HeaderCell.Value = column.title;
                }
            }
        }
        public static void SetMember(DataTable table, ComboBox comboBox, List<TableColumn> columns, string displayMember, string valueMember)
        {
            comboBox.DataSource = table;
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
                comboBox.DisplayMember = displayMember;
                comboBox.ValueMember = valueMember;
            }
        }
        public static string ExecuteStoredQuery(NpgsqlConnection conn, string queryName, DataTable table, List <Parameter> parameters = null)
        {
            Stopwatch timer = new Stopwatch();
            double time = 0.0;
            string result = "";
            table.Clear();
            //////////////////////////////////
            NpgsqlCommand command = new NpgsqlCommand(queryName, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
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
            try
            {
                conn.Open();
            }
            catch
            {
                throw new Exception("Can't open a connection");
            }
            //////////////////////////////////
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
            result = Convert.ToString(table.Rows.Count) + " строк. Затрачено " + Convert.ToString(time) + " мсек.";
            return result;
        }
        public static string ExecuteFunction(NpgsqlConnection conn, string funcName, List<Parameter> parameters = null)
        {
            Stopwatch timer = new Stopwatch();
            double time = 0.0;
            string result = "";
            int rowsAffected = 0;
            //////////////////////////////////
            NpgsqlCommand command = new NpgsqlCommand(funcName, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
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
            try
            {
                conn.Open();
            }
            catch
            {
                throw new Exception("Can't open a connection");
            }
            //////////////////////////////////
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
            result = "Затрачено " + Convert.ToString(time) + " мсек.";
            return result;
        }

        public static bool IsCorrect_Date(string dateStr)
        {
            DateTime date;
            return DateTime.TryParse(dateStr, out date);
        }
        public static bool IsCorrect_String(string str)
        {
            if (str == "")
                return false;
            return true;
        }
        public static bool IsCorrect_Decimal(string decimStr)
        {
            Decimal decim;
            return Decimal.TryParse(decimStr, out decim);
        }

    }
}
