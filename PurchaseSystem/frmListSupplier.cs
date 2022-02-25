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
    public partial class frmListSupplier : Form
    {
        public string ItemSelect { get; set; }
        public frmListSupplier()
        {
            InitializeComponent();
        }

        List<Supplier> supplierList;
        private void frmListSupplier_Load(object sender, EventArgs e)
        {
            dgvList.AutoGenerateColumns = false;
            LoadData();
        }
        private void LoadData()
        {
            supplierList = new SupplierRepo().GetSuppliers();
            dgvList.DataSource = supplierList;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void Search()
        {
            string searchText = txtSearch.Text.ToLower();
            if (searchText != "")
            {
                dgvList.DataSource = supplierList.Where(c => c.Sid.Contains(searchText) || c.Sname.ToLower().Contains(searchText)).ToList();
            }
            else
            {
                LoadData();
            }
        }

        //private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        Search();
        //    }
        //}



        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                dgvList.CurrentRow.Selected = true;
                ItemSelect = dgvList.Rows[e.RowIndex].Cells["Sid"].Value.ToString();

                this.Close();
            }
        }

        //private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        //{
             
        //        Search();
 
        //}

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            Search();
        }
    }
}
