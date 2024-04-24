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

namespace ImagesApp
{
    public partial class Form1 : Form
    {
        private volatile Bitmap orginalBitmap;
        private PictureBox[] images;

        public Form1()
        {
            InitializeComponent();
            images = new[]
            {
                image1, image2, image3, image4
            };
        }
        
        private void load_image_Click(object sender, EventArgs e)
        {
            //openFileDialog1.Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpg;*.jpeg)|*.jpg;*.jpeg";
            openFileDialog1.ShowDialog();
            string file = openFileDialog1.FileName;
            if (file != null)
            {
                orginalBitmap = new Bitmap(file);
                orginal.SizeMode = PictureBoxSizeMode.Zoom;
                orginal.Image = orginalBitmap;
            }
        }

        private void start_Click(object sender, EventArgs e)
        {
            Parallel.Invoke(() =>
            {
                for (int i = 0; i < images.Length; i++)
                {
                    images[i].SizeMode = PictureBoxSizeMode.Zoom;
                    Bitmap clone = orginalBitmap.Clone() as Bitmap;
                    switch (i)
                    {
                        case 0:
                            images[i].Image = ImageFilter.Negative(clone);
                            break;
                        case 1:
                            images[i].Image = ImageFilter.Sepia(clone);
                            break;
                        case 2:
                            //images[i].Image = ImageFilter.AdjustContrast(clone, 10f);
                            images[i].Image = ImageFilter.Mirror(clone, MirrorMode.HORIZONTAL);
                            break;
                        case 3:
                            //images[i].Image = ImageFilter.Brighten(clone, 10);
                            images[i].Image = ImageFilter.Mirror(clone, MirrorMode.VERTICAL);
                            break;
                    }
                }
            });
        }
        
    }
}