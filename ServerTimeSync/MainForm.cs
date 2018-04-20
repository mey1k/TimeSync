﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

using InpegSocketLib;

namespace ServerTimeSync
{
    public partial class MainForm : Form
    {
        private InpegServerSocket server = new InpegServerSocket();

        public MainForm()
        {
            InitializeComponent();
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

        private bool StartServer(int port)
        {
            if (!server.IsRunning)
            {
                server.ClientConnectHandler = ClientConnectHandler;
                server.ClientDisconnectHandler = ClientDisconnectHandler;
                server.ReceiveHandler = ClientReceiveHandler;
                return server.StartServer(port);
            }
            return false;
        }

        private void ClientConnectHandler(InpegClientSession client)
        {
            IPEndPoint clientAddress = (IPEndPoint)client.clientSock.RemoteEndPoint;
            WriteStatusLog(string.Format("클라이언트 {0}:{1} 접속되었습니다", clientAddress.Address.ToString(), clientAddress.Port));
        }

        private void ClientDisconnectHandler(InpegClientSession client)
        {
            IPEndPoint clientAddress = (IPEndPoint)client.clientSock.RemoteEndPoint;
            WriteStatusLog(string.Format("클라이언트 {0}:{1} 접속이 끊어졌습니다", clientAddress.Address.ToString(), clientAddress.Port));
        }

        private void ClientReceiveHandler(InpegClientSession client, byte[] recvBuffer, int size)
        {
            IPEndPoint clientAddress = (IPEndPoint)client.clientSock.RemoteEndPoint;

            DateTime now = DateTime.Now;
            byte[] byaSysTime = StringToByte(now.ToString());

            string strBuffer = Encoding.UTF8.GetString(byaSysTime, 0, byaSysTime.Length);
            client.Send(byaSysTime, byaSysTime.Length);

            strBuffer = strBuffer.Trim((char)0x00);
            strBuffer += "\r\n";
            WriteStatusLog(clientAddress.Address.ToString() + " 클라이언트 " + strBuffer + " 송신 ");

            string strReceiveData = Encoding.UTF8.GetString(recvBuffer, 0, size);
            strReceiveData += "\r\n";
            WriteReceiveData(strReceiveData);
        }
        private byte[] StringToByte(string str)
        {
            byte[] StrByte = Encoding.UTF8.GetBytes(str);
            return StrByte;
        }
        private void btnOpenClose_Click(object sender, EventArgs e)
        {
            if (!server.IsRunning)
            {
                int port = 8080;
                try
                {
                    port = int.Parse(txtServerPort.Text);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    WriteStatusLog("잘못된 포트번호 입니다");
                    return;
                }

                if (StartServer(port))
                {
                    WriteStatusLog(string.Format("서버 {0} 를 시작했습니다", port));
                    btnOpenClose.Text = "종료";
                }
                else
                {
                    WriteStatusLog("서버 시작에 실패했습니다");
                    btnOpenClose.Text = "시작";
                }
            }
            else
            {
                WriteStatusLog("서버를 종료중입니다...");
                server.StopServer();
                WriteStatusLog("서버를 종료하였습니다");
                btnOpenClose.Text = "시작";
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.StopServer();
        }

        private void btnStatusClear_Click(object sender, EventArgs e)
        {
            listBoxStatus.Items.Clear();
        }

        private void btnReceiveDataClear_Click(object sender, EventArgs e)
        {
            txtReceiveData.Text = "";
        }
    }
}
