// Copyright(c) 2009 Masato MIYATA
// Released under the MIT license
// https://github.com/MasatoMiyata/graph_digitizer/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace digitizer_v3
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
