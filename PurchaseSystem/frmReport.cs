using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
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
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }
        public string Code { get; set; }
        public string ReportName { get; set; }
        private void frmReport_Load(object sender, EventArgs e)
        {
            ReportDocument report = new ReportDocument();
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();

            Tables CrTables;
            //report.Load(GlobalVar.PathReport +Name);
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            report.Load(GlobalVar.PathReport + Name);
           
            crConnectionInfo.ServerName = GlobalVar.ServerName;
            crConnectionInfo.DatabaseName = GlobalVar.Database;
            crConnectionInfo.UserID = GlobalVar.SqlUserID;
            crConnectionInfo.Password = GlobalVar.SqlPassword;

            
            CrTables = report.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }

            //paramiter
            report.SetParameterValue("@Code", Code);

            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Update();
            crystalReportViewer1.Refresh();
        }
        private void ReportLogin()
        {

        }
    }
}
