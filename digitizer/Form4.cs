// Copyright(c) 2009 Masato MIYATA
// Released under the MIT license
// https://github.com/MasatoMiyata/graph_digitizer/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace digitizer_v3
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("http://www.bsca.or.jp/index.html");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.bsca.or.jp/index.html");
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
