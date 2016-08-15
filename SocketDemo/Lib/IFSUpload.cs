using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocketDemo.Lib
{
    interface IFSUpload
    {
        //上传进出库信息
        int UpLoadStoreInfo(string SiteID,DateTime Date, string[] IDLabels);

        //上传辐射监测信息
        int UpLoadFSData(string SiteID,DateTime Date, string Labels, double VFval, double jd, double wd,double dc);
    }
}
