using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace OpenCVtest
{
    public class ModelMainForm
    {
        private VideoCapture videoCapture = null;
        private bool isPreview = false;
        private Mat frame = null;

        ~ModelMainForm()
        {
            if (isPreview)
            {
                videoCapture.Dispose();
            }
        }
        public void CaptureStart()
        {
            //カメラ画像取得用のVideoCapture作成
            videoCapture = new VideoCapture(1);
            int width = 720;
            int height = 405;
            videoCapture.FrameWidth = width;
            videoCapture.FrameHeight = height;

            //取得先のMat作成
            frame = new Mat(height, width, MatType.CV_8UC3);

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
                videoCapture.Read(frame);
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
    }
}
