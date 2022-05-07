namespace digitizer_v3
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openPicFile = new System.Windows.Forms.OpenFileDialog();
            this.tb_message = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.PicBox = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtn_open = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtn_large = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_small = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_rotate = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_fix = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtn_finish = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtn_save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtn_help = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openPicFile
            // 
            this.openPicFile.FileName = "性能曲線スキャン画像";
            // 
            // tb_message
            // 
            this.tb_message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_message.Location = new System.Drawing.Point(712, 82);
            this.tb_message.Multiline = true;
            this.tb_message.Name = "tb_message";
            this.tb_message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_message.Size = new System.Drawing.Size(280, 547);
            this.tb_message.TabIndex = 11;
            this.tb_message.TabStop = false;
            this.tb_message.Text = ">> 性能曲線の画像を読み込んでください．";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 641);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(999, 23);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(152, 18);
            this.statusLabel.Text = "画像を読み込んでください";
            // 
            // PicBox
            // 
            this.PicBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PicBox.Location = new System.Drawing.Point(13, 82);
            this.PicBox.Name = "PicBox";
            this.PicBox.Size = new System.Drawing.Size(693, 547);
            this.PicBox.TabIndex = 2;
            this.PicBox.TabStop = false;
            this.PicBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicBox_MouseMove);
            this.PicBox.Click += new System.EventHandler(this.PicBox_Click);
            this.PicBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicBox_MouseDown);
            this.PicBox.Paint += new System.Windows.Forms.PaintEventHandler(this.picBox_Paint);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtn_open,
            this.toolStripSeparator1,
            this.tsbtn_large,
            this.tsbtn_small,
            this.tsbtn_rotate,
            this.tsbtn_fix,
            this.toolStripSeparator3,
            this.tsbtn_finish,
            this.toolStripSeparator4,
            this.tsbtn_save,
            this.toolStripSeparator2,
            this.tsbtn_help});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(999, 79);
            this.toolStrip1.TabIndex = 22;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtn_open
            // 
            this.tsbtn_open.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_open.Image")));
            this.tsbtn_open.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtn_open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_open.Name = "tsbtn_open";
            this.tsbtn_open.Size = new System.Drawing.Size(52, 76);
            this.tsbtn_open.Text = "開く";
            this.tsbtn_open.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtn_open.Click += new System.EventHandler(this.btn_fileopen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 79);
            // 
            // tsbtn_large
            // 
            this.tsbtn_large.Enabled = false;
            this.tsbtn_large.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_large.Image")));
            this.tsbtn_large.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtn_large.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_large.Name = "tsbtn_large";
            this.tsbtn_large.Size = new System.Drawing.Size(52, 76);
            this.tsbtn_large.Text = "拡大";
            this.tsbtn_large.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtn_large.Click += new System.EventHandler(this.btn_large_Click);
            // 
            // tsbtn_small
            // 
            this.tsbtn_small.Enabled = false;
            this.tsbtn_small.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_small.Image")));
            this.tsbtn_small.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtn_small.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_small.Name = "tsbtn_small";
            this.tsbtn_small.Size = new System.Drawing.Size(58, 76);
            this.tsbtn_small.Text = "縮小";
            this.tsbtn_small.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtn_small.Click += new System.EventHandler(this.btn_small_Click);
            // 
            // tsbtn_rotate
            // 
            this.tsbtn_rotate.Enabled = false;
            this.tsbtn_rotate.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_rotate.Image")));
            this.tsbtn_rotate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtn_rotate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_rotate.Name = "tsbtn_rotate";
            this.tsbtn_rotate.Size = new System.Drawing.Size(52, 76);
            this.tsbtn_rotate.Text = "回転";
            this.tsbtn_rotate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtn_rotate.Click += new System.EventHandler(this.btn_rotate_Click);
            // 
            // tsbtn_fix
            // 
            this.tsbtn_fix.Enabled = false;
            this.tsbtn_fix.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_fix.Image")));
            this.tsbtn_fix.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtn_fix.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_fix.Name = "tsbtn_fix";
            this.tsbtn_fix.Size = new System.Drawing.Size(72, 76);
            this.tsbtn_fix.Text = "画像を固定";
            this.tsbtn_fix.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtn_fix.Click += new System.EventHandler(this.btn_fix_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 79);
            // 
            // tsbtn_finish
            // 
            this.tsbtn_finish.Enabled = false;
            this.tsbtn_finish.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_finish.Image")));
            this.tsbtn_finish.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtn_finish.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_finish.Name = "tsbtn_finish";
            this.tsbtn_finish.Size = new System.Drawing.Size(84, 76);
            this.tsbtn_finish.Text = "読み取り終了";
            this.tsbtn_finish.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtn_finish.Click += new System.EventHandler(this.btn_finish_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 79);
            // 
            // tsbtn_save
            // 
            this.tsbtn_save.Enabled = false;
            this.tsbtn_save.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_save.Image")));
            this.tsbtn_save.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtn_save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_save.Name = "tsbtn_save";
            this.tsbtn_save.Size = new System.Drawing.Size(52, 76);
            this.tsbtn_save.Text = "保存";
            this.tsbtn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 79);
            // 
            // tsbtn_help
            // 
            this.tsbtn_help.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_help.Image")));
            this.tsbtn_help.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtn_help.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_help.Name = "tsbtn_help";
            this.tsbtn_help.Size = new System.Drawing.Size(120, 76);
            this.tsbtn_help.Text = "このソフトについて";
            this.tsbtn_help.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtn_help.Click += new System.EventHandler(this.このプログラムについてToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 664);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tb_message);
            this.Controls.Add(this.PicBox);
            this.Name = "Form1";
            this.Text = "graph digitizer v1.2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PicBox;
        private System.Windows.Forms.OpenFileDialog openPicFile;
        private System.Windows.Forms.TextBox tb_message;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtn_open;
        private System.Windows.Forms.ToolStripButton tsbtn_help;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtn_large;
        private System.Windows.Forms.ToolStripButton tsbtn_small;
        private System.Windows.Forms.ToolStripButton tsbtn_rotate;
        private System.Windows.Forms.ToolStripButton tsbtn_fix;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtn_save;
        private System.Windows.Forms.ToolStripButton tsbtn_finish;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}

