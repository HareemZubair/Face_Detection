using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace pakcam
{
    public partial class Form1 : Form
    {
        //Declare Variables to use them in all project
        MCvFont font = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_TRIPLEX, 0.6d,0.6d);
        HaarCascade faceDetected;
        Image<Bgr, Byte> Frame;
        private Capture Camera;
        Image<Gray,byte> result;
        Image<Gray,byte> TrainedFace = null;
        Image<Gray, byte> grayFace = null;
        List<Image<Gray,byte>> trainingImages = new List< Image<Gray,byte>>();
        List<string> labels = new List<string>();
        List<string> Users = new List<string>();
        int Count, NumLabels, t;
        string name, names = null;


        public Form1()
        {
            InitializeComponent();
            //HaarCascade is for Face Detection
            faceDetected = new HaarCascade("haarcascade_frontalface_default.xml");
            try
            {
               string Labelsinfo = File.ReadAllText(Application.StartupPath + "/Faces/Faces.txt");
               string [] Labels = Labelsinfo.Split(',');
                //The first label before , will be the number of saved faces
                NumLabels = Convert.ToInt16(Labels[0]);
                Count = NumLabels;
                string FacesLoad;
                for(int i=1; i < NumLabels + 1; i++)
                {
                    FacesLoad = "faces" + 1 + ".bmp";
                    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/Faces/Faces.txt"));
                    labels.Add(Labels[i]);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Nothing in Database");
            }
        }

        private void cameraBox_Click(object sender, EventArgs e)
        {
           
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            Count = Count + 1;
            grayFace = Camera.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            MCvAvgComp[][] DetectedFaces = grayFace.DetectHaarCascade(faceDetected, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,new Size(20,20));
            foreach(MCvAvgComp f in DetectedFaces[0])
            {
                TrainedFace = Frame.Copy(f.rect).Convert<Gray, byte>();
                break;
            }
            TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            trainingImages.Add(TrainedFace);
            labels.Add(txtname.Text);
            File.WriteAllText(Application.StartupPath + "/Faces/Faces.txt", trainingImages.ToArray().Length.ToString() + ".");
            for(int i =1; i<trainingImages.ToArray().Length + 1; i++)
            {
                trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/Faces/face" + i + ".bmp");
                File.AppendAllText(Application.StartupPath + "/Faces/Faces.txt", labels.ToArray()[i - 1] + ",");
            }
            MessageBox.Show(txtname.Text + "Added Successfully");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void start_Click(object sender, EventArgs e)
        {
            Camera = new Capture();
            Camera.QueryFrame();
            Application.Idle += new EventHandler(Frameprocedure);
        }

        private void Frameprocedure(object sender, EventArgs e)
        {
            Users.Add("");
            Frame = Camera.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            grayFace = Frame.Convert<Gray, Byte>();
            MCvAvgComp[][] faceDetectedNow = grayFace.DetectHaarCascade(faceDetected, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));
            foreach (MCvAvgComp f in faceDetectedNow[0])
            {
                result = Frame.Copy(f.rect).Convert<Gray, Byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                Frame.Draw(f.rect, new Bgr(Color.Green), 3);
                if (trainingImages.ToArray().Length != 0)
                {
                    MCvTermCriteria termCriterias = new MCvTermCriteria(Count, 0.001);
                    EigenObjectRecognizer recognizer = new EigenObjectRecognizer(trainingImages.ToArray(), labels.ToArray(), 1500, ref termCriterias);
                    name = recognizer.Recognize(result);
                    Frame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.Red));
                    
                }
                //Users[t - 1]= name;
                Users.Add("");

            }
            cameraBox.Image = Frame;
            names = "";
            Users.Clear();
        }
    }
}
