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
        private volatile Bitmap _orginalBitmap;
        private PictureBox[] _images;

        public Form1()
        {
            InitializeComponent();
            _images = new[]
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
                _orginalBitmap = new Bitmap(file);
                orginal.SizeMode = PictureBoxSizeMode.Zoom;
                orginal.Image = _orginalBitmap;
            }
        }

        private void start_Click(object sender, EventArgs e)
        {
            Parallel.Invoke(() =>
            {
                for (int i = 0; i < _images.Length; i++)
                {
                    _images[i].SizeMode = PictureBoxSizeMode.Zoom;
                    switch (i)
                    {
                        case 0:
                            _images[i].Image = ImageFilter.Negative(_orginalBitmap);
                            break;
                        case 1:
                            _images[i].Image = ImageFilter.Sepia(_orginalBitmap);
                            break;
                        case 2:
                            _images[i].Image = ImageFilter.Mirror(_orginalBitmap, MirrorMode.HORIZONTAL);
                            break;
                        case 3:
                            _images[i].Image = ImageFilter.Mirror(_orginalBitmap, MirrorMode.VERTICAL);
                            break;
                    }
                }
            });
        }
        
    }
}