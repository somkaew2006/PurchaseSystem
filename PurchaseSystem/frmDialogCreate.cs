using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PurchaseSystem
{
    public partial class frmDialogCreate : Form
    {
        public frmDialogCreate()
        {
            InitializeComponent();
        }
        public string Code { get; set; }
        private void frmDialogCreate_Load(object sender, EventArgs e)
        {
            lblCode.Text = Code;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
