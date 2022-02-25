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
    public partial class frmAddEditSupplier : Form
    {
        public frmAddEditSupplier()
        {
            InitializeComponent();
        }
        public string Action { get; set; }
        public string Code { get; set; }
        private void frmAddEditSupplier_Load(object sender, EventArgs e)
        {
            if (Action == "Edit")
            {
                Supplier supplier = new SupplierRepo().GetSupplier(Code);
                txtSupplierName.Text = supplier.Sname;
                txtTaxID.Text = supplier.Staxid;
                txtBranch.Text = supplier.Sbranch;
                txtPhone.Text = supplier.Sphone;
                txtEmail.Text = supplier.Semail;
                txtAddress.Text = supplier.Saddress;

                groupBoxContact.Visible = false;
            }
        }

        private void pcbCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pcbSave_Click(object sender, EventArgs e)
        {
            if (txtSupplierName.Text == "")
            {
                MessageBox.Show("ข้อมูล ชื่อบริษัท ห้ามเป็นค่าว่าง", "Error");
                txtSupplierName.Focus();
                return;
            }
            

            Result result = new Result();
            if (Action == "Add")
            {
                Supplier model = new Supplier();
                model.Sname = txtSupplierName.Text;
                model.Staxid = txtTaxID.Text;
                model.Sbranch = txtBranch.Text;
                model.Sphone = txtPhone.Text;
                model.Semail = txtEmail.Text;
                model.Saddress = txtAddress.Text;

                result = new SupplierRepo().Create(model);
                if (result.Flag)
                {
                    //add contract 
                    SupplierA supplierA = new SupplierA();
                    supplierA.Aname = txtContactName.Text;
                    supplierA.Aphone = txtContactPhone.Text;
                    supplierA.Aemail = txtContactEmail.Text;
                    supplierA.ID = result.Code;
                    supplierA.Name = txtSupplierName.Text;

                    result = new ContactRepo().Create(supplierA);

                    if (result.Flag)
                    {
                        this.Code = supplierA.ID;
                        MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "information");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("เกิดปัญหาในการบันทึกข้อมูล", "Error");
                       
                    }
                   
                }
            }
            else
            {

                //edit 
                Supplier model = new Supplier();
                model.Sid = Code;
                model.Sname = txtSupplierName.Text;
                model.Staxid = txtTaxID.Text;
                model.Sbranch = txtBranch.Text;
                model.Sphone = txtPhone.Text;
                model.Semail = txtEmail.Text;
                model.Saddress = txtAddress.Text;

                result = new SupplierRepo().Update(model, Code);
                if (result.Flag)
                {
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "information");
                    this.Close();
                }
            }
        }
    }
}
