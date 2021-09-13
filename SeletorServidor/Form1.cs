using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeletorServidor
{
    public partial class frmSelServidor : Form
    {
        public frmSelServidor()
        {
            InitializeComponent();
        }

        private void btnSairSelServidor_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
