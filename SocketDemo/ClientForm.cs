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
using System.Collections;


namespace SocketDemo
{
    public partial class ClientForm : Form,PubStart
    {
        private ClientClass _client;
        private bool _isrun = false;
        private bool _isconnetcd = false;
        private string _heartstr = "Active";
        private Hashtable _htrec = new Hashtable();
        private string C_HostIp = "";
        private string C_HostPort = "";
        private string C_Protocol = "";

        private System.Timers.Timer Rec_timer = new System.Timers.Timer();
        private System.Timers.Timer Check_timer = new System.Timers.Timer();
        private System.Timers.Timer Heart_timer = new System.Timers.Timer();

        public ClientForm()
        {
            InitializeComponent();
        }

        public ClientForm(string hostip, string port, string protocol, string name,bool heart)
        {
            InitializeComponent();
            this.Text = name;
            tb_LocalIP.Text = hostip;
            C_HostIp = hostip;
            tb_port.Text = port;
            C_HostPort = port;
            C_Protocol = protocol;
            cbSendHeart.Checked = heart;
        }

        private void btn_clear_rev_Click(object sender, EventArgs e)
        {
            lv_rec.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rtb_send.Clear();
        }

        private void btn_con_Click(object sender, EventArgs e)
        {
            try
            {
                string _remoteip = tb_LocalIP.Text;
                string _remoteport = tb_port.Text;
                _isrun = true;
                _client = new ClientClass(_remoteip, _remoteport);
                //WaitCallback wc = new WaitCallback(BeginConnect);
                //ThreadPool.QueueUserWorkItem(wc, null);

                int r = _client.BeginConnect();
                this.Invoke(new Action<string>(ShowLog), "开始尝试连接远程服务器");
                _isrun = true;
                BeginCheck();
                BeginReceive();
                BeginHeart();
                btn_con.Enabled = false;
                btn_discon.Enabled = true;
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
                string _remoteip = tb_LocalIP.Text;
                string _remoteport = tb_port.Text;
                _isrun = true;
                _client = new ClientClass(_remoteip, _remoteport);
                //WaitCallback wc = new WaitCallback(BeginConnect);
                //ThreadPool.QueueUserWorkItem(wc, null);

                int r = _client.BeginConnect();
                this.Invoke(new Action<string>(ShowLog), "开始尝试连接远程服务器");
                _isrun = true;
                BeginCheck();
                BeginReceive();
                BeginHeart();
                btn_con.Enabled = false;
                btn_discon.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BeginCheck()
        {
            //WaitCallback wc = new WaitCallback(Check);
            //ThreadPool.QueueUserWorkItem(wc, null);
            Check_timer.Start();
        }

        private void Check(object o)
        {
            while (_isrun)
            {
                lock (_client)
                {
                    int sessioncount = _client.SessionTable.Count;
                    if (sessioncount > 0)
                    {
                        bool tmptf = true;
                        if (tmptf != _isconnetcd)
                        {
                            _isconnetcd = tmptf;
                            this.Invoke(new Action<string>(ShowLog), "建立连接成功");
                        }
                    }
                    else
                    {
                        bool tmptf = false;
                        if (tmptf != _isconnetcd)
                        {
                            _isconnetcd = tmptf;
                            this.Invoke(new Action<string>(ShowLog), "无可用的连接");
                            _client.BeginConnect();
                            this.Invoke(new Action<string>(ShowLog), "尝试重新建立连接");
                        }
                    }
                }

                Thread.Sleep(1000 * 5);
            }
        }

        private void Check()
        {

            lock (_client)
            {
                int sessioncount = _client.SessionTable.Count;
                if (sessioncount > 0)
                {
                    bool tmptf = true;
                    if (tmptf != _isconnetcd)
                    {
                        _isconnetcd = tmptf;
                        this.Invoke(new Action<string>(ShowLog), "建立连接成功");
                    }
                }
                else
                {
                    bool tmptf = false;
                    if (tmptf != _isconnetcd)
                    {
                        _isconnetcd = tmptf;
                        this.Invoke(new Action<string>(ShowLog), "无可用的连接");
                        _client.BeginConnect();
                        this.Invoke(new Action<string>(ShowLog), "尝试重新建立连接");
                    }
                }
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
                if (_isconnetcd)
                {
                    lock(_client)
                    {
                        foreach (object obj in _client.SessionTable.Values)
                        {
                            try
                            {
                                Session s = obj as Session;
                                string key = s.ID;
                                string value = _client.Receive(s);
                                if (_htrec.Contains(key))
                                {
                                    _htrec[key] += value;
                                }
                                else
                                {
                                    _htrec.Add(key, value);
                                }
                                
                            }
                            catch (Exception ex)
                            {
                                this.Invoke(new Action<string>(ShowLog), ex.Message);
                                continue;
                            }
                        }

                        foreach (object str in _htrec.Values)
                        {
                            string tmpstr = str.ToString();
                            if(tmpstr.Length>0)
                            this.Invoke(new Action<string>(ShowRec), str.ToString());
                        }
                        //处理接收到的数据  不处理就清空
                        _htrec.Clear();
                    }
                }
                Thread.Sleep(1000 * 5);
            }
        }

        private void Receive()
        {

            if (_isconnetcd)
            {
                lock (_client)
                {
                    foreach (object obj in _client.SessionTable.Values)
                    {
                        try
                        {
                            Session s = obj as Session;
                            string key = s.ID;
                            string value = _client.Receive(s);
                            if (_htrec.Contains(key))
                            {
                                _htrec[key] += value;
                            }
                            else
                            {
                                _htrec.Add(key, value);
                            }

                        }
                        catch (Exception ex)
                        {
                            this.Invoke(new Action<string>(ShowLog), ex.Message);
                            continue;
                        }
                    }

                    foreach (object str in _htrec.Values)
                    {
                        string tmpstr = str.ToString();
                        if (tmpstr.Length > 0)
                            this.Invoke(new Action<string>(ShowRec), str.ToString());
                    }
                    //处理接收到的数据  不处理就清空
                    _htrec.Clear();
                }
            }

        }

        private void BeginHeart()
        {
            //WaitCallback wc = new WaitCallback(SendHeart);
            //ThreadPool.QueueUserWorkItem(wc, null);
            Heart_timer.Start();
        }

        private void SendHeart(object o)
        {
            while (_isrun)
            {
                if (cbSendHeart.Checked == true&&_isconnetcd)
                {
                    lock (_client)
                    {

                        List<Session> _todel = new List<Session>();
                        foreach (object obj in _client.SessionTable.Values)
                        {
                            Session s = obj as Session;
                            int r = _client.Send(s, _heartstr);
                            if (r < 0)
                            {
                                _todel.Add(s);
                            }
                        }
                        foreach(Session s in _todel)
                        {
                            this.Invoke(new Action<string>(ShowLog), "发送心跳失败，关闭会话：" + s.ID);
                            _client.CloseSession(s);
                        }

                      
                    }
                }
                Thread.Sleep(1000 * 5);
            }
        }

        private void SendHeart()
        {

            if (cbSendHeart.Checked == true && _isconnetcd)
            {
                lock (_client)
                {

                    List<Session> _todel = new List<Session>();
                    foreach (object obj in _client.SessionTable.Values)
                    {
                        Session s = obj as Session;
                        int r = _client.Send(s, _heartstr);
                        if (r < 0)
                        {
                            _todel.Add(s);
                        }
                    }
                    foreach (Session s in _todel)
                    {
                        this.Invoke(new Action<string>(ShowLog), "发送心跳失败，关闭会话：" + s.ID);
                        _client.CloseSession(s);
                    }


                }
            }

        }

        //private void BeginConnect(object o)
        //{
        //    while (_isrun)
        //    {
        //        lock (_client)
        //        {
        //            if (_isconnetcd == false)
        //            {
        //                int r = _client.Connect();
        //                if (r > 0)
        //                {
        //                    this.Invoke(new Action<string>(ShowLog), "建立连接成功");
        //                    _isconnetcd = true;
        //                    WaitCallback wc = new WaitCallback(Receive);
        //                    ThreadPool.QueueUserWorkItem(wc, null);

        //                    WaitCallback wc_heart = new WaitCallback(SendHeart);
        //                    ThreadPool.QueueUserWorkItem(wc_heart, null);
        //                    return;
        //                }
        //                else
        //                {
        //                    this.Invoke(new Action<string>(ShowLog), "尝试建立连接失败，等待1秒后自动重新尝试连接");
        //                }
        //            }
        //        }
        //        Thread.Sleep(1000);
        //    }
        //}

        //private void Receive(object sender)
        //{
        //    while (_isconnetcd)
        //    {

        //        lock (_client)
        //        {
        //            try
        //            {
        //                if (_client.ReceiveData.Length > 0)
        //                {
        //                    string r = _client.Receive();
        //                    this.Invoke(new Action<string>(ShowRec), r);
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                this.Invoke(new Action<string>(ShowLog), ex.Message);
        //                continue;
        //            }
        //        }

        //        Thread.Sleep(1000 * 5);
        //    }
        //}

        private void ShowLog(string message)
        {
            if (rtb_log.Lines.Count() > 100)
                rtb_log.Clear();
            rtb_log.AppendText("[" + DateTime.Now.ToLongTimeString() + "]:" + message + "\n");
        }

        private void ShowRec(string message)
        {
            if (lv_rec.Items.Count > 100)
                lv_rec.Items.Clear();
            ListViewItem lvi = new ListViewItem();
            lvi.Text = "[" + DateTime.Now.ToLongTimeString() + "]";
            lvi.SubItems.Add(message);
            lv_rec.Items.Add(lvi);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SendMessage(rtb_send.Text);
            }
            catch (Exception ex)
            {
                this.Invoke(new Action<string>(ShowLog), ex.Message);
            }
        }

        private void btn_discon_Click(object sender, EventArgs e)
        {
            Rec_timer.Stop();
            Heart_timer.Stop();
            Check_timer.Stop();
            try
            {
                _isrun = false;
                lock (_client)
                {
                    _client.Disconnect();
                    _isconnetcd = false;
                }
                this.Invoke(new Action<string>(ShowLog), "连接已断开");
                btn_con.Enabled = true;
                btn_discon.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SendMessage(string message)
        {
            if (_isrun)
            {
                string sendmessage = message;
                int count =_client.SessionTable.Count;
                if (count > 0)
                {
                    foreach (object se in _client.SessionTable.Values)
                    {
                        Session tmp = se as Session;
                        int r = _client.Send(tmp, sendmessage);
                        if (r > 0)
                        {
                            this.Invoke(new Action<string>(ShowLog), "发送消息："+sendmessage);
                        }
                        else
                        {
                            this.Invoke(new Action<string>(ShowLog), "发送消息失败");
                        }
                    }
                }
            }
            else
            {

                this.Invoke(new Action<string>(ShowLog), "无可用连接");
            }
        }
        
        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (_isrun)
                {
                    MessageBox.Show("关闭窗口前请先断开连接");
                    e.Cancel = true;
                }
                else
                {
                    if (_client != null)
                    {
                        lock (_client)
                        {
                            _client.Disconnect();
                            _isrun = false;
                            _isconnetcd = false;
                        }
                    }
                }
            }
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            Rec_timer.Interval = 10000;
            Rec_timer.Elapsed += new System.Timers.ElapsedEventHandler(Rec_timer_Elapsed);
            Rec_timer.Stop();

            Check_timer.Interval = 5000;
            Check_timer.Elapsed += new System.Timers.ElapsedEventHandler(Check_timer_Elapsed);
            Check_timer.Stop();

            Heart_timer.Interval = 120000;
            Heart_timer.Elapsed += new System.Timers.ElapsedEventHandler(Heart_timer_Elapsed);
            Heart_timer.Stop();
        }

        void Heart_timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_isrun)
            {
                ThreadStart ts = new ThreadStart(SendHeart);
                Thread t = new Thread(ts);
                t.Start();
                t.Join();
            }
        }

        void Check_timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_isrun)
            {
                ThreadStart ts = new ThreadStart(Check);
                Thread t = new Thread(ts);
                t.Start();
                t.Join();
            }
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
