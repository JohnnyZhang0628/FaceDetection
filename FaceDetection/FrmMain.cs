using OpenCvSharp;
using OpenCvSharp.Dnn;
using OpenCvSharp.Extensions;
using OpenCvSharp.XFeatures2D;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FaceDetection
{
    public partial class FrmMain : Form
    {
        private bool openCamera = false;
        public FrmMain()
        {
            InitializeComponent();
        }


        private void OnHaarFaceDetection(object sender, EventArgs e)
        {
            openCamera = false;
            var haarCascade = new CascadeClassifier("model/haarcascade_frontalface_alt.xml");
            Run(src => HaarAndLbp(src,haarCascade));
        }

        private void OnLbpFaceDetection(object sender, EventArgs e)
        {
            openCamera = false;
            var lbpCascade = new CascadeClassifier("model/lbpcascade_frontalface.xml");
           
            Run(src => HaarAndLbp(src,lbpCascade));
        }

        private void OnCNNFaceDetection(object sender, EventArgs e)
        {
            openCamera = false;
            Run(src => CNN(src));
        }
        private void Run(Func<Mat, Mat> src)
        {
            openCamera = true;
            VideoCapture capture = new VideoCapture(0);
            using (Mat image = new Mat()) // Frame image buffer
            {
                // When the movie playback reaches end, Mat.data becomes NULL.
                while (openCamera)
                {
                    capture.Read(image); // same as cvQueryFrame
                    if (image.Empty()) break;

                    picCamer.Image = src.Invoke(image).ToBitmap();
                    Cv2.WaitKey(30);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        ///<param name="src"></param>
        /// <param name="cascade"></param>
        /// <returns></returns>
        private Mat HaarAndLbp(Mat src,CascadeClassifier cascade)
        {
          

            using (var gray = new Mat())
            {
                Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);

                // Detect faces
                Rect[] faces = cascade.DetectMultiScale(
                    gray, 1.08, 2, HaarDetectionType.ScaleImage, new OpenCvSharp.Size(30, 30));

                // Render all detected faces
                foreach (Rect face in faces)
                {
                    src.Rectangle(face, Scalar.Red, 2);
                }
            }
            return src;
        }


        private Mat CNN(Mat src)
        {
            const string configFile = "model/deploy.prototxt";
            const string faceModel = "model/res10_300x300_ssd_iter_140000_fp16.caffemodel";

            // Read sample image
            int srcHeight = src.Rows;
            int srcWidth = src.Cols;
            using (var faceNet = CvDnn.ReadNetFromCaffe(configFile, faceModel))
            {
                using (var blob = CvDnn.BlobFromImage(src, 1.0, new OpenCvSharp.Size(300, 300),
                    new Scalar(104, 117, 123), false, false))
                {
                    faceNet.SetInput(blob, "data");

                    using (var detection = faceNet.Forward("detection_out"))
                    {
                        using (var detectionMat = new Mat(detection.Size(2), detection.Size(3), MatType.CV_32F,
                          detection.Ptr(0)))
                        {
                            for (int i = 0; i < detectionMat.Rows; i++)
                            {
                                float confidence = detectionMat.At<float>(i, 2);

                                if (confidence > 0.7)
                                {
                                    int x1 = (int)(detectionMat.At<float>(i, 3) * srcWidth);
                                    int y1 = (int)(detectionMat.At<float>(i, 4) * srcHeight);
                                    int x2 = (int)(detectionMat.At<float>(i, 5) * srcWidth);
                                    int y2 = (int)(detectionMat.At<float>(i, 6) * srcHeight);

                                    Cv2.Rectangle(src, new OpenCvSharp.Point(x1, y1), new OpenCvSharp.Point(x2, y2), new Scalar(0, 255, 0), 2,
                                        LineTypes.Link4);
                                }
                            }

                            return src;
                        }
                    }


                }


            }

        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            openCamera = false;
        }


    }
}
