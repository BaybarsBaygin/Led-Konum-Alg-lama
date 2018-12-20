using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Imaging.Filters;
using AForge.Imaging;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Vision;
using AForge.Vision.Motion;

namespace Led_Yakma
{
    public partial class Form1 : Form
    {
        private VideoCaptureDevice camera;
        private FilterInfoCollection camfilt;
        public Form1()
        {
            InitializeComponent();
        }
        int X = 0;
        int Y = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            for (int i = 0; i < System.IO.Ports.SerialPort.GetPortNames().Length; i++)
            {
                toolStripComboBox2.Items.Add(System.IO.Ports.SerialPort.GetPortNames()[i]);
            }
            camfilt = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo VideoCaptureDevice in camfilt)
            {
                toolStripComboBox1.Items.Add(VideoCaptureDevice.Name);
                toolStripComboBox1.SelectedIndex = 0;
            }
        }

        private void kameraBaslat_Click(object sender, EventArgs e)
        {
            try
            {
                camera = new VideoCaptureDevice(camfilt[toolStripComboBox1.SelectedIndex].MonikerString);
                camera.NewFrame += new NewFrameEventHandler(pccam_NewFrame);
                camera.DesiredFrameRate = 30;
                camera.DesiredFrameSize = new Size(640, 480); 
                camera.Start();
                radioButton1.Checked = true;
            }
            catch (Exception)
            {

                MessageBox.Show("HİÇ KAMERA BULUNAMADI", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pccam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap image = (Bitmap)eventArgs.Frame.Clone();
            Bitmap image1 = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = image;
            if (radioButton1.Checked) { }

            if (radioButton2.Checked)
            {
                EuclideanColorFiltering filter = new EuclideanColorFiltering();
                filter.CenterColor = new RGB(Color.FromArgb(97, 95, 195)); 
                filter.Radius = 50;
                filter.ApplyInPlace(image1);          
                cevreal(image1);
            }
        }

        private void cevreal(Bitmap image)
        {
            BlobCounter blobCounter = new BlobCounter();
            blobCounter.MinWidth = 2;
            blobCounter.MinHeight = 2;
            blobCounter.FilterBlobs = true;
            blobCounter.ObjectsOrder = ObjectsOrder.Size;

            Grayscale grayFilter = new Grayscale(0.2125, 0.7154, 0.0721);
            Bitmap grayImage = grayFilter.Apply(image);

            blobCounter.ProcessImage(grayImage);
            Rectangle[] rects = blobCounter.GetObjectsRectangles();
            foreach (Rectangle recs in rects)
            {

                if (rects.Length > 0)
                {
                    Rectangle objectRect = rects[0];
                    Graphics g = pictureBox1.CreateGraphics();
                    using (Pen pen = new Pen(Color.FromArgb(252, 3, 26), 2))
                    {

                        g.DrawRectangle(pen, objectRect);
                    }

                    X = objectRect.X + (objectRect.Width / 2);
                    Y = objectRect.Y + (objectRect.Height / 2);
                    g.DrawString(X.ToString() + "X" + Y.ToString(), new Font("Arial", 12), Brushes.Red, new System.Drawing.Point(250, 1));
                    g.Dispose();
                    Kontrol_Konum();

                }
            }


        }

        private void kameraDur_Click(object sender, EventArgs e)
        {
            if (camera.IsRunning)
            {
                camera.Stop();

            }
        }

        private void Kontrol_Konum()
        {
            if (X <= 210 && Y <= 160)
            {
                serialPort1.Write("1");
                serialPort1.Write("b");
                serialPort1.Write("c");
                serialPort1.Write("d");
                serialPort1.Write("e");
                serialPort1.Write("f");
                serialPort1.Write("g");
                serialPort1.Write("h");
                serialPort1.Write("j");
            }
            else if (X <= 210 && Y <= 320)
            {
                serialPort1.Write("2");
                serialPort1.Write("a");
                serialPort1.Write("c");
                serialPort1.Write("d");
                serialPort1.Write("e");
                serialPort1.Write("f");
                serialPort1.Write("g");
                serialPort1.Write("h");
                serialPort1.Write("j");
            }
            else if (X <= 210 && Y <= 480)
            {
                serialPort1.Write("3");
                serialPort1.Write("b");
                serialPort1.Write("a");
                serialPort1.Write("d");
                serialPort1.Write("e");
                serialPort1.Write("f");
                serialPort1.Write("g");
                serialPort1.Write("h");
                serialPort1.Write("j");
            }
            else if (X > 210 && X <= 420 && Y <= 160)
            {
                serialPort1.Write("4");
                serialPort1.Write("b");
                serialPort1.Write("c");
                serialPort1.Write("a");
                serialPort1.Write("e");
                serialPort1.Write("f");
                serialPort1.Write("g");
                serialPort1.Write("h");
                serialPort1.Write("j");
            }
            else if (X > 210 && Y > 160 && X <= 420 && Y <= 320)
            {
                serialPort1.Write("5");
                serialPort1.Write("b");
                serialPort1.Write("c");
                serialPort1.Write("d");
                serialPort1.Write("a");
                serialPort1.Write("f");
                serialPort1.Write("g");
                serialPort1.Write("h");
                serialPort1.Write("j");
            }
            else if (X > 210 && Y > 320 && X <= 420 && Y <= 480)
            {
                serialPort1.Write("6");
                serialPort1.Write("b");
                serialPort1.Write("c");
                serialPort1.Write("d");
                serialPort1.Write("e");
                serialPort1.Write("a");
                serialPort1.Write("g");
                serialPort1.Write("h");
                serialPort1.Write("j");
            }
            else if (X <= 640 && Y <= 160)
            {
                serialPort1.Write("7");
                serialPort1.Write("b");
                serialPort1.Write("c");
                serialPort1.Write("d");
                serialPort1.Write("e");
                serialPort1.Write("f");
                serialPort1.Write("a");
                serialPort1.Write("h");
                serialPort1.Write("j");
            }
            else if (X <= 640 && Y <= 320)
            {
                serialPort1.Write("8");
                serialPort1.Write("b");
                serialPort1.Write("c");
                serialPort1.Write("d");
                serialPort1.Write("e");
                serialPort1.Write("f");
                serialPort1.Write("g");
                serialPort1.Write("a");
                serialPort1.Write("j");
            }
            else if (X <= 640 && Y <= 480)
            {
                serialPort1.Write("9");
                serialPort1.Write("b");
                serialPort1.Write("c");
                serialPort1.Write("d");
                serialPort1.Write("e");
                serialPort1.Write("f");
                serialPort1.Write("g");
                serialPort1.Write("h");
                serialPort1.Write("a");
            }

        }

        private void seriBaglan_Click(object sender, EventArgs e)
        {

            serialPort1.PortName = toolStripComboBox2.Text;
            label2.Text = "Bağlandı (" + toolStripComboBox2.Text + ")";
            serialPort1.Open();
       
        }

        private void baglantıKes_Click(object sender, EventArgs e)
        {
            label1.Text = "COM Port Seç !";
            serialPort1.Close();
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            kameraBaslat.BackColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            kameraBaslat.BackColor = Color.FromArgb(192, 64, 0);
        }
    }
}
