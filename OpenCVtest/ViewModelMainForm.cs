using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.IO;
using System.Windows;
using System.Diagnostics;
using System.ComponentModel;
using FormsMvvm;
using System.Drawing;



namespace OpenCVtest
{
    public class ViewModelMainForm : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public PropertySetter PropertySetter { get; private set; }
        #endregion

        
        
        private Mat videoFrame = null;

        private string searchRangePictPath;
        public string SearchRangePictPath
        {
            get => searchRangePictPath;
            set => PropertySetter.Set(ref searchRangePictPath, value);
        }

        private string targetPictPath;
        public string TargetPictPath
        {
            get => targetPictPath;
            set => PropertySetter.Set(ref targetPictPath, value);
        }

        private Image dispImage = null;
        public Image DispImage
        {
            get => dispImage;
            set => PropertySetter.Set(ref dispImage, value);
        }
        public Mat VideoFrame
        {
            get => videoFrame;
            set => PropertySetter.Set(ref videoFrame, value);
        }
        

        public ViewModelMainForm()
        {
            PropertySetter = new PropertySetter(this, OnPropertyChanged);
        }
        ~ViewModelMainForm()
        {

        }

    }
}
