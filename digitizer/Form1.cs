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
    public partial class Form1 : Form
    {

        // 画像処理に関する変数
        string fileName;
        public Image _bmp;
        float k_pic = 1F;
        float picX = 0F;
        float picY = 0F;
        float startX = 0;
        float startY = 0;
        bool flg_picFix = false;
        double d = 0;

        // 基準となる座標を保存する変数
        Point[] pXX_rotate = new Point[2];
        Point[] pXX = new Point[2];
        Point[] pYY = new Point[2];
        double[] value_X = new double[2];
        double[] value_Y = new double[2];

        // 性能曲線から読み取った点を保存するための変数（フォーム座標）
        List<Point> pXY_form = new List<Point>();
        List<List<Point>> pXY_form_Vec = new List<List<Point>>();

        // 性能曲線から読み取った点を保存するための変数（性能曲線上の座標）
        double[] tmpXY = new double[2];
        List<double[]> pXY = new List<double[]>();
        List<List<double[]>> pXY_Vec = new List<List<double[]>>();

        // 各y軸の名称を保存する変数
        String xName_Vec;
        List<String> yName_Vec = new List<string>();

        // 作業過程を示すフラグ
        bool[] flag_rotate = new bool[2];
        bool[] flag_pX = new bool[4];  // 初期値はfalse
        bool[] flag_pY = new bool[4];  // 初期値はfalse


        int num = 0;

        DialogResult r1;
        DialogResult r2;

        // 色ベクトル
        string[] colorVec = new string[2] { "Blue", "Red" };

        //フォントオブジェクトの作成
        Font fnt = new Font("MS UI Gothic", 8);


        public Form1()
        {
            InitializeComponent();
        }

        // [確定]ボタンを押したら…
        private void btn_fix_Click(object sender, EventArgs e)
        {
            flg_picFix = true;
            tsbtn_large.Enabled = false;
            tsbtn_small.Enabled = false;
            tsbtn_rotate.Enabled = false;
            tsbtn_fix.Enabled = false;

            messageAdd(">> 図が固定されました．");
            messageAdd(">> ");

            // フォームサイズ変更不可にする．
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // メッセージボックスの表示
            MessageBox.Show("軸の設定を行います．", "軸の設定開始",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            messageAdd(">> ******* X軸の設定 *******");
            messageAdd(">> ");


            // x軸の名称を問う．                    
            MessageBox.Show("X軸の名称を入力してください．", "軸の名称",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            messageAdd(">> X軸の名称を入力してください．");

            input_name nameX = new input_name();
            nameX.ShowDialog();
            xName_Vec = nameX.getdata();

            messageAdd(">> X軸の名称: " + xName_Vec);
            messageAdd(">> ");


            MessageBox.Show("X軸上の一点をクリックしてください．", "X軸の設定(1)",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            messageAdd(">> X軸上の一点をクリックしてください．");

            flag_pX[0] = true;

        }

        // PictureBox上でクリックされたら…
        private void PicBox_Click(object sender, EventArgs e)
        {

            // pictureBox上でクリックされた場合，座標を返す．
            Point mp = Control.MousePosition;
            // ContextMenuを表示しているコントロールのクライアント座標に変換
            Point cp = PicBox.PointToClient(mp);

            Graphics gp = PicBox.CreateGraphics();

            if (flg_picFix == true)
            {

                // どのフラグが立っているかで，座標を保存する変数を変える．
                if (flag_pX[0])
                {

                    // 点を描く
                    gp.FillEllipse(Brushes.Blue, cp.X - 5, cp.Y - 5, 10, 10);

                    // 値を問う
                    input_data id_pX1 = new input_data();
                    id_pX1.ShowDialog();
                    value_X[0] = double.Parse(id_pX1.getdata());

                    // 値を記述
                    gp.DrawString("X1=" + value_X[0].ToString(), fnt, Brushes.Blue, cp.X + 10, cp.Y - 10);
                    gp.Dispose();

                    // 座標を読み取って保存
                    pXX[0] = cp;

                    messageAdd(">> X軸上の値(1): " + value_X[0].ToString());

                    // 次の処理へ
                    MessageBox.Show("X軸上のもう一点をクリックしてください．", "X軸の設定(2)",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                    messageAdd(">> X軸上のもう一点をクリックしてください．");

                    flag_pX[0] = false;
                    flag_pX[1] = true;

                }
                else if (flag_pX[1])
                {

                    // 点を描く
                    gp.FillEllipse(Brushes.Blue, cp.X - 5, cp.Y - 5, 10, 10);

                    // 値を問う
                    input_data id_pX2 = new input_data();
                    id_pX2.ShowDialog();
                    value_X[1] = double.Parse(id_pX2.getdata());

                    // 値を記述
                    gp.DrawString("X2=" + value_X[1].ToString(), fnt, Brushes.Blue, cp.X + 10, cp.Y - 10);
                    gp.Dispose();

                    // 座標を読み取って保存
                    pXX[1] = cp;

                    messageAdd(">> X軸上の値(2): " + value_X[1].ToString());
                    messageAdd(">> ");


                    // 次の処理へ
                    MessageBox.Show("Y" + (pXY_Vec.Count + 1).ToString() + "軸の設定を行います．", "軸の設定",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                    messageAdd(">> ******* Y" + (pXY_Vec.Count + 1).ToString() + "軸の設定 *******");
                    messageAdd(">> ");


                    // y軸の名称を問う．                    
                    MessageBox.Show("Y" + (pXY_Vec.Count + 1).ToString() + "軸の名称を入力してください．", "軸の名称",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    messageAdd(">> Y" + (pXY_Vec.Count + 1).ToString() + "軸の名称を入力してください．");

                    input_name nameY = new input_name();
                    nameY.ShowDialog();
                    yName_Vec.Add(nameY.getdata());

                    messageAdd(">> y" + (pXY_Vec.Count + 1).ToString() + "軸の名称: " + yName_Vec[yName_Vec.Count - 1]);
                    messageAdd(">> ");


                    MessageBox.Show("Y" + (pXY_Vec.Count + 1).ToString() + "軸上の一点をクリックしてください．",
                        "Y" + (pXY_Vec.Count + 1).ToString() + "軸の設定(1)", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    messageAdd(">> Y" + (pXY_Vec.Count + 1).ToString() + "軸上の一点をクリックしてください．");

                    flag_pX[1] = false;
                    flag_pY[0] = true;

                }
                else if (flag_pY[0])
                {
                    gp.FillEllipse(Brushes.Red, cp.X - 5, cp.Y - 5, 10, 10);

                    // 値を問う
                    input_data id_pY1 = new input_data();
                    id_pY1.ShowDialog();
                    value_Y[0] = double.Parse(id_pY1.getdata());

                    gp.DrawString("Y" + (pXY_Vec.Count + 1).ToString() + "1=" +
                        value_Y[0].ToString(), fnt, Brushes.Red, cp.X + 10, cp.Y - 10);
                    gp.Dispose();

                    // 座標を読み取って保存
                    pYY[0] = cp;

                    messageAdd(">> Y" + (pXY_Vec.Count + 1).ToString() + "軸上の値(1): " + value_Y[0].ToString());

                    // 次の処理へ
                    MessageBox.Show("Y" + (pXY_Vec.Count + 1).ToString() + "軸上のもう一点をクリックしてください．",
                        "Y" + (pXY_Vec.Count + 1).ToString() + "軸の設定(2)", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    messageAdd(">> Y" + (pXY_Vec.Count + 1).ToString() + "軸上のもう一点をクリックしてください．");

                    flag_pY[0] = false;
                    flag_pY[1] = true;

                }
                else if (flag_pY[1])
                {
                    gp.FillEllipse(Brushes.Red, cp.X - 5, cp.Y - 5, 10, 10);

                    // 値を問う
                    input_data id_pY2 = new input_data();
                    id_pY2.ShowDialog();
                    value_Y[1] = double.Parse(id_pY2.getdata());

                    gp.DrawString("Y" + (pXY_Vec.Count + 1).ToString() + "=" +
                        value_Y[1].ToString(), fnt, Brushes.Red, cp.X + 10, cp.Y - 10);
                    gp.Dispose();

                    // 座標を読み取って保存
                    pYY[1] = cp;

                    messageAdd(">> Y" + (pXY_Vec.Count + 1).ToString() + "軸上の値(2): " + value_Y[1].ToString());

                    // 次の処理へ
                    MessageBox.Show("Y" + (pXY_Vec.Count + 1).ToString() + "軸の設定が終わりました．",
                        "Y" + (pXY_Vec.Count + 1).ToString() + "軸の設定(3)", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MessageBox.Show("Y" + (pXY_Vec.Count + 1).ToString() + "の曲線上の値をクリックしてください．",
                        "Y" + (pXY_Vec.Count + 1).ToString() + "軸の読み取り", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    statusLabel.Text = "Y" + (pXY_Vec.Count + 1).ToString() +
                        "の曲線上の値をクリックしてください．読み取りを終わる場合は[読み取り終了]ボタンを押してください．";

                    messageAdd(">> Y" + (pXY_Vec.Count + 1).ToString() + "の曲線上を複数点クリックしてください．");
                    messageAdd(">> ---- Y" + (pXY_Vec.Count + 1).ToString() + "のデータ ----");

                    flag_pY[1] = false;
                    flag_pY[2] = true;

                    pXY_form.Clear();
                    pXY.Clear();

                }
                else if (flag_pY[2])
                {

                    // 点を描く
                    gp.FillEllipse(Brushes.Red, cp.X - 3, cp.Y - 3, 6, 6);
                    gp.Dispose();

                    // 座標変換
                    tmpXY[0] = ((value_X[0] - value_X[1]) / (pXX[0].X - pXX[1].X)) * (cp.X - pXX[0].X) + value_X[0];
                    tmpXY[1] = ((value_Y[0] - value_Y[1]) / (pYY[0].Y - pYY[1].Y)) * (cp.Y - pYY[0].Y) + value_Y[0];

                    // メッセージウィンドに値を表示
                    messageAdd("" + tmpXY[0].ToString("F3") + "," + tmpXY[1].ToString("F3") + "");

                    // 座標を保存        
                    pXY_form.Add(new Point(cp.X, cp.Y));
                    pXY.Add(new double[2] { tmpXY[0], tmpXY[1] });

                    tsbtn_finish.Enabled = true;
                    flag_pY[3] = true;

                }

            }
            else
            {
                if (flag_rotate[0])
                {
                    // 点を描く
                    gp.FillEllipse(Brushes.CornflowerBlue, cp.X - 5, cp.Y - 5, 10, 10);

                    pXX_rotate[0] = cp;

                    // 次の処理へ
                    MessageBox.Show("X軸上のもう一点をクリックしてください．", "軸の回転",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                    messageAdd(">> X軸上のもう一点をクリックしてください．");

                    flag_rotate[0] = false;
                    flag_rotate[1] = true;

                }
                else if (flag_rotate[1])
                {
                    // 点を描く
                    gp.FillEllipse(Brushes.CornflowerBlue, cp.X - 5, cp.Y - 5, 10, 10);

                    pXX_rotate[1] = cp;

                    // 回転処理
                    d = d + (-1)*Math.Atan(((double)pXX_rotate[1].Y - (double)pXX_rotate[0].Y) / ((double)pXX_rotate[1].X - (double)pXX_rotate[0].X));
                    // 図を更新
                    PicBox.Invalidate();

                    messageAdd(">> 図を回転しました．");
                    messageAdd(">> ");

                    flag_rotate[1] = false;

                }

            }
        }

        // 読み取り終了ボタン
        private void btn_finish_Click(object sender, EventArgs e)
        {

            statusLabel.Text = null;

            if (flag_pY[3])
            {

                MessageBox.Show("Y" + (pXY_Vec.Count + 1).ToString() + "軸の読み取りが終わりました．",
                    "Y" + (pXY_Vec.Count + 1).ToString() + "軸の読み取り終了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                messageAdd(">> ------------------");
                messageAdd(">> Y" + (pXY_Vec.Count + 1).ToString() + "の読み取り終了");

                Graphics gp = PicBox.CreateGraphics();

                // 色の変更
                foreach (Point po in pXY_form)
                {
                    gp.FillEllipse(Brushes.SeaGreen, (float)(po.X - 3), (float)(po.Y - 3), 6, 6);
                }


                // 値の保存
                pXY_form_Vec.Add(new List<Point>(pXY_form));
                pXY_Vec.Add(new List<double[]>(pXY));

                flag_pY[2] = false;
                flag_pY[3] = false;
                tsbtn_finish.Enabled = false;


                // 更に読み取りを行うかを問う．
                r1 = MessageBox.Show("さらに読み取りを行いますか？", "Y軸の追加", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r1 == DialogResult.Yes)
                {

                    MessageBox.Show("Y" + (pXY_Vec.Count + 1).ToString() + "軸の名称を入力してください．", "軸の名称",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    messageAdd(">> Y" + (pXY_Vec.Count + 1).ToString() + "軸の名称を入力してください．");


                    // 軸の名称
                    input_name nameY = new input_name();
                    nameY.ShowDialog();
                    yName_Vec.Add(nameY.getdata());

                    messageAdd(">> y" + (pXY_Vec.Count + 1).ToString() + "軸の名称: " + yName_Vec[yName_Vec.Count - 1]);
                    messageAdd(">> ");


                    // 軸の設定を改めてするかを問う．
                    r2 = MessageBox.Show("Y軸の設定を改めて行いますか？", "Y軸の追加", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r2 == DialogResult.Yes)
                    {

                        MessageBox.Show("Y" + (pXY_Vec.Count + 1).ToString() + "軸の設定を行います．", "軸の設定",
                             MessageBoxButtons.OK, MessageBoxIcon.Information);

                        messageAdd(">> ");
                        messageAdd(">> ******* Y" + (pXY_Vec.Count + 1).ToString() + "軸の設定 *******");
                        messageAdd(">> ");

                        MessageBox.Show("Y" + (pXY_Vec.Count + 1).ToString() + "軸上の一点をクリックしてください．",
                            "Y" + (pXY_Vec.Count + 1).ToString() + "軸の設定(1)", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        messageAdd(">> Y" + (pXY_Vec.Count + 1).ToString() + "軸上の一点をクリックしてください．");

                        flag_pY[0] = true;

                    }
                    else if (r2 == DialogResult.No)
                    {
                        messageAdd(">> ");
                        messageAdd(">> ******* Y" + (pXY_Vec.Count + 1).ToString() + "軸の設定 *******");
                        messageAdd(">> ");
                        messageAdd(">> 軸の設定を引き継ぎました．");

                        MessageBox.Show("Y" + (pXY_Vec.Count + 1).ToString() + "の曲線上の値をクリックしてください．",
                            "Y" + (pXY_Vec.Count + 1).ToString() + "軸の読み取り", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        statusLabel.Text = "Y" + (pXY_Vec.Count + 1).ToString() +
                            "の曲線上の値をクリックしてください．読み取りを終わる場合は[読み取り終了]ボタンを押してください．";

                        messageAdd(">> Y" + (pXY_Vec.Count + 1).ToString() + "の曲線上を複数点クリックしてください．");
                        messageAdd(">> ---- Y" + (pXY_Vec.Count + 1).ToString() + "のデータ ----");

                        flag_pY[2] = true;
                        pXY_form.Clear();
                        pXY.Clear();

                    }

                }
                else if (r1 == DialogResult.No)
                {
                    MessageBox.Show("読み取りを終了します．\r\n[保存]ボタンを押して，データを保存してください．", "作業終了",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    messageAdd(">> ******* 読み取り終了 *******");

                    tsbtn_save.Enabled = true;
                    //saveToolStripMenuItem.Enabled = true;

                }

            }

        }

        // (pictureBox)座標を読み取り
        private void PicBox_MouseDown(object sender, MouseEventArgs e)
        {
            // マウス座標を更新
            startX = e.X;
            startY = e.Y;
        }

        // (pictureBox)図の表示
        private void btn_fileopen_Click(object sender, EventArgs e)
        {

            openPicFile.Filter = "画像ファイル(*.jpg)|*.jpg";

            // ファイルの読み込み
            if (openPicFile.ShowDialog() == DialogResult.OK)
            {
                fileName = openPicFile.FileName;
                //txt_filename.Text = fileName;
                _bmp = Image.FromFile(fileName);
                PicBox.Invalidate();

                // メッセージ欄にコメントを表示
                messageAdd(">> \" " + fileName + " \" を読み込みました");
                messageAdd(">> [拡大][縮小][回転]ボタンで画像を調整し，[画像を固定]ボタンを押して図を固定して下さい．");

                tsbtn_large.Enabled = true;
                tsbtn_small.Enabled = true;
                tsbtn_rotate.Enabled = true;
                tsbtn_fix.Enabled = true;
                statusLabel.Text = null;
            }

        }

        // (pictureBox)図の拡大
        private void btn_large_Click(object sender, EventArgs e)
        {
            if (flg_picFix == false)
            {
                // 倍率を更新
                k_pic = k_pic + 0.1F;

                // 図を更新
                PicBox.Invalidate();
            }
        }

        // (pictureBox)図の縮小
        private void btn_small_Click(object sender, EventArgs e)
        {
            if (flg_picFix == false)
            {
                // 倍率を更新
                k_pic = k_pic - 0.1F;

                // 図を更新
                PicBox.Invalidate();
            }
        }

        // (pictureBox)図の回転
        private void btn_rotate_Click(object sender, EventArgs e)
        {

            messageAdd(">> ******* 図の回転 *******");

            MessageBox.Show("X軸上の一点を選択してください．", "軸の回転",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            flag_rotate[0] = true;

            messageAdd(">> X軸上の一点を選択してください．");

        }

        // (pictureBox)図の移動
        private void PicBox_MouseMove(object sender, MouseEventArgs e)
        {

            // 図を移動する
            if (e.Button == MouseButtons.Left && flg_picFix == false)
            {
                picX = picX + (e.X - startX);
                picY = picY + (e.Y - startY);
                startX = e.X;
                startY = e.Y;
                PicBox.Invalidate();
            }

        }

        // (pictureBox)ペイントイベント
        private void picBox_Paint(object sender, PaintEventArgs e)
        {

            if (_bmp != null)
            {
                // 図を描画
                float x1 = picX + _bmp.Width * (float)Math.Cos(d) * k_pic;
                float y1 = picY + _bmp.Width * (float)Math.Sin(d) * k_pic;
                float x2 = picX - _bmp.Height * (float)Math.Sin(d) * k_pic;
                float y2 = picY + _bmp.Height * (float)Math.Cos(d) * k_pic;
                
                //PointF配列を作成
                PointF[] destinationPoints = { new PointF(picX, picY), new PointF(x1, y1), new PointF(x2, y2) };
                e.Graphics.DrawImage(_bmp, destinationPoints);


                // 軸の設定を再描画
                if (pXX[0].X != 0 && pXX[0].Y != 0)
                {
                    e.Graphics.FillEllipse(Brushes.Blue, (float)(pXX[0].X - 5), (float)(pXX[0].Y - 5), 10, 10);
                    e.Graphics.DrawString("X1=" + value_X[0].ToString(), fnt, Brushes.Blue, (float)(pXX[0].X + 10), (float)(pXX[0].Y - 10));
                }
                if (pXX[1].X != 0 && pXX[1].Y != 0)
                {
                    e.Graphics.FillEllipse(Brushes.Blue, (float)(pXX[1].X - 5), (float)(pXX[1].Y - 5), 10, 10);
                    e.Graphics.DrawString("X2=" + value_X[1].ToString(), fnt, Brushes.Blue, (float)(pXX[1].X + 10), (float)(pXX[1].Y - 10));
                }

                if (pYY[0].X != 0 && pYY[0].Y != 0)
                {
                    e.Graphics.FillEllipse(Brushes.Red, (float)(pYY[0].X - 5), (float)(pYY[0].Y - 5), 10, 10);
                    e.Graphics.DrawString("Y1=" + value_Y[0].ToString(), fnt, Brushes.Red, (float)(pYY[0].X + 10), (float)(pYY[0].Y - 10));
                }
                if (pYY[1].X != 0 && pYY[1].Y != 0)
                {
                    e.Graphics.FillEllipse(Brushes.Red, (float)(pYY[1].X - 5), (float)(pYY[1].Y - 5), 10, 10);
                    e.Graphics.DrawString("Y2=" + value_Y[1].ToString(), fnt, Brushes.Red, (float)(pYY[1].X + 10), (float)(pYY[1].Y - 10));
                }

                // プロット点の再描画(現在プロットしている点)
                foreach (Point po in pXY_form)
                {
                    e.Graphics.FillEllipse(Brushes.Red, (float)(po.X - 3), (float)(po.Y - 3), 6, 6);
                }

                foreach (List<Point> poVec in pXY_form_Vec)
                {
                    foreach (Point po in poVec)
                    {
                        e.Graphics.FillEllipse(Brushes.SeaGreen, (float)(po.X - 3), (float)(po.Y - 3), 6, 6);
                    }

                }

            }

        }

        // コメントの表示
        private void messageAdd(string msg)
        {
            tb_message.Text += System.Environment.NewLine;
            tb_message.Text += msg;
            tb_message.SelectionStart = tb_message.Text.Length;
            tb_message.Focus();
            tb_message.ScrollToCaret();
        }

        // 終了
        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // 保存
        private void btn_save_Click(object sender, EventArgs e)
        {

            saveFileDialog1.Filter = "csvファイル (*.csv)|*.csv";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                System.IO.StreamWriter writer = new System.IO.StreamWriter
                (saveFileDialog1.FileName, true, Encoding.Default);


                // 名称の出力
                for (int i = 0; i < yName_Vec.Count; i++)
                {
                    if (i == yName_Vec.Count - 1)
                    {
                        writer.WriteLine(xName_Vec + "," + yName_Vec[i]);
                    }
                    else
                    {
                        writer.Write(xName_Vec + "," + yName_Vec[i] + ",");
                    }
                }
                             
                // 何行吐き出すか
                for (int i = 0; i < pXY_Vec.Count; i++)
                {
                    num = Math.Max(num, pXY_Vec[i].Count);                   
                }                


                for (int i = 0; i < num; i++)
                {
                    for (int j = 0; j < pXY_Vec.Count; j++ )
                    {
                        if (i < pXY_Vec[j].Count)
                        {
                            if (j == pXY_Vec.Count - 1)
                            {
                                writer.WriteLine(pXY_Vec[j][i][0].ToString() + "," + pXY_Vec[j][i][1].ToString().ToString());
                            }
                            else
                            {
                                writer.Write(pXY_Vec[j][i][0].ToString() + "," + pXY_Vec[j][i][1].ToString().ToString() + ",");
                            }
                            
                        }
                        else
                        {
                            if (j == pXY_Vec.Count - 1)
                            {
                                writer.WriteLine(" ,");
                            }
                            else
                            {
                                writer.Write(" , ,");
                            } 
                        }

                    }

                }

            writer.Close();

            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 閉じる
            e.Cancel = MessageBox.Show("本当に終了しますか？","プログラムの終了",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.bsca.or.jp/index.html");
        }

        private void このプログラムについてToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 help = new Form4();
            help.ShowDialog();
        }


    }
}
