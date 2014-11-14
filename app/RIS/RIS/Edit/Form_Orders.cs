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
        NpgsqlConnection conn;
        public Form_Orders(NpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }
    }
}
