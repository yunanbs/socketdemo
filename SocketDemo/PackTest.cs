using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SocketDemo.Lib;

namespace SocketDemo
{
    public partial class PackTest : Form
    {
        public PackTest()
        {
            InitializeComponent();
        }

        private void richTextBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string s = richTextBox1.Text+"\r\n";
            if (s.Length > 0)
            {
                DataDeal dd = new DataDeal();
                string[] b = textBox1.Text.Split(',');
                string[][] r = dd.DealPack(ref s, b[0], b[1], "test");

                if (r[0] != null)
                {
                    foreach (string sub in r[0])
                    {
                        richTextBox2.AppendText(sub + "\r\n");
                    }
                }

                if (r[1] != null)
                {
                    foreach (string sub in r[1])
                    {
                        richTextBox2.AppendText(sub + "\r\n");
                    }
                }
                    
            }
        }
    }
}
