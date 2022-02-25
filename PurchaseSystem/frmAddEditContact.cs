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
    public partial class frmAddEditContact : Form
    {
        public string Action { get; set; }
        public string Code { get; set; }
        public frmAddEditContact()
        {
            InitializeComponent();
        }

        private void frmAddEditContact_Load(object sender, EventArgs e)
        {
            List<Supplier> suppliers = new SupplierRepo().GetSuppliers();
            cmbSupplier.DataSource = suppliers;
            cmbSupplier.DisplayMember = "Sname";
            cmbSupplier.ValueMember = "Sid";

            if (Action == "Edit")
            {
                SupplierA contact = new ContactRepo().GetContact(Code);

                txtName.Text = contact.Aname;
                txtPhone.Text = contact.Aphone;
                txtLine.Text = contact.Aline;
                txtEmail.Text = contact.Aemail;
                txtDetail.Text = contact.Adetail;
                cmbSupplier.SelectedValue = contact.ID;
            }
        }

        private void pcbCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pcbSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("ข้อมูล ชื่อผู้ติดต่อ ห้ามเป็นค่าว่าง", "Error");
                txtName.Focus();
                return;
            }

            //validate company 
            List<Supplier> suppliers = new SupplierRepo().GetSuppliers().Where(c => c.Sname == cmbSupplier.Text).ToList();
            if (suppliers.Count==0)
            {
                MessageBox.Show("เลือกข้อมูลบริษัทไม่ถูกต้อง", "Error");

                return;
            }

            txtName.Focus();

            Result result = new Result();
            if (Action == "Add")
            {
                SupplierA model = new SupplierA();
                model.Aname = txtName.Text;
                model.Aphone = txtPhone.Text;
                model.Aemail = txtEmail.Text;
                model.Adetail = txtDetail.Text;
                model.ID =(string) cmbSupplier.SelectedValue;
                model.Name = cmbSupplier.Text;
                model.Aline = txtLine.Text;


                result = new ContactRepo().Create(model);
                if (result.Flag)
                {
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "information");
                    this.Close();
                }
            }
            else
            {

                //edit 
                SupplierA model = new SupplierA();
                model.Aid = Code;
                model.Aname = txtName.Text;
                model.Aphone = txtPhone.Text;
                model.Aemail = txtEmail.Text;
                model.Adetail = txtDetail.Text;
                model.ID = (string)cmbSupplier.SelectedValue;
                model.Name = cmbSupplier.Text;
                model.Aline = txtLine.Text;

                result = new ContactRepo().Update(model, Code);
                if (result.Flag)
                {
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "information");
                    this.Close();
                }
            }
        }
    }
}
