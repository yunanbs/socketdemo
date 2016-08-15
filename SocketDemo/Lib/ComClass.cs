using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace SocketDemo.Lib
{
    class ComClass
    {
        private SerialPort m_clientcom;
        private int C_DataBits = 8;
        private byte[] _ReadBuff;
        private string _receivedata;
        private bool _isrun = false;

        /// <summary>
        /// 是否打开
        /// </summary>
        private bool IsOpen
        {
            get
            {
                return m_clientcom.IsOpen;
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="comno">端口号</param>
        /// <param name="baudrate">波特率</param>
        public ComClass(string comno,string baudrate)
        {
            m_clientcom = new SerialPort(comno);
            m_clientcom.BaudRate = int.Parse(baudrate);
            m_clientcom.DataBits = C_DataBits;
            m_clientcom.StopBits = StopBits.One;
            m_clientcom.DataReceived += new SerialDataReceivedEventHandler(m_clientcom_DataReceived);//添加数据接收事件
           
        }

        /// <summary>
        /// 打开端口
        /// </summary>
        /// <returns>1成功；-1失败</returns>
        public int OpenCom()
        {
            try
            {
                m_clientcom.Open();
                _isrun = true;
                return 1;
            }
            catch
            {
                return -1;
            }
        }

        void m_clientcom_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            ReceiveData();//接收数据
        }

        /// <summary>
        /// 接收数据
        /// </summary>
        private void ReceiveData()
        {
            try
            {
                if (_isrun)
                {
                    _ReadBuff = new byte[m_clientcom.BytesToRead];
                    int tmp = m_clientcom.Read(_ReadBuff, 0, _ReadBuff.Length);
                    string _tmp = GetString(_ReadBuff);
                    _receivedata += _receivedata;//接收数据进入缓存
                }
            }
            catch
            {
                return;
            }
        }

       
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="message"></param>
        /// <returns>1成功；-1串口未打开；-9999异常</returns>
        public int SendMessage(string message)
        {
            int i_result = 0;
            try
            {
                if (IsOpen)
                {
                    byte[] tosend = null;
                    tosend = GetBytes(message);
                    m_clientcom.Write(tosend, 0, tosend.Length);
                    i_result = 1;
                    return i_result;
                }
                else
                {
                    return -1;
                }
            }
            catch
            {
                i_result = -9999;
                return i_result;
            }
        }

        /// <summary>
        /// 字符串转数组
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private byte[] GetBytes(string message)
        {
            byte[] result = Encoding.Default.GetBytes(message);
            return result;
        }

        /// <summary>
        /// 数组转字符串
        /// </summary>
        /// <param name="receivebyte"></param>
        /// <returns></returns>
        private string GetString(byte[] receivebyte)
        {
            return Encoding.Default.GetString(receivebyte);
        }

        /// <summary>
        /// 停止
        /// </summary>
        public int Stop()
        {
            int result = 1;
            try
            {
                _isrun = false;
                m_clientcom.Close();
                m_clientcom.Dispose();
                return result;
            }
            catch
            {
                result = -1;
                return result;
            }
        }

        /// <summary>
        /// 读取并清空缓存数据
        /// </summary>
        /// <returns></returns>
        public string GetReaceiveData()
        {
            string tmp = _receivedata;
            _receivedata = "";
            return tmp;
        }

     
    }
}
