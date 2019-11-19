namespace OpenCVtest
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.StdButton1 = new System.Windows.Forms.Button();
            this.GrayButton1 = new System.Windows.Forms.Button();
            this.MatchButton1 = new System.Windows.Forms.Button();
            this.BorderLineTextBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MatchButton2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.PictureTextBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PictureTextBox2 = new System.Windows.Forms.TextBox();
            this.CaptureButton1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // StdButton1
            // 
            this.StdButton1.Font = new System.Drawing.Font("Meiryo UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.StdButton1.Location = new System.Drawing.Point(40, 30);
            this.StdButton1.Name = "StdButton1";
            this.StdButton1.Size = new System.Drawing.Size(200, 75);
            this.StdButton1.TabIndex = 0;
            this.StdButton1.Text = "基本";
            this.StdButton1.UseVisualStyleBackColor = true;
            this.StdButton1.Click += new System.EventHandler(this.StdButton1_Click);
            // 
            // GrayButton1
            // 
            this.GrayButton1.Font = new System.Drawing.Font("Meiryo UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GrayButton1.Location = new System.Drawing.Point(40, 111);
            this.GrayButton1.Name = "GrayButton1";
            this.GrayButton1.Size = new System.Drawing.Size(200, 75);
            this.GrayButton1.TabIndex = 1;
            this.GrayButton1.Text = "グレースケール";
            this.GrayButton1.UseVisualStyleBackColor = true;
            this.GrayButton1.Click += new System.EventHandler(this.GrayButton1_Click);
            // 
            // MatchButton1
            // 
            this.MatchButton1.Font = new System.Drawing.Font("Meiryo UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MatchButton1.Location = new System.Drawing.Point(40, 192);
            this.MatchButton1.Name = "MatchButton1";
            this.MatchButton1.Size = new System.Drawing.Size(200, 75);
            this.MatchButton1.TabIndex = 2;
            this.MatchButton1.Text = "ﾃﾝﾌﾟﾚｰﾄﾏｯﾁﾝｸﾞ";
            this.MatchButton1.UseVisualStyleBackColor = true;
            this.MatchButton1.Click += new System.EventHandler(this.MatchButton1_Click);
            // 
            // BorderLineTextBox1
            // 
            this.BorderLineTextBox1.Location = new System.Drawing.Point(305, 108);
            this.BorderLineTextBox1.Name = "BorderLineTextBox1";
            this.BorderLineTextBox1.Size = new System.Drawing.Size(50, 25);
            this.BorderLineTextBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(270, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "閾値";
            // 
            // MatchButton2
            // 
            this.MatchButton2.Font = new System.Drawing.Font("Meiryo UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MatchButton2.Location = new System.Drawing.Point(40, 273);
            this.MatchButton2.Name = "MatchButton2";
            this.MatchButton2.Size = new System.Drawing.Size(200, 75);
            this.MatchButton2.TabIndex = 5;
            this.MatchButton2.Text = "ﾃﾝﾌﾟﾚｰﾄﾏｯﾁﾝｸﾞ2";
            this.MatchButton2.UseVisualStyleBackColor = true;
            this.MatchButton2.Click += new System.EventHandler(this.MatchButton2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "検索範囲";
            // 
            // PictureTextBox1
            // 
            this.PictureTextBox1.Location = new System.Drawing.Point(305, 27);
            this.PictureTextBox1.Name = "PictureTextBox1";
            this.PictureTextBox1.Size = new System.Drawing.Size(300, 25);
            this.PictureTextBox1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(246, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "検索画像";
            // 
            // PictureTextBox2
            // 
            this.PictureTextBox2.Location = new System.Drawing.Point(305, 64);
            this.PictureTextBox2.Name = "PictureTextBox2";
            this.PictureTextBox2.Size = new System.Drawing.Size(300, 25);
            this.PictureTextBox2.TabIndex = 9;
            // 
            // CaptureButton1
            // 
            this.CaptureButton1.Font = new System.Drawing.Font("Meiryo UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CaptureButton1.Location = new System.Drawing.Point(40, 354);
            this.CaptureButton1.Name = "CaptureButton1";
            this.CaptureButton1.Size = new System.Drawing.Size(200, 75);
            this.CaptureButton1.TabIndex = 10;
            this.CaptureButton1.Text = "キャプチャ";
            this.CaptureButton1.UseVisualStyleBackColor = true;
            this.CaptureButton1.Click += new System.EventHandler(this.CaptureButton1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(255, 136);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(717, 413);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker1_ProgressChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(665, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(276, 26);
            this.comboBox1.TabIndex = 12;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.CaptureButton1);
            this.Controls.Add(this.PictureTextBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PictureTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MatchButton2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BorderLineTextBox1);
            this.Controls.Add(this.MatchButton1);
            this.Controls.Add(this.GrayButton1);
            this.Controls.Add(this.StdButton1);
            this.Name = "Form1";
            this.Text = "sample_show";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StdButton;
        private System.Windows.Forms.Button StdButton1;
        private System.Windows.Forms.Button GrayButton1;
        private System.Windows.Forms.Button MatchButton1;
        private System.Windows.Forms.TextBox BorderLineTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button MatchButton2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PictureTextBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PictureTextBox2;
        private System.Windows.Forms.Button CaptureButton1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

