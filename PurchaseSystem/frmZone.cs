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
    public partial class frmZone : Form
    {
        public frmZone()
        {
            InitializeComponent();
        }
        private string code;
        private void frmZone_Load(object sender, EventArgs e)
        {
            code = "";
            dgvList.AutoGenerateColumns = false;
            LoadData();
        }
          private void LoadData()
        {
            List<Zone> zones = new ZoneRepo().GetZones();
            dgvList.DataSource = zones;
            code = "";
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                dgvList.CurrentRow.Selected = true;
                code = dgvList.Rows[e.RowIndex].Cells["Zid"].FormattedValue.ToString();

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
            //        Result result = new ZoneRepo().Delete(code);
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
            frmAddEditZone fAddEditZone = new frmAddEditZone();
            fAddEditZone.Action = "Add";
            fAddEditZone.ShowDialog(this);

            LoadData();
        }

        private void pcbEdit_Click(object sender, EventArgs e)
        {

            Search();
        }
        private void Search()
        {
            if (code != "")
            {
                frmAddEditZone fAddEditZone = new frmAddEditZone();
                fAddEditZone.Action = "Edit";
                fAddEditZone.Code = code;
                fAddEditZone.ShowDialog(this);

                LoadData();
            }
            else
            {
                MessageBox.Show("ยังไม่ได้เลือกรายการ", "Information");
            }
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Search();
        }
    }
}
