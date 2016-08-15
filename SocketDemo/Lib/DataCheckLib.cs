using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;


namespace SocketDemo
{
    public class DataCheckLib
    {
        Dictionary<string, DataLimit> dic_Limits = new Dictionary<string, DataLimit>();//限值标准集合

        public DataCheckLib()
        {
            this.IniLimit();
        }

        /// <summary>
        /// 初始化限值集合
        /// </summary>
        private void IniLimit()
        {
            dic_Limits.Add("a21026", this.GetLimitStr("SO2", 0, -0.014, 0.003));
            dic_Limits.Add("a21003", this.GetLimitStr("NO", 0, -0.010, 0.002));
            dic_Limits.Add("a21004", this.GetLimitStr("NO2", 0, -0.010, 0.002));
            dic_Limits.Add("a21002", this.GetLimitStr("NOX", 0, -0.010, 0.002));
            dic_Limits.Add("a21005", this.GetLimitStr("CO", 0, -1, 0.3));
            dic_Limits.Add("a05024", this.GetLimitStr("O3", 0, -0.010, 0.002));
            dic_Limits.Add("a34002", this.GetLimitStr("PM10", 0, -0.005, 0.002));
            dic_Limits.Add("a34050", this.GetLimitStr("PM2.5", 0, -0.005, 0.002));
        }

        /// <summary>
        /// 生成限值对象
        /// </summary>
        /// <param name="typeName"></param>
        /// <param name="hi"></param>
        /// <param name="low"></param>
        /// <param name="stander"></param>
        /// <returns></returns>
        private DataLimit GetLimitStr(string typeName,double hi,double low,double stander)
        {
            DataLimit tmp = new DataLimit();
            tmp.ElementType = typeName;
            tmp.HiLimit = hi;
            tmp.LowLimit = low;
            tmp.StanderVal = stander;
            return tmp;
        }

        /// <summary>
        /// 获取修正值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public double CheckVal(string type, double val)
        {
            double result = val;
            if (dic_Limits.Keys.Contains(type))
            {
                DataLimit limit = dic_Limits[type];
                if (val <= limit.HiLimit && val >= limit.LowLimit)
                {
                    result = limit.StanderVal;
                }
                else if (val < limit.LowLimit)//小于最小值 返回-9999
                {
                    result = -9999;
                }
                return result;
            }
            else//无需判断的因子直接返回
            {
                return result;
            }
        }
    }

    /// <summary>
    /// 限值结构体
    /// </summary>
    public struct DataLimit
    {
        public string ElementType { get; set; }//因子类型
        public double HiLimit { get; set; }//高限
        public double LowLimit { get; set; }//低限
        public double StanderVal { get; set; }//标准值
    }
}
