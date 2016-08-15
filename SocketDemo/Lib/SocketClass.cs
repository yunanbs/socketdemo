using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Collections;
using System.Threading;

namespace SocketDemo.Lib
{
    /// <summary>
    /// 服务端类
    /// </summary>
    public class ServerClass
    {
        public string ServerIp { get; set; }
        public string Port { get; set; }
        Socket _sersocket;
        private bool _isrun = false;
        private int _buffersize = 64 * 1024;
        public Hashtable ClientTable = new Hashtable();//客户端列表

        public ServerClass(string IP, string port)
        {
            ServerIp = IP;
            Port = port;
        }

        /// <summary>
        /// 启动监听
        /// </summary>
        /// <returns>1成功；-1异常</returns>
        public int StartListen()
        {
            _isrun = true;
            _sersocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint _serverpoint = new IPEndPoint(IPAddress.Parse(ServerIp), int.Parse(Port));
            try
            {
                _sersocket.Bind(_serverpoint);
                _sersocket.Listen(5);
                _sersocket.BeginAccept(new AsyncCallback(BeginAcceptCallBack), _sersocket);
                return 1;
            }
            catch
            {
                return -1;
            }        
        }

        /// <summary>
        /// 接收到链接
        /// </summary>
        /// <param name="ar"></param>
        private void BeginAcceptCallBack(IAsyncResult ar)
        {
            try
            {
                if (_isrun)
                {
                    Socket oldserver = ar.AsyncState as Socket;
                    Socket client = _sersocket.EndAccept(ar);
                    Session s = new Session(client, _buffersize);//创建会话
                    if (_isrun)
                    {
                        
                        lock (ClientTable)
                        {
                            //2011-5-18修改 每次介绍到链接后 清空之前的链接 始终保持一个链接
                            //foreach (object o in ClientTable.Values)
                            //{
                            //    Session sub = (Session)o;
                            //    sub.Dispose();
                            //}
                            //ClientTable.Clear();

                            ClientTable.Add(s.ID, s);
                        }
                    }
                    oldserver.BeginAccept(new AsyncCallback(BeginAcceptCallBack), _sersocket);//继续监听
                }
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// 发送
        /// </summary>
        /// <param name="s">会话ID</param>
        /// <param name="message">需要发送的消息</param>
        /// <returns></returns>
        public int send(Session s, string message)
        {
            try
            {
                return s.Send(message);
            }
            catch
            {
                return -9999;
            }
        }

        /// <summary>
        /// 接收
        /// </summary>
        /// <param name="s">会话ID</param>
        /// <returns></returns>
        public string receive(Session s)
        {
            try
            {
                string tmp = s.ReceiveData;
                s.ReceiveData = "";

                return tmp;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 关闭会话
        /// </summary>
        /// <param name="s"></param>
        public void CloseSession(Session s)
        {
            s.Dispose();
            ClientTable.Remove(s.ID);
        }

        /// <summary>
        /// 停止监听
        /// </summary>
        public void StopListen()
        {
            try
            {
                _isrun = false;
                if (_sersocket.Connected)
                {
                    _sersocket.Shutdown(SocketShutdown.Both);
                    _sersocket.Disconnect(true);
                }
                _sersocket.Close();
                //_sersocket.Dispose();
                foreach (object s in ClientTable.Values)
                {
                    Session tmp = s as Session;
                    tmp.Dispose();
                }
                ClientTable.Clear();
            }
            catch
            {
                return;
            }
        }
    }

    /// <summary>
    /// 会话类
    /// </summary>
    public class Session
    {
        private Socket _client;
        private byte[] _buffer;
        private string _receivedata="";
        public string ReceiveData
        {
            get
            {
                return _receivedata;
            }
            set
            {
                _receivedata = value;
            }
        }

        public bool IsConnect
        {
            get
            {
                return _client.Connected;
            }
        }
        
        public string ID { get; set; }
        public int BuffSize { get; set; }

        System.Timers.Timer timer_Rec = new System.Timers.Timer();


        public Session(Socket client, int buffsize)
        {
            _client = client;
            ID = _client.RemoteEndPoint.ToString();

            BuffSize = buffsize;
            _client.ReceiveBufferSize = BuffSize;
            _client.SendBufferSize = BuffSize;
            _buffer = new byte[BuffSize];
            timer_Rec.Interval = 10000;
            timer_Rec.Elapsed += new System.Timers.ElapsedEventHandler(timer_Rec_Elapsed);
            timer_Rec.Start();
            //WaitCallback wc = new WaitCallback(BeginRecevice);//启动接收线程
            //ThreadPool.QueueUserWorkItem(wc,null);

        }

        void timer_Rec_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (IsConnect)
            {
                ThreadStart ts = new ThreadStart(BeginRecevice);
                Thread t = new Thread(ts);
                t.Start();
                t.Join();
            }
        }

        private void BeginRecevice()
        {
            if (_client != null)
            {
                lock (_client)
                {
                    try
                    {
                        if (_client.Available > 0)
                        {

                            //_client.BeginReceive(_buffer, 0, BuffSize, SocketFlags.None, new AsyncCallback(BeginReceiveCallBack), _client);

                            int rl = _client.Receive(_buffer);
                            _receivedata += System.Text.Encoding.Default.GetString(_buffer, 0, rl);
                        }
                    }
                    catch
                    {
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 异步接收
        /// </summary>
        /// <param name="sender"></param>
        private void BeginRecevice(object sender)
        {
            while (true)
            {

                    while (IsConnect)
                    {
                        if (_client != null)
                        {
                            lock (_client)
                            {
                                try
                                {
                                    if (_client.Available > 0)
                                    {

                                        _client.BeginReceive(_buffer, 0, BuffSize, SocketFlags.None, new AsyncCallback(BeginReceiveCallBack), _client);

                                    }
                                }
                                catch
                                {
                                    break;
                                }
                            }
                        }
                    }
                Thread.Sleep(1000);
            }
        }
        /// <summary>
        /// 接收数据
        /// </summary>
        /// <param name="ar"></param>
        private void BeginReceiveCallBack(IAsyncResult ar)
        {
            try
            {
                Socket client = ar.AsyncState as Socket;
                int rl = client.EndReceive(ar);
                if (rl > 0)
                {
                    //接收数据写入缓存
                    _receivedata = _receivedata + System.Text.Encoding.Default.GetString(_buffer, 0, rl);
                }
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// 发送
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public int Send(string message)
        {
            if (IsConnect)
                try
                {
                    if (_client != null)
                    {
                        lock (_client)
                        {
                            return _client.Send(System.Text.Encoding.Default.GetBytes(message));
                        }
                    }
                    else
                    {
                        return -1;
                    }
                }
                catch
                {
                    return -9999;
                }
            else
                return -1;
        }

        //销毁
        public void Dispose()
        {
            if (IsConnect)
            {
                lock (_client)
                {
                    _client.Shutdown(SocketShutdown.Both);
                    _client.Disconnect(true);
                    _client.Close();
                    //_client.Dispose();
                }

            }
        }

    }

    /// <summary>
    /// 客户端类
    /// </summary>
    public class ClientClass
    {
        private Socket _clientsocket;
        private string C_Port = "";
        private string C_RemoteIp="";
        private bool _isrun = false;
        private int _buffersize = 64 * 1024;
        //private byte[] _buffer;
        private string _receivedata = "";
        private IPEndPoint _hosts;
        public Hashtable SessionTable = new Hashtable();//

        public string ReceiveData
        {
            get
            {
                return _receivedata;
            }
        }

        public bool IsConnect
        {
            get
            {
                return _clientsocket.Connected;
            }
        }

        public ClientClass(string remoteip,string port)
        {
            C_Port = port;
            C_RemoteIp = remoteip;
             _clientsocket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
             //_clientsocket.SendBufferSize = _buffersize;
             //_clientsocket.ReceiveBufferSize = _buffersize;
             //_buffer = new byte[_buffersize];
        }

        public int BeginConnect()
        {
            try
            {
                _isrun = true;
                _hosts = new IPEndPoint(IPAddress.Parse(C_RemoteIp),int.Parse(C_Port));
                _clientsocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _clientsocket.BeginConnect(_hosts, new AsyncCallback(BeginConnect_CallBack), _clientsocket);
                return 1;
            }
            catch
            {
                return -1;
            }
        }

        private void BeginConnect_CallBack(IAsyncResult iar)
        {

            Socket client = iar.AsyncState as Socket;
            try
            {
                client.EndConnect(iar);
                Session s = new Session(client, _buffersize);
                SessionTable.Add(s.ID, s);
            }
            catch
            {
                Thread.Sleep(1000);
                if (_isrun)
                {
                    _clientsocket.BeginConnect(_hosts, new AsyncCallback(BeginConnect_CallBack), _clientsocket);
                }
            }


        }

        public int Send(Session s,string message)
        {
            return s.Send(message);
        }

        public string Receive(Session s)
        {
            string _datastr = s.ReceiveData;
            s.ReceiveData = "";
            return _datastr;
        }

        public void CloseSession(Session s)
        {
            try
            {
                s.Dispose();
                SessionTable.Remove(s.ID);
            }
            catch
            {
                return;
            }
        }

        public void Disconnect()
        {
            try
            {
                _isrun = false;
                foreach (object o in SessionTable.Values)
                {
                    Session s = o as Session;
                    s.Dispose();
                }
                SessionTable.Clear();
            }
            catch
            {
                return;
            }
        }

        //public int Connect()
        //{
        //    try
        //    {
        //        _clientsocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //        _clientsocket.SendBufferSize = _buffersize;
        //        _clientsocket.ReceiveBufferSize = _buffersize;
        //        _buffer = new byte[_buffersize];
        //        _clientsocket.Connect(C_RemoteIp, int.Parse(C_Port));
        //        if (_clientsocket.Connected)
        //        {

        //            _isrun = true;
        //            WaitCallback wc = new WaitCallback(BeginReceive);
        //            ThreadPool.QueueUserWorkItem(wc, null);
        //            return 1;
        //        }
        //        else
        //        {
        //            return -1;
        //        }
        //    }
        //    catch
        //    {
        //        return -9999;
        //    }

        //}

        //public void Disconnect()
        //{
        //    try
        //    {

        //        if (_clientsocket.Connected)
        //        {
        //            _isrun = false;
        //            _clientsocket.Shutdown(SocketShutdown.Both);
        //            _clientsocket.Disconnect(true);
        //            _clientsocket.Close();
        //            _clientsocket.Dispose();

        //        }
        //    }
        //    catch
        //    {
        //        _isrun = false;
        //    }
        //}

        //public int Send(string message)
        //{
        //    int result = 0;
        //    try
        //    {
        //        if (IsConnect)
        //        {
        //            result = _clientsocket.Send(System.Text.Encoding.Default.GetBytes(message));
        //        }
        //        else
        //        {
        //            result = -1;
        //        }
        //        return result;
        //    }
        //    catch
        //    {
        //        result = -2;
        //        return result;
        //    }
        //}

        //public string Receive()
        //{
        //    string rdata = _receivedata;
        //    _receivedata = "";
        //    return rdata;
        //}

        //private void BeginReceive(object sender)
        //{
        //    while (_isrun)
        //    {
        //        if (_clientsocket.Available > 0)
        //        {
        //            _clientsocket.BeginReceive(_buffer,0,_buffersize,SocketFlags.None,new AsyncCallback(BeginReceiveCallBack),_clientsocket);
        //        }

        //        Thread.Sleep(10000);
        //    }
        //}

        //private void BeginReceiveCallBack(IAsyncResult iar)
        //{
        //    Socket client = iar.AsyncState as Socket;
        //    int rl = client.EndReceive(iar);
        //    if (rl > 0)
        //    {
        //        _receivedata = _receivedata + System.Text.Encoding.Default.GetString(_buffer, 0, rl);
        //    }
        //}
    }
}
