using PurchaseSystem.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PurchaseSystem
{
    public partial class frmAddEditTarcking : Form
    {
        public frmAddEditTarcking()
        {
            InitializeComponent();
        }
        public string Action { get; set; }
        public string Code { get; set; }
        private void frmAddEditTarcking_Load(object sender, EventArgs e)
        {
            LoadData();

            cmbUser.SelectedValue = GlobalVar.UserID;

            if (Action == "Edit" || Action == "Copy")
            {
                Tracking tracking = new TrackingRepo().GetTrackingByID(Code);

                //binding data 
                lblTid.Text = tracking.Tid;
                dtpDocDate.Value = (DateTime)tracking.DocDate;
                dtpDocDate.Enabled = false;

                cmbUser.Enabled = false;
                cmbUser.Text = tracking.Tper;

                txtSupplierID.Text = tracking.Tsid;
                txtTaxID.Text = tracking.Tstaxid;
                txtBrach.Text = tracking.Tsbranth;
                txtPhone.Text = tracking.Tsphone;
                txtSupplierName.Text = tracking.Tsname;
                txtEmail.Text = tracking.Tsemail;

                cmbContact.DataSource = new ContactRepo().GetContacts(tracking.Tsid);
                cmbContact.DisplayMember = "Aname";
                cmbContact.ValueMember = "Aid";
                cmbContact.Text = tracking.Tsa;

                txtAddress.Text = tracking.Tsaddress;
                chkVat.Checked = true;
                if (tracking.Tvat != "0")
                {
                    //คิด vat 
                    chkVat.Checked = false;
                }


                cmbReceipt.Text = tracking.Tin;
                cmbShip.Text = tracking.Tout;


                txtDetail.Text = tracking.Tdetaillist;
                txtRemark.Text = tracking.Tdetail;
                txtCustomerID.Text = tracking.Tzid;
                txtZone.Text = tracking.Tzname;

                cmbPayment.Text = tracking.Tbank;
                dtpReceiptDate.Value = (DateTime)tracking.ReceiptDate;

                txtTf.Text = tracking.Tf;
                txtPathFile.Text = tracking.Tff;

                txtAmt.Text = string.Format("{0:#,0.00}", Math.Round(Convert.ToDecimal( tracking.Ttotail),2));
                txtVat.Text = tracking.Tvat;
                txtVatAmt.Text = string.Format("{0:#,0.00}", Math.Round(Convert.ToDecimal (tracking.Tvattatoil),2));
                txtNetAmt.Text = string.Format("{0:#,0.00}", Math.Round(Convert.ToDecimal( tracking.Ttatoill),2));


                // dgvList.DataSource = tracking.TarckingLists.ToList();

                if (tracking.TarckingLists.Count()>0)
                {
                    foreach (var item in tracking.TarckingLists.ToList())
                    {
                        var index = dgvList.Rows.Add();
                        dgvList.Rows[index].Cells["Tb"].Value = item.Tb;
                        dgvList.Rows[index].Cells["Ta"].Value = item.Ta;
                        dgvList.Rows[index].Cells["Tc"].Value = string.Format("{0:#,0.00}", Math.Round(Convert.ToDecimal(item.Tc), 2));
                        dgvList.Rows[index].Cells["Td"].Value = item.Td;
                        dgvList.Rows[index].Cells["Te"].Value = string.Format("{0:#,0.00}", Math.Round(Convert.ToDecimal(item.Te), 2));
                        dgvList.Rows[index].Cells["Tf"].Value = string.Format("{0:#,0.00}", Math.Round(Convert.ToDecimal(item.Tf), 2));
                    }
                }
           


            }

            //copy ทำเพิ่ม
            if (Action == "Copy")
            {
                lblTid.Text = "-";
                txtPathFile.Text = "";
                cmbUser.Enabled = true;
                dtpDocDate.Enabled = true;
                dtpDocDate.Value = DateTime.Now;
                dtpReceiptDate.Value = DateTime.Now;
                cmbUser.SelectedValue = GlobalVar.UserID;
                cmbReceipt.SelectedIndex = 0;
                cmbShip.SelectedIndex = 0;
            }
        }
        private void LoadData()
        {
            cmbUser.DataSource = new PersonnelRepo().GetPersonnels();
            cmbUser.DisplayMember = "Pname";
            cmbUser.ValueMember = "Pid";

            cmbReceipt.DataSource = new ReceiptStatusRepo().GetTins();
            cmbReceipt.DisplayMember = "Name";
            cmbReceipt.ValueMember = "ID";

            cmbShip.DataSource = new ShipStatusRepo().GetTtouts();
            cmbShip.DisplayMember = "Name";
            cmbShip.ValueMember = "ID";

            cmbPayment.DataSource = new PaymentRepo().GetTbanks();
            cmbPayment.DisplayMember = "Name";
            cmbPayment.ValueMember = "ID";

            txtVat.Text = "7";
            chkVat.Checked = false;
        }



        private void dgvList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvList.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnNewSupplier_Click(object sender, EventArgs e)
        {
            frmAddEditSupplier fAddEditSupplier = new frmAddEditSupplier();
            fAddEditSupplier.Action = "Add";
            fAddEditSupplier.ShowDialog(this);

            DisplaySupplier( fAddEditSupplier.Code);
        }
        private void DisplaySupplier(string code)
        {
            //display
            Supplier supplier = new SupplierRepo().GetSupplier(code);
            if (supplier != null)
            {
                //clear text 
                txtSupplierID.Text = "";
                txtTaxID.Text = "";
                txtBrach.Text = "";
                txtPhone.Text = "";
                txtSupplierName.Text = "";
                txtEmail.Text = "";
                txtAddress.Text = "";
                cmbContact.DataSource = null;

                txtSupplierID.Text = code;
                txtTaxID.Text = supplier.Staxid == null ? "" : supplier.Staxid;
                txtBrach.Text = supplier.Sbranch == null ? "" : supplier.Sbranch;
                txtPhone.Text = supplier.Sphone == null ? "" : supplier.Sphone;
                txtSupplierName.Text = supplier.Sname == null ? "" : supplier.Sname;
                txtEmail.Text = supplier.Semail == null ? "" : supplier.Semail;
                txtAddress.Text = supplier.Saddress == null ? "" : supplier.Saddress;
                cmbContact.DataSource = new ContactRepo().GetContacts(txtSupplierID.Text);
                cmbContact.DisplayMember = "Aname";
                cmbContact.ValueMember = "Aid";
            }
        }

        private void btnSearchSupplier_Click(object sender, EventArgs e)
        {
            frmListSupplier fListSupplier = new frmListSupplier();
            fListSupplier.ShowDialog(this);

            DisplaySupplier(fListSupplier.ItemSelect);
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            frmAddEditCustomer fAddEditCustomer = new frmAddEditCustomer();
            fAddEditCustomer.Action = "Add";
            fAddEditCustomer.ShowDialog(this);

            DisplayCustomer(fAddEditCustomer.Code);
        }

        private void DisplayCustomer(string code)
        {
            //display
            Customer customer = new CustomerRepo().GetCustomer(code);
            if (customer != null)
            {
                //clear text 
                txtCustomerID.Text = "";
                txtZone.Text = "";

                txtCustomerID.Text = customer.Cname;
                txtZone.Text = customer.Czone == null ? "" : customer.Czone;
            }
        }


        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            frmListCustomer fListCustomer = new frmListCustomer();
            fListCustomer.ShowDialog(this);

            DisplayCustomer(fListCustomer.ItemSelect);
        }

        private void dgvList_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //e.FormattedValue  will return current cell value and 
            //e.ColumnIndex & e.RowIndex will rerurn current cell position

            // If you want to validate particular cell data must be numeric then check e.FormattedValue is all numeric 
            // if not then just set  e.Cancel = true and show some message 
            //Like this 

            if (e.ColumnIndex == 2 || e.ColumnIndex == 4)
            {
                //if (!IsNumeric(e.FormattedValue.ToString()))  // IsNumeric will be your method where you will check for numebrs 
                //{
                //    MessageBox.Show("ป้อนตัวเลขได้เท่านั้น");
                //    dgvList.CurrentCell.Value = 0;
                //    e.Cancel = true;
                //}
                if (e.FormattedValue.ToString()!="")
                {
                    if (!isCorrectFloatNumberFormat(e.FormattedValue.ToString()))
                    {
                        MessageBox.Show("ป้อนตัวเลขได้เท่านั้น");
                        //dgvList.CurrentCell.Value = 0;
                        e.Cancel = true;
                    }
                    else
                    {
                        //decial เช็ค ทศนิยม
                        string val = e.FormattedValue.ToString();
                        string[] arr = val.Split('.');
                        if (arr.Count()>1)
                        {
                            if (arr[1].ToString().Length>2)
                            {
                                MessageBox.Show("ป้อนจำนวนทศนิยมได้แค่ 2 ตำแหน่ง");
                                //dgvList.CurrentCell.Value = 0;
                                e.Cancel = true;
                            }
                        }

                    }
                }
               
            }
        }

        private Boolean isCorrectFloatNumberFormat(string compareString)
        {

            if (compareString == null || compareString == "")
            {
                return false;
            }

            string floatNumberPattern = @"\d+(.\d+)?";

            Regex regularExpression = new Regex(floatNumberPattern);

            return regularExpression.IsMatch(compareString);
        }
        public bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }

        private void dgvList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 || e.ColumnIndex == 4)
            {

                decimal qty = Convert.ToDecimal(dgvList.Rows[e.RowIndex].Cells["Tc"].Value);
                decimal unitPrice = Convert.ToDecimal(dgvList.Rows[e.RowIndex].Cells["Te"].Value);
                decimal totalPrice = qty * unitPrice;

                dgvList.Rows[e.RowIndex].Cells["Tf"].Value = string.Format("{0:#0.00}", totalPrice);

                //คำนวณเงิน
                CalAmount();

            }


        }
        private void CalAmount()
        {
            decimal totalAmount = 0;
            decimal vatAmount = 0;
            decimal totalNet = 0;

            for (int i = 0; i < dgvList.Rows.Count - 1; i++)
            {
                totalAmount = totalAmount + Convert.ToDecimal(dgvList.Rows[i].Cells["Tf"].Value);
            }

            txtAmt.Text = string.Format("{0:#,0.00}", totalAmount);
            vatAmount = (totalAmount * Convert.ToDecimal(txtVat.Text)) / 100;
            txtVatAmt.Text = string.Format("{0:#,0.00}", vatAmount);


            totalNet = totalAmount + vatAmount;
            txtNetAmt.Text = string.Format("{0:#,0.00}", totalNet);
        }

        private void dgvList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        string item = "";
        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                dgvList.CurrentRow.Selected = true;
                item = dgvList.Rows[e.RowIndex].Cells["Tb"].FormattedValue.ToString();

            }
        }


        private void toolStripMenuItemRemove_Click(object sender, EventArgs e)
        {
            try
            {
                dgvList.Rows.RemoveAt(this.dgvList.SelectedRows[0].Index);
               // CalAmount();
            }
            catch (Exception)
            {
                MessageBox.Show("กรุณาเลือกแถวที่ต้องการลบ");

            }

        }

        private void chkVat_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVat.Checked)
            {
                txtVat.Text = "0";
            }
            else
            {
                txtVat.Text = "7";
            }
            CalAmount();
        }

        private void pcbSave_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            txtDetail.Focus();
            txtDetail.SelectAll();
            //validate data 
            if (txtSupplierID.Text == "")
            {
                MessageBox.Show("ข้อมูลผู้ขายห้ามเป็นค่าว่าง", "Error");
                txtSupplierID.Focus();
                return;
            }

            if (txtCustomerID.Text == "")
            {
                MessageBox.Show("ข้อมูลลูกค้าห้ามเป็นค่าว่าง", "Error");
                txtCustomerID.Focus();
                return;
            }

            if (dgvList.Rows.Count < 2)
            {
                MessageBox.Show("ยังไม่ได้ระบุรายการสั่งซื้อ", "Error");
                return;
            }

            if (Action == "Copy" && lblTid.Text !="-")
            {
                MessageBox.Show("คุณกำลังจะบันทึกข้อมูลซ้ำ ไม่สามารถทำได้", "Error");
                return;
            }
            if (Action == "Add" && lblTid.Text != "-")
            {
                MessageBox.Show("คุณกำลังจะบันทึกข้อมูลซ้ำ ไม่สามารถทำได้", "Error");
                return;
            }

            //save 
            Tracking tracking = new Tracking();
            tracking.DocDate = dtpDocDate.Value;
            tracking.Tdate = dtpDocDate.Value.ToString("dd/MM/yyyy");
            tracking.Tstatus = "Active";
            tracking.Tper = cmbUser.Text;
            tracking.Tsid = txtSupplierID.Text;
            tracking.Tsname = txtSupplierName.Text;
            tracking.Tstaxid = txtTaxID.Text;
            tracking.Tsbranth = txtBrach.Text;
            tracking.Tsphone = txtPhone.Text;
            tracking.Tsemail = txtEmail.Text;
            tracking.Tsaddress = txtAddress.Text;
            tracking.Tsa = cmbContact.Text;
            tracking.Tzid = txtCustomerID.Text;
            tracking.Tzname = txtZone.Text;
            tracking.Tbank = cmbPayment.Text;
            tracking.ReceiptDate = dtpReceiptDate.Value;
            tracking.Tbankdate = dtpReceiptDate.Value.ToString("dd/MM/yyyy");
            tracking.Ttotail = txtAmt.Text;
            tracking.Tvat = txtVat.Text;
            tracking.Tvattatoil = txtVatAmt.Text;
            tracking.Ttatoill = txtNetAmt.Text;
            tracking.Tla = dgvList.Rows[0].Cells["Ta"].Value == null ? "-" : dgvList.Rows[0].Cells["Ta"].Value.ToString();// dgvList.Rows[0].Cells["Ta"].Value.ToString();
            tracking.Tlb = dgvList.Rows[0].Cells["Tb"].Value.ToString();
            tracking.Tlc = chkVat.Checked ? "true" : "false";//ยังติดอยู่  เดาว่า คิด vat หรือเปล่า 
            tracking.Tdetaillist = txtDetail.Text; //detail 
            tracking.Tdetail = txtRemark.Text; //remark หรือเปล่า
            tracking.Tin = cmbReceipt.Text;
            tracking.Tout = cmbShip.Text;
            tracking.Tf = txtTf.Text;
            //tracking.Tff = txtPathFile.Text;//รู้ตอนบันทึก
            tracking.TResult = ThaiBaht(tracking.Ttatoill);

            //detail 
            for (int i = 0; i < dgvList.Rows.Count - 1; i++)
            {
                TarckingList tarckingList = new TarckingList();

                //รายการ
                if (dgvList.Rows[i].Cells["Tb"].Value ==null || dgvList.Rows[i].Cells["Tb"].Value=="")
                {
                    MessageBox.Show("ข้อมูลรายการห้ามเป็นค่าว่าง");
                    return;
                }
                else
                {
                    tarckingList.Tb = dgvList.Rows[i].Cells["Tb"].Value.ToString();
                }

                //brand
                tarckingList.Ta = dgvList.Rows[i].Cells["Ta"].Value  == null ? "-" : dgvList.Rows[i].Cells["Ta"].Value.ToString();

                //จำนวน 
                if (dgvList.Rows[i].Cells["Tc"].Value==null || dgvList.Rows[i].Cells["Tc"].Value=="")
                {
                    MessageBox.Show("ข้อมูลจำนวน ต้องมีค่ามากว่า 0");
                    return;
                }
                else
                {
                    tarckingList.Tc = Convert.ToDecimal( dgvList.Rows[i].Cells["Tc"].Value).ToString("###0.00");
                }

               //unit
                tarckingList.Td = dgvList.Rows[i].Cells["Td"].Value ==null ?"" : dgvList.Rows[i].Cells["Td"].Value.ToString();

                if (dgvList.Rows[i].Cells["Te"].Value==null || dgvList.Rows[i].Cells["Te"].Value=="")
                {
                    MessageBox.Show("ข้อมูลราคา/หน่อย ต้องมีค่ามากว่า 0");
                    return;
                }
                else
                {

                    tarckingList.Te =Convert.ToDecimal( dgvList.Rows[i].Cells["Te"].Value).ToString("###0.00").Replace(",","");
                }
               
                tarckingList.Tf = dgvList.Rows[i].Cells["Tf"].Value.ToString().Replace(",","");

                tracking.TarckingLists.Add(tarckingList);
            }
            //--------action ---------------//

            Result result = new Result();


            if (Action == "Add" || Action == "Copy")
            {
               
                result = new TrackingRepo().Create(tracking);

                if (result.Flag)
                {
                   // MessageBox.Show("สร้างเอกสารเรียบร้อยแล้ว เลขที่ : " + result.Code);
                    lblTid.Text = result.Code;

                    //get folder 
                    CreateFolder(result.Code);
                    Code = result.Code;
                    Action = "Edit";
                    frmDialogCreate frmDialogCreate = new frmDialogCreate();
                    frmDialogCreate.Code = result.Code;
                    frmDialogCreate.ShowDialog(this);
                }
                else
                {
                    MessageBox.Show("เกิดปัญหาในการบันทึกข้อมูล " + result.Message);
                }
            }
            else
            {
                //edit
                tracking.Tid = lblTid.Text;
                tracking.Tff = txtPathFile.Text;

                result = new TrackingRepo().Update(tracking, Code);
                if (result.Flag)
                {
                    // MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "information");
                    frmDialog frmDialog = new frmDialog();
                    frmDialog.ShowDialog(this);
                }
                else
                {
                    MessageBox.Show("เกิดปัญหาในการบันทึกข้อมูล " + result.Message);
                }
            }



            Cursor.Current = Cursors.Default;

        }
        private void CreateFolder(string JobNo)
        {
            //create folder 
            string dest = GlobalVar.PathFolder + JobNo;
            try
            {
                if (Directory.Exists(dest))
                {
                    Console.WriteLine("That path exists already.");
                    return;
                }
                DirectoryInfo di = Directory.CreateDirectory(dest);
            }
            catch (Exception)
            {

                throw;
            }

            txtPathFile.Text = dest;
        }

        public static string ThaiBaht(string txt)
        {
            string bahtTxt, n, bahtTH = "";
            double amount;
            try { amount = Convert.ToDouble(txt); }
            catch { amount = 0; }
            bahtTxt = amount.ToString("####.00");
            string[] num = { "ศูนย์", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า", "สิบ" };
            string[] rank = { "", "สิบ", "ร้อย", "พัน", "หมื่น", "แสน", "ล้าน" };
            string[] temp = bahtTxt.Split('.');
            string intVal = temp[0];
            string decVal = temp[1];
            if (Convert.ToDouble(bahtTxt) == 0)
                bahtTH = "ศูนย์บาทถ้วน";
            else
            {
                for (int i = 0; i < intVal.Length; i++)
                {
                    n = intVal.Substring(i, 1);
                    if (n != "0")
                    {
                        if ((i == (intVal.Length - 1)) && (n == "1"))
                            bahtTH += "เอ็ด";
                        else if ((i == (intVal.Length - 2)) && (n == "2"))
                            bahtTH += "ยี่";
                        else if ((i == (intVal.Length - 2)) && (n == "1"))
                            bahtTH += "";
                        else
                            bahtTH += num[Convert.ToInt32(n)];
                        bahtTH += rank[(intVal.Length - i) - 1];
                    }
                }
                bahtTH += "บาท";
                if (decVal == "00")
                    bahtTH += "ถ้วน";
                else
                {
                    for (int i = 0; i < decVal.Length; i++)
                    {
                        n = decVal.Substring(i, 1);
                        if (n != "0")
                        {
                            if ((i == decVal.Length - 1) && (n == "1"))
                                bahtTH += "เอ็ด";
                            else if ((i == (decVal.Length - 2)) && (n == "2"))
                                bahtTH += "ยี่";
                            else if ((i == (decVal.Length - 2)) && (n == "1"))
                                bahtTH += "";
                            else
                                bahtTH += num[Convert.ToInt32(n)];
                            bahtTH += rank[(decVal.Length - i) - 1];
                        }
                    }
                    bahtTH += "สตางค์";
                }
            }
            return bahtTH;
        }

        private void txtOpenFoler_Click(object sender, EventArgs e)
        {
            string pathFile = txtPathFile.Text;
            if (pathFile == "")
            {
               
                frmDialogNotFolder frmDialogNotFolder = new frmDialogNotFolder();
                frmDialogNotFolder.ShowDialog(this);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

                System.Diagnostics.Process process = new System.Diagnostics.Process();

               

                
                string[] f = pathFile.Split('\\');
                //string fileName = f[(f.Length - 1)];
                string folder = f[(f.Length - 1)];
                string dest = GlobalVar.PathFolder + folder;

                process.StartInfo.UseShellExecute = true;

                process.StartInfo.FileName = dest;

                //process.StartInfo.Arguments = @" ";

                process.Start();

                Cursor.Current = Cursors.Default;

            

        }

        private void pcbCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pcbPrint_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (lblTid.Text == "-")
            {
                MessageBox.Show("ยังไม่ได้บันทึกข้อมูล");
                return;
            }

            //print
            frmReport fReport = new frmReport();
            fReport.Code = Code;
            fReport.Name = "rptTracking.rpt";

            fReport.ShowDialog(this);

            Cursor.Current = Cursors.Default;
        }

        private void dgvList_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //คำนวณเงิน
            CalAmount();
        }
    }
}
