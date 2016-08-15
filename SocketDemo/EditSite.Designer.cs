namespace SocketDemo
{
    partial class EditSite
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
            this.panel7 = new System.Windows.Forms.Panel();
            this.btn_cofirm = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.cb_heart = new System.Windows.Forms.CheckBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cb_protocol = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tb_baudrate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tb_ip = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cb_sitetype = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_sitename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel7);
            this.groupBox1.Controls.Add(this.panel8);
            this.groupBox1.Controls.Add(this.panel6);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 241);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "站点信息";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btn_cofirm);
            this.panel7.Controls.Add(this.btn_close);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(3, 213);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(330, 26);
            this.panel7.TabIndex = 6;
            // 
            // btn_cofirm
            // 
            this.btn_cofirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_cofirm.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_cofirm.Location = new System.Drawing.Point(180, 0);
            this.btn_cofirm.Name = "btn_cofirm";
            this.btn_cofirm.Size = new System.Drawing.Size(75, 26);
            this.btn_cofirm.TabIndex = 1;
            this.btn_cofirm.Tag = "";
            this.btn_cofirm.Text = "提交";
            this.btn_cofirm.UseVisualStyleBackColor = true;
            this.btn_cofirm.Click += new System.EventHandler(this.btn_cofirm_Click);
            // 
            // btn_close
            // 
            this.btn_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_close.Location = new System.Drawing.Point(255, 0);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 26);
            this.btn_close.TabIndex = 0;
            this.btn_close.Text = "取消";
            this.btn_close.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.cb_heart);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(3, 185);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(330, 28);
            this.panel8.TabIndex = 7;
            // 
            // cb_heart
            // 
            this.cb_heart.AutoSize = true;
            this.cb_heart.Dock = System.Windows.Forms.DockStyle.Right;
            this.cb_heart.Location = new System.Drawing.Point(258, 0);
            this.cb_heart.Name = "cb_heart";
            this.cb_heart.Size = new System.Drawing.Size(72, 28);
            this.cb_heart.TabIndex = 0;
            this.cb_heart.Text = "默认心跳";
            this.cb_heart.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.cb_protocol);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(3, 157);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(330, 28);
            this.panel6.TabIndex = 5;
            // 
            // cb_protocol
            // 
            this.cb_protocol.Dock = System.Windows.Forms.DockStyle.Right;
            this.cb_protocol.FormattingEnabled = true;
            this.cb_protocol.Location = new System.Drawing.Point(63, 0);
            this.cb_protocol.Name = "cb_protocol";
            this.cb_protocol.Size = new System.Drawing.Size(267, 20);
            this.cb_protocol.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "所用协议";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tb_baudrate);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 129);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(330, 28);
            this.panel5.TabIndex = 4;
            // 
            // tb_baudrate
            // 
            this.tb_baudrate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_baudrate.Dock = System.Windows.Forms.DockStyle.Right;
            this.tb_baudrate.Location = new System.Drawing.Point(63, 0);
            this.tb_baudrate.Name = "tb_baudrate";
            this.tb_baudrate.Size = new System.Drawing.Size(267, 21);
            this.tb_baudrate.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "波特率";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tb_port);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 101);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(330, 28);
            this.panel4.TabIndex = 3;
            // 
            // tb_port
            // 
            this.tb_port.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_port.Dock = System.Windows.Forms.DockStyle.Right;
            this.tb_port.Location = new System.Drawing.Point(63, 0);
            this.tb_port.Name = "tb_port";
            this.tb_port.Size = new System.Drawing.Size(267, 21);
            this.tb_port.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "端口/COM";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tb_ip);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 73);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(330, 28);
            this.panel3.TabIndex = 2;
            // 
            // tb_ip
            // 
            this.tb_ip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ip.Dock = System.Windows.Forms.DockStyle.Right;
            this.tb_ip.Location = new System.Drawing.Point(63, 0);
            this.tb_ip.Name = "tb_ip";
            this.tb_ip.Size = new System.Drawing.Size(267, 21);
            this.tb_ip.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "主机地址";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cb_sitetype);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(330, 28);
            this.panel2.TabIndex = 1;
            // 
            // cb_sitetype
            // 
            this.cb_sitetype.Dock = System.Windows.Forms.DockStyle.Right;
            this.cb_sitetype.FormattingEnabled = true;
            this.cb_sitetype.Location = new System.Drawing.Point(63, 0);
            this.cb_sitetype.Name = "cb_sitetype";
            this.cb_sitetype.Size = new System.Drawing.Size(267, 20);
            this.cb_sitetype.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "站点类型";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tb_sitename);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 28);
            this.panel1.TabIndex = 0;
            // 
            // tb_sitename
            // 
            this.tb_sitename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_sitename.Dock = System.Windows.Forms.DockStyle.Right;
            this.tb_sitename.Location = new System.Drawing.Point(63, 0);
            this.tb_sitename.Name = "tb_sitename";
            this.tb_sitename.Size = new System.Drawing.Size(267, 21);
            this.tb_sitename.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "站点名称";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EditSite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 241);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditSite";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditSite";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditSite_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb_sitename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cb_sitetype;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tb_ip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox cb_protocol;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox tb_baudrate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btn_cofirm;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.CheckBox cb_heart;
    }
}