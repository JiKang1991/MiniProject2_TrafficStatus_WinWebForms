using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniProject2_WinForms_VirtualCar
{
    public partial class FormSet : Form
    {
        public static string serverIp = "127.0.0.1";
        public static string serverPort = "9001";

        public FormSet()
        {
            InitializeComponent();            
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (TbIp1.Text.Trim().Equals("")|| TbIp2.Text.Trim().Equals("") || TbIp3.Text.Trim().Equals("") || TbIp4.Text.Trim().Equals(""))
            {
                MessageBox.Show("IP 입력란를 확인해주세요.");
            }
            if (TbPort.Text.Trim().Equals(""))
            {
                MessageBox.Show("Port 입력란을 확인해주세요.");
            }
            serverIp = $"{TbIp1.Text}.{TbIp2.Text}.{TbIp3.Text}.{TbIp4.Text}";
            serverPort = TbPort.Text;

            this.DialogResult = DialogResult.OK;
        }
    }
}
