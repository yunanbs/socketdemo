using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;

namespace SocketDemo
{
    public partial class EditSite : Form
    {
        private string _configpath = Application.StartupPath + "/config.xml";//获取配置文件路径
        XDocument xd;
        bool _isnew;
        public EditSite()
        {
            xd = XDocument.Load(_configpath);
            InitializeComponent();
            IniCB();
            _isnew = true;
        }

        public EditSite(string sitename,string sitetype,string ip,string port,string baudrate,string protocol,bool isheart)
        {
            xd = XDocument.Load(_configpath);
            InitializeComponent();
            tb_sitename.Text = sitename;
            tb_sitename.ReadOnly = true;
            cb_sitetype.Text = sitetype;
            cb_sitetype.Enabled = false;
            tb_ip.Text = ip;
            tb_port.Text = port;
            tb_baudrate.Text = baudrate;
            cb_protocol.Text = protocol;
            cb_heart.Checked = isheart;
            IniCB();
            _isnew = false;
        }

        private void IniCB()
        {
            XElement _typexe = xd.Descendants("Sites").First();
            foreach (XElement xe in _typexe.Elements())
            {
                cb_sitetype.Items.Add(xe.Name.ToString());
            }

            XElement _proxe = xd.Descendants("Protocols").First();
            foreach (XElement xe in _proxe.Elements())
            {
                cb_protocol.Items.Add(xe.Name.ToString());
            }
        }

        private void btn_cofirm_Click(object sender, EventArgs e)
        {
            if (_isnew)
            {
                CreateSite();
            }
            else
            {
                UpdatSite();
            }
           
        }

        private void UpdatSite()
        {
            string sitename = tb_sitename.Text;
            string sitetype = cb_sitetype.Text;
            string ip = tb_ip.Text;
            string port = tb_port.Text;
            string baudrate = tb_baudrate.Text;
            string protocol = cb_protocol.Text;
            string isheart = cb_heart.Checked.ToString();

            XElement typexe = xd.Descendants(sitetype).First();
            foreach (XElement xe in typexe.Elements())
            {
                if (xe.Attribute("name").Value == sitename)
                {
                    xe.SetAttributeValue("IP", ip);
                    xe.SetAttributeValue("port", port);
                    xe.SetAttributeValue("baudrate", baudrate);
                    xe.SetAttributeValue("protocol", protocol);
                    xe.SetAttributeValue("heart", isheart);
                    break;
                }
            }
            xd.Save(_configpath);
        }

        private void CreateSite()
        {
            string sitename = tb_sitename.Text;
            string sitetype = cb_sitetype.Text;
            string ip = tb_ip.Text;
            string port = tb_port.Text;
            string baudrate = tb_baudrate.Text;
            string protocol = cb_protocol.Text;
            string isheart = cb_heart.Checked.ToString();

            XElement typexe = xd.Descendants(sitetype).First();

            XElement site = new XElement("Site");
            site.SetAttributeValue("name", sitename);
            site.SetAttributeValue("IP", ip);
            site.SetAttributeValue("port", port);
            site.SetAttributeValue("baudrate", baudrate);
            site.SetAttributeValue("protocol", protocol);
            site.SetAttributeValue("heart", isheart);
            typexe.Add(site);
            xd.Save(_configpath);
        }

        private void EditSite_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.GetType().GetMethod("SetList").Invoke(this.Owner, null);
        }
    }
}
