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
    public partial class frmAddEditZone : Form
    {
        public frmAddEditZone()
        {
            InitializeComponent();
        }

        public string Action { get; set; }
        public string Code { get; set; }
        private void pcbSave_Click(object sender, EventArgs e)
        {
            if (txtZone.Text == "")
            {
                MessageBox.Show("ข้อมูล Zone ห้ามเป็นค่าว่าง", "Error");
                txtZone.Focus();
                return;
            }
            if (txtDetail.Text == "")
            {
                MessageBox.Show("ข้อมูล Detail ห้ามเป็นค่าว่าง", "Error");
                txtDetail.Focus();
                return;
            }

            Result result = new Result();
            if (Action == "Add")
            {
                Zone model = new Zone();
                model.Zname = txtZone.Text;
                model.Zdetail = txtDetail.Text;

                result = new ZoneRepo().Create(model);
                if (result.Flag)
                {
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "information");
                    this.Close();
                }
            }
            else
            {

                //edit 
                Zone model = new Zone();
                model.Zid = Code;
                model.Zname = txtZone.Text;
                model.Zdetail = txtDetail.Text;
  
                result = new ZoneRepo().Update(model, Code);
                if (result.Flag)
                {
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "information");
                    this.Close();
                }
            }


        }

        private void pcbCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddEditZone_Load(object sender, EventArgs e)
        {
            if (Action == "Edit")
            {
                Zone zone = new ZoneRepo().GetZone(Code);
                txtZone.Text = zone.Zname;
                txtDetail.Text = zone.Zdetail;
            }
        }
    }
}
