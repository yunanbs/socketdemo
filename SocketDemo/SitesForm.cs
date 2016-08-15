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
    public partial class SitesForm : Form
    {
        private string _configpath = Application.StartupPath + "/config.xml";//获取配置文件路径
        XDocument xd;

        public SitesForm()
        {
            InitializeComponent();
            SetList();
        }

        public void SetList()
        {
            try
            {
                xd = XDocument.Load(_configpath);
                XElement[] _clientxe = xd.Descendants("Client").ToArray();
                XElement[] _serverxe = xd.Descendants("Server").ToArray();
                XElement[] _comxe = xd.Descendants("Com").ToArray();
                listView1.Items.Clear();

                if (_clientxe.Count() > 0)
                {
                    
                    foreach (XElement xe in _clientxe.First().Elements())
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = xe.Attribute("name").Value.ToString();
                        lvi.SubItems.Add("Client");
                        lvi.SubItems.Add(xe.Attribute("IP").Value.ToString());
                        lvi.SubItems.Add(xe.Attribute("port").Value.ToString());
                        lvi.SubItems.Add(xe.Attribute("baudrate").Value.ToString());
                        lvi.SubItems.Add(xe.Attribute("protocol").Value.ToString());
                        lvi.SubItems.Add(xe.Attribute("heart").Value.ToString());
                        listView1.Items.Add(lvi);
                    }
                }

                if (_serverxe.Count() > 0)
                {
                    foreach (XElement xe in _serverxe.First().Elements())
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = xe.Attribute("name").Value.ToString();
                        lvi.SubItems.Add("Server");
                        lvi.SubItems.Add(xe.Attribute("IP").Value.ToString());
                        lvi.SubItems.Add(xe.Attribute("port").Value.ToString());
                        lvi.SubItems.Add(xe.Attribute("baudrate").Value.ToString());
                        lvi.SubItems.Add(xe.Attribute("protocol").Value.ToString());
                        lvi.SubItems.Add(xe.Attribute("heart").Value.ToString());
                        listView1.Items.Add(lvi);
                    }
                }

                if (_comxe.Count() > 0)
                {
                    foreach (XElement xe in _comxe.First().Elements())
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = xe.Attribute("name").Value.ToString();
                        lvi.SubItems.Add("Com");
                        lvi.SubItems.Add(xe.Attribute("IP").Value.ToString());
                        lvi.SubItems.Add(xe.Attribute("port").Value.ToString());
                        lvi.SubItems.Add(xe.Attribute("baudrate").Value.ToString());
                        lvi.SubItems.Add(xe.Attribute("protocol").Value.ToString());
                        lvi.SubItems.Add(xe.Attribute("heart").Value.ToString());
                        listView1.Items.Add(lvi);
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            EditSite es = new EditSite();
            es.Owner = this;
            es.ShowDialog();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择需要编辑的站点信息");
                return;
            }

            ListViewItem lvi = listView1.SelectedItems[0];

            string sitename = lvi.Text;
            string sitetype = lvi.SubItems[1].Text;
            string ip = lvi.SubItems[2].Text;
            string port = lvi.SubItems[3].Text;
            string baudrate = lvi.SubItems[4].Text;
            string protocol = lvi.SubItems[5].Text;
            string isheart = lvi.SubItems[6].Text;

            EditSite es = new EditSite(sitename, sitetype, ip, port, baudrate, protocol,Convert.ToBoolean(isheart));
            es.Owner = this;
            es.ShowDialog();
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认要删除该站点吗？") == DialogResult.OK)
            {
                ListViewItem lvi = listView1.SelectedItems[0];

                string sitename = lvi.Text;
                string sitetype = lvi.SubItems[1].Text;
                string port = lvi.SubItems[3].Text;

                XElement sitetypexe = xd.Descendants(sitetype).First();
                XElement todel = null;
                foreach (XElement xe in sitetypexe.Elements())
                {
                    if (xe.Attribute("port").Value.ToString() == port)
                    {
                        todel = xe;
                        break;
                    }
                }
                todel.Remove();
                xd.Save(_configpath);
                SetList();

            }
        }
    }

}
