using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Data;
using System.Windows.Forms;


namespace SocketDemo.Lib
{
    public class DataDeal
    {
        public string[][] DealPack(ref string sourcedata, string protocol,string port,string sitename)
        {
            string s_source = sourcedata;
            PackDeal pd = null;
            string[] result = null;
            string[] callback = null;
            switch (protocol)
            {
                case "BaoShan":
                    pd = new BaoShanData(port, sitename);
                    result = pd.GetWebStr(ref s_source);
                    callback = pd.GetCallBackStr();
                    break;

                case "AW2010":
                    pd = new AW2010Data(port);
                    result = pd.GetWebStr(ref s_source);
                    callback = pd.GetCallBackStr();
                    break;

                case "BaoShanFS":

                     pd = new BaoShanFS(port,sitename);
                    result = pd.GetWebStr(ref s_source);
                    callback = pd.GetCallBackStr();
                    break;
                default:
                    break;
            }
            sourcedata = s_source;
            return new string[][]{callback,result};
        }
    }


    interface PackDeal
    {
        string[] GetWebStr(ref string sourcedata);
        string[] GetCallBackStr();
    }

    public class BaoShanData : PackDeal
    {
        private Cems_KQ.ServiceSoapClient cemskq = new Cems_KQ.ServiceSoapClient();

        //##0223QN=20110224122830361;ST=32;CN=2082;MN=88888888;CP=&&DataTime=20110224122800;DATState=2;PV01-Min=6.27,PV01-Avg=6.27,PV01-Max=6.27;CV01-Min=22.56,CV01-Avg=22.56,CV01-Max=22.56;FV01-Min=225.00,FV01-Avg=225.00,FV01-Max=225.00&&1B0B\r\n 
        private string s_config = Application.StartupPath +"\\config.xml";
        private string C_HeaderChar = "";
        private string C_EndChar = "";
        private string C_Port = "";
        private string C_SiteName = "";
        private string C_DataTime = "";
        private string C_UpdateState = "1,2";
        public List<Dictionary<string, string>> DataList = new List<Dictionary<string, string>>();
        private Hashtable ht_stlist = new Hashtable();
        private Hashtable ht_cnlist = new Hashtable();
        private Hashtable ht_dtlist = new Hashtable();
        private Hashtable ht_datalist = new Hashtable();
        private Hashtable ht_eclist = new Hashtable();
        private List<string> l_returnstr = new List<string>();
        private List<string> l_callbackstr = new List<string>();

        //2014-02-11 增加空气站点数据修约规范
        private DataCheckLib dcl_Checker = new DataCheckLib();

        public BaoShanData(string port,string sitename)
        {
            C_Port = port;
            C_SiteName = sitename;
            IniProtocols();
        }

        private void IniProtocols()
        {
            XDocument xd = XDocument.Load(s_config);
            XElement Root = xd.Descendants("BaoShan").First();
            XElement SiteElement = Root.Descendants("SiteType").First();
            XElement CommandElement = Root.Descendants("CommandType").First();
            XElement DataTypeElement = Root.Descendants("DataType").First();
            XElement DataElement = Root.Descendants("Datas").First();
            XElement Errorcode = Root.Descendants("ErrorCode").First(); 
            foreach (XElement sub in SiteElement.Elements())
            {
                ht_stlist.Add(sub.Attribute("name").Value, sub.Attribute("value").Value);
            }

            foreach (XElement sub in CommandElement.Elements())
            {
                ht_cnlist.Add(sub.Attribute("name").Value, sub.Attribute("value").Value);
            }

            foreach (XElement sub in DataTypeElement.Elements())
            {
                ht_dtlist.Add(sub.Attribute("name").Value, sub.Attribute("value").Value);
            }

            foreach (XElement sub in DataElement.Elements())
            {
                ht_datalist.Add(sub.Attribute("name").Value, sub.Attribute("value").Value);
            }

            foreach (XElement sub in Errorcode.Elements())
            {
                string name = sub.Attribute("ecodname").Value;
                string code = sub.Attribute("fxcode").Value;
                if(name=="XYH")
                {
                    name = "<";
                }else if(name =="DYH")
                {
                    name = ">";
                }
                
                ht_eclist.Add(name,code);
            }

            C_HeaderChar = Root.Descendants("Pack").First().Attribute("Header").Value;
            C_EndChar = Root.Descendants("Pack").First().Attribute("Ender").Value;
            C_HeaderChar = "##";
            C_EndChar = "\r\n";
            C_DataTime = Root.Descendants("Pack").First().Attribute("DataTime").Value;
        }

        private void ReadPack(ref string sourcedata)
        {
            string s_getdata = sourcedata;
            int i_headerindex = s_getdata.IndexOf(C_HeaderChar);
            if ( i_headerindex > -1)
            {
                s_getdata = s_getdata.Substring(i_headerindex);
            }
            else
            {
                sourcedata = "";
                return;
            }

            int i_enderindex = s_getdata.IndexOf(C_EndChar);

            if (i_enderindex > -1)
            {
                s_getdata = s_getdata.Substring(0,i_enderindex+C_EndChar.Length);
                //增加报文判断，非数据报文调用报文处理接口进行处理
                string cn = GetCN(s_getdata);
                if (ht_cnlist.ContainsKey(cn))
                {
                    AnalyPack(s_getdata);
                }
                else
                {
                    string callbackstr = "";
                    int r = cemskq.PackinDB(s_getdata, C_SiteName,ref callbackstr);
                    l_callbackstr.Add(callbackstr);
                  
                }
                sourcedata = sourcedata.Substring(s_getdata.Length);
                ReadPack(ref sourcedata);
            }
            else
            {
                sourcedata = s_getdata;
                return;
            }

        }

        private void AnalyPack(string Datastr)
        {
            try
            {
                int i_receivedatal = Datastr.Length - C_HeaderChar.Length - C_EndChar.Length - 4 - 4;
                int i_senddatal =int.Parse(Datastr.Substring(2, 4));
                //取消长度校验 2011-04-12 by 俞楠
                i_senddatal=i_receivedatal ;

                if (i_receivedatal == i_senddatal)
                {
                    //string str_datapart = Datastr.Substring(6, i_senddatal);
                    //AddDataDic(str_datapart);
                    string cn = GetCN(Datastr);
                    string qn = GetQN(Datastr);
                    string st = GetStieType(Datastr);

                     //生成应答报文 2011-04-12 by 俞楠
                        string rstr = "";
                        rstr += "ST=91;";
                        rstr += "CN=" + cn + ";";
                        rstr += "CP=&&";
                        rstr += "QN=" + qn;
                        rstr += "&&";
                        CRC16 crc = new CRC16();
                        string crccode = crc.CalculateCrc16(System.Text.Encoding.Default.GetBytes(rstr)).ToString("X");
                        string l = rstr.Length.ToString().PadLeft(4, '0');
                        rstr = C_HeaderChar +l+ rstr +crccode+ C_EndChar;
                        l_callbackstr.Add(rstr);

                            Tag[] tags = GetDataTags(Datastr, cn, st);


                            if (tags != null)
                            {
                                string[] s = ReadTags(tags);
                                foreach (string ss in s)
                                {
                                    l_returnstr.Add(ss);
                                }
                            }
                       
                    return;
                }
                else
                {

                    return;
                }
            }
            catch
            {
                return;
            }
        }

        private string GetCN(string sourcedata)
        {
            string substr = sourcedata.Substring(sourcedata.IndexOf("CN="));
            substr = substr.Substring(0,substr.IndexOf(";"));
            string cn = substr.Substring(3);
            return cn;
        }

        private string GetQN(string sourcedata)
        {
            string substr = sourcedata.Substring(sourcedata.IndexOf("QN="));
            substr = substr.Substring(0,substr.IndexOf(";"));
            string qn = substr.Substring(3);
            return qn;
        }

        private string GetStieType(string sourcedata)
        {
            string substr = sourcedata.Substring(sourcedata.IndexOf("ST="));
            substr = substr.Substring(0,substr.IndexOf(";"));
            string st = substr.Substring(3);
            return ht_stlist[st].ToString();
        }

        private Tag[] GetDataTags(string sourcedata,string cn,string st)
        {
            //##0332ST=22;CN=2051;PW=123456;MN=88888880000001;CP=&&DataTime=20110513092300;QN=20110513092300001;a01001-Avg=23.4;a01002-Avg=32;a01005-Avg=-100,a01005-Flag=B;a01006-Avg=1011.65;a01007-Avg=0.575;a05024-Avg=0.0205;a06001-Avg=123.035;a21002-Avg=0.1496;a21003-Avg=0.055;a21004-Avg=0.0653;a21026-Avg=0.0873;a34004-Avg=0.0968;a34005-Avg=0.185&&9983

            try
            {
                Hashtable ht_tag = new Hashtable();

                string datastr = sourcedata.Substring(sourcedata.IndexOf("CP=&&"));
                datastr = datastr.Substring(5);
                datastr = datastr.Substring(0, datastr.Length - 6-C_EndChar.Length);

                string dttype = ht_cnlist[cn].ToString();
                string[] tagstrs = datastr.Split(';');

                string datetime = "";
                foreach (string s in tagstrs)
                {
                    if (s.Contains(C_DataTime))
                    {
                        datetime = s.Replace(C_DataTime + "=", "");
                        datetime = datetime.Insert(4, "-");
                        datetime = datetime.Insert(7, "-");
                        datetime = datetime.Insert(10, " ");
                        datetime = datetime.Insert(13, ":");
                        datetime = datetime.Insert(16, ":");
                        continue;
                    }
                        //上海市空气协议需要判断DATState位来确定是5分钟数据或者小时数据
                    else if (s.Contains("DATState="))
                    {
                        string state = s.Replace("DATState=","");
                        if (state == "3")
                        {
                            dttype = "60";
                        }
                    }
                    else if (s.Contains("-"))
                    {
                        string[] substr = s.Split(',');
                        string flag = "N";//默认为正常数据
                        string s_dataname = "";//因子名称
                        //string datatype ="";
                        //string dataval ="";

                        foreach (string ss in substr)
                        {
                            if (ss.Contains("-Flag"))//找数据标记
                            {
                                string s_Flag = ss.Substring(ss.IndexOf("=") + 1);
                                if (s_Flag != "N")
                                {
                                    if (s_Flag.Contains(">") || s_Flag.Contains("<"))
                                    {
                                        flag = s_Flag;
                                    }
                                    else
                                    {
                                        flag = s_Flag == s_Flag.ToUpper() ? ">" + s_Flag.ToUpper() : "<" + s_Flag.ToUpper();
                                    }
                                    
                                }
                                continue;
                            }

                            if (ss.Contains("-"))//找值数据
                            {
                                string dataname = ss.Substring(0, ss.IndexOf("-"));
                                s_dataname = dataname;
                                string datatype = ss.Substring(ss.IndexOf("-") + 1);
                                datatype = datatype.Substring(0, datatype.IndexOf("="));
                                string dataval = ss.Substring(ss.IndexOf("=") + 1);

                                //处理多余3位的小时
                          
                                double tmpd = double.Parse(dataval);
                                //dataval = tmpd.ToString("f3");


                                if(dataname=="a21005"||dataname=="a01005")//CO保留1位小数
                                {
                                    dataval = this.DataFormat(tmpd,1);
                                }else//其他因子 保留3位小数
                                {
                                    dataval = this.DataFormat(tmpd, 3);
                                }
                                

                                if (ht_datalist.ContainsKey(dataname))
                                {
                                    if (ht_tag.Contains(dataname))
                                    {
                                        Tag t = (Tag)ht_tag[dataname];
                                        t.GetType().GetProperty(datatype).SetValue(t, dataval, null);
                                        ht_tag[dataname] = t;
                                    }
                                    else
                                    {
                                        Tag t = new Tag();
                                        t.DataTime = datetime;
                                        t.TagName = dataname;
                                        t.St = st;
                                        //t.TimeType = ht_cnlist[cn].ToString();
                                        t.TimeType = dttype;
                                        PropertyInfo pi = t.GetType().GetProperty(datatype);
                                        pi.SetValue(t, dataval, null);
                                        ht_tag.Add(dataname, t);
                                    }
                                }
                                continue;
                            }
                        }

                        //2014-02-11
                        //需加入数据修正

                        Tag t_Tag = (Tag)ht_tag[s_dataname];//取出值
                        if (t_Tag != null)
                        {
                            string s_DataVal = t_Tag.Avg;
                            double d_dataval = 0;
                            t_Tag.Flag = flag;

                            if (double.TryParse(s_DataVal, out d_dataval))
                            {
                                d_dataval = Math.Round(d_dataval, 3);
                                d_dataval = dcl_Checker.CheckVal(s_dataname, d_dataval);
                                if (d_dataval != -9999)
                                {
                                    s_DataVal = d_dataval.ToString();
                                    t_Tag.Avg = s_DataVal;
                                }
                                else//-9999不需要修改数据 直接修改状态位为d
                                {
                                    flag = "<D";
                                    t_Tag.Flag = flag;
                                }
                            }
                            ht_tag[s_dataname] = t_Tag;
                            #region old
                            //foreach (string ss in substr)
                            //{
                            //    if (ss.Contains("-"))
                            //    {
                            //        string dataname = ss.Substring(0, ss.IndexOf("-"));
                            //        string datatype = ss.Substring(ss.IndexOf("-") + 1);
                            //        datatype = datatype.Substring(0, datatype.IndexOf("="));
                            //        string dataval = ss.Substring(ss.IndexOf("=") + 1);

                            //        //2014-02-11
                            //        //需加入数据修正
                            //        double d_dataval = 0;
                            //        if (double.TryParse(dataval, out d_dataval))
                            //        {

                            //        }

                            //        if (ht_datalist.ContainsKey(dataname))
                            //        {
                            //            if (ht_tag.Contains(dataname))
                            //            {
                            //                Tag t = (Tag)ht_tag[dataname];
                            //                t.GetType().GetProperty(datatype).SetValue(t, dataval, null);
                            //                ht_tag[dataname] = t;

                            //            }
                            //            else
                            //            {
                            //                Tag t = new Tag();
                            //                t.DataTime = datetime;
                            //                t.TagName = dataname;
                            //                t.St = st;
                            //                t.TimeType = ht_cnlist[cn].ToString();
                            //                PropertyInfo pi = t.GetType().GetProperty(datatype);
                            //                pi.SetValue(t, dataval, null);

                            //                ht_tag.Add(dataname, t);
                            //            }
                            //        }
                            //    }
                            //}
                            #endregion
                        }
                    }

                    

                }

                return ht_tag.Values.OfType<Tag>().ToArray();
            }
            catch
            {
                return null;
            }
        }

        private void AddDataDic(string data)
        {
            string s_data = data.Replace("CP=&&","").Replace("&&","");
            s_data = s_data.Replace(',', ';');
            string[] s_datas = s_data.Split(';');
            Dictionary<string, string> dic_data = new Dictionary<string, string>();
            foreach(string s_sub in s_datas)
            {
                try
                {
                    string[] kv = s_sub.Split('=');
                    dic_data.Add(kv[0], kv[1]);
                }
                catch
                {
                    continue;
                }
            }
            DataList.Add(dic_data);
        }

        private string[] ReadDic()
        {
            List<string> l_result = new List<string>();
            l_returnstr = new List<string>();

            if(DataList!=null)
            {
                foreach (Dictionary<string, string> dc in DataList)
                {
                    try
                    {
                        //生成应答报文 2011-04-12 by 俞楠
                        string rstr = "";
                        rstr += "ST=91;";
                        rstr += "CN=" + dc["CN"] + ";";
                        rstr += "CP=&&";
                        rstr += "QN" + dc["QN"];
                        rstr += "&&";
                        CRC16 crc = new CRC16();
                        string crccode = crc.CalculateCrc16(System.Text.Encoding.Default.GetBytes(rstr)).ToString("X");
                        string l = rstr.Length.ToString().PadLeft(4, '0');
                        rstr = C_HeaderChar +l+ rstr +crccode+ C_EndChar;
                        l_returnstr.Add(rstr);


                        string _st = dc["ST"];
                        string _cn = dc["CN"];
                        string _datatime = dc[C_DataTime];
                        dc.Remove("ST");
                        dc.Remove("CN");
                        dc.Remove(C_DataTime);
                        dc.Remove("MN");
                        dc.Remove("QN");
                        dc.Remove("DATState");
                        dc.Remove("PW");
                        foreach (string _key in dc.Keys)
                        {
                            try
                            {
                                string _value = dc[_key];
                                string[] _subkeys = _key.Split('-');
                                _subkeys[0] = ht_datalist[_subkeys[0]].ToString();
                                _subkeys[1] = ht_dtlist[_subkeys[1]].ToString();
                                StringBuilder sb = new StringBuilder();
                                sb.Append(ht_stlist[_st] + C_Port + ",");
                                sb.Append(C_Port + ht_cnlist[_cn] + _subkeys[0] + _subkeys[1] + ",");
                                sb.Append(_value + ",");
                                sb.Append(C_UpdateState + ",");
                                sb.Append(GetDataTimeStr(_datatime));
                                l_result.Add(sb.ToString());
                            }
                            catch
                            {
                                continue;
                            }
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
            }

            //将应答报文插入至返回数组的第一条 2011-04-12 by 俞楠
            string returnstr = "";
            foreach (string s in l_returnstr)
            {
                returnstr += s;
            }

            l_result.Insert(0, returnstr);

            return l_result.ToArray() ;
        }

        private string[] ReadTags(Tag[] tags)
        {
            try
            {
                List<string> r = new List<string>();
                StringBuilder sb = new StringBuilder();
                foreach (Tag t in tags)
                {
                    string flag = t.Flag;
                    if (flag == null)
                    {
                        flag = "1";
                    }
                    else if (flag == "N")
                    {
                        flag = "1";
                    }
                    else
                    {
                        string f = t.Flag;
                        flag = "";
                        foreach (Char c in f)
                        {
                            string s = c.ToString();
                            flag += ht_eclist[s].ToString();
                        }
                        flag = "9" + flag + "2";
                        //>b 修改为1
                        //if (flag.Contains("926"))
                        //{
                        //    flag = "1";
                        //}
                    }

                    if (t.Rtd != null)
                    {
                        sb = new StringBuilder();
                        sb.Append(t.St + C_Port + ",");
                        sb.Append(C_Port + t.TimeType + ht_datalist[t.TagName] + ht_dtlist["Rtd"] + ",");
                        sb.Append(t.Rtd + ",");
                        sb.Append(flag + ",");
                        sb.Append(t.DataTime);
                        r.Add(sb.ToString());
                    }

                    if (t.Avg != null)
                    {
                        //过滤空气数据中的负值数据
                        double d_tmp = double.Parse(t.Avg);
                        if (!(d_tmp < 0 && t.St == "DQ"))
                        {
                            sb = new StringBuilder();
                            sb.Append(t.St + C_Port + ",");
                            sb.Append(C_Port + t.TimeType + ht_datalist[t.TagName] + ht_dtlist["Avg"] + ",");
                            sb.Append(t.Avg + ",");
                            sb.Append(flag + ",");
                            sb.Append(t.DataTime);
                            r.Add(sb.ToString());
                        }
                    }

                    if (t.Max != null)
                    {
                        sb = new StringBuilder();
                        sb.Append(t.St + C_Port + ",");
                        sb.Append(C_Port + t.TimeType + ht_datalist[t.TagName] + ht_dtlist["Max"] + ",");
                        sb.Append(t.Max + ",");
                        sb.Append(flag + ",");
                        sb.Append(t.DataTime);
                        r.Add(sb.ToString());
                    }

                    if (t.Min != null)
                    {
                        sb = new StringBuilder();
                        sb.Append(t.St + C_Port + ",");
                        sb.Append(C_Port + t.TimeType + ht_datalist[t.TagName] + ht_dtlist["Min"] + ",");
                        sb.Append(t.Min + ",");
                        sb.Append(flag + ",");
                        sb.Append(t.DataTime);
                        r.Add(sb.ToString());
                    }

                    if (t.Cou != null)
                    {
                        sb = new StringBuilder();
                        sb.Append(t.St + C_Port + ",");
                        sb.Append(C_Port + t.TimeType + ht_datalist[t.TagName] + ht_dtlist["Cou"] + ",");
                        sb.Append(t.Cou + ",");
                        sb.Append(flag + ",");
                        sb.Append(t.DataTime);
                        r.Add(sb.ToString());
                    }

                    if (t.ZsAvg != null)
                    {
                        sb = new StringBuilder();
                        sb.Append(t.St + C_Port + ",");
                        sb.Append(C_Port + t.TimeType + ht_datalist[t.TagName] + ht_dtlist["ZsAvg"] + ",");
                        sb.Append(t.ZsAvg + ",");
                        sb.Append(flag + ",");
                        sb.Append(t.DataTime);
                        r.Add(sb.ToString());
                    }

                    if (t.ZsMax != null)
                    {
                        sb = new StringBuilder();
                        sb.Append(t.St + C_Port + ",");
                        sb.Append(C_Port + t.TimeType + ht_datalist[t.TagName] + ht_dtlist["ZsMax"] + ",");
                        sb.Append(t.ZsMax + ",");
                        sb.Append(flag + ",");
                        sb.Append(t.DataTime);
                        r.Add(sb.ToString());
                    }

                    if (t.ZsMin != null)
                    {
                        sb = new StringBuilder();
                        sb.Append(t.St + C_Port + ",");
                        sb.Append(C_Port + t.TimeType + ht_datalist[t.TagName] + ht_dtlist["ZsMin"] + ",");
                        sb.Append(t.ZsMin + ",");
                        sb.Append(flag + ",");
                        sb.Append(t.DataTime);
                        r.Add(sb.ToString());
                    }
                }

                //补上状态位为2的语句
                string[] ss = r.ToArray();
                foreach (string tmps in ss)
                {
                    string[] t = tmps.Split(',');
                    if(t[3]=="1")
                        t[3] = "2";
                    string newstr = "";
                    for (int i = 0; i < t.Length; i++)
                    {
                        newstr += t[i] + ",";
                    }
                    newstr = newstr.Remove(newstr.Length - 1);
                    r.Add(newstr);
                }
                return r.ToArray();
            }
            catch
            {
                return null;
            }

        }

        private string GetDataTimeStr(string timestr)
        {
            string newstr = timestr.Insert(12, ":");
            newstr = newstr.Insert(10, ":");
            newstr = newstr.Insert(8, " ");
            newstr = newstr.Insert(6, "-");
            newstr = newstr.Insert(4, "-");
            return newstr;
        }


        public string[] GetWebStr(ref string sourcedata)
        {
            ReadPack(ref sourcedata);
            return l_returnstr.ToArray();
        }

        public string[] GetCallBackStr()
        {
            return l_callbackstr.ToArray();
        }

        public string DataFormat(double SourceData, int count)
        {
            string s_Result = "";
            if (!SourceData.ToString().Contains("."))
            {
                s_Result = SourceData.ToString(string.Format("f{0}", count.ToString()));
            }
            else
            {
                int l_Len = SourceData.ToString().Substring(SourceData.ToString().IndexOf('.') + 1).Length;
                if (l_Len < (count + 1))//小数位数不超过的情况下不需要处理
                {
                    s_Result = SourceData.ToString();
                }
                else
                {
                    int i_Mod = int.Parse(SourceData.ToString().Substring(SourceData.ToString().IndexOf('.') + (count + 1), 1));//获取第X+1位
                    if (i_Mod != 5)//不等于5时 使用四舍五入
                    {
                        s_Result = SourceData.ToString(string.Format("f{0}", count.ToString()));
                    }
                    else//等于5时使用近双处理
                    {
                        SourceData = SourceData * Math.Pow(10, count);
                        SourceData = Math.Ceiling(SourceData);

                        SourceData = SourceData % 2 == 0 ? SourceData : SourceData - 1;
                        SourceData = SourceData / Math.Pow(10, count);
                        s_Result = SourceData.ToString(string.Format("f{0}", count.ToString()));
                    }
                }
            }

            return s_Result;
        }

        private class Tag
        {
            public string TagName { get; set; }
            public string DataTime { get; set; }
            public string TimeType { get; set; }
            public string Rtd { get; set; }
            public string Avg { get; set; }
            public string Max { get; set; }
            public string Min { get; set; }
            public string Flag { get; set; }
            public string St{get;set;}
            public string Cou { get; set; }
            public string ZsAvg { get; set; }
            public string ZsMin { get; set; }
            public string ZsMax { get; set; }
        }
    }

    /*
     * <Package>
	    <LtdInfo>
		    <Code>[41574100000116]</Code>
		    <Pwd>[111111]</Pwd>
		    <Class>[N001]</Class>
		    <Flag>[20110329134252673]</Flag>
	    </LtdInfo>
	    <Data>
     *      <Name>[Lafp]</Name>
     *      <Unit>[dB]</Unit>
     *      <Value>[51.6]</Value>
     *  </Data>
        </Package>
     * 
     * <Package><LtdInfo><Code>[88888880000001]</Code><Pwd>[123456]</Pwd><Class>[N011]</Class><Flag>[20040516010101001]</Flag></LtdInfo><Data><Name>[Datatype,DateTime,InteTime,Leq,L5,L10,L50,L90,L95,LMn,LMx,SD…]</Name><Unit>[1, ,s,dB,dB,dB,dB,dB,dB,dB,dB,… ]</Unit><Value>[0,20040516010101,60,76.1,81.4,79.3,75.9,63.2,55.2,50.7,85.0,3.5…]</Value></Data></Package><Package>
     * 返回值为##0080CP=&&Leq=10;SO2=10;NOX=10;PM10=10&&@@
     * */


    public class AW2010Data : PackDeal
    {
        private string s_config = Application.StartupPath + "\\config.xml";
        private string C_HeaderChar = "";
        private string C_EndChar = "";
        private string C_Port = "";
        private string C_DataTime = "";
        private string C_UpdateState = "1";
        private string C_CMLabel = "Class";
        private Hashtable ht_datatype = new Hashtable();
        private Hashtable ht_cmtype = new Hashtable();
        private Hashtable ht_data = new Hashtable();
        //API hashset
        private Hashtable ht_api = new Hashtable();

        List<string> l_returnstr = new List<string>();
        List<string> l_callbackstr = new List<string>();

        RequestHisData.RequestHisDataSoapClient rhc = new RequestHisData.RequestHisDataSoapClient();
        DataSet tmp_ds = new DataSet();

        public class ApiClass
        {
            public string TagName { get; set; }
            public string TagType { get; set; }
            public string TagValue { get; set; }
        }


        public AW2010Data(string port)
        {
            C_Port = port;
            IniProtocols();
        }

        private void IniProtocols()
        {
            XDocument xd = XDocument.Load(s_config);
            XElement root = xd.Descendants("AW2010").First();
            XElement tmp = root.Descendants("Pack").First();
            C_HeaderChar = "<" + tmp.Attribute("Header").Value + ">";
            C_EndChar = @"<" + tmp.Attribute("Ender").Value + ">";
            C_DataTime = tmp.Attribute("DataTime").Value;
            C_CMLabel = tmp.Attribute("CMLabel").Value;
            XElement dataxe = root.Descendants("Datas").First();
            foreach (XElement t_xe in dataxe.Elements())
            {
                ht_datatype.Add(t_xe.Attribute("name").Value, t_xe.Attribute("value").Value);
            }

            XElement cmxe = root.Descendants("CommandType").First();
            foreach (XElement t_xe in cmxe.Elements())
            {
                ht_cmtype.Add(t_xe.Attribute("name").Value, t_xe.Attribute("value").Value);
            }

            //获取API标签
            XElement siteroot = xd.Descendants("Client").First();
            foreach (XElement t_xe in siteroot.Elements())
            {
                if (t_xe.Attribute("port").Value == C_Port)
                {
                    foreach (XElement sub_xe in t_xe.Elements())
                    {
                        ApiClass ac = new ApiClass();
                        ac.TagName = sub_xe.Attribute("name").Value;
                        ac.TagType = sub_xe.Attribute("type").Value;
                        ac.TagValue = "";
                        ht_api.Add(ac.TagName, ac);
                    }
                }
            }
        }

      

        /// <summary>
        /// 截取报文内容 去除报文头尾
        /// </summary>
        /// <param name="sourcedata"></param>
        private void ReadPack(ref string sourcedata)
        {
            string s_getdata = sourcedata;
            int i_headerindex = s_getdata.IndexOf(C_HeaderChar);
            if (i_headerindex > -1)
            {
                s_getdata = s_getdata.Substring(i_headerindex);
            }
            else
            {
                sourcedata = "";
                return;
            }

            int i_enderindex = s_getdata.IndexOf(C_EndChar);

            if (i_enderindex > -1)
            {
                s_getdata = s_getdata.Substring(0, i_enderindex + C_EndChar.Length);
                //对于收到的报文进行判断，如果收到非数据报文，如控制响应指令 则执行其他方法

                AnalyPack(s_getdata);
                sourcedata = sourcedata.Substring(s_getdata.Length);
                ReadPack(ref sourcedata);
            }
            else
            {
                sourcedata = s_getdata;
                return;
            }

        }

        private void AnalyPack(string Datastr)
        {
            try
            {
                string xml_str = Datastr;
                //StringReader sr = new StringReader(xml_str);
                XDocument xd = XDocument.Parse(xml_str);

                XElement root = xd.Descendants("Data").First();
                XElement names = root.Descendants("Name").First();
                List<string> l_names = new List<string>();
                List<string> l_values = new List<string>();

                if (names != null)
                {
                    string str_names = names.Value.Replace("[", "").Replace("]", "");
                    string[] tmp_names = str_names.Split(',');
                    foreach (string s in tmp_names)
                    {
                        l_names.Add(s);
                    }
                }

                XElement values = root.Descendants("Value").First();

                if (values != null)
                {
                    string str_values = values.Value.Replace("[", "").Replace("]", "");
                    string[] tmp_values = str_values.Split(',');
                    foreach (string s in tmp_values)
                    {
                        l_values.Add(s);
                    }
                }

                for (int i = 0; i < l_names.Count; i++)
                {
                    ht_data.Add(l_names[i], l_values[i]);
                }

                XElement time = xd.Descendants(C_DataTime).First();
                ht_data.Add(C_DataTime, time.Value);

                XElement cm = xd.Descendants(C_CMLabel).First();
                ht_data.Add(C_CMLabel, cm.Value);

                if (ht_data != null)
                {
                    //WS5401,5401050102,7.20,1,2011-03-23 16:45:00
                    foreach (object obj in ht_datatype.Keys)
                    {
                        try
                        {
                            if (ht_data.Contains(obj.ToString()))
                            {
                                StringBuilder sb = new StringBuilder();
                                sb.Append("ZS");
                                sb.Append(C_Port + ",");
                                sb.Append(C_Port + ht_cmtype[ht_data[C_CMLabel]] + ht_datatype[obj.ToString()] + ",");
                                sb.Append(ht_data[obj.ToString()] + ",");
                                sb.Append(C_UpdateState + ",");
                                sb.Append(GetDataTimeStr(ht_data[C_DataTime].ToString()));
                                l_returnstr.Add(sb.ToString());

                            }
                           
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    //补上状态位为2的语句
                    string[] ss = l_returnstr.ToArray();
                    foreach (string tmps in ss)
                    {
                        string[] t = tmps.Split(',');
                        if (t[3] == "1")
                            t[3] = "2";
                        string newstr = "";
                        for (int i = 0; i < t.Length; i++)
                        {
                            newstr += t[i] + ",";
                        }
                        newstr = newstr.Remove(newstr.Length - 1);
                        l_returnstr.Add(newstr);
                    }

                    //##0080Leq=10;SO2=10;NO2=10;PM10=10&&@@
                    StringBuilder rsb = new StringBuilder();
                    rsb.Append("Leq=" + ht_data["Leq"].ToString() + ";");
                    foreach (string tag in ht_api.Keys)
                    {
                        ApiClass ac = ht_api[tag] as ApiClass;
                        string[] tagname = {ac.TagName};
                        tmp_ds = rhc.reqHisBaseData(tagname, DateTime.Now.AddDays(-1), DateTime.Now);
                        if (tmp_ds != null && tmp_ds.Tables[0].Rows.Count > 0)
                        {
                            ac.TagValue = tmp_ds.Tables[0].Rows[tmp_ds.Tables[0].Rows.Count - 1][1].ToString() ;
                        }
                        rsb.Append(ac.TagType + "=" + ac.TagValue + ";");
                    }
                    rsb.Remove(rsb.Length - 1, 1);
                    string l = rsb.Length.ToString().PadLeft(4,'0');
                    l_callbackstr.Add("##" + l + rsb + "@@");
                }
            }
            catch
            {
                return;
            }
        }

        private string[] ReadDic()
        {
            List<string> l_result = new List<string>();
            if (ht_data != null)
            {
                //WS5401,5401050102,7.20,1,2011-03-23 16:45:00
                foreach (object obj in ht_datatype.Keys)
                {
                    try
                    {
                        if (ht_data.Contains(obj.ToString()))
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("ZS");
                            sb.Append(C_Port + ",");
                            sb.Append(C_Port + ht_cmtype[ht_data[C_CMLabel]] + ht_datatype[obj.ToString()] + ",");
                            sb.Append(ht_data[obj.ToString()] + ",");
                            sb.Append(C_UpdateState + ",");
                            sb.Append(GetDataTimeStr(ht_data[C_DataTime].ToString()));
                            l_result.Add(sb.ToString());
                        }
                    }
                    catch 
                    {
                        continue;
                    }
                }

            }

            //应答报文 2011-04-12 by 俞楠
            //l_result.Insert(0, "Received");
            return l_result.ToArray();
        }

        private string GetDataTimeStr(string timestr)
        {
            string newstr = timestr;
            newstr = newstr.Substring(1);
            newstr = newstr.Substring(0, newstr.Length - 4);
            newstr = newstr.Insert(12, ":");
            newstr = newstr.Insert(10, ":");
            newstr = newstr.Insert(8, " ");
            newstr = newstr.Insert(6, "-");
            newstr = newstr.Insert(4, "-");
            return newstr;
        }

        public string[] GetWebStr(ref string sourcedata)
        {
            ReadPack(ref sourcedata);

            return l_returnstr.ToArray();
        }


        public string[] GetCallBackStr()
        {
            return l_callbackstr.ToArray();
        }

      
    }


    /*
     * 1 进出库电文
     *##01yyyyMMddHHmmss；L1-1,L2-0,L3-2\r\n
     *##功能号时间；标签-进出标记包尾
     *L1 进 L2 出 L3 重叠 不能判断

     *2 辐射监测数值电文
     *##02yyyyMMddHHmmss；L1，L2，L3（固定则为999999）；VFVal；JD;WD（固定则为0，0）;dc\r\n
     *##功能号时间；标签；辐射监测值；经纬度包尾

     *3 反馈电文
     *##01yyyyMMddHHmmss\r\n
     **/
    public class BaoShanFS : PackDeal
    {
       
        private string s_config = Application.StartupPath + "\\config.xml";//配置文件地址
        private string C_HeaderChar = "";//报头
        private string C_EndChar = "";//报尾
        private string C_Port = "";//端口号
        private string C_SiteName = "";//站点名称
        private List<string> l_returnstr = new List<string>();
        private List<string> l_callbackstr = new List<string>();
        private FSService.ServiceClient _FSUObj = new FSService.ServiceClient();//辐射上传接口

        public BaoShanFS(string port, string sitename)
        {
            C_Port = port;
            C_SiteName = sitename;
            IniProtocols();
        }

        private void IniProtocols()
        {
            XDocument xd = XDocument.Load(s_config);
            XElement Root = xd.Descendants("BaoShanFS").First();
       
            C_HeaderChar = Root.Descendants("Pack").First().Attribute("Header").Value;//获取报头
            C_EndChar = Root.Descendants("Pack").First().Attribute("Ender").Value;//获取报尾
        }

        /// <summary>
        /// 读取报文 判断报文完整性
        /// </summary>
        /// <param name="sourcedata"></param>
        private void ReadPack(ref string sourcedata)
        {
            string s_getdata = sourcedata;
            int i_headerindex = s_getdata.IndexOf(C_HeaderChar);//找报头
            if (i_headerindex > -1)
            {
                s_getdata = s_getdata.Substring(i_headerindex);//截取报头后的报文
            }
            else
            {
                sourcedata = "";//未找到报头则丢弃
                return;
            }

            int i_enderindex = s_getdata.IndexOf(C_EndChar);//找报尾

            if (i_enderindex > -1)
            {
                //获取一条完整的报文
                s_getdata = s_getdata.Substring(0, i_enderindex + C_EndChar.Length);
                this.AnalyPack(s_getdata);//解析电文
                //获取剩余的电文
                sourcedata = sourcedata.Substring(s_getdata.Length);
                //递归判断
                ReadPack(ref sourcedata);
            }
            else
            {
                sourcedata = s_getdata;
                return;
            }

        }

        private void AnalyPack(string Datastr)
        {
            try
            {
                string packStr = Datastr.Replace(C_HeaderChar, "").Replace(C_EndChar, "");
                string funCode = packStr.Substring(0, 2);
                packStr = packStr.Substring(2);
                string[] subPack = packStr.Split(';');

                //获取时间
                string dateStr = this.GetDataTimeStr(subPack[0]);
                DateTime dt = Convert.ToDateTime(dateStr);

                int opResult = 9999;
                switch (funCode)
                {
                    case "01"://获取进出库电文
                        opResult = _FSUObj.UpLoadStoreInfo(C_SiteName,dt,subPack[1].Split(','));
                        break;

                    case "02"://获取监测数据电文
                        opResult = _FSUObj.UpLoadFSData(C_SiteName, dt, subPack[1], double.Parse(subPack[2]), double.Parse(subPack[3]), double.Parse(subPack[4]), double.Parse(subPack[5]));
                        break;

                    default:
                        break;
                }

                l_returnstr.Add(opResult.ToString());
            }
            catch
            {
                return;
            }
        }

        private string GetDataTimeStr(string timestr)
        {
            string newstr = timestr;
            //newstr = newstr.Substring(1);
            //newstr = newstr.Substring(0, newstr.Length - 4);
            newstr = newstr.Insert(12, ":");
            newstr = newstr.Insert(10, ":");
            newstr = newstr.Insert(8, " ");
            newstr = newstr.Insert(6, "-");
            newstr = newstr.Insert(4, "-");
            return newstr;
        }

        public string[] GetWebStr(ref string sourcedata)
        {
            ReadPack(ref sourcedata);
            return l_returnstr.ToArray();
        }

        public string[] GetCallBackStr()
        {
            return l_callbackstr.ToArray();
        }

      
    }

    /// <summary>
    /// 212协议
    /// </summary>
    public class GB212 : PackDeal
    {

        public string[] GetWebStr(ref string sourcedata)
        {
            throw new NotImplementedException();
        }

        public string[] GetCallBackStr()
        {
            throw new NotImplementedException();
        }

        private string GetDataTimeStr(string timestr)
        {
            string newstr = timestr;
            //newstr = newstr.Substring(1);
            //newstr = newstr.Substring(0, newstr.Length - 4);
            newstr = newstr.Insert(12, ":");
            newstr = newstr.Insert(10, ":");
            newstr = newstr.Insert(8, " ");
            newstr = newstr.Insert(6, "-");
            newstr = newstr.Insert(4, "-");
            return newstr;
        }
    }
}
