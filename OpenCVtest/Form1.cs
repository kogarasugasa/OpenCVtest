using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;


namespace OpenCVtest
{
    public partial class Form1 : Form
    {
        private string picturePath1;
        private string picturePath2;
        private bool isPreview = false;
        private Timer captureTimer = new Timer();
        VideoCapture camera = null;
        private Mat frame = null;
        Graphics graphic;
        Bitmap bmp;

        public Form1()
        {
            InitializeComponent();

            BorderLineTextBox1.Text = "0.9";
            PictureTextBox1.Text = @"C:\作業\A001.jpg";
            PictureTextBox2.Text = @"C:\作業\A002.jpg";

            //captureTimer.Tick += new EventHandler(this.Capture);
            //captureTimer.Interval = 200;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isPreview)
            {
                CaptureStop();
                isPreview = false;
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void StdButton1_Click(object sender, EventArgs e)
        {
            GetPicturePath(ref picturePath1,ref picturePath2);

            using (Mat mat = new Mat(picturePath1))
            {
                Cv2.ImShow("sample_show", mat);
            }

        }

        private void GrayButton1_Click(object sender, EventArgs e)
        {
            using (Mat mat = new Mat(@"C:\作業\A001.jpg"))
            using (Mat matGray = mat.CvtColor(ColorConversionCodes.BGR2GRAY))
            {
                Cv2.ImShow("grayscale_show", matGray);

                //画像を保存
                Cv2.ImWrite(@"C:\作業\B001.jpg", mat);

                //画像の切り欠き保存
                var mat2 = mat.Clone(new Rect(100, 100, 200, 150));
                Cv2.ImWrite(@"C:\作業\C001.jpg", mat2);
            }
        }

        private void MatchButton1_Click(object sender, EventArgs e)
        {
            GetPicturePath(ref picturePath1, ref picturePath2);

            //検索対象の画像とテンプレートが画像
            using (Mat mat = new Mat(picturePath1))
            using (Mat temp = new Mat(picturePath2))
            using (Mat result = new Mat())
            {
                //テンプレートマッチ
                Cv2.MatchTemplate(mat, temp, result, TemplateMatchModes.CCoeffNormed);

                //類似度が最大/最小となる画素の位置を調べる
                OpenCvSharp.Point minloc, maxloc;
                double minval, maxval;
                Cv2.MinMaxLoc(result, out minval, out maxval, out minloc, out maxloc);

                //閾値で判断
                double threshold;
                double.TryParse(BorderLineTextBox1.Text, out threshold);
                if (threshold <= 0)
                {
                    threshold = 0.9;
                }

                if (maxval >= threshold)
                {
                    //最も見つかった場所に赤枠を表示
                    Rect rect = new Rect(maxloc.X, maxloc.Y, temp.Width, temp.Height);
                    Cv2.Rectangle(mat, rect, new OpenCvSharp.Scalar(0, 0, 255), 2);

                    //ウィンドウに画像を表示
                    Cv2.ImShow("template1_show", mat);
                }
                else
                {
                    //見つからない
                    MessageBox.Show("見つかりませんでした");
                }

            }
        }

        private void MatchButton2_Click(object sender, EventArgs e)
        {
            GetPicturePath(ref picturePath1, ref picturePath2);

            // 検索対象の画像とテンプレート画像
            using (Mat mat = new Mat(picturePath1))
            using (Mat temp = new Mat(picturePath2))
            using (Mat result = new Mat())
            {

                // テンプレートマッチ
                Cv2.MatchTemplate(mat, temp, result, TemplateMatchModes.CCoeffNormed);

                // しきい値の範囲に絞る
                Cv2.Threshold(result, result, 0.8, 1.0, ThresholdTypes.Tozero);

                while (true)
                {
                    // 類似度が最大/最小となる画素の位置を調べる
                    OpenCvSharp.Point minloc, maxloc;
                    double minval, maxval;
                    Cv2.MinMaxLoc(result, out minval, out maxval, out minloc, out maxloc);

                    var threshold = 0.8;
                    if (maxval >= threshold)
                    {

                        // 見つかった場所に赤枠を表示
                        Rect rect = new Rect(maxloc.X, maxloc.Y, temp.Width, temp.Height);
                        Cv2.Rectangle(mat, rect, new OpenCvSharp.Scalar(0, 0, 255), 2);

                        // 見つかった箇所は塗りつぶす
                        Rect outRect;
                        Cv2.FloodFill(result, maxloc, new OpenCvSharp.Scalar(0), out outRect, new OpenCvSharp.Scalar(0.1),
                                    new OpenCvSharp.Scalar(1.0), FloodFillFlags.Link4);

                    }
                    else
                    {
                        break;
                    }
                }

                // ウィンドウに画像を表示
                Cv2.ImShow("template2_show", mat);
            }
        }

        private void CaptureButton1_Click(object sender, EventArgs e)
        {
            
            if (isPreview)
            {
                //captureTimer.Stop();
                CaptureStop();
                isPreview = false;
            }
            else
            {
                //captureTimer.Start();
                CaptureStart();
                isPreview = true;
            }
        }

        public void CaptureStart()
        {
            //カメラ画像取得用のVideoCapture作成
            camera = new VideoCapture(1);
            if (!camera.IsOpened())
            {
                MessageBox.Show("cannot open camera");
                this.Close();
            }
            int width = 720;
            int height = 405;
            camera.FrameWidth = width;
            camera.FrameHeight = height;

            //取得先のMat作成
            frame = new Mat(height, width, MatType.CV_8UC3);

            ////表示用のBitmap作成
            //bmp = new Bitmap(frame.Cols, frame.Rows, (int)frame.Step(), System.Drawing.Imaging.PixelFormat.Format24bppRgb, frame.Data);

            //PictureBoxを出力サイズに合わせる
            pictureBox1.Width = frame.Cols;
            pictureBox1.Height = frame.Rows;

            //画像取得スレッド開始
            backgroundWorker1.RunWorkerAsync();
        }
        private void CaptureStop()
        {
            Cv2.ImWrite(@"Z001.jpg", frame);
            //スレッドの終了を待機
            backgroundWorker1.CancelAsync();
            while (backgroundWorker1.IsBusy)
            {
                Application.DoEvents();
            }
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = (BackgroundWorker)sender;

            while (!backgroundWorker1.CancellationPending)
            {
                //画像取得
                camera.Read(frame);
                Task.Delay(3500);
                bw.ReportProgress(0);
            }
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //描画
            //graphic.DrawImage(bmp, 0, 0, frame.Cols, frame.Rows);
            TemprateMatch(frame);
            Image dispImage;            

            using (Mat resizeFrame = new Mat())
            {
                Cv2.Resize(frame, resizeFrame, new OpenCvSharp.Size(720, 405));
                dispImage = BitmapConverter.ToBitmap(resizeFrame);
            }

            Image oldImage = pictureBox1.Image;

            pictureBox1.Image = dispImage;
            if (oldImage != null)
            {
                oldImage.Dispose();
            }

        }
        private void GetPicturePath(ref string filePath1, ref string filePath2)
        {
            filePath1 = PictureTextBox1.Text;
            filePath2 = PictureTextBox2.Text;
        }

        private bool TemprateMatch(Mat mat)
        {
            GetPicturePath(ref picturePath1, ref picturePath2);

            //検索対象の画像とテンプレートが画像
            using (Mat temp = new Mat(picturePath2))
            using (Mat result = new Mat())
            {
                //テンプレートマッチ
                Cv2.MatchTemplate(mat, temp, result, TemplateMatchModes.CCoeffNormed);

                //類似度が最大/最小となる画素の位置を調べる
                OpenCvSharp.Point minloc, maxloc;
                double minval, maxval;
                Cv2.MinMaxLoc(result, out minval, out maxval, out minloc, out maxloc);

                //閾値で判断
                double threshold;
                double.TryParse(BorderLineTextBox1.Text, out threshold);
                if (threshold <= 0)
                {
                    threshold = 0.9;
                }

                if (maxval >= threshold)
                {
                    //最も見つかった場所に赤枠を表示
                    Rect rect = new Rect(maxloc.X, maxloc.Y, temp.Width, temp.Height);
                    Cv2.Rectangle(mat, rect, new OpenCvSharp.Scalar(0, 0, 255), 2);

                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        
    }
}
