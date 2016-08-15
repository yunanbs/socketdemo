namespace SocketDemo
{
    partial class ComForm
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
            this.cb_hexrec = new System.Windows.Forms.CheckBox();
            this.cb_hexsend = new System.Windows.Forms.CheckBox();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.cb_baudrate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_comname = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lv_rec = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_clear_rev = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rtb_send = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_send = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rtb_update = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rtb_log = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_hexrec);
            this.groupBox1.Controls.Add(this.cb_hexsend);
            this.groupBox1.Controls.Add(this.btn_stop);
            this.groupBox1.Controls.Add(this.btn_start);
            this.groupBox1.Controls.Add(this.cb_baudrate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cb_comname);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1016, 43);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "客户端信息";
            // 
            // cb_hexrec
            // 
            this.cb_hexrec.AutoSize = true;
            this.cb_hexrec.Dock = System.Windows.Forms.DockStyle.Left;
            this.cb_hexrec.Location = new System.Drawing.Point(591, 17);
            this.cb_hexrec.Name = "cb_hexrec";
            this.cb_hexrec.Size = new System.Drawing.Size(96, 23);
            this.cb_hexrec.TabIndex = 5;
            this.cb_hexrec.Text = "十六进制接收";
            this.cb_hexrec.UseVisualStyleBackColor = true;
            // 
            // cb_hexsend
            // 
            this.cb_hexsend.AutoSize = true;
            this.cb_hexsend.Dock = System.Windows.Forms.DockStyle.Left;
            this.cb_hexsend.Location = new System.Drawing.Point(495, 17);
            this.cb_hexsend.Name = "cb_hexsend";
            this.cb_hexsend.Size = new System.Drawing.Size(96, 23);
            this.cb_hexsend.TabIndex = 4;
            this.cb_hexsend.Text = "十六进制发送";
            this.cb_hexsend.UseVisualStyleBackColor = true;
            // 
            // btn_stop
            // 
            this.btn_stop.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_stop.Enabled = false;
            this.btn_stop.Location = new System.Drawing.Point(420, 17);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(75, 23);
            this.btn_stop.TabIndex = 3;
            this.btn_stop.Text = "停止";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // btn_start
            // 
            this.btn_start.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_start.Location = new System.Drawing.Point(345, 17);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 2;
            this.btn_start.Text = "启动";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // cb_baudrate
            // 
            this.cb_baudrate.Dock = System.Windows.Forms.DockStyle.Left;
            this.cb_baudrate.FormattingEnabled = true;
            this.cb_baudrate.Items.AddRange(new object[] {
            "9600",
            "115200"});
            this.cb_baudrate.Location = new System.Drawing.Point(224, 17);
            this.cb_baudrate.Name = "cb_baudrate";
            this.cb_baudrate.Size = new System.Drawing.Size(121, 20);
            this.cb_baudrate.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(183, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "波特率";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cb_comname
            // 
            this.cb_comname.Dock = System.Windows.Forms.DockStyle.Left;
            this.cb_comname.FormattingEnabled = true;
            this.cb_comname.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4"});
            this.cb_comname.Location = new System.Drawing.Point(62, 17);
            this.cb_comname.Name = "cb_comname";
            this.cb_comname.Size = new System.Drawing.Size(121, 20);
            this.cb_comname.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择COM口";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lv_rec);
            this.groupBox2.Controls.Add(this.btn_clear_rev);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1016, 210);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "原始数据";
            // 
            // lv_rec
            // 
            this.lv_rec.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lv_rec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_rec.FullRowSelect = true;
            this.lv_rec.GridLines = true;
            this.lv_rec.Location = new System.Drawing.Point(3, 17);
            this.lv_rec.Name = "lv_rec";
            this.lv_rec.Size = new System.Drawing.Size(893, 190);
            this.lv_rec.TabIndex = 3;
            this.lv_rec.UseCompatibleStateImageBehavior = false;
            this.lv_rec.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "时间";
            this.columnHeader1.Width = 134;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "内容";
            this.columnHeader2.Width = 712;
            // 
            // btn_clear_rev
            // 
            this.btn_clear_rev.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_clear_rev.Location = new System.Drawing.Point(896, 17);
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
            this.groupBox3.Location = new System.Drawing.Point(0, 253);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1016, 95);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发送";
            // 
            // rtb_send
            // 
            this.rtb_send.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_send.Location = new System.Drawing.Point(3, 17);
            this.rtb_send.Name = "rtb_send";
            this.rtb_send.Size = new System.Drawing.Size(893, 75);
            this.rtb_send.TabIndex = 1;
            this.rtb_send.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_send);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(896, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(117, 75);
            this.panel1.TabIndex = 5;
            // 
            // btn_send
            // 
            this.btn_send.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_send.Location = new System.Drawing.Point(0, 23);
            this.btn_send.MaximumSize = new System.Drawing.Size(117, 23);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(117, 23);
            this.btn_send.TabIndex = 4;
            this.btn_send.Text = "发送";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
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
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rtb_update);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(0, 348);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1016, 164);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "上传数据";
            // 
            // rtb_update
            // 
            this.rtb_update.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_update.Location = new System.Drawing.Point(3, 17);
            this.rtb_update.Name = "rtb_update";
            this.rtb_update.Size = new System.Drawing.Size(1010, 144);
            this.rtb_update.TabIndex = 2;
            this.rtb_update.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rtb_log);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 512);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1016, 261);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "日志";
            // 
            // rtb_log
            // 
            this.rtb_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_log.Location = new System.Drawing.Point(3, 17);
            this.rtb_log.Name = "rtb_log";
            this.rtb_log.Size = new System.Drawing.Size(1010, 241);
            this.rtb_log.TabIndex = 2;
            this.rtb_log.Text = "";
            // 
            // ComForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 773);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ComForm";
            this.Text = "ComForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ComForm_FormClosing);
            this.Load += new System.EventHandler(this.ComForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cb_comname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lv_rec;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btn_clear_rev;
        private System.Windows.Forms.CheckBox cb_hexrec;
        private System.Windows.Forms.CheckBox cb_hexsend;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox rtb_send;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RichTextBox rtb_update;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox rtb_log;
        private System.Windows.Forms.ComboBox cb_baudrate;
        private System.Windows.Forms.Label label2;
    }
}