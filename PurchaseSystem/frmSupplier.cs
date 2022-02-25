using PurchaseSystem.Repository;
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
    public partial class frmSupplier : Form
    {
        public frmSupplier()
        {
            InitializeComponent();
        }

        private string code;
        List<Supplier> suppliers;
        private void frmSupplier_Load(object sender, EventArgs e)
        {
            code = "";
            dgvList.AutoGenerateColumns = false;
            LoadData();
        }
        private void LoadData()
        {
            suppliers = new SupplierRepo().GetSuppliers();
            dgvList.DataSource = suppliers;
          
        }

        private void pcbAdd_Click(object sender, EventArgs e)
        {
            frmAddEditSupplier fAddEditSupplier = new frmAddEditSupplier();
            fAddEditSupplier.Action = "Add";
            fAddEditSupplier.ShowDialog(this);

             LoadData();
           
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                dgvList.CurrentRow.Selected = true;
                code = dgvList.Rows[e.RowIndex].Cells["Sid"].FormattedValue.ToString();

            }
        }

        private void pcbEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }
        private void Edit()
        {
            if (code != "")
            {
                frmAddEditSupplier fAddEditSupplier = new frmAddEditSupplier();
                fAddEditSupplier.Action = "Edit";
                fAddEditSupplier.Code = code;
                fAddEditSupplier.ShowDialog(this);

                //LoadData();
                Search();
            }
            else
            {
                MessageBox.Show("ยังไม่ได้เลือกรายการ", "Information");
            }
        }

        private void pcbDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ไม่สามารถทำการลบข้อมูลได้", "Information");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
        private void Search()
        {
            string searchValue = txtSearch.Text.ToLower();
            suppliers = new SupplierRepo().GetSuppliers();
            
            if (searchValue != "")
            {
                dgvList.DataSource = suppliers.Where(c => c.Sname.ToLower().Contains(searchValue) || c.Sid.ToLower().Contains(searchValue)).ToList();
            }
            else
            {
                dgvList.DataSource = suppliers;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Edit();
        }
    }
}
