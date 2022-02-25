using PurchaseSystem.Model;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace PurchaseSystem
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private string code;
        private void frmMain_Load(object sender, EventArgs e)
        {
            code = "";
            dgvList.AutoGenerateColumns = false;

            lblExport.Visible = false;
            pcbExport.Visible = false;
            ToolStripMenuItemMainI.Enabled = false;

            if (GlobalVar.PUser.ToLower().Contains("admin"))
            {
                lblExport.Visible = true;
                pcbExport.Visible = true;

                ToolStripMenuItemMainI.Enabled = true;
            }
            LoadData();
        }
        private void LoadData()
        {
            Cursor.Current = Cursors.WaitCursor;

            lblPID.Text = GlobalVar.UserID;
            lblPName.Text = GlobalVar.UserName;
            cmbUser.DataSource = new PersonnelRepo().GetPersonnels().ToList();
            cmbUser.ValueMember = "Pname";
            cmbUser.DisplayMember = "Pname";
            code = "";

            dgvList.DataSource = new TrackingRepo().GetTrackingsForAction();

            Cursor.Current = Cursors.Default;
        }

        

        private void ToolStripMenuPersonal_Click(object sender, EventArgs e)
        {
            frmPersonnel fPersonnel = new frmPersonnel();
            fPersonnel.ShowDialog(this);
        }

        private void ToolStripMenuZone_Click(object sender, EventArgs e)
        {
            frmZone fZone = new frmZone();
            fZone.ShowDialog(this);
        }

        private void ToolStripMenuCompany_Click(object sender, EventArgs e)
        {
            frmCustomer fCustomer = new frmCustomer();
            fCustomer.ShowDialog(this);

        }

       

       

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ToolStripMenuExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("คุณต้องการออกจากโปรแกรม ใช่หรือไม่", "กรุณายืนยัน", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

      

        private void pcbRefresh_Click(object sender, EventArgs e)
        {
            Reset();
            LoadData();
        }

        private void pcbSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void Search()
        {
            Cursor.Current = Cursors.WaitCursor;

            List<TrackingPartial> trackingList = new List<TrackingPartial>();
            string supplierID = txtSupplier.Text.ToLower();
            string zone = txtZone.Text.ToLower();
            string code = txtCode.Text.ToLower();
            string poNo = txtPoNo.Text.ToLower();
            string product = txtProduct.Text.ToLower();
            string brand = txtBrand.Text.ToLower();
            string user = cmbUser.Text;

           

            //
            if (chkAll.Checked)
            {
                //เอามาทั้งหมด
                trackingList = new TrackingRepo().GetTrackingsAllForAction();
            }
            else
            {
                //default
                trackingList = new TrackingRepo().GetTrackingsForAction();
            }
           
            if (supplierID != "")
            {
                trackingList = trackingList.Where(c => c.Tsname.ToLower().Contains(supplierID)).ToList();
            }
            if (zone != "")
            {
                trackingList = trackingList.Where(c => c.Tzname.ToLower().Contains(zone)).ToList();
            }
            if (code != "")
            {
                trackingList = trackingList.Where(c => c.Tzid.ToLower() == code).ToList();
            }


            if (poNo != "")
            {
                trackingList = trackingList.Where(c => c.Tid.ToLower().Contains(poNo)).ToList();
            }

            if (product != "")
            {
                trackingList = trackingList.Where(c => c.TarckingLists.Any(p => p.Tb.ToLower().Contains(product.ToLower()))).ToList();
            }

            if (brand != "")
            {
                trackingList = trackingList.Where(c => c.TarckingLists.Any(p => p.Ta.ToLower().Contains(brand.ToLower()))).ToList();
            }

            //user
            if (user != "")
            {
                trackingList = trackingList.Where(c => c.Tper == user).ToList();
            }



            //late
            if (chkLate.Checked)
            {
                trackingList = trackingList.Where(c => c.Tin == "-" && c.Tout == "-" && c.ReceiptDate<DateTime.Now ).ToList();
            }

            if (chkTin.Checked)
            {
                //สถานะของเข้า
                trackingList = trackingList.Where(c => c.Tin == "รับแล้ว").ToList();
            }
            if (chkTout.Checked)
            {
                //ส่ง่ของแล้ว
                trackingList = trackingList.Where(c => c.Tout == "ส่งแล้ว").ToList();
            }

            if (chkCash.Checked)
            {
                //เงินสด
                trackingList = trackingList.Where(c => c.Tbank == "เงินสด").ToList();
            }

            if (chkTransfer.Checked)
            {
                //โอนชำระ
                trackingList = trackingList.Where(c => c.Tbank == "โอนชำระ").ToList();
            }


 
            dgvList.DataSource = trackingList;


            Cursor.Current = Cursors.Default;
        }

        private void pcbReset_Click(object sender, EventArgs e)
        {
            Reset();
            LoadData();
        }
        private void Reset()
        {
            txtSupplier.Text = "";
            txtProduct.Text = "";
            txtZone.Text = "";
            txtCode.Text = "";
            txtPoNo.Text = "";
            chkCash.Checked = false;
            chkTin.Checked = false;
            chkTout.Checked = false;
            chkTransfer.Checked = false;
            chkAll.Checked = false;
            cmbUser.SelectedIndex = 0;
            chkLate.Checked = false;
            txtBrand.Text = "";
        }
       

        private void pcbExport_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ExportExcel();
            Cursor.Current = Cursors.Default;
        }
        private void ExportExcel()
        {
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook ExcelBook;
            Microsoft.Office.Interop.Excel._Worksheet ExcelSheet;

            int i = 0;
            int j = 0;

            //create object of excel
            ExcelBook = (Microsoft.Office.Interop.Excel._Workbook)ExcelApp.Workbooks.Add(1);
            ExcelSheet = (Microsoft.Office.Interop.Excel._Worksheet)ExcelBook.ActiveSheet;

            // header
            for (i = 1; i <= this.dgvList.Columns.Count; i++)
            {
                ExcelSheet.Cells[1, i] = this.dgvList.Columns[i - 1].HeaderText;
            }

            // data
            for (i = 1; i <= this.dgvList.RowCount; i++)
            {
                for (j = 1; j <= dgvList.Columns.Count; j++)
                {
                    ExcelSheet.Cells[i + 1, j] = dgvList.Rows[i - 1].Cells[j - 1].Value;
                }
            }

            ExcelApp.Visible = true;
            ExcelSheet = null;
            ExcelBook = null;
            ExcelApp = null;
        }
 

        private void txtSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                Search();
            }
        }

        private void txtProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        private void txtPoNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        private void txtZone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        private void chkTin_CheckedChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void chkTout_CheckedChanged(object sender, EventArgs e)
        {
            Search();
        }

        

        private void chkCash_CheckedChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void chkTransfer_CheckedChanged(object sender, EventArgs e)
        {
            Search();
        }
        private void pcbNew_Click(object sender, EventArgs e)
        {
            frmAddEditTarcking fAddEditTarcking = new frmAddEditTarcking();
            fAddEditTarcking.Action = "Add";
            fAddEditTarcking.ShowDialog(this);

            Reset();
            LoadData();
        }

        private void pcbEdit_Click(object sender, EventArgs e)
        {
            EditData();
        }
        private void EditData()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (code != "")
            {
                frmAddEditTarcking fAddEditTracking = new frmAddEditTarcking();
                fAddEditTracking.Action = "Edit";
                fAddEditTracking.Code = code;
                fAddEditTracking.ShowDialog(this);

                //Reset();
                //LoadData();
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
                code = dgvList.Rows[e.RowIndex].Cells["Tid"].FormattedValue.ToString();
            }
        }

        private void pcbDelete_Click(object sender, EventArgs e)
        {
            //  MessageBox.Show("ไม่สามารถทำการลบข้อมูลได้", "Information");
            if (code != "")
            {
                DialogResult dialogResult = MessageBox.Show("คุณต้องการลบข้อมูล : " + code, "กรุณายืนยัน", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Result result = new TrackingRepo().Delete(code);
                    if (result.Flag)
                    {
                        MessageBox.Show("ลบข้อมูลเรียบร้อยแล้ว", "Information");
                        LoadData();
                    }

                }

            }
            else
            {
                MessageBox.Show("ยังไม่ได้เลือกรายการ", "Information");
            }
        }

        private void pcbCopy_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (code != "")
            {
                frmAddEditTarcking fAddEditTracking = new frmAddEditTarcking();
                fAddEditTracking.Action = "Copy";
                fAddEditTracking.Code = code;
                fAddEditTracking.ShowDialog(this);

                Reset();
                LoadData();
            }
            else
            {
                MessageBox.Show("ยังไม่ได้เลือกรายการ", "Information");
            }
            Cursor.Current = Cursors.Default;
        }

        private void dgvList_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DateTime receiptDate = (DateTime)dgvList["ReceiptDate", e.RowIndex].Value;
            string receiptStatus = (string)dgvList["Tin", e.RowIndex].Value;
            string shipStatus = (string)dgvList["Tout", e.RowIndex].Value;

            if (receiptDate < DateTime.Now && receiptStatus != "รับแล้ว")
            {
                dgvList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
            }

            if (receiptStatus == "รับแล้ว" && shipStatus =="-")
            {
                dgvList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Khaki;
            }



            if (receiptStatus == "รับแล้ว" && shipStatus == "ส่งแล้ว")
            {
                dgvList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }

        private void chkLate_CheckedChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void pcbSearch_Click_1(object sender, EventArgs e)
        {
            Search();
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                dgvList.CurrentRow.Selected = true;
                code = dgvList.Rows[e.RowIndex].Cells["Tid"].FormattedValue.ToString();
                if (code!="")
                {
                    EditData();
                }
            }
        }

        private void txtBrand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        private void ToolStripMenuSuppliers_Click(object sender, EventArgs e)
        {
            frmSupplier fSupplier = new frmSupplier();
            fSupplier.ShowDialog(this);
        }

        private void ToolStripMenuContact_Click(object sender, EventArgs e)
        {
            frmContact fContact = new frmContact();
            fContact.ShowDialog(this);
        }

        
    }
}
