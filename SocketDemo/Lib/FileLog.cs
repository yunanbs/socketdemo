using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileLog
{
    public class Log
    {
        /// <summary>
        /// 文件日志写入
        /// </summary>
        /// <param name="filefullpath"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static int WriteLog(string filefullpath, string context)
        {
            FileStream fs = null;
            int result = 0;
            StreamWriter sw = null;
            try
            {
                if (!File.Exists(filefullpath))
                {
                    fs = File.Create(filefullpath);
                    fs.Close();
                }
                sw = new StreamWriter(filefullpath, true);
                sw.WriteLine("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "] " + context);
                sw.Close();
                result = 1;
            }
            catch
            {
                result = 0;
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                    sw.Dispose();
                }
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
            }
            return result;

        }


    }
}
