using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SocketDemo.Lib;
using System.Threading;

namespace SocketDemo
{
    public partial class ComForm : Form,PubStart
    {
        ComClass m_comlib;//串口通讯对象
        bool _isrun = false;
        string m_receivedata = "";
        DataDeal m_datadeal = new DataDeal();//报文处理对象
        string m_protocol = "";
        string m_baudrate = "";

        private System.Timers.Timer Rec_timer = new System.Timers.Timer();

        public ComForm()
        {
            InitializeComponent();
        }

        public ComForm(string comno, string baudrate, string protocol,string header)
        {
            InitializeComponent();
            this.Text = header;
            m_protocol = protocol;
            cb_comname.Text = comno;
            cb_baudrate.Text = baudrate;
            m_baudrate = baudrate;
        }

        /// <summary>
        /// 显示接收信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="message"></param>
        public void ShowReceive(string message)
        {
            if (lv_rec.Items.Count > 100)
                lv_rec.Items.Clear();

            ListViewItem lvi = new ListViewItem();
            lvi.Text = System.DateTime.Now.ToLongTimeString();
            lvi.SubItems.Add(message);
            lv_rec.Items.Add(lvi);
        }

        /// <summary>
        /// 显示日志
        /// </summary>
        /// <param name="message"></param>
        public void ShowLog(string message)
        {
            if (rtb_log.Lines.Count() > 100)
                rtb_log.Clear();
            rtb_log.AppendText("[" + System.DateTime.Now.ToLongTimeString() + "]" + message + "\n");
        }

        /// <summary>
        /// 显示上传参数
        /// </summary>
        /// <param name="message"></param>
        public void ShowUpdate(string message)
        {
            if (rtb_update.Lines.Count() > 100)
                rtb_update.Clear();
            rtb_update.AppendText("[" + System.DateTime.Now.ToLongTimeString() + "]" + message + "\n");
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            try
            {
                string comno = cb_comname.Text;
                string baudrate = cb_baudrate.Text;
                m_comlib = new ComClass(comno, baudrate);
                int r = m_comlib.OpenCom();
                string log = (r > 0) ? "串口已打开" : "打开串口失败";
                ShowLog(log);
                if (r > 0)
                {
                    _isrun = true;
                    BeginReceive();
                    btn_start.Enabled = false;
                    btn_stop.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void PubStart()
        {
            try
            {
                string comno = cb_comname.Text;
                string baudrate = cb_baudrate.Text;
                m_comlib = new ComClass(comno, baudrate);
                int r = m_comlib.OpenCom();
                string log = (r > 0) ? "串口已打开" : "打开串口失败";
                ShowLog(log);
                if (r > 0)
                {
                    _isrun = true;
                    BeginReceive();
                    btn_start.Enabled = false;
                    btn_stop.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BeginReceive()
        {
            //WaitCallback wc = new WaitCallback(Receive);
            //ThreadPool.QueueUserWorkItem(wc, null);
            Rec_timer.Start();
        }

        private void Receive(object o)
        {
            while (_isrun)
            {
                try
                {
                    if (m_comlib != null)
                    {
                        string tmp = m_comlib.GetReaceiveData();
                        string tmprec = (cb_hexrec.Checked) ? GetStringAsHex(tmp) : tmp;
                        ShowReceive(tmprec);
                        m_receivedata += tmp;
                        if (m_receivedata.Length > 0)
                        {
                            string[][] data = m_datadeal.DealPack(ref m_receivedata, m_protocol, m_baudrate,"");
                            //string[] _returnstr = data[0];
                            foreach (string s in data[1])
                            {
                               
                                    ShowUpdate(s);
                            }
                        }
                    }
                    Thread.Sleep(1000 * 5);
                }
                catch
                {
                    continue;
                }
            }
        }

        private void Receive()
        {
            
                try
                {
                    if (m_comlib != null)
                    {
                        string tmp = m_comlib.GetReaceiveData();
                        string tmprec = (cb_hexrec.Checked) ? GetStringAsHex(tmp) : tmp;
                        ShowReceive(tmprec);
                        m_receivedata += tmp;
                        if (m_receivedata.Length > 0)
                        {
                            string[][] data = m_datadeal.DealPack(ref m_receivedata, m_protocol, m_baudrate, "");
                            //string[] _returnstr = data[0];
                            foreach (string s in data[1])
                            {

                                ShowUpdate(s);
                            }
                        }
                    }
                    Thread.Sleep(1000 * 5);
                }
                catch
                {
                    return;
                }
          
        }

        /// <summary>
        /// 转化Hex为字符串
        /// </summary>
        /// <param name="receivebyte"></param>
        /// <returns></returns>
        public string GetStringAsHex(string message)
        {
            StringBuilder sb = new StringBuilder();
            byte[] receivebyte = System.Text.Encoding.Default.GetBytes(message);
            foreach (byte b in receivebyte)
            {
                string hex = b.ToString("x").ToUpper();
                hex = (hex.Length == 1) ? "0" + hex : hex;
                sb.Append(hex + " ");
            }
            return sb.ToString();
        }

        /// <summary>
        /// 转换为Hex发送
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string GetHexBytes(string message)
        {
            string hexString = message.Trim();
            int len = hexString.Length / 2;
            char[] chars = hexString.ToCharArray();
            string[] hexes = new string[len];
            byte[] bytes = new byte[len];
            for (int i = 0, j = 0; j < len; i = i + 2, j++)
            {
                hexes[j] = "" + chars[i] + chars[i + 1];
                bytes[j] = (byte)(Convert.ToInt16(hexes[j], 16));
            }
            return System.Text.Encoding.Default.GetString(bytes);
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            _isrun = false;
            Rec_timer.Stop();
            try
            {
                int r = m_comlib.Stop();
                string logstr = (r > 0) ? "端口关闭成功" : "端口关闭失败";
                ShowLog(logstr);
                btn_start.Enabled = true;
                btn_stop.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ComForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (_isrun)
                {
                    MessageBox.Show("关闭窗口前请先断开连接");
                    e.Cancel = true;
                }
            }
        }

        private void btn_clear_rev_Click(object sender, EventArgs e)
        {
            lv_rec.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rtb_send.Clear();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            string s = rtb_send.Text;
            s = (cb_hexsend.Checked) ? GetHexBytes(s) : s;
            int r = m_comlib.SendMessage(s);
            string log = (r > 0) ? "发送消息 " + s + " 成功" : "发送消息 " + s + " 失败";
        }

        private void ComForm_Load(object sender, EventArgs e)
        {
            Rec_timer.Interval = 10000;
            Rec_timer.Elapsed += new System.Timers.ElapsedEventHandler(Rec_timer_Elapsed);
            Rec_timer.Stop();
        }

        void Rec_timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_isrun)
            {
                ThreadStart ts = new ThreadStart(Receive);
                Thread t = new Thread(ts);
                t.Start();
                t.Join();
            }
        }
    }
}
