using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniProject2_WinForms_ServerProgram
{
    public partial class FormMain : Form
    {
        Socket serverSocket = null;
        Socket socket = null;
        Thread serverThread = null;
        Thread receiptThread = null;
        Thread fabricationThread = null;
        List<Socket> list = new List<Socket>();

        byte[] ip = { 0, 0, 0, 0 };

        IAsyncResult ar;
        bool pending = false;

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\kosta\C#\trafficStatus.mdf;Integrated Security=True;Connect Timeout=30";
        DbConnecter receiptDbConnecter;
        DbConnecter fabricationDbConnecter;

        public FormMain()
        {
            InitializeComponent();
            receiptDbConnecter = new DbConnecter(connectionString);
            fabricationDbConnecter = new DbConnecter(connectionString);

        }

        private delegate void PrintStatusCB(string str);

        private void PrintStatus(string str)
        {
            if (TbMornitering.InvokeRequired)
            {
                Invoke(new PrintStatusCB(PrintStatus), str);
            }
            else
            {
                TbMornitering.AppendText(str + "\r\n");
            }
        }
                

        private void MnuSetting_Click(object sender, EventArgs e)
        {
            FormSet formSet = new FormSet();
            DialogResult dialogResult = formSet.ShowDialog();

            if(dialogResult != DialogResult.OK)
            {
                return;
            }
            ip = Encoding.Default.GetBytes(FormSet.serverIp);
        }

        private void BtnRun_Click(object sender, EventArgs e)
        {
            if(serverSocket != null)
            {
                serverSocket.Close();
            }
            if(serverThread != null)
            {
                serverThread.Abort();
            }
            
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverThread = new Thread(serverProcess);
            serverThread.IsBackground = true;
            serverThread.Start();


        }

        private void DoReceipt()
        {
            if(receiptThread != null)
            {
                receiptThread.Abort();
                receiptThread = null;
            }            

            receiptThread = new Thread(receiptProcess);
            receiptThread.IsBackground = true;
            receiptThread.Start();
        }

        private Socket acceptSocket()
        {
            Socket tempSocket = serverSocket.EndAccept(ar);
            serverSocket.BeginAccept(new AsyncCallback(OnAccept), null);
            pending = false;
            return tempSocket;
        }

        private void OnAccept(IAsyncResult iar)
        {
            pending = true;
            // IAsyncResult는 소켓 생성시 사용하는 객체입니다.
            // 현재 OnAccept() 내에서 소켓을 생성하지 않으므로 전역변수에 대입하여
            // 추후 소켓을 생성할 때 사용할 수 있도록 합니다.
            ar = iar;
        }

        private void serverProcess()
        {
            if (fabricationThread != null)
            {
                fabricationThread.Abort();
                fabricationThread = null;
            }
            fabricationThread = new Thread(fabricationProcess);
            fabricationThread.IsBackground = true;
            fabricationThread.Start();

            IPAddress ipAddress = new IPAddress(ip);
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, int.Parse(FormSet.serverPort));
            serverSocket.Bind(ipEndPoint);
            serverSocket.Listen(int.MaxValue);

            serverSocket.BeginAccept(new AsyncCallback(OnAccept), null);

            while (true)
            {
                if (pending)
                {
                    socket = acceptSocket();
                    DoReceipt();
                    list.Add(socket);
                }
                Thread.Sleep(100);
            }
            
        }

        private void receiptProcedure(Socket socket, byte[] bArr)
        {
            string str = Encoding.Default.GetString(bArr);

            string speed = str.Substring(1, 5);
            string locationX = str.Substring(6, 10);
            string locationY = str.Substring(16, 10);
            string roadId = str.Substring(26, 8);
            string sTime = DateTime.Now.ToString("yyyy -MM-dd HH:mm:ss");

            PrintStatus($"{speed} {locationX} {locationY} {roadId} {sTime}");

            string sql = "";
            

            sql = $"INSERT INTO traffic_status(r_id, ts_speed, ts_loc_x, ts_loc_y, time)" +
                $" VALUES('{roadId}', '{speed}', '{locationX}', '{locationY}', '{sTime}')";

            receiptDbConnecter.RunSql(sql);
        }

        private void receiptProcess()
        {
            
            while (true)
            {
                for(int i = 0; i < list.Count; i++)
                {
                   
                    if (list[i] != null && list[i].Available > 0)
                    {
                        string car = ((IPEndPoint)list[i].RemoteEndPoint).Port.ToString();
                        PrintStatus(car + "번 차량으로부터 데이터가 전송되었습니다.");
                        byte[] bArr = new byte[list[i].Available];
                        list[i].Receive(bArr);
                        //PrintStatus(Encoding.Default.GetString(bArr));
                        receiptProcedure(socket, bArr);
                    }
                }
                Thread.Sleep(100);
            }
        }

        private void fabricationProcess()
        {
            while (true)
            {
                int sec = int.Parse(DateTime.Now.ToString("ss"));
                if(sec % 10 == 9)
                {
                    string sql = "";
                    sql = "SELECT COUNT(*) FROM traffic_status";
                    
                    int count = (int)fabricationDbConnecter.Get(sql);
                    if(count == 0)
                    {
                        continue;
                    }
                    else
                    {

                        //sql = "SELECT count(distinct r_id) FROM traffic_status";
                        //int roadCount = (int)fabricationDbConnecter.Get(sql);
                        //MessageBox.Show($"{roadCount}");

                        sql = "DELETE FROM traffic_status";
                        fabricationDbConnecter.RunSql(sql);

                        sql = "DBCC CHECKIDENT('traffic_status', RESEED, 0)";
                        fabricationDbConnecter.RunSql(sql);
                    }
                }


            }
        }
    }    
}
