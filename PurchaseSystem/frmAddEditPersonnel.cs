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
    public partial class frmAddEditPersonnel : Form
    {
        public frmAddEditPersonnel()
        {
            InitializeComponent();
        }
        public string Action { get; set; }
        public string Code { get; set; }
        private void frmAddEditPersonnel_Load(object sender, EventArgs e)
        {
            if (Action == "Edit")
            {
                    Personnel personnel = new PersonnelRepo().GetPersonnel(Code);
                    txtUserName.Text = personnel.Pname;
                    txtUserID.Text = personnel.Puser;
                    txtPassword.Text = personnel.Ppass;
            }
        }

        private void pcbCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pcbSave_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text=="")
            {
                MessageBox.Show("ข้อมูล ชื่อ-สกุล ห้ามเป็นค่าว่าง", "Error");
                txtUserName.Focus();
                return;
            }
            if (txtUserID.Text == "")
            {
                MessageBox.Show("ข้อมูล User ห้ามเป็นค่าว่าง", "Error");
                txtUserID.Focus();
                return;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("ข้อมูล Password ห้ามเป็นค่าว่าง", "Error");
                txtUserID.Focus();
                return;
            }


            Result result = new Result();
            if (Action == "Add")
            {
                Personnel model = new Personnel();
                model.Pname = txtUserName.Text;
                model.Puser = txtUserID.Text;
                model.Ppass = txtPassword.Text;

                result = new PersonnelRepo().Create(model);
                if (result.Flag)
                {
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "information");
                    this.Close();
                }
            }
            else
            {

                //edit 
                Personnel model = new Personnel();
                model.Pid = Code;
                model.Pname = txtUserName.Text;
                model.Puser = txtUserID.Text;
                model.Ppass = txtPassword.Text;

                result = new PersonnelRepo().Update(model,Code);
                if (result.Flag)
                {
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "information");
                    this.Close();
                }
            }
        }
    }
}
