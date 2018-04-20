﻿namespace ClientTimeSync
{
    partial class MainForm
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.btnOpenClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStatusClear = new System.Windows.Forms.Button();
            this.listBoxStatus = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnReceiveDataClear = new System.Windows.Forms.Button();
            this.txtReceiveData = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblSyncInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "동기서버 IP";
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(88, 21);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(100, 21);
            this.txtServerIP.TabIndex = 1;
            this.txtServerIP.Text = "127.0.0.1";
            // 
            // btnOpenClose
            // 
            this.btnOpenClose.Location = new System.Drawing.Point(387, 19);
            this.btnOpenClose.Name = "btnOpenClose";
            this.btnOpenClose.Size = new System.Drawing.Size(75, 23);
            this.btnOpenClose.TabIndex = 2;
            this.btnOpenClose.Text = "접속";
            this.btnOpenClose.UseVisualStyleBackColor = true;
            this.btnOpenClose.Click += new System.EventHandler(this.btnOpenClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "동기서버 포트";
            // 
            // txtServerPort
            // 
            this.txtServerPort.Location = new System.Drawing.Point(281, 21);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(100, 21);
            this.txtServerPort.TabIndex = 4;
            this.txtServerPort.Text = "8010";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(222, 54);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(108, 23);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "지금 업데이트(U)";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "상태정보";
            // 
            // btnStatusClear
            // 
            this.btnStatusClear.Location = new System.Drawing.Point(410, 147);
            this.btnStatusClear.Name = "btnStatusClear";
            this.btnStatusClear.Size = new System.Drawing.Size(75, 23);
            this.btnStatusClear.TabIndex = 9;
            this.btnStatusClear.Text = "Clear";
            this.btnStatusClear.UseVisualStyleBackColor = true;
            this.btnStatusClear.Click += new System.EventHandler(this.btnStatusClear_Click);
            // 
            // listBoxStatus
            // 
            this.listBoxStatus.FormattingEnabled = true;
            this.listBoxStatus.ItemHeight = 12;
            this.listBoxStatus.Location = new System.Drawing.Point(16, 173);
            this.listBoxStatus.MinimumSize = new System.Drawing.Size(469, 130);
            this.listBoxStatus.Name = "listBoxStatus";
            this.listBoxStatus.Size = new System.Drawing.Size(469, 124);
            this.listBoxStatus.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 308);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "수신데이터";
            // 
            // btnReceiveDataClear
            // 
            this.btnReceiveDataClear.Location = new System.Drawing.Point(410, 303);
            this.btnReceiveDataClear.Name = "btnReceiveDataClear";
            this.btnReceiveDataClear.Size = new System.Drawing.Size(75, 23);
            this.btnReceiveDataClear.TabIndex = 12;
            this.btnReceiveDataClear.Text = "Clear";
            this.btnReceiveDataClear.UseVisualStyleBackColor = true;
            this.btnReceiveDataClear.Click += new System.EventHandler(this.btnReceiveDataClear_Click);
            // 
            // txtReceiveData
            // 
            this.txtReceiveData.Location = new System.Drawing.Point(18, 332);
            this.txtReceiveData.Multiline = true;
            this.txtReceiveData.Name = "txtReceiveData";
            this.txtReceiveData.Size = new System.Drawing.Size(467, 130);
            this.txtReceiveData.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "동기화 주기(초)";
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(116, 56);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(100, 21);
            this.txtInterval.TabIndex = 6;
            this.txtInterval.Text = "10";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // lblSyncInfo
            // 
            this.lblSyncInfo.AutoSize = true;
            this.lblSyncInfo.Location = new System.Drawing.Point(14, 98);
            this.lblSyncInfo.Name = "lblSyncInfo";
            this.lblSyncInfo.Size = new System.Drawing.Size(0, 12);
            this.lblSyncInfo.TabIndex = 15;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 477);
            this.Controls.Add(this.lblSyncInfo);
            this.Controls.Add(this.txtReceiveData);
            this.Controls.Add(this.btnReceiveDataClear);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listBoxStatus);
            this.Controls.Add(this.btnStatusClear);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtInterval);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtServerPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOpenClose);
            this.Controls.Add(this.txtServerIP);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "시간동기클라이언트";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.Button btnOpenClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtServerPort;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnStatusClear;
        private System.Windows.Forms.ListBox listBoxStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnReceiveDataClear;
        private System.Windows.Forms.TextBox txtReceiveData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lblSyncInfo;
    }
}

