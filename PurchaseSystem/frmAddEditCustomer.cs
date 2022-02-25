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
    public partial class frmAddEditCustomer : Form
    {
        public frmAddEditCustomer()
        {
            InitializeComponent();
        }
        public string Action { get; set; }
        public string Code { get; set; }

        private void frmAddEditCustomer_Load(object sender, EventArgs e)
        {
            List<Zone> zones = new ZoneRepo().GetZones();
            cmbZone.DataSource = zones;
            cmbZone.DisplayMember = "Zname";
            cmbZone.ValueMember = "Zname";

            if (Action == "Edit")
            {
                Customer customer = new CustomerRepo().GetCustomer(Code);

                txtCode.Text = customer.Cname;
                cmbZone.SelectedValue = customer.Czone;
            }
        }

        private void pcbCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pcbSave_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("ข้อมูล Code ห้ามเป็นค่าว่าง", "Error");
                txtCode.Focus();
                return;
            }
           


            Result result = new Result();
            if (Action == "Add")
            {
                Customer model = new Customer();
                model.Cname = txtCode.Text;
                model.Czone = cmbZone.Text;
               

                result = new CustomerRepo().Create(model);
                if (result.Flag)
                {
                    this.Code = result.Code;
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "information");
                    this.Close();
                }
            }
            else
            {

                //edit 
                Customer model = new Customer();
                model.Cid = Code;
                model.Cname = txtCode.Text;
                model.Czone = cmbZone.Text;

                result = new CustomerRepo().Update(model, Code);
                if (result.Flag)
                {
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "information");
                    this.Close();
                }
            }
        }
    }
}
