using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SocketDemo.Lib;
using System.Xml.Linq;
using System.IO;
using System.Diagnostics;

namespace SocketDemo
{
    public partial class Form1 : Form
    {
        private string _configpath = Application.StartupPath + "/config.xml";//获取配置文件路径

        public Form1()
        {
            InitializeComponent();

            //DataCheckLib tmp = new DataCheckLib();

            //double bb = tmp.CheckVal("a21026", 0);

            #region 测试
            //噪声测试
            //DataDeal dd = new DataDeal();
            //string tmpstr = @"<Package><LtdInfo><Code>[41574100000123]</Code><Pwd>[111111]</Pwd><Class>[N011]</Class><Flag>[20110819155600361]</Flag></LtdInfo><Data><Name>[Datatype,DateTime,Leq,L5,L10,L50,L90,L95,max,min,SD,Rate,InteTime,W-Speed,A-Temp,Humi-R,Ari-P,PRF,Ld,Ln,Ldn]</Name><Unit>[,,dB,dB,dB,dB,dB,dB,dB,dB,dB,%,s,m/s,C,%,P,mm,db,db,db]</Unit><Value>[0,2011-08-19 15:46:00,57.1,59.9,57.8,52.1,46.6,45.7,75.7,43.4,4.6,92.2,600,0.0,0.0,0.0,0.0,0.0,11,12,13]</Value></Data></Package>";


            //string[][] test = dd.DealPack(ref tmpstr, "AW2010", "9003", "test");

            //int a = test.Length;
            //return;

            //空气测试            
            //DataDeal dd = new DataDeal();
            //string tmpstr = "##0385ST=22;CN=2051;PW=123456;MN=88888880000001;CP=&&DataTime=20140226153000;QN=20140226153000001;a01001-Avg=9.3;a01002-Avg=100;a01005-Avg=0.6016;a01006-Avg=1017.1,a01006-Flag=d;a01007-Avg=2.9;a01008-Avg=180.6;a01031-Avg=27.12;a01032-Avg=46.4622;a05024-Avg=0.0944;a21002-Avg=0.0336;a21003-Avg=0.0014;a21004-Avg=0.0315;a21026-Avg=0.0111;a34004-Avg=0.0523;a34005-Avg=0.0886;af0001-Avg=1.1622&&7222\r\n";

            //////string tmpstr11 = "##0250QN=20110412095600001;ST=22;CN=2051;PW=123456;MN=88888880000001;CP=&&DataTime=20110412095600;a01005-Avg=-100,a01005-Flag=B;a05024-Avg=28.47;a21002-Avg=84.525;a21003-Avg=57.3882;a21004-Avg=27.1636;a21026-Avg=2.8608;a34004-Avg=0.0123;a34005-Avg=0.0651&&723D\r\n";

            //string[][] test = dd.DealPack(ref tmpstr, "BaoShan", "8912", "test");

            //int a = test.Length;
            //return;

            


            //DataDeal dd = new DataDeal();
            //string kq = "##0356QN=20111024151601000;ST=32;CN=2082;PW=123456;MN=26243840000115;CP=&&DataTime=20111024151000;w01102-Min=220.00,w01102-Avg=220.00,w01102-Max=220.00,w01102-Flag=N;w01001-Min=7.00,w01001-Avg=7.00,w01001-Max=7.00,w01001-Flag=N;W01018-Min=456.00,W01018-Avg=456.00,W01018-Max=456.00,W01018-Flag=N;w01101-Min=22334,w01101-Avg=22334,w01101-Max=22334,w01101-Flag=N&&FFFF\r\n";
            //string[][] test = dd.DealPack(ref kq, "BaoShan", "8900","test");
            //int a = test.Length;
            //return;


            //DataDeal dd = new DataDeal();
            //string kq = "##0088ST=91;CN=3012;CP=&&QN=20040516010100001;RS=1&&23AD\r\n";
            //string[][] test = dd.DealPack(ref kq, "BaoShan", "8900","test3012");
            //int a = test.Length;
            //return;


            //空气控制测试
            //DataDeal dd = new DataDeal();
            //string kq = "##0613QN=20140623124500312;ST=31;CN=2082;MN=31011300010129;CP=&&DataTime=20140623110000;DATState=3;a21003-Min=0.009,a21003-Avg=0.011,a21003-Max=0.013,a21003-Flag=m;a21004-Min=0.04,a21004-Avg=0.042,a21004-Max=0.044,a21004-Flag=m;a21002-Min=0.054,a21002-Avg=0.059,a21002-Max=0.063,a21002-Flag=m;a21026-Min=0.011,a21026-Avg=0.018,a21026-Max=0.022,a21026-Flag=m;a34002-Min=-0.006,a34002-Avg=0.035,a34002-Max=0.074,a34002-Flag=N;a05024-Min=0.034,a05024-Avg=0.04,a05024-Max=0.062,a05024-Flag=N;a34050-Min=0.032,a34050-Avg=0.039,a34050-Max=0.045,a34050-Flag=N;a21005-Min=0.783,a21005-Avg=0.839,a21005-Max=0.951,a21005-Flag=m&&6F8B\r\n";
            //string[][] test = dd.DealPack(ref kq, "BaoShan", "8900", "test3012");
            //int a = test.Length;
            //return;

            //DataDeal dd = new DataDeal();
            //string kq = "##0088ST=91;CN=3044;CP=&&QN=20040516010100001;TASKID=1234;TASKNAME=test;TASKDEATIAL='........';STARTTIME=yyyymmddhhhmiss;FREQUCE=24;STATUS=1&&23AD\r\n";
            //string[][] test = dd.DealPack(ref kq, "BaoShan", "8900", "test3012");
            //int a = test.Length;
            //return;

            //DataDeal dd = new DataDeal();
            //string kq = "##0679QN=20130902113600000;ST=31;CN=2081;PW=123456;MN=88888880000001;CP=&&DataTime=20130902113000;02-Min=0.14,02-Avg=0.14,02-Max=0.14,02-Flag=N;02-ZsMin=0.13,02-ZsAvg=0.13,02-ZsMax=0.13,02-ZsFlag=N;01-Min=13.46,01-Avg=13.46,01-Max=13.46,01-Flag=N;01-ZsMin=12.42,01-ZsAvg=12.42,01-ZsMax=12.42,01-ZsFlag=N;03-Min=32.120,03-Avg=32.120,03-Max=32.120,03-Flag=N;03-ZsMin=29.630,03-ZsAvg=29.630,03-ZsMax=29.630,03-ZsFlag=N;S01-Min=14.5,S01-Avg=14.5,S01-Max=14.5,S01-Flag=N;S02-Min=11.76,S02-Avg=11.76,S02-Max=11.76,S02-Flag=N;S03-Min=88.5,S03-Avg=88.5,S03-Max=88.5,S03-Flag=N;S08-Min=-1.03,S08-Avg=-1.03,S08-Max=-1.03,S08-Flag=N;S04-Min=970832.0,S04-Avg=970832.0,S04-Max=970832.0,S04-Flag=N&&2154\r\n";
            //string[][] test = dd.DealPack(ref kq, "BaoShan", "8900", "test3012");
            //int a = test.Length;
            //return;



            //烟气测试


            //DataDeal dd = new DataDeal();
            //string kq = "##0783QN=20111129160000000;ST=31;CN=2082;PW=987654;MN=88888880000001;CP=&&DataTime=20111129155500;S01-Min=0,S01-Max=0,S01-Avg=0,S01-Cou=0,S01-Flag=N;S02-Min=0,S02-Max=0,S02-Avg=2,S02-Cou=0,S02-Flag=N;S03-Min=0,S03-Max=0,S03-Avg=0,S03-Cou=0,S03-Flag=N;S08-Min=0,S08-Max=0,S08-Avg=36,S08-Cou=0,S08-Flag=N;S09-Min=0,S09-Max=0,S09-Avg=0,S09-Cou=0,S09-Flag=N;01-Min=0,01-Max=0,01-Avg=0,01-ZsMin=0,01-ZsMax=0,01-ZsAvg=0,01-Cou=0,01-Flag=N;02-Min=0,02-Max=0,02-Avg=3689,02-ZsMin=0,02-ZsMax=0,02-ZsAvg=0,02-Cou=368,02-Flag=N;03-Min=0,03-Max=0,03-Avg=0,03-ZsMin=0,03-ZsMax=0,03-ZsAvg=0,03-Cou=0,03-Flag=N;S10-Min=0,S10-Max=0,S10-Avg=0,S10-Cou=0,S10-Flag=N;S04-Min=0,S04-Max=0,S04-Avg=0,S04-Cou=0,S04-Flag=N;StaTem-min=0,StaTem-Max=0,StaTem-Avg=0&&45C4\r\n";
            //string[][] test = dd.DealPack(ref kq, "BaoShan", "5001", "test3012");
            //int a = test.Length;
            //return;


            //辐射 测试

            //DataDeal Datadeal = new DataDeal();
            //string fs = "##0220140613090745;999999;0.206;0.000;0.000;12.000@@##0220140613090750;999999;0.185;0.000;0.000;12.000@@";
            ////处理接收的报文，生成上传数据参数
            //string[][] _getData = Datadeal.DealPack(ref fs, "BaoShanFS", "6009", "FS01");
            //int a = 0;
            //return;

            #endregion

            //return;
            OneFormProtect();

            LogCheck(6, "log");





            //按配置文件初始化站点
            try
            {
                XDocument xd = XDocument.Load(_configpath);
                XElement _site = xd.Descendants("Sites").First();

                if (_site.Descendants("Client").Count() > 0)
                {
                    XElement _Client = _site.Descendants("Client").First();//获取客户端站点名称
                    foreach (XElement sub in _Client.Elements())
                    {
                        ServerForm sf = new ServerForm(sub.Attribute("port").Value.ToString(), sub.Attribute("protocol").Value.ToString(), sub.Attribute("name").Value.ToString(), Convert.ToBoolean(sub.Attribute("heart").Value.ToString()));
                        sf.Show();
                        sf.MdiParent = this;
                    }
                }

                if (_site.Descendants("Server").Count() > 0)
                {
                    XElement _Server = _site.Descendants("Server").First();//获取服务端站点名称
                    foreach (XElement sub in _Server.Elements())
                    {
                        ClientForm cf = new ClientForm(sub.Attribute("IP").Value.ToString(), sub.Attribute("port").Value.ToString(), sub.Attribute("protocol").Value.ToString(), sub.Attribute("name").Value.ToString(), Convert.ToBoolean(sub.Attribute("heart").Value.ToString()));
                        cf.Show();
                        cf.MdiParent = this;
                    }
                }

                if (_site.Descendants("Com").Count() > 0)
                {
                    XElement _com = _site.Descendants("Com").First();//获取串口站点名称
                    foreach (XElement sub in _com.Elements())
                    {
                        ComForm cof = new ComForm(sub.Attribute("port").Value.ToString(), sub.Attribute("baudrate").Value.ToString(), sub.Attribute("protocol").Value.ToString(), sub.Attribute("name").Value.ToString());
                        cof.Show();
                        cof.MdiParent = this;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

         
            
        }

        private void OneFormProtect()
        {
            Process p = Process.GetCurrentProcess();
            string str_pname = p.ProcessName;
            Process[] tmp = Process.GetProcessesByName(str_pname);
            if (tmp.Count()>1)
            {
                MessageBox.Show("已有一个相同的实例在运行中，不能同时启动2个实例");
                p.Kill();
            }
        }

        private void serverToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ServerForm sf = new ServerForm();
            sf.Show();
            sf.MdiParent = this;
        }

        private void getDeviceNoListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "csv文件|*.csv";
            if (sfd.ShowDialog()==DialogResult.OK)
            GetDNoList(sfd.FileName);
            
        }

        /// <summary>
        /// 生成点表
        /// </summary>
        /// <param name="filename"></param>
        private void GetDNoList(string filename)
        {
            
            List<string> l_list = new List<string>();

            List<string> l_st = new List<string>();
            List<string> l_cn = new List<string>();
            List<string> l_data = new List<string>();
            List<string> l_datatype = new List<string>();

            List<string> l_dataname = new List<string>();
            List<string> l_cnname = new List<string>();
            List<string> l_datatypename = new List<string>();


            StringBuilder sb = new StringBuilder();

            XDocument xd = XDocument.Load(_configpath);
            XElement _sitelist = xd.Descendants("Sites").First();

            StreamWriter sw = new StreamWriter(filename, false,Encoding.UTF8);

            try
            {
                foreach (XElement sub in _sitelist.Elements())
                {
                    string _sitename = sub.Attribute("name").Value;
                    string _siteport = sub.Attribute("port").Value;
                    string _protocolname = sub.Attribute("protocol").Value;



                    XElement _protocol = xd.Descendants(_protocolname).First();

                    l_st.Clear();
                    l_cn.Clear();
                    l_cnname.Clear();
                    l_data.Clear();
                    l_dataname.Clear();
                    l_datatype.Clear();
                    l_datatypename.Clear();




                    foreach (XElement ssub in _protocol.Descendants("SiteType").First().Elements())
                    {
                        l_st.Add(ssub.Attribute("value").Value);
                    }

                    foreach (XElement ssub in _protocol.Descendants("CommandType").First().Elements())
                    {
                        l_cn.Add(ssub.Attribute("value").Value);
                        l_cnname.Add(ssub.Name.ToString());
                    }

                    foreach (XElement ssub in _protocol.Descendants("Datas").First().Elements())
                    {
                        l_data.Add(ssub.Attribute("value").Value);
                        l_dataname.Add(ssub.Name.ToString());
                    }

                    foreach (XElement ssub in _protocol.Descendants("DataType").First().Elements())
                    {
                        l_datatype.Add(ssub.Attribute("value").Value);
                        l_datatypename.Add(ssub.Name.ToString());
                    }

                    string[] s1 = linkstr(new string[] { "A:" }, l_st.ToArray());
                    string[] s2 = linkstr(s1, new string[] { _siteport + ":" });
                    string[] s3 = linkstr(s2, new string[] { _siteport });
                    string[] s4 = linkstr(s3, l_cn.ToArray());
                    string[] s5 = linkstr(s4, l_data.ToArray());
                    string[] s6 = linkstr(s5, l_datatype.ToArray());

                    string[] sname0 = linkstr(l_st.ToArray(), new string[] { _sitename });
                    string[] sname1 = linkstr(sname0, l_dataname.ToArray());
                    string[] sname2 = linkstr(sname1, l_cnname.ToArray());
                    string[] sname3 = linkstr(sname2, l_datatypename.ToArray());

                    //sw = File.AppendText(filename);
                    for (int i = 0; i < sname3.Length; i++)
                    {
                        string _towrite = sname3[i]+","+ s6[i];
                       
                        sw.WriteLine(_towrite);
                    }



                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sw.Close();
                sw.Dispose();
            }
        }

        /// <summary>
        /// 组合字符串
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        private string[] linkstr(string[] s1, string[] s2)
        {
            List<string> result = new List<string>();
            foreach (string s in s1)
            {
                foreach (string ss in s2)
                {
                    result.Add(s+ ss);
                }
            }
            return result.ToArray();
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Count() != 0)//必须先退出各个子窗体
            {
                MessageBox.Show("请先确认关闭所有的子窗体");
            }
            else
            {
                this.Dispose();
            }
        }

        /// <summary>
        /// 启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void allStarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form[] c = this.MdiChildren;
            foreach (Form tmp in c)
            {

                tmp.GetType().GetMethod("PubStart").Invoke(tmp, null);
                    
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            e.Cancel = true;
            this.Visible = false;
            notifyIcon1.Visible = true;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            notifyIcon1.Visible = false;
        }

        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientForm cf = new ClientForm();
            cf.MdiParent = this;
            cf.Show();
        }

        private void sendhexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComClass cc = new ComClass("com1", "9600");

        }

        private void allMinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                f.WindowState = FormWindowState.Minimized;
            }
        }

        private void allMaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                f.WindowState = FormWindowState.Maximized; 
            }
        }

        private void sitesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SitesForm sf = new SitesForm();
            sf.Show();
            sf.MdiParent = this;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Form[] c = this.MdiChildren;
            foreach (Form tmp in c)
            {

                tmp.GetType().GetMethod("PubStart").Invoke(tmp, null);

            }
            
        }

        private void sendappToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SystemInfo.EventStruct es = new SystemInfo.EventStruct();
            //SystemInfo.EventStruct ess = new SystemInfo.EventStruct();
            //Cems_KQ.ServiceSoapClient sc = new Cems_KQ.ServiceSoapClient();
            
            //SystemInfo.SystemInfoSoapClient sic = new SystemInfo.SystemInfoSoapClient();
            //es.appName = "App_8908";
            //es.Event = sc.GetDateCN();


            //ess.appName = "App_8908";
            //ess.Event = sc.GetCheckDateDateCN();

            //sic.writeEvent(es);
            //sic.writeEvent(ess);

        }

        private void LogCheck(int bakmonth,string lastname)
        {
            string path = Application.StartupPath;
            string[] files = Directory.GetFiles(path);
            DateTime nowdt = System.DateTime.Now;
            DateTime bakdt = nowdt.AddMonths(-bakmonth);

            foreach (string f in files)
            {
                try
                {
                    if (f.Contains("." + lastname))
                    {
                        FileInfo fi = new FileInfo(f);

                        if (fi.LastWriteTime < bakdt)
                        {
                            File.Delete(f);
                        }
                    }
                }
                catch
                {
                    continue;
                }
            }

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
