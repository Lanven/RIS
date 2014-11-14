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
        NpgsqlConnection conn;
        public Form_Goods(NpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }
    }
}
