namespace SocketDemo
{
    partial class ClientForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbSendHeart = new System.Windows.Forms.CheckBox();
            this.btn_discon = new System.Windows.Forms.Button();
            this.btn_con = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_LocalIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lv_rec = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_clear_rev = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rtb_send = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rtb_log = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbSendHeart);
            this.groupBox1.Controls.Add(this.btn_discon);
            this.groupBox1.Controls.Add(this.btn_con);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_port);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tb_LocalIP);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1016, 47);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "主机信息";
            // 
            // cbSendHeart
            // 
            this.cbSendHeart.AutoSize = true;
            this.cbSendHeart.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbSendHeart.Location = new System.Drawing.Point(733, 17);
            this.cbSendHeart.Name = "cbSendHeart";
            this.cbSendHeart.Size = new System.Drawing.Size(48, 27);
            this.cbSendHeart.TabIndex = 8;
            this.cbSendHeart.Text = "心跳";
            this.cbSendHeart.UseVisualStyleBackColor = true;
            // 
            // btn_discon
            // 
            this.btn_discon.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_discon.Enabled = false;
            this.btn_discon.Location = new System.Drawing.Point(658, 17);
            this.btn_discon.Name = "btn_discon";
            this.btn_discon.Size = new System.Drawing.Size(75, 27);
            this.btn_discon.TabIndex = 7;
            this.btn_discon.Text = "断开";
            this.btn_discon.UseVisualStyleBackColor = true;
            this.btn_discon.Click += new System.EventHandler(this.btn_discon_Click);
            // 
            // btn_con
            // 
            this.btn_con.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_con.Location = new System.Drawing.Point(583, 17);
            this.btn_con.Name = "btn_con";
            this.btn_con.Size = new System.Drawing.Size(75, 27);
            this.btn_con.TabIndex = 6;
            this.btn_con.Text = "连接";
            this.btn_con.UseVisualStyleBackColor = true;
            this.btn_con.Click += new System.EventHandler(this.btn_con_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(462, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(409, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "编码方式";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_port
            // 
            this.tb_port.Dock = System.Windows.Forms.DockStyle.Left;
            this.tb_port.Location = new System.Drawing.Point(277, 17);
            this.tb_port.Name = "tb_port";
            this.tb_port.Size = new System.Drawing.Size(132, 21);
            this.tb_port.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(212, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Server端口";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_LocalIP
            // 
            this.tb_LocalIP.Dock = System.Windows.Forms.DockStyle.Left;
            this.tb_LocalIP.Location = new System.Drawing.Point(80, 17);
            this.tb_LocalIP.Name = "tb_LocalIP";
            this.tb_LocalIP.Size = new System.Drawing.Size(132, 21);
            this.tb_LocalIP.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "ServerIP地址";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lv_rec);
            this.groupBox2.Controls.Add(this.btn_clear_rev);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1016, 210);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "接收";
            // 
            // lv_rec
            // 
            this.lv_rec.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3});
            this.lv_rec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_rec.FullRowSelect = true;
            this.lv_rec.GridLines = true;
            this.lv_rec.Location = new System.Drawing.Point(3, 17);
            this.lv_rec.Name = "lv_rec";
            this.lv_rec.Size = new System.Drawing.Size(917, 190);
            this.lv_rec.TabIndex = 2;
            this.lv_rec.UseCompatibleStateImageBehavior = false;
            this.lv_rec.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "时间";
            this.columnHeader1.Width = 121;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "内容";
            this.columnHeader3.Width = 562;
            // 
            // btn_clear_rev
            // 
            this.btn_clear_rev.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_clear_rev.Location = new System.Drawing.Point(920, 17);
            this.btn_clear_rev.MaximumSize = new System.Drawing.Size(93, 23);
            this.btn_clear_rev.Name = "btn_clear_rev";
            this.btn_clear_rev.Size = new System.Drawing.Size(93, 23);
            this.btn_clear_rev.TabIndex = 1;
            this.btn_clear_rev.Text = "清空";
            this.btn_clear_rev.UseVisualStyleBackColor = true;
            this.btn_clear_rev.Click += new System.EventHandler(this.btn_clear_rev_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rtb_send);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 257);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1016, 106);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发送";
            // 
            // rtb_send
            // 
            this.rtb_send.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_send.Location = new System.Drawing.Point(3, 17);
            this.rtb_send.Name = "rtb_send";
            this.rtb_send.Size = new System.Drawing.Size(917, 86);
            this.rtb_send.TabIndex = 1;
            this.rtb_send.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(920, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(93, 86);
            this.panel1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(0, 23);
            this.button1.MaximumSize = new System.Drawing.Size(93, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "清空";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.MaximumSize = new System.Drawing.Size(93, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "发送";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rtb_log);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 363);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1016, 410);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "日志";
            // 
            // rtb_log
            // 
            this.rtb_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_log.Location = new System.Drawing.Point(3, 17);
            this.rtb_log.Name = "rtb_log";
            this.rtb_log.Size = new System.Drawing.Size(1010, 390);
            this.rtb_log.TabIndex = 2;
            this.rtb_log.Text = "";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 773);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_LocalIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_con;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_clear_rev;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox rtb_send;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox rtb_log;
        private System.Windows.Forms.ListView lv_rec;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btn_discon;
        private System.Windows.Forms.CheckBox cbSendHeart;
        private System.Windows.Forms.Panel panel1;
    }

}