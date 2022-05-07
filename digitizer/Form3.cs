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
    public partial class input_name : Form
    {
        
        string yName;

        public input_name()
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string getdata()
        {
            return yName;

        }

        private void input_name_FormClosing(object sender, FormClosingEventArgs e)
        {
            yName = this.value.Text;

            try
            {
                if (yName == "")
                {
                    MessageBox.Show("名称を入力してください", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }

            }
            catch
            {
                MessageBox.Show("名称を入力してください", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

     }
}
