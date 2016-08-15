using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Collections;
using SocketDemo.Lib;
using System.Threading;
using System.Net;

namespace SocketDemo
{
    public partial class ServerForm : Form,PubStart
    {
        Hashtable servertable = new Hashtable();//服务端集合
        Hashtable ReceviceData = new Hashtable();//接收数据集合
        ServerClass sc;//服务端类
        DataDeal Datadeal = new DataDeal();//报文处理类
        private string C_Protocol = "";//协议名称
        private string C_Port = "";//端口号
        bool _isrun = false;
        SystemInfo.SystemInfoSoapClient si = new SystemInfo.SystemInfoSoapClient();
        //NewOnlineService.OnLineDataServerInterfaceClient _online = new NewOnlineService.OnLineDataServerInterfaceClient();
        private string C_AppName = "";
        private string C_SiteName = "";


        //bool _startcheck = false;
        private string _heartpack = "?";//心跳包内容

        private CDataCenter.CDataCenterSoapClient dc = new CDataCenter.CDataCenterSoapClient();//数据入库webservice

        private Cems_KQ.ServiceSoapClient cemskq = new Cems_KQ.ServiceSoapClient();


        private System.Timers.Timer Rec_timer = new System.Timers.Timer();
        private System.Timers.Timer Check_timer = new System.Timers.Timer();
        private System.Timers.Timer Heart_timer = new System.Timers.Timer();


        public ServerForm()
        {
            InitializeComponent();
            IniLocalIp();
        }

        public ServerForm(string port,string protocol,string header,bool heart)
        {
            InitializeComponent();
            IniLocalIp();
            this.Text = header;
            tb_port.Text = port;
            cb_heart.Checked = heart;

            C_Port = port;
            C_Protocol = protocol;

            C_AppName = "App_" + port;
            C_SiteName = this.Text;
            
            EventTrick.Start();

        }

        /// <summary>
        /// 获取本机IP地址
        /// </summary>
        private void IniLocalIp()
        {
            try
            {
                treeView1.Nodes.Clear();
                string hostname = Dns.GetHostName();
                IPAddress[] hosts = Dns.GetHostAddresses(hostname);
                if (hosts.Count() > 0)
                {
                    foreach (IPAddress sub in hosts)
                    {
                        if (sub.AddressFamily == AddressFamily.InterNetwork)
                        {
                            tb_LocalIP.Text = sub.ToString();
                            AddTreeNode("", sub.ToString());
                        }
                    }

                }
                ShowLog("初始化本机地址成功",true);
            }
            catch (Exception ex)
            {
                ShowLog("初始化本机地址失败："+ex.Message,true);
            }
        }

        /// <summary>
        /// 添加树节点
        /// </summary>
        /// <param name="parent">父节点名称</param>
        /// <param name="nodename">节点名称</param>
        private void AddTreeNode(string parent, string nodename)
        {

            try
            {
                if (parent == "")
                {
                    TreeNode _rootnode = new TreeNode();
                    _rootnode.Text = nodename;
                    _rootnode.Name = nodename;
                    treeView1.Nodes.Add(_rootnode);
                    treeView1.ExpandAll();
                }
                else
                {

                    TreeNode[] tns = treeView1.Nodes.Find(nodename, true);
                    if (tns.Count() > 0)
                    {
                        return;
                    }
                    else
                    {
                        TreeNode sub = new TreeNode();
                        sub.Name = nodename;
                        sub.Text = nodename;
                        tns = treeView1.Nodes.Find(parent, true);
                        if (tns.Count() > 0)
                        {
                            tns[0].Nodes.Add(sub);
                            treeView1.ExpandAll();
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowLog("显示树状结构失败："+ex.Message,false);
            }
            
        }

        /// <summary>
        /// 清除术结构
        /// </summary>
        /// <param name="sender"></param>
        private void ClearTree(object sender)
        {
            try
            {
                TreeNode[] tns = treeView1.Nodes.Find(sender.ToString(), true);
                tns[0].Nodes.Clear();
            }
            catch (Exception ex)
            {
                ShowLog("清除树结构失败："+ex.Message,false);
            }
        }

        private void btn_lis_Click(object sender, EventArgs e)
        {
            try
            {
                sc = new Lib.ServerClass(tb_LocalIP.Text, tb_port.Text);//实例化服务类
                int r = sc.StartListen();//启动监听
                if (r > 0)
                {
                    ShowLog("开始监听:" + tb_port.Text,true);
                    AddTreeNode(tb_LocalIP.Text, tb_port.Text);
                    _isrun = true;
                    BeginGetStatus();//启动状态检测进程
                    BeginReceive();//启动接收进程
                    BeginHeart();//启动心跳进程
                    lock (servertable)
                    {
                        servertable.Add(tb_port.Text, sc);//实例加入到服务端集合
                    }
                    btn_lis.Enabled = false;
                    btn_stop.Enabled = true;
                }
                else
                {
                    MessageBox.Show("打开端口出错，端口已占用");
                }
            }
            catch (Exception ex)
            {
                ShowLog("启动监听失败："+ex.Message,true);
            }
        }

        /// <summary>
        /// 外部启动
        /// </summary>
        public void PubStart()
        {
            try
            {
                sc = new Lib.ServerClass(tb_LocalIP.Text, tb_port.Text);
                int r = sc.StartListen();
                if (r > 0)
                {
                    ShowLog("开始监听:" + tb_port.Text,true);
                    AddTreeNode(tb_LocalIP.Text, tb_port.Text);
                    _isrun = true;
                    BeginGetStatus();
                    BeginReceive();
                    BeginHeart();
                    lock (servertable)
                    {
                        servertable.Add(tb_port.Text, sc);
                    }
                    btn_lis.Enabled = false;
                    btn_stop.Enabled = true;
                }
                else
                {
                    MessageBox.Show("打开端口出错，端口已占用");
                }
            }
            catch (Exception ex)
            {
                ShowLog("启动监听失败：" + ex.Message,true);
            }
        }

        /// <summary>
        /// 显示接收信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="message"></param>
        public void ShowReceive(string id,string message)
        {
            if (lv_rec.Items.Count > 500)
                lv_rec.Items.Clear();

            ListViewItem lvi = new ListViewItem();
            lvi.Text = System.DateTime.Now.ToLongTimeString();

            lvi.SubItems.Add(id);
            lvi.SubItems.Add(message);
            lv_rec.Items.Add(lvi);
        }

        /// <summary>
        /// 显示日志
        /// </summary>
        /// <param name="message"></param>
        public void ShowLog(string message,bool tofile)
        {
            if (rtb_log.Lines.Count() > 500)
                rtb_log.Clear();
            string log = "[" + System.DateTime.Now.ToLongTimeString() + "]" + message + "\n";
            rtb_log.AppendText(log);
            if (tofile)
            {
                string filename = Application.StartupPath + "/" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                FileLog.Log.WriteLog(filename, C_Port + " - " + log);
            }
        }

        /// <summary>
        /// 显示上传参数
        /// </summary>
        /// <param name="message"></param>
        public void ShowUpdate(string message)
        {
            if (rtb_update.Lines.Count() > 500)
                rtb_update.Clear();
            rtb_update.AppendText("[" + System.DateTime.Now.ToLongTimeString() + "]" + message + "\n");
        }

        /// <summary>
        /// 状态监测
        /// </summary>
        /// <param name="o"></param>
        public void GetStatus(object o)
        {
            while (_isrun)
            {
                    if (servertable.Count > 0)
                    {
                        lock (servertable)
                        {
                            try
                            {
                                this.Invoke(new Action<object>(ClearTree), tb_LocalIP.Text);
                                foreach (object obj in servertable.Values)
                                {
                                    ServerClass sc = obj as ServerClass; //获取客户端
                                    this.Invoke(new Action<string, string>(AddTreeNode), new string[] { tb_LocalIP.Text, sc.Port.ToString() });
                                    Hashtable ht = sc.ClientTable;//获取端口连接的会话列表
                                    int count = sc.ClientTable.Values.Count;

                                    if (count > 0)
                                    {
                                        foreach (object se in ht.Values)
                                        {
                                            Session tmp = se as Session;
                                            if (tmp.IsConnect)//监测会话的状态
                                            {
                                                this.Invoke(new Action<string, string>(AddTreeNode), new string[] { sc.Port.ToString(), tmp.ID });
                                                this.Invoke(new Action<string,bool>(ShowLog),"获取来自："+tmp.ID+" 的连接",false);
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                ShowLog("检测服务状态失败：" + ex.Message,true);
                            }
                        }
                }
                Thread.Sleep(1000 * 5);
            }
        }

        public void GetStatus()
        {

            if (servertable.Count > 0)
            {
                lock (servertable)
                {
                    try
                    {
                        this.Invoke(new Action<object>(ClearTree), tb_LocalIP.Text);
                        foreach (object obj in servertable.Values)
                        {
                            ServerClass sc = obj as ServerClass; //获取客户端
                            this.Invoke(new Action<string, string>(AddTreeNode), new string[] { tb_LocalIP.Text, sc.Port.ToString() });
                            Hashtable ht = sc.ClientTable;//获取端口连接的会话列表
                            int count = sc.ClientTable.Values.Count;

                            if (count > 0)
                            {
                                foreach (object se in ht.Values)
                                {
                                    Session tmp = se as Session;
                                    if (tmp.IsConnect)//监测会话的状态
                                    {
                                        this.Invoke(new Action<string, string>(AddTreeNode), new string[] { sc.Port.ToString(), tmp.ID });
                                        this.Invoke(new Action<string, bool>(ShowLog), "获取来自：" + tmp.ID + " 的连接", false);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowLog("检测服务状态失败：" + ex.Message, true);
                    }
                }
            }

        }

        public void BeginGetStatus()
        {
            //WaitCallback wc = new WaitCallback(GetStatus);
            //ThreadPool.QueueUserWorkItem(wc, null);
            Check_timer.Start();
        }

        public void Recevice(object o)
        {
            while (_isrun)
            {
                if (servertable.Count > 0)
                {

                    lock (servertable)
                    {
                        foreach (object obj in servertable.Values)
                        {
                            try
                            {
                                ServerClass sc = obj as ServerClass;//获取客户端
                                Hashtable ht = sc.ClientTable; //获取会话列表
                                int count = sc.ClientTable.Values.Count;
                                if (count > 0)
                                {
                                    foreach (object se in ht.Values)
                                    {
                                        Session tmp = se as Session;
                                        if (tmp.IsConnect && tmp.ReceiveData.Length > 0)
                                        {
                                            string _rdata = sc.receive(tmp);//获取会话中接收到的数据
                                            this.Invoke(new Action<string, string>(ShowReceive), new string[] { tmp.ID, _rdata });
                                            //缓存数据记录到接收数据集合中
                                            if (ReceviceData.Contains(tmp.ID))
                                            {
                                                string _org = ReceviceData[tmp.ID].ToString();
                                                _org += _rdata;
                                                ReceviceData[tmp.ID] = _org;
                                            }
                                            else
                                            {
                                                ReceviceData.Add(tmp.ID, _rdata);
                                            }
                                            string _orgdata = ReceviceData[tmp.ID].ToString();
                                            this.Invoke(new Action<string,bool>(ShowLog), _orgdata,true);

                                            //处理接收的报文，生成上传数据参数
                                            string[][] _getData = Datadeal.DealPack(ref _orgdata, C_Protocol, C_Port,C_SiteName);
                                            
                                            //更新接收数据的缓存
                                            ReceviceData[tmp.ID] = _orgdata;

                                            //报文应答 2011-04-12 by 俞楠
                                            if (_getData[0] != null)
                                            {
                                                string[] _returnstr = _getData[0];//返回数据的第一组为应答报文
                                                if (_returnstr != null)
                                                {
                                                    foreach (string rs in _returnstr)
                                                    {
                                                        int rr = sc.send(tmp, rs);
                                                        if (rr > 0)
                                                        {
                                                            this.Invoke(new Action<string,bool>(ShowLog), "发送应答报文:" + rs + "成功",true);
                                                        }
                                                        else
                                                        {
                                                            this.Invoke(new Action<string,bool>(ShowLog), "发送应答报文:" + rs + "失败",true);
                                                        }
                                                    }
                                                }
                                            }

                                            //上传数据
                                            if (_getData[1]!=null)
                                            {
                                                foreach (string _s in _getData[1])
                                                {
                                                    this.Invoke(new Action<string,bool>(ShowLog), _s,true);
                                                    int r = dc.DownWriteValueString(_s);
                                                    this.Invoke(new Action<string,bool>(ShowLog), "数据入数据中心,返回：" + r.ToString(),true);
                                                    this.Invoke(new Action<string>(ShowUpdate), new string[] { _s });
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                this.Invoke(new Action<string,bool>(ShowLog), "接收数据处理失败：" + ex.Message,true);

                                continue;
                            }
                        }
                    }
                }
                Thread.Sleep(1000 * 5);
            }
        }

        public void Recevice()
        {

            if (servertable.Count > 0)
            {

                lock (servertable)
                {
                    foreach (object obj in servertable.Values)
                    {
                        try
                        {
                            ServerClass sc = obj as ServerClass;//获取客户端
                            Hashtable ht = sc.ClientTable; //获取会话列表
                            int count = sc.ClientTable.Values.Count;
                            count = 1;
                            if (count > 0)
                            {
                                foreach (object se in ht.Values)
                                {
                                    Session tmp = se as Session;
                                    if (tmp.IsConnect && tmp.ReceiveData.Length > 0)
                                    {
                                        string _rdata = sc.receive(tmp);//获取会话中接收到的数据
                                        //_rdata = "##0783QN=20111129160000000;ST=31;CN=2082;PW=987654;MN=88888880000001;CP=&&DataTime=20111129155500;S01-Min=0,S01-Max=0,S01-Avg=0,S01-Cou=0,S01-Flag=N;S02-Min=0,S02-Max=0,S02-Avg=2,S02-Cou=0,S02-Flag=N;S03-Min=0,S03-Max=0,S03-Avg=0,S03-Cou=0,S03-Flag=N;S08-Min=0,S08-Max=0,S08-Avg=36,S08-Cou=0,S08-Flag=N;S09-Min=0,S09-Max=0,S09-Avg=0,S09-Cou=0,S09-Flag=N;01-Min=0,01-Max=0,01-Avg=0,01-ZsMin=0,01-ZsMax=0,01-ZsAvg=0,01-Cou=0,01-Flag=N;02-Min=0,02-Max=0,02-Avg=3689,02-ZsMin=0,02-ZsMax=0,02-ZsAvg=0,02-Cou=368,02-Flag=N;03-Min=0,03-Max=0,03-Avg=0,03-ZsMin=0,03-ZsMax=0,03-ZsAvg=0,03-Cou=0,03-Flag=N;S10-Min=0,S10-Max=0,S10-Avg=0,S10-Cou=0,S10-Flag=N;S04-Min=0,S04-Max=0,S04-Avg=0,S04-Cou=0,S04-Flag=N;StaTem-min=0,StaTem-Max=0,StaTem-Avg=0&&45C4\r\n";
                                        this.Invoke(new Action<string, string>(ShowReceive), new string[] { tmp.ID, _rdata });
                                        //缓存数据记录到接收数据集合中
                                        if (ReceviceData.Contains(tmp.ID))
                                        {
                                            string _org = ReceviceData[tmp.ID].ToString();
                                            _org += _rdata;
                                            ReceviceData[tmp.ID] = _org;
                                        }
                                        else
                                        {
                                            ReceviceData.Add(tmp.ID, _rdata);
                                        }
                                        string _orgdata = ReceviceData[tmp.ID].ToString();
                                        this.Invoke(new Action<string, bool>(ShowLog), _orgdata, true);

                                        //处理接收的报文，生成上传数据参数
                                        string[][] _getData = Datadeal.DealPack(ref _orgdata, C_Protocol, C_Port, C_SiteName);

                                        //更新接收数据的缓存
                                        ReceviceData[tmp.ID] = _orgdata;

                                        //报文应答 2011-04-12 by 俞楠
                                        if (_getData[0] != null)
                                        {
                                            string[] _returnstr = _getData[0];//返回数据的第一组为应答报文
                                            if (_returnstr != null)
                                            {
                                                foreach (string rs in _returnstr)
                                                {
                                                    int rr = sc.send(tmp, rs);
                                                    if (rr > 0)
                                                    {
                                                        this.Invoke(new Action<string, bool>(ShowLog), "发送应答报文:" + rs + "成功", true);
                                                    }
                                                    else
                                                    {
                                                        this.Invoke(new Action<string, bool>(ShowLog), "发送应答报文:" + rs + "失败", true);
                                                    }
                                                }
                                            }
                                        }

                                        //上传数据
                                        if (_getData[1] != null)
                                        {

                                            foreach (string _s in _getData[1])
                                            {
                                                this.Invoke(new Action<string, bool>(ShowLog), _s, true);
                                                int r = dc.DownWriteValueString(_s);
                                                this.Invoke(new Action<string, bool>(ShowLog), "数据入数据中心,返回：" + r.ToString(), true);
                                                this.Invoke(new Action<string>(ShowUpdate), new string[] { _s });
                                            }
                                        }
                                        else
                                        {
                                            this.Invoke(new Action<string, bool>(ShowLog), "无数据", true);
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            this.Invoke(new Action<string, bool>(ShowLog), "接收数据处理失败：" + ex.Message, true);

                            continue;
                        }
                    }
                }
            }

        }

        public void BeginReceive()
        {
            //WaitCallback wc = new WaitCallback(Recevice);
            //ThreadPool.QueueUserWorkItem(wc, sc);
            Rec_timer.Start();
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {

            _isrun = false;
            Rec_timer.Stop();
            Check_timer.Stop();
            Heart_timer.Stop();
            try
            {
                ServerClass sc = servertable[tb_port.Text] as ServerClass;
                sc.StopListen();
                
                lock (servertable)
                {
                    servertable.Remove(tb_port.Text);
                }
                ShowLog("停止监听:" + tb_port.Text,true);
                IniLocalIp();
                btn_lis.Enabled = true;
                btn_stop.Enabled = false;
            }
            catch (Exception ex)
            {
                ShowLog("关闭监听失败：" + ex.Message,true);
            }
        }

        private void btn_clear_rev_Click(object sender, EventArgs e)
        {
            lv_rec.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rtb_send.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SendMessage(rtb_send.Text);
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message"></param>
        private void SendMessage(string message)
        {
            if (_isrun)
            {
                string sendmessage = message;
                int count = sc.ClientTable.Values.Count;
                if (count > 0)
                {
                    foreach (object se in sc.ClientTable.Values)
                    {
                        Session tmp = se as Session;
                        int r = sc.send(tmp, sendmessage);
                        if (r > 0)
                        {
                            this.Invoke(new Action<string,bool>(ShowLog), "发送 "+sendmessage+" 成功",true);
                        }
                        else
                        {
                            this.Invoke(new Action<string,bool>(ShowLog), "发送消息失败",true);
                        }
                    }
                }
                else
                {
                    this.Invoke(new Action<string,bool>(ShowLog), "无可用连接",true);
                }
            }
            else
            {
                this.Invoke(new Action<string,bool>(ShowLog), "无可用连接",true);
            }
        }

        /// <summary>
        /// 发送心跳
        /// </summary>
        /// <param name="sender"></param>
        private void SendHeart(object sender)
        {
            while (_isrun)
            {
                if (cb_heart.Checked == true)
                {
                    lock (servertable)
                    {
                        foreach (object obj in servertable.Values)
                        {
                            try
                            {
                                ServerClass sc = obj as ServerClass;
                                if (sc.ClientTable.Values.Count > 0)
                                {
                                    List<string> _todel = new List<string>();
                                    foreach (object session in sc.ClientTable.Values)
                                    {
                                        Session tp = session as Session;
                                        int r = sc.send(tp, _heartpack);//发送心跳包
                                        if (r < 0)
                                        {
                                            _todel.Add(tp.ID);
                                        }
                                    }
                                    if (_todel.Count > 0)
                                    {
                                        for (int i = 0; i < _todel.Count; i++)
                                        {
                                            Session tmp = (Session)sc.ClientTable[_todel[i]];
                                            sc.CloseSession(tmp);
                                            this.Invoke(new Action<string,bool>(ShowLog), "发送心跳失败，断开会话：" + _todel[i],true);
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                this.Invoke(new Action<string,bool>(ShowLog), "心跳失败：" + ex.Message,true);
                                continue;
                            }
                        }
                    }
                    
                }
                Thread.Sleep(1000 * 10);
            }
        }

        private void SendHeart()
        {

            if (cb_heart.Checked == true)
            {
                lock (servertable)
                {
                    foreach (object obj in servertable.Values)
                    {
                        try
                        {
                            ServerClass sc = obj as ServerClass;
                            if (sc.ClientTable.Values.Count > 0)
                            {
                                List<string> _todel = new List<string>();
                                foreach (object session in sc.ClientTable.Values)
                                {
                                    Session tp = session as Session;
                                    int r = sc.send(tp, _heartpack);//发送心跳包
                                    if (r < 0)
                                    {
                                        _todel.Add(tp.ID);
                                    }
                                }
                                if (_todel.Count > 0)
                                {
                                    for (int i = 0; i < _todel.Count; i++)
                                    {
                                        Session tmp = (Session)sc.ClientTable[_todel[i]];
                                        sc.CloseSession(tmp);
                                        this.Invoke(new Action<string, bool>(ShowLog), "发送心跳失败，断开会话：" + _todel[i], true);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            this.Invoke(new Action<string, bool>(ShowLog), "心跳失败：" + ex.Message, true);
                            continue;
                        }
                    }
                }

            }

        }


        private void BeginHeart()
        {
            //WaitCallback wc = new WaitCallback(SendHeart);
            //ThreadPool.QueueUserWorkItem(wc, null);
            Heart_timer.Start();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.Level == 1)
            {
                tb_port.Text = treeView1.SelectedNode.Text;
            }
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)//判断触发关闭事件的方法
            {
                if (_isrun)
                {
                    MessageBox.Show("关闭窗口前请先停止监听");
                    e.Cancel = true;
                }
                else
                {
                    if (servertable != null)
                    {
                        lock (servertable)
                        {
                            foreach (object obj in servertable.Values)
                            {
                                ServerClass sc = obj as ServerClass;
                                sc.StopListen();

                            }
                            servertable.Clear();
                        }
                    }
                }
                
                
            }

        }

        /// <summary>
        /// 2011-5-4 增加读取消息中心的控制指令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventTrick_Tick(object sender, EventArgs e)
        {
            try
            {
                using (NewOnlineService.OnLineDataServerInterfaceClient tmpclient = new NewOnlineService.OnLineDataServerInterfaceClient())//消息中心
                {
                    NewOnlineService.NullObj no = new NewOnlineService.NullObj();
                    string result = string.Empty;
                    result = tmpclient.GetEventInfo(C_AppName, no);
                    if (string.IsNullOrEmpty(result))
                        return;
                    string[] s = result.Split('$');
                    foreach (string cs in s)
                    {
                        this.Invoke(new Action<string, bool>(ShowLog), cs, true);
                        SendMessage(cs);
                    }
                }
                
            }
            catch(Exception ex)
            {
                this.Invoke(new Action<string, bool>(ShowLog),string.Format("获取远程指令失败：{0}",ex.Message,true));
                return;
            }
        }

        private void ServerForm_Load(object sender, EventArgs e)
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
                ThreadStart ts = new ThreadStart(GetStatus);
                Thread t = new Thread(ts);
                t.Start();
                t.Join();
            }
        }

        void Rec_timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_isrun)
            {
                ThreadStart ts = new ThreadStart(Recevice);
                Thread t = new Thread(ts);
                t.Start();
                t.Join();
            }
        }
    }
}
