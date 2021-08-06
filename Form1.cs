using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alturos.Yolo;
using Alturos.Yolo.Model;
using System.Diagnostics;




namespace CarDetect
{


    public partial class FormForDetectingCars : Form
    {
        
        //создание видеопотока - изображений из видео или камеры
        
        Image finalImage = null;
        YoloWrapper yolo;
        MemoryStream memoryStream;
        private int car = 0;
        private int truck = 0;
        private int bus = 0;
        private int motorbike = 0;
        private int objectCount = 0;
        private double confCar = 0.0;
        private double confTruck = 0.0;
        private double confBus = 0.0;
        private double confBike = 0.0;
        private bool noClasses = true;
        private double conf = 0.0;
        private String[] types = { "car", "truck", "motorbike" };
        int maximum = 0;
        //YoloItem - найденный на изображении объект 
        //items - для всех объектов
        //badItems - для объектов, не из области интересов
        List<YoloItem> badItems = new List<YoloItem>();
        List<YoloItem> items;
        private String filename = String.Empty;
        

        //контруктор общей формы
        public FormForDetectingCars()
        {
            //инициализирует форму и все её составляющие
            InitializeComponent();
        }
        //кнопка перехода к папкам с файлами
        private void открытьToolStripMenuMenuItem_click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            { 
                filename = openFileDialog1.FileName;
                pictureBoxForImageOrVideo.Image = Image.FromFile(filename);
              
            }
            else
            {
                MessageBox.Show("Choose the pic", "Picture didn't chose", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
       
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox.Clear();
            pictureBoxForResult.Image = pictureBoxForImageOrVideo.Image;
            finalImage = pictureBoxForResult.Image;

            //pictureBoxForDetectObjects.Image = pictureBoxForImageOrVideo.Image;
            Stopwatch st = new Stopwatch();
            st.Start();
            //DnnInvoke.ReadNet("yolov3.weights", "yolov3.cfg")
            yolo = new YoloWrapper("yolov3.cfg", "yolov3.weights", "coco.names");

            memoryStream = new MemoryStream();

            pictureBoxForImageOrVideo.Image.Save(memoryStream, ImageFormat.Jpeg);

            //pictureBoxForDetectObjects.Image.Save(memoryStream, ImageFormat.Jpeg);
            
            items = yolo.Detect(memoryStream.ToArray()).ToList<YoloItem>();
            st.Stop();
            //finalImage = pictureBoxForDetectObjects.Image;

            Graphics graph = Graphics.FromImage(finalImage);
            Font font = new Font("Consolas", 20, FontStyle.Bold);
            SolidBrush brush = new SolidBrush(Color.Black);
            
            try
            {
                if (pictureBoxForImageOrVideo.Image == null)
                {
                    throw new Exception("No image!");
                }


                //pictureBoxForDetectObjects.Image.Save(memoryStream, ImageFormat.Png);


                badItems.Clear();


                foreach (YoloItem item in items)
                {

                    /*  double conf = item.Confidence * 100;
                      if (item.Type != "person" && item.Type != "" )
                      {*/
                
                    conf = item.Confidence * 100;
                    if (types.Contains(item.Type))
                    {


                        Point rectPoint = new Point(item.X, item.Y);
                        Size rectSize = new Size(item.Width, item.Height);
                        Rectangle rect = new Rectangle(rectPoint, rectSize);

                        /*if (conf < 50)
                        {
                            Pen pen = new Pen(Color.Red, 5);
                            graph.DrawRectangle(pen, rect);
                            //graph.DrawString(item.Type, font, brush, rectPoint);
                        }
                        if (conf >= 50 && conf < 80)
                        {
                            Pen pen = new Pen(Color.Yellow, 5);
                            graph.DrawRectangle(pen, rect);
                            //graph.DrawString(item.Type, font, brush, rectPoint);
                        }
                        if (conf > 80)
                        {
                            Pen pen = new Pen(Color.Green, 5);
                            graph.DrawRectangle(pen, rect);
                            //graph.DrawString(item.Type, font, brush, rectPoint);
                        }*/
                        

                        objectCount += 1;
                        if (conf > 60)
                        {
                            switch (item.Type)
                            {
                                case "car":
                                    car += 1;
                                    confCar += item.Confidence;
                                    Pen pen = new Pen(Color.Black, 5);
                                    graph.DrawRectangle(pen, rect);
                                    break;
                                case "truck":
                                    truck += 1;
                                    confTruck += item.Confidence;
                                    Pen pen1 = new Pen(Color.Green, 5);
                                    graph.DrawRectangle(pen1, rect);
                                    break;
                                case "bus":
                                    bus += 1;
                                    confBus += item.Confidence;
                                    break;
                                case "motorbike":
                                    motorbike += 1;
                                    confBike += item.Confidence;
                                    break;
                            }
                        }
                        

                        
                    }

                }
                //int[] typesCount = { car, truck, bus, motorbike };
                /* maximum = typesCount.Max();
                TextBoxForCount.Text = maximum.ToString();*/
                //richTextBox.Text += "All types: " + objectCount.ToString() + "\n";
                richTextBox.Text += "All types: " + (car + truck).ToString() + "\n";
                if (car != 0)
                    richTextBox.Text += "Car: " + car.ToString() + "\nAvg conf: " + Math.Floor(confCar / car * 100).ToString() + "%\n";
                if(truck != 0)
                    richTextBox.Text += "Truck: " + truck.ToString() + "\nAvg conf: " + Math.Floor(confTruck / truck * 100).ToString() + "%\n";
                if (bus != 0)
                    richTextBox.Text += "Bus: " + bus.ToString() + "\nAvg conf: " + Math.Floor(confBus / bus *100).ToString() + "%\n";
                if (motorbike != 0)
                    richTextBox.Text += "Bikes: " + motorbike.ToString() + "\nAvg conf: " + Math.Floor(confBike / motorbike *100).ToString() + "%\n";

                confCar = 0;
                confTruck = 0;
                confBus = 0;
                confBike = 0;
                objectCount = 0;
                maximum = 0;
                car = 0;
                truck = 0;
                bus = 0;
                motorbike = 0;

                pictureBoxForResult.Image = finalImage;
                richTextBox.Text += "Time:" + st.Elapsed.TotalSeconds.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //pictureBoxForDetectObjects.Image = finalImage;
        }
            private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
      
        /*private void buttonForCameraActivation_Click(object sender, EventArgs e)
        {
            String filename = "C://Users//пользователь//Desktop//CCTV Камера наблюдения перекресток Невский проспект и Садовая улица 17feb2021 01-29.mp4";
            try
            {
                capture = new VideoCapture(filename);
                if (!File.Exists(filename))
                    throw new Exception("No such file!");
                
                capture.ImageGrabbed += Capture_ImageGrabbed;

                capture.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
           
            capture = new VideoCapture();

            
            capture.ImageGrabbed += Capture_ImageGrabbed;

            capture.Start();
        }*/
    
 

   
       
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ToolStripMenuItemForChooseFile_Click(object sender, EventArgs e)
        {

        }

      
    }
}
// МЕТОДЫ ПОКАЗА БЫВШИХ ПЛОХИХ ОБЪЕКТОВ
/*try
            {
                if (pictureBoxForImageOrVideo.Image == null)
                {
                    throw new Exception("No image!");
                }
                richTextBoxForRestObjects.Clear();
                if (badItems.Count != 0)
                {
                    if (items.Count - badItems.Count == 0)
                    {
                        richTextBoxForRestObjects.Text += "On this photo only :";
                        foreach (YoloItem item in badItems)
                        {
                            richTextBoxForRestObjects.Text += ", " + item.Type.ToString() + " - " + Math.Round((item.Confidence * 100), 2).ToString();
                        }

                    }
                    else
                    {
                        richTextBoxForRestObjects.Text += "Also here can be";
                        foreach (YoloItem item in badItems)
                        {
                            richTextBoxForRestObjects.Text += ", " + item.Type.ToString() + " - " + Math.Round((item.Confidence * 100), 2).ToString();
                        }
                    }
                }
                else
                {
                    richTextBoxForRestObjects.Text += "No more objects can be here";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }*/
/*pictureBoxForDetectObjects.Image = pictureBoxForImageOrVideo.Image;
            finalImage = pictureBoxForDetectObjects.Image;

            MemoryStream memoryStream = new MemoryStream();

            try
            {
                if (pictureBoxForImageOrVideo.Image == null)
                {
                    throw new Exception("No image!");
                }


                pictureBoxForDetectObjects.Image.Save(memoryStream, ImageFormat.Png);


                pictureBoxForImageOrVideo.Image.Save(memoryStream, ImageFormat.Png);
                Graphics graph = Graphics.FromImage(finalImage);
                Font font = new Font("Consolas", 20, FontStyle.Bold);
                SolidBrush brush = new SolidBrush(Color.Black);
                foreach (YoloItem item in badItems)
                {
                    Point rectPoint = new Point(item.X, item.Y);
                    Size rectSize = new Size(item.Width, item.Height);
                    Rectangle rect = new Rectangle(rectPoint, rectSize);
                    Pen pen = new Pen(Color.Black, 5);
                    if (rect.Width != 0 || rect.Height != 0)
                        graph.DrawRectangle(pen, rect);
                    graph.DrawString(item.Type, font, brush, rectPoint);

                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK);
            }*/
// МЕТОД ПОИСКА ДОМИНИРУЮЩЕГО ЦВЕТА НА ИЗОБРАЖЕНИИ
/* public Color getDominantColor(System.Drawing.Bitmap bmp)
        {
            BitmapData srcData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            int stride = srcData.Stride;

            IntPtr Scan0 = srcData.Scan0;

            int[] totals = new int[] { 0, 0, 0 };

            int width = bmp.Width;
            int height = bmp.Height;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        for (int color = 0; color < 3; color++)
                        {
                            int idx = (y * stride) + x * 4 + color;
                            totals[color] += p[idx];
                        }
                    }
                }
            }

            int avgB = totals[0] / (width * height);
            int avgG = totals[1] / (width * height);
            int avgR = totals[2] / (width * height);

            bmp.UnlockBits(srcData);

            return Color.FromArgb(avgR, avgG, avgB);
        }*/
//ТЯЖЕЛЫЕ РАСЧЕТЫ 
/*  if (item.Type == "car")
                              {
                                  confCar += item.Confidence;
                                  car += 1;
                              }
                              if (item.Type == "truck")
                              {
                                  confTruck += item.Confidence;
                                  truck += 1;
                              }
                              if (item.Type == "bus")
                              {
                                  confBus += item.Confidence;
                                  bus += 1;
                              }
                          }
                          if ((item.Confidence * 100) < 80 || item.Type == "person")
                          {
                              badItems.Add(item);
                          }

                      }*/
/* for (int i = 0; i < items.Count; i++)
     if (items[i].Type != "person")
         noClasses = false;
 if (noClasses == false)
 {
     TextBoxForAllCount.Text = items.Count.ToString();
     int a = Max(car, bus, truck);
     TextBoxForCount.Text = a.ToString();
     if (a == car)
     {
         TextBoxForType.Text = "car";
     }
     if (a == truck)
     {
         TextBoxForType.Text = "truck";
     }
     if (a == bus)
     {
         TextBoxForType.Text = "bus";
     }

     if (TextBoxForType.Text == "car")
     {
         TextBoxForCount.Text = car.ToString();
         TextBoxForConfidence.Text = (confCar / car).ToString();
     }
     if (TextBoxForType.Text == "truck")
     {
         TextBoxForCount.Text = truck.ToString();
         TextBoxForConfidence.Text = (confTruck / truck).ToString();
     }
     if (TextBoxForType.Text == "bus")
     {
         TextBoxForCount.Text = bus.ToString();
         TextBoxForConfidence.Text = (confBus / bus).ToString();
     }
 }
 else
 {
     TextBoxForType.Text = "No classes";
     TextBoxForCount.Text = "0";
     TextBoxForConfidence.Text = "0";
     TextBoxForAllCount.Text = items.Count.ToString();
 }*/
/*Console.WriteLine("GOOD");
foreach (YoloItem item in items)
{
    Console.WriteLine(item.Type + " " + item.Confidence);
}*/
/*Console.WriteLine(items.Count);
Console.WriteLine("BAD");
foreach (YoloItem item in badItems)
{
    Console.WriteLine(item.Type + " " + item.Confidence);
}
Console.WriteLine(badItems.Count);*/
