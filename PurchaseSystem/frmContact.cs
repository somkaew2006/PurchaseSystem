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
    public partial class frmContact : Form
    {
        public frmContact()
        {
            InitializeComponent();
        }

        private string code;
        List<SupplierA> contact;
        private void frmContact_Load(object sender, EventArgs e)
        {
            code = "";
            dgvList.AutoGenerateColumns = false;
            LoadData();
        }

        private void LoadData()
        {
            contact = new ContactRepo().GetContacts();
            dgvList.DataSource = contact;
            code = "";
        }

        private void pcbAdd_Click(object sender, EventArgs e)
        {
            frmAddEditContact fAddEditContact = new frmAddEditContact();
            fAddEditContact.Action = "Add";
            fAddEditContact.ShowDialog(this);

            LoadData();
        }

        private void pcbEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }
        private void Edit()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (code != "")
            {
                frmAddEditContact fAddEditContact = new frmAddEditContact();
                fAddEditContact.Action = "Edit";
                fAddEditContact.Code = code;
                fAddEditContact.ShowDialog(this);

                //  LoadData();
                Search();
            }
            else
            {
                MessageBox.Show("ยังไม่ได้เลือกรายการ", "Information");
            }
            Cursor.Current = Cursors.Default;
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                dgvList.CurrentRow.Selected = true;
                code = dgvList.Rows[e.RowIndex].Cells["Aid"].FormattedValue.ToString();

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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
        private void Search()
        {
            
            string searchValue = txtSearch.Text.ToLower();
            contact = new ContactRepo().GetContacts();
            if (searchValue != "")
            {
                dgvList.DataSource = contact.Where(c => c.Aname.ToLower().Contains(searchValue)).ToList();
            }
            else
            {
                dgvList.DataSource = contact;
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
