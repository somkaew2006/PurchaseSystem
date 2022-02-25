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
    public partial class frmListCustomer : Form
    {
        public string ItemSelect { get; set; }
        public frmListCustomer()
        {
            InitializeComponent();
        }

        List<Customer> customerList;
        private void frmListCustomer_Load(object sender, EventArgs e)
        {
            dgvList.AutoGenerateColumns = false;
            LoadData();
        }

        private void LoadData()
        {
            customerList = new CustomerRepo().GetCustomers();
            dgvList.DataSource = customerList;
        }
        private void Search()
        {
            string searchText = txtSearch.Text.ToLower();
            if (searchText != "")
            {
                dgvList.DataSource = customerList.Where(c=>c.Cname.ToLower().Contains(searchText)).ToList();
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
                ItemSelect = dgvList.Rows[e.RowIndex].Cells["Cid"].Value.ToString();

                this.Close();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}
