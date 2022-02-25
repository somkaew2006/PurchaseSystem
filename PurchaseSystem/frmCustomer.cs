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
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }
        private string code;
        List<Customer> customers;
        private void frmCustomer_Load(object sender, EventArgs e)
        {
            code = "";
            dgvList.AutoGenerateColumns = false;
            txtSearch.Focus();
            LoadData();
        }
        private void LoadData()
        {
            customers = new CustomerRepo().GetCustomers();
            dgvList.DataSource = customers;
            code = "";
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                dgvList.CurrentRow.Selected = true;
                code = dgvList.Rows[e.RowIndex].Cells["Cid"].FormattedValue.ToString();

            }

        }

        private void pcbDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ไม่สามารถทำการลบข้อมูลได้", "Information");
            //if (code != "")
            //{
            //    DialogResult dialogResult = MessageBox.Show("คุณต้องการลบข้อมูล : " + code, "กรุณายืนยัน", MessageBoxButtons.YesNo);
            //    if (dialogResult == DialogResult.Yes)
            //    {
            //        Result result = new CustomerRepo().Delete(code);
            //        if (result.Flag)
            //        {
            //            MessageBox.Show("ลบข้อมูลเรียบร้อยแล้ว", "Information");
            //            LoadData();
            //        }

            //    }

            //}
            //else
            //{
            //    MessageBox.Show("ยังไม่ได้เลือกรายการ", "Information");
            //}
        }

        private void pcbAdd_Click(object sender, EventArgs e)
        {
            frmAddEditCustomer fAddEditCustomer = new frmAddEditCustomer();
            fAddEditCustomer.Action = "Add";
            fAddEditCustomer.ShowDialog(this);

            LoadData();
        }

        private void pcbEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }
        private void Edit()
        {
            if (code != "")
            {
                frmAddEditCustomer fAddEditCustomer = new frmAddEditCustomer();
                fAddEditCustomer.Action = "Edit";
                fAddEditCustomer.Code = code;
                fAddEditCustomer.ShowDialog(this);

                // LoadData();
                Search();
            }
            else
            {
                MessageBox.Show("ยังไม่ได้เลือกรายการ", "Information");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
        private void Search()
        {
            string searchValue = txtSearch.Text.ToLower();
            customers = new CustomerRepo().GetCustomers().ToList();
            if (searchValue != "")
            {
                dgvList.DataSource = customers.Where(c => c.Cname.ToLower().Contains(searchValue) || c.Cid.ToLower().Contains(searchValue)).ToList();
            }
            else
            {
                dgvList.DataSource = customers;
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
