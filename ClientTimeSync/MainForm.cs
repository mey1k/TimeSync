using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using InpegSocketLib;
using System.Runtime.InteropServices;

namespace ClientTimeSync
{
    public partial class MainForm : Form
    {
        [DllImport("kernel32")]
        private extern static void GetSystemTime(ref SYSTEMTIME lpSystemTime);

        [DllImport("kernel32")]
        private extern static uint SetSystemTime(ref SYSTEMTIME lpSystemTime);

        System.Windows.Forms.Timer timerTimeSyn;

        private InpegClientSocket client = new InpegClientSocket();

        delegate void deleSetTimeSyncText(string strTimeInfo);

        public MainForm()
        {
            InitializeComponent();
            timerTimeSyn = new System.Windows.Forms.Timer();
            timerTimeSyn.Tick += new EventHandler(timer_Tick);
        }

        private void WriteStatusLog(string message)
        {
            Action doAction = delegate
            {
                listBoxStatus.Items.Insert(0, message);
                listBoxStatus.SelectedIndex = 0;
            };

            if (this.InvokeRequired) this.BeginInvoke(doAction);
            else doAction();
        }

        private void WriteReceiveData(string message)
        {
            Action doAction = delegate
            {
                txtReceiveData.Text += message;
            };

            if (this.InvokeRequired) this.BeginInvoke(doAction);
            else doAction();
        }

        private void ReceiveHandler(Socket sock, byte[] recvBuffer, int size)
        {
            string strBuffer = Encoding.UTF8.GetString(recvBuffer, 0, size);
            SetTime(strBuffer);
            strBuffer += "\r\n";
            WriteReceiveData(strBuffer);
        }

        private void DisconnectHandler(Socket sock)
        {
            WriteStatusLog("서버와의 연결이 끊어졌습니다");

            Action doAction = delegate
            {
                btnOpenClose.Text = "연결";
            };

            if (this.InvokeRequired) this.BeginInvoke(doAction);
            else doAction();
            while (!client.IsConnected)
            {
                btnOpenClose_Click(null, null);
                Thread.Sleep(10000);
            }
        }

        private void btnOpenClose_Click(object sender, EventArgs e)
        {
            if (!client.IsConnected)
            {
                client.ReceiveHandler = ReceiveHandler;
                client.DisconnectHandler = DisconnectHandler;

                WriteStatusLog("서버에 접속중...");

                Action doAction = delegate
                {
                    //if (client.Connect("ipvlocal.iptime.org", int.Parse(txtServerPort.Text), 3000))
                    //if (client.Connect("192.168.1.145", int.Parse(txtServerPort.Text), 3000))
                    if (client.Connect(IPAddress.Parse(txtServerIP.Text), int.Parse(txtServerPort.Text), 3000))
                    {
                        WriteStatusLog("서버에 접속했습니다");
                        btnOpenClose.Text = "종료";

                    }
                    else
                    {
                        WriteStatusLog("서버 접속에 실패했습니다");
                    }
                };
                this.BeginInvoke(doAction);
            }
            else
            {
                client.Disconnect();
                WriteStatusLog("서버 접속을 종료하였습니다");
                btnOpenClose.Text = "연결";
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (client.IsConnected)
            {
                timerTimeSyn.Interval = Convert.ToInt32(txtInterval.Text) * 1000; //주기 설정, 1초
                timerTimeSyn.Start();

                //string message = txtSendData.Text;
                string message = DateTime.Now.ToString();
                if (message.Length > 0)
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(message);
                    int ret = client.Send(buffer, buffer.Length);
                }
            }
        }

        private void btnStatusClear_Click(object sender, EventArgs e)
        {
            listBoxStatus.Items.Clear();
        }

        private void btnReceiveDataClear_Click(object sender, EventArgs e)
        {
            txtReceiveData.Text = "";
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.Disconnect();
        }

        // 시간 동기화 설정
        private struct SYSTEMTIME
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMilliseconds;
        }

        private void GetTime()
        {
            // Call the native GetSystemTime method
            // with the defined structure.
            SYSTEMTIME stime = new SYSTEMTIME();
            GetSystemTime(ref stime);

            // Show the current time.           
            //MessageBox.Show("Current Time: " +
            //    stime.wHour.ToString() + ":"
            //    + stime.wMinute.ToString());
        }

        private DateTime SetSystemTime(string strServerTime)
        {
            int iyear = 0;
            int imonth = 0;
            int iday = 0;
            int ihour = 0;
            int iminute = 0;
            int iSecond = 0;

            if (strServerTime.Length == 19)
            {
                iyear = int.Parse(strServerTime.Substring(0, 4));
                imonth = int.Parse(strServerTime.Substring(5, 2));
                iday = int.Parse(strServerTime.Substring(8, 2));
                ihour = int.Parse(strServerTime.Substring(11, 2));
                iminute = int.Parse(strServerTime.Substring(14, 2));
                iSecond = int.Parse(strServerTime.Substring(17, 2));
            }

            return new DateTime(iyear, imonth, iday, ihour, iminute, iSecond);

        }

        private void SetTime(string strServerTime)
        {
            // Call the native GetSystemTime method
            // with the defined structure.
            SYSTEMTIME systime = new SYSTEMTIME();
            //GetSystemTime(ref systime);
            //SetSystemTime(strServerTime);
            DateTime tempTime = Convert.ToDateTime(strServerTime);

            DateTimeOffset sourceTime;
            DateTime targetTime;

            // Convert UTC to DateTime value
            sourceTime = new DateTimeOffset(tempTime, TimeSpan.Zero);
            targetTime = sourceTime.DateTime;
            Console.WriteLine("{0} converts to {1} {2}",
                              sourceTime,
                              targetTime,
                              targetTime.Kind.ToString());

            // Convert local time to DateTime value
            sourceTime = new DateTimeOffset(tempTime,
                                            TimeZoneInfo.Local.GetUtcOffset(tempTime));
            targetTime = sourceTime.DateTime;
            Console.WriteLine("{0} converts to {1} {2}",
                              sourceTime,
                              targetTime,
                              targetTime.Kind.ToString());

            if (sourceTime.Offset.TotalHours != 0)
            {
                targetTime = targetTime.ToUniversalTime();
                sourceTime = targetTime;
                Console.WriteLine("{0} converts to {1} {2}",
                                  sourceTime,
                                  targetTime,
                targetTime.Kind.ToString());
            }

            string strTimeInfo;

            // Set the system clock ahead one hour.
            systime.wYear = (ushort)targetTime.Year;
            systime.wMonth = (ushort)targetTime.Month;
            systime.wDayOfWeek = (ushort)0;
            systime.wDay = (ushort)targetTime.Day;
            systime.wHour = (ushort)targetTime.Hour;
            systime.wMinute = (ushort)targetTime.Minute;
            systime.wSecond = (ushort)targetTime.Second;
            systime.wMilliseconds = (ushort)0;

            SetSystemTime(ref systime);

            WriteStatusLog("New time: " + systime.wYear.ToString()+"-"+systime.wMonth.ToString()+"-"+systime.wDay.ToString()+ " " +
                systime.wHour.ToString()+":"+systime.wMinute.ToString()+":"+systime.wSecond.ToString()+" 적용 되었습니다.");

            strTimeInfo = "시계가 " + systime.wYear.ToString() + "-" + systime.wMonth.ToString() + "-" + systime.wDay.ToString() + " " +
                systime.wHour.ToString() + ":" + systime.wMinute.ToString() + ":" + systime.wSecond.ToString() +"에" +" "+txtServerIP.Text.ToString()
                +"과(와) 동기화되었습니다.";

            SetTimeSyncText(strTimeInfo);
        }

        private void SetTimeSyncText(string strTimeinfo)
        {
            if ( lblSyncInfo.InvokeRequired )
                lblSyncInfo.Invoke(new deleSetTimeSyncText(SetTimeSyncText), strTimeinfo);
            else
                lblSyncInfo.Text = strTimeinfo;
        }

        void timer_Tick(object sender, System.EventArgs e)
        {
            //수행해야할 작업
            btnSend_Click(null, null);
        }
    }
}
