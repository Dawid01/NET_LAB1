using System;
using System.Drawing;

namespace ImagesApp
{
    public enum MirrorMode
    {
        HORIZONTAL, VERTICAL
    }
    
    public class ImageFilter
    {
        public static Bitmap Negative(Bitmap originalImage)
        {
            Bitmap newImage = new Bitmap(originalImage.Width, originalImage.Height);
        
            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    Color originalColor = originalImage.GetPixel(x, y);
                    Color newColor = Color.FromArgb(255 - originalColor.R, 255 - originalColor.G, 255 - originalColor.B);
                    newImage.SetPixel(x, y, newColor);
                }
            }
        
            return newImage;
        }

        public static Bitmap Sepia(Bitmap originalImage)
        {
            Bitmap newImage = new Bitmap(originalImage.Width, originalImage.Height);

            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    Color originalColor = originalImage.GetPixel(x, y);
                    int newR = (int)(originalColor.R * 0.393 + originalColor.G * 0.769 + originalColor.B * 0.189);
                    int newG = (int)(originalColor.R * 0.349 + originalColor.G * 0.686 + originalColor.B * 0.168);
                    int newB = (int)(originalColor.R * 0.272 + originalColor.G * 0.534 + originalColor.B * 0.131);

                    newR = Math.Min(255, Math.Max(0, newR));
                    newG = Math.Min(255, Math.Max(0, newG));
                    newB = Math.Min(255, Math.Max(0, newB));

                    Color newColor = Color.FromArgb(newR, newG, newB);
                    newImage.SetPixel(x, y, newColor);
                }
            }

            return newImage;
        }
        
        public static Bitmap Brighten(Bitmap originalImage, int value)
        {
            Bitmap newImage = new Bitmap(originalImage);

            for (int x = 0; x < newImage.Width; x++)
            {
                for (int y = 0; y < newImage.Height; y++)
                {
                    Color originalColor = originalImage.GetPixel(x, y);
                    int newR = originalColor.R + value;
                    int newG = originalColor.G + value;
                    int newB = originalColor.B + value;

                    newR = Math.Min(255, Math.Max(0, newR));
                    newG = Math.Min(255, Math.Max(0, newG));
                    newB = Math.Min(255, Math.Max(0, newB));

                    Color newColor = Color.FromArgb(newR, newG, newB);
                    newImage.SetPixel(x, y, newColor);
                }
            }

            return newImage;
        }

        public static Bitmap Mirror(Bitmap originalImage, MirrorMode mirrorMode)
        {
            Bitmap newImage = new Bitmap(originalImage);

            for (int x = 0; x < newImage.Width; x++)
            {
                for (int y = 0; y < newImage.Height; y++)
                {
                    Color color = originalImage.GetPixel(x,y);
                    if (mirrorMode == MirrorMode.HORIZONTAL)
                    {
                        newImage.SetPixel((newImage.Width - 1) - x, y, color);
                    }
                    else
                    {
                        newImage.SetPixel(x, (newImage.Height - 1) - y, color);
                    }
                }
            }

            return newImage;
        }

        public static Bitmap AdjustContrast(Bitmap originalImage, float value)
        {
            Bitmap newImage = new Bitmap(originalImage);

            float factor = (259f * (value + 255f)) / (255f * (259f - value));

            for (int x = 0; x < newImage.Width; x++)
            {
                for (int y = 0; y < newImage.Height; y++)
                {
                    Color originalColor = originalImage.GetPixel(x, y);
                    int newR = (int)(factor * (originalColor.R - 128) + 128);
                    int newG = (int)(factor * (originalColor.G - 128) + 128);
                    int newB = (int)(factor * (originalColor.B - 128) + 128);

                    newR = Math.Min(255, Math.Max(0, newR));
                    newG = Math.Min(255, Math.Max(0, newG));
                    newB = Math.Min(255, Math.Max(0, newB));

                    Color newColor = Color.FromArgb(newR, newG, newB);
                    newImage.SetPixel(x, y, newColor);
                }
            }

            return newImage;
        }
    }
}