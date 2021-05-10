
namespace MiniProject2_WinForms_VirtualCar
{
    partial class FormMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.setConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuServer = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.SbCheckConnect = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.BtnDrive = new System.Windows.Forms.Button();
            this.BtnBoard = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CbRoad = new System.Windows.Forms.ComboBox();
            this.TbLocationY = new System.Windows.Forms.TextBox();
            this.TbLocationX = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LbSpeed = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NUDAccelPressPower = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.NUDBrakePressPower = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.LbRun = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDAccelPressPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDBrakePressPower)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setConnectionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(442, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // setConnectionToolStripMenuItem
            // 
            this.setConnectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuServer});
            this.setConnectionToolStripMenuItem.Name = "setConnectionToolStripMenuItem";
            this.setConnectionToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.setConnectionToolStripMenuItem.Text = "Set Connection";
            // 
            // MnuServer
            // 
            this.MnuServer.Name = "MnuServer";
            this.MnuServer.Size = new System.Drawing.Size(107, 22);
            this.MnuServer.Text = "Server";
            this.MnuServer.Click += new System.EventHandler(this.MnuServer_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SbCheckConnect});
            this.statusStrip1.Location = new System.Drawing.Point(0, 443);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(442, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // SbCheckConnect
            // 
            this.SbCheckConnect.AutoSize = false;
            this.SbCheckConnect.Name = "SbCheckConnect";
            this.SbCheckConnect.Size = new System.Drawing.Size(100, 17);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(442, 419);
            this.splitContainer1.SplitterDistance = 179;
            this.splitContainer1.TabIndex = 2;
            // 
            // BtnDrive
            // 
            this.BtnDrive.Enabled = false;
            this.BtnDrive.Location = new System.Drawing.Point(11, 51);
            this.BtnDrive.Name = "BtnDrive";
            this.BtnDrive.Size = new System.Drawing.Size(89, 23);
            this.BtnDrive.TabIndex = 1;
            this.BtnDrive.Text = "Drive";
            this.BtnDrive.UseVisualStyleBackColor = true;
            this.BtnDrive.Click += new System.EventHandler(this.BtnDrive_Click);
            // 
            // BtnBoard
            // 
            this.BtnBoard.Location = new System.Drawing.Point(11, 22);
            this.BtnBoard.Name = "BtnBoard";
            this.BtnBoard.Size = new System.Drawing.Size(89, 23);
            this.BtnBoard.TabIndex = 1;
            this.BtnBoard.Text = "Board";
            this.BtnBoard.UseVisualStyleBackColor = true;
            this.BtnBoard.Click += new System.EventHandler(this.BtnBoard_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CbRoad);
            this.groupBox1.Controls.Add(this.TbLocationY);
            this.groupBox1.Controls.Add(this.TbLocationX);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.LbRun);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.LbSpeed);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 128);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // CbRoad
            // 
            this.CbRoad.FormattingEnabled = true;
            this.CbRoad.Location = new System.Drawing.Point(79, 91);
            this.CbRoad.Name = "CbRoad";
            this.CbRoad.Size = new System.Drawing.Size(100, 20);
            this.CbRoad.TabIndex = 3;
            // 
            // TbLocationY
            // 
            this.TbLocationY.Location = new System.Drawing.Point(260, 61);
            this.TbLocationY.Name = "TbLocationY";
            this.TbLocationY.Size = new System.Drawing.Size(100, 21);
            this.TbLocationY.TabIndex = 1;
            this.TbLocationY.Text = "222.222222";
            // 
            // TbLocationX
            // 
            this.TbLocationX.Location = new System.Drawing.Point(79, 61);
            this.TbLocationX.Name = "TbLocationX";
            this.TbLocationX.Size = new System.Drawing.Size(100, 21);
            this.TbLocationX.TabIndex = 1;
            this.TbLocationX.Text = "111.111111";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(193, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "LocationY";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(188, 33);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(66, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "Run Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(36, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Road";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "LocationX";
            // 
            // LbSpeed
            // 
            this.LbSpeed.AutoSize = true;
            this.LbSpeed.Location = new System.Drawing.Point(77, 33);
            this.LbSpeed.Name = "LbSpeed";
            this.LbSpeed.Size = new System.Drawing.Size(21, 12);
            this.LbSpeed.TabIndex = 0;
            this.LbSpeed.Text = "0.0";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnBoard);
            this.groupBox2.Controls.Add(this.NUDBrakePressPower);
            this.groupBox2.Controls.Add(this.NUDAccelPressPower);
            this.groupBox2.Controls.Add(this.BtnDrive);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(3, 137);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(436, 96);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "accelerator press power";
            // 
            // NUDAccelPressPower
            // 
            this.NUDAccelPressPower.Location = new System.Drawing.Point(294, 22);
            this.NUDAccelPressPower.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.NUDAccelPressPower.Name = "NUDAccelPressPower";
            this.NUDAccelPressPower.Size = new System.Drawing.Size(100, 21);
            this.NUDAccelPressPower.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(152, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "brake press power";
            // 
            // NUDBrakePressPower
            // 
            this.NUDBrakePressPower.Location = new System.Drawing.Point(294, 54);
            this.NUDBrakePressPower.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.NUDBrakePressPower.Name = "NUDBrakePressPower";
            this.NUDBrakePressPower.Size = new System.Drawing.Size(100, 21);
            this.NUDBrakePressPower.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "Speed";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(120, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "KM/h";
            // 
            // LbRun
            // 
            this.LbRun.AutoSize = true;
            this.LbRun.Location = new System.Drawing.Point(258, 34);
            this.LbRun.Name = "LbRun";
            this.LbRun.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LbRun.Size = new System.Drawing.Size(50, 12);
            this.LbRun.TabIndex = 0;
            this.LbRun.Text = "Not Run";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 465);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Car Status";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDAccelPressPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDBrakePressPower)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TbLocationY;
        private System.Windows.Forms.TextBox TbLocationX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LbSpeed;
        private System.Windows.Forms.Button BtnBoard;
        private System.Windows.Forms.ToolStripMenuItem setConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnuServer;
        private System.Windows.Forms.Button BtnDrive;
        private System.Windows.Forms.ComboBox CbRoad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripStatusLabel SbCheckConnect;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown NUDBrakePressPower;
        private System.Windows.Forms.NumericUpDown NUDAccelPressPower;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LbRun;
    }
}

