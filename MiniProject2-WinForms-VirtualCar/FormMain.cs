using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniProject2_WinForms_VirtualCar
{
    public partial class FormMain : Form
    {
        Socket socket = null;
        Thread timerThread = null;
        Thread carThread = null;

        char stx = '\u0002';
        char etx = '\u0003';

        int defaultSpeed = 15;
        float nowSpeed = 0;

        public FormMain()
        {
            InitializeComponent();
            CbRoad.Items.Add("1");
        }

        private delegate void ToggleBtnDriveCB(bool flag);
        private delegate void PrintSpeedCB(float speed);
        private delegate string GetControlValueCB(ComboBox cb);

        private void ToggleBtnDrive(bool flag)
        {
            if (BtnDrive.InvokeRequired)    Invoke(new ToggleBtnDriveCB(ToggleBtnDrive), flag);
            else                            BtnDrive.Enabled = flag;            
        }

        private void PrintSpeed(float speed)
        {
            if (LbSpeed.InvokeRequired)      Invoke(new PrintSpeedCB(PrintSpeed), speed);
            else                             LbSpeed.Text = $"{speed:F1}";
        }

        private string GetControlValue(ComboBox cb)
        {
            if (cb.InvokeRequired)
            {
                return (string)Invoke(new GetControlValueCB(GetControlValue), new object[] { cb });                
            }
            else
            {
                 //cb.Text;
            }
            
        }

        private void MnuServer_Click(object sender, EventArgs e)
        {
            FormSet formSet = new FormSet();
            DialogResult dialogResult = formSet.ShowDialog();

            if(dialogResult != DialogResult.OK)
            {
                return;
            }            
        }

        private void BtnBoard_Click(object sender, EventArgs e)
        {
            if (socket == null)
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(FormSet.serverIp, int.Parse(FormSet.serverPort));
                SbCheckConnect.BackColor = Color.Green;
            }
            
            if (carThread == null)
            {
                carThread = new Thread(carProcess);
                carThread.IsBackground = true;
                carThread.Start();
            }
        }

        private void carProcess()
        {
            
            while (true)
            {
                int nowBpp = (int)NUDBrakePressPower.Value;
                if (nowBpp >= 80)
                {
                    ToggleBtnDrive(true);
                    if(timerThread != null)
                    {
                        break;
                    }
                }
                else
                {
                    ToggleBtnDrive(false);
                }
                
                Thread.Sleep(100);
            }

            while (true)
            {               
                int nowApp = (int)NUDAccelPressPower.Value;
                int nowBpp = (int)NUDBrakePressPower.Value;

                if(nowApp == 0 && nowBpp == 0)
                {
                    if (nowSpeed > defaultSpeed)        nowSpeed--;
                    else if (nowSpeed < defaultSpeed)   nowSpeed += 2; 
                    
                }

                // 액셀을 밟을 경우
                if(nowApp > 0 && nowSpeed <= 220)
                {             
                    
                    if(nowApp > nowSpeed)           // 속도가 증가하는 경우
                    {
                        nowSpeed += nowApp / 10;
                    }
                    else if(nowApp < nowSpeed)      // 속도가 감소하는 경우
                    {
                        nowSpeed--;
                    }
                    else                            // 속도가 유지되는 경우
                    {
                        nowSpeed = nowApp;
                    }
                }

                // 브레이크를 밟을 경우
                if(nowBpp > 0 && nowSpeed > 0)
                {
                    nowSpeed -= nowBpp / 10;
                }

                PrintSpeed(nowSpeed);

                Thread.Sleep(1000);
            }

            
        }
        

        private void BtnDrive_Click(object sender, EventArgs e)
        {
            try
            {
                LbRun.Text = "Run";
                if (timerThread == null)
                {
                    timerThread = new Thread(timerProcess);
                    timerThread.IsBackground = true;
                    timerThread.Start();
                }                
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

       

        private void timerProcess()
        {
            while(true)
            {
                int sec = int.Parse(DateTime.Now.ToString("ss"));
                if(sec % 10 == 0)
                {
                    string dd = GetControlValue(CbRoad);
                    string str = $"{stx}{float.Parse(LbSpeed.Text),5:F1}{double.Parse(TbLocationX.Text),10:F6}" +
                        $"{double.Parse(TbLocationY.Text),10:F6}{int.Parse(GetControlValue(CbRoad)):D8}{etx}";

                    byte[] bArr = Encoding.Default.GetBytes(str);

                    if (IsArrive(socket))
                    {
                        socket.Send(bArr);
                    }
                    Thread.Sleep(1000);
                }
                else
                {
                    //Thread.Sleep(100);
                }
                
            }
        }

       

        public bool IsArrive(Socket sock)
        {
            if(sock == null || sock.Connected != true)
            {
                timerThread.Abort();
                return false;
            }

            bool canRead = sock.Poll(1000, SelectMode.SelectRead);
            if(canRead && sock.Available == 0)
            {
                return false;
            }

            try
            {
                sock.Send(new byte[1], SocketFlags.OutOfBand);
                return true;
            }
            catch
            {
                return false;
            }
        }

        
    }
}
