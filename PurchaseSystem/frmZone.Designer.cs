namespace PurchaseSystem
{
    partial class frmZone
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.Zid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pcbDelete = new System.Windows.Forms.PictureBox();
            this.label18 = new System.Windows.Forms.Label();
            this.pcbEdit = new System.Windows.Forms.PictureBox();
            this.label19 = new System.Windows.Forms.Label();
            this.pcbAdd = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvList);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 387);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // dgvList
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Zid,
            this.UserName,
            this.Password});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(3, 16);
            this.dgvList.Name = "dgvList";
            this.dgvList.Size = new System.Drawing.Size(447, 368);
            this.dgvList.TabIndex = 2;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            this.dgvList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellDoubleClick);
            // 
            // Zid
            // 
            this.Zid.DataPropertyName = "Zid";
            this.Zid.HeaderText = "รหัส";
            this.Zid.Name = "Zid";
            this.Zid.ReadOnly = true;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "Zname";
            this.UserName.HeaderText = "Zone";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // Password
            // 
            this.Password.DataPropertyName = "Zdetail";
            this.Password.FillWeight = 300F;
            this.Password.HeaderText = "Detail";
            this.Password.Name = "Password";
            this.Password.ReadOnly = true;
            this.Password.Width = 200;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.pcbDelete);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.pcbEdit);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.pcbAdd);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(453, 89);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(121, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "ลบ";
            // 
            // pcbDelete
            // 
            this.pcbDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbDelete.Image = global::PurchaseSystem.Properties.Resources.Symbol___Delete;
            this.pcbDelete.Location = new System.Drawing.Point(115, 25);
            this.pcbDelete.Name = "pcbDelete";
            this.pcbDelete.Size = new System.Drawing.Size(34, 33);
            this.pcbDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbDelete.TabIndex = 6;
            this.pcbDelete.TabStop = false;
            this.pcbDelete.Click += new System.EventHandler(this.pcbDelete_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(65, 63);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(34, 13);
            this.label18.TabIndex = 3;
            this.label18.Text = "แก้ไข";
            // 
            // pcbEdit
            // 
            this.pcbEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbEdit.Image = global::PurchaseSystem.Properties.Resources.Edit;
            this.pcbEdit.Location = new System.Drawing.Point(66, 25);
            this.pcbEdit.Name = "pcbEdit";
            this.pcbEdit.Size = new System.Drawing.Size(34, 33);
            this.pcbEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbEdit.TabIndex = 2;
            this.pcbEdit.TabStop = false;
            this.pcbEdit.Click += new System.EventHandler(this.pcbEdit_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(8, 63);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(49, 13);
            this.label19.TabIndex = 1;
            this.label19.Text = "สร้างใหม่";
            // 
            // pcbAdd
            // 
            this.pcbAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbAdd.Image = global::PurchaseSystem.Properties.Resources.Symbol___Add;
            this.pcbAdd.Location = new System.Drawing.Point(15, 25);
            this.pcbAdd.Name = "pcbAdd";
            this.pcbAdd.Size = new System.Drawing.Size(34, 33);
            this.pcbAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbAdd.TabIndex = 0;
            this.pcbAdd.TabStop = false;
            this.pcbAdd.Click += new System.EventHandler(this.pcbAdd_Click);
            // 
            // frmZone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 476);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmZone";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ข้อมูลโซนลูกค้า";
            this.Load += new System.EventHandler(this.frmZone_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbAdd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pcbDelete;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.PictureBox pcbEdit;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.PictureBox pcbAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Zid;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
    }
}