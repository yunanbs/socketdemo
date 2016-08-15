namespace SocketDemo
{
    partial class ServerForm
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_heart = new System.Windows.Forms.CheckBox();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_lis = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_LocalIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lv_rec = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_clear_rev = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rtb_send = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rtb_log = new System.Windows.Forms.RichTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rtb_update = new System.Windows.Forms.RichTextBox();
            this.EventTrick = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_heart);
            this.groupBox1.Controls.Add(this.btn_stop);
            this.groupBox1.Controls.Add(this.btn_lis);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_port);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tb_LocalIP);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(200, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(816, 47);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "服务器";
            // 
            // cb_heart
            // 
            this.cb_heart.AutoSize = true;
            this.cb_heart.Dock = System.Windows.Forms.DockStyle.Left;
            this.cb_heart.Location = new System.Drawing.Point(688, 17);
            this.cb_heart.Name = "cb_heart";
            this.cb_heart.Size = new System.Drawing.Size(72, 27);
            this.cb_heart.TabIndex = 8;
            this.cb_heart.Text = "发送心跳";
            this.cb_heart.UseVisualStyleBackColor = true;
            // 
            // btn_stop
            // 
            this.btn_stop.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_stop.Enabled = false;
            this.btn_stop.Location = new System.Drawing.Point(613, 17);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(75, 27);
            this.btn_stop.TabIndex = 7;
            this.btn_stop.Text = "停止监听";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // btn_lis
            // 
            this.btn_lis.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_lis.Location = new System.Drawing.Point(538, 17);
            this.btn_lis.Name = "btn_lis";
            this.btn_lis.Size = new System.Drawing.Size(75, 27);
            this.btn_lis.TabIndex = 6;
            this.btn_lis.Text = "开始监听";
            this.btn_lis.UseVisualStyleBackColor = true;
            this.btn_lis.Click += new System.EventHandler(this.btn_lis_Click);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBox1.Location = new System.Drawing.Point(438, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(385, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "连接名称";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_port
            // 
            this.tb_port.Dock = System.Windows.Forms.DockStyle.Left;
            this.tb_port.Location = new System.Drawing.Point(253, 17);
            this.tb_port.Name = "tb_port";
            this.tb_port.Size = new System.Drawing.Size(132, 21);
            this.tb_port.TabIndex = 3;
            this.tb_port.Text = "8900";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(200, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "监听端口";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_LocalIP
            // 
            this.tb_LocalIP.Dock = System.Windows.Forms.DockStyle.Left;
            this.tb_LocalIP.Location = new System.Drawing.Point(68, 17);
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
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "本机IP地址";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lv_rec);
            this.groupBox2.Controls.Add(this.btn_clear_rev);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(200, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(816, 210);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "原始数据";
            // 
            // lv_rec
            // 
            this.lv_rec.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader2});
            this.lv_rec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_rec.FullRowSelect = true;
            this.lv_rec.GridLines = true;
            this.lv_rec.Location = new System.Drawing.Point(3, 17);
            this.lv_rec.Name = "lv_rec";
            this.lv_rec.Size = new System.Drawing.Size(693, 190);
            this.lv_rec.TabIndex = 3;
            this.lv_rec.UseCompatibleStateImageBehavior = false;
            this.lv_rec.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "时间";
            this.columnHeader1.Width = 134;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ID";
            this.columnHeader3.Width = 137;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "内容";
            this.columnHeader2.Width = 540;
            // 
            // btn_clear_rev
            // 
            this.btn_clear_rev.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_clear_rev.Location = new System.Drawing.Point(696, 17);
            this.btn_clear_rev.MaximumSize = new System.Drawing.Size(117, 23);
            this.btn_clear_rev.Name = "btn_clear_rev";
            this.btn_clear_rev.Size = new System.Drawing.Size(117, 23);
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
            this.groupBox3.Location = new System.Drawing.Point(200, 257);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(816, 95);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发送";
            // 
            // rtb_send
            // 
            this.rtb_send.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_send.Location = new System.Drawing.Point(3, 17);
            this.rtb_send.Name = "rtb_send";
            this.rtb_send.Size = new System.Drawing.Size(693, 75);
            this.rtb_send.TabIndex = 1;
            this.rtb_send.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(696, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(117, 75);
            this.panel1.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.Location = new System.Drawing.Point(0, 23);
            this.button2.MaximumSize = new System.Drawing.Size(117, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "发送";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.MaximumSize = new System.Drawing.Size(117, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "清空";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rtb_log);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(200, 519);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(816, 214);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "日志";
            // 
            // rtb_log
            // 
            this.rtb_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_log.Location = new System.Drawing.Point(3, 17);
            this.rtb_log.Name = "rtb_log";
            this.rtb_log.Size = new System.Drawing.Size(810, 194);
            this.rtb_log.TabIndex = 2;
            this.rtb_log.Text = "";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.treeView1);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 733);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(3, 17);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(194, 713);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rtb_update);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(200, 352);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(816, 167);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "上传数据";
            // 
            // rtb_update
            // 
            this.rtb_update.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_update.Location = new System.Drawing.Point(3, 17);
            this.rtb_update.Name = "rtb_update";
            this.rtb_update.Size = new System.Drawing.Size(810, 147);
            this.rtb_update.TabIndex = 2;
            this.rtb_update.Text = "";
            // 
            // EventTrick
            // 
            this.EventTrick.Interval = 60000;
            this.EventTrick.Tick += new System.EventHandler(this.EventTrick_Tick);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 733);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.Name = "ServerForm";
            this.Text = "ServerForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerForm_FormClosing);
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_LocalIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_lis;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_clear_rev;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox rtb_log;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.RichTextBox rtb_send;
        private System.Windows.Forms.ListView lv_rec;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.CheckBox cb_heart;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RichTextBox rtb_update;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer EventTrick;
    }
}