// Copyright(c) 2009 Masato MIYATA
// Released under the MIT license
// https://opensource.org/licenses/mit-license.php

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
    public partial class input_data : Form
    {
        
        string point;

        public input_data()
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
            return point;

        }

        private void input_data_FormClosing(object sender, FormClosingEventArgs e)
        {
            point = this.value.Text;

            try
            {
                double.Parse(point);

                if (point == "")
                {
                    MessageBox.Show("値を入力してください", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }

            }
            catch
            {
                MessageBox.Show("数値を入力してください", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }


     }
}
