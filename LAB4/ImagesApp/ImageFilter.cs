using System;
using System.Drawing;

namespace ImagesApp
{
    public class ImageFilter
    {
        public static Bitmap Negative(Bitmap originalImage)
        {
            Bitmap newImage = new Bitmap(originalImage.Width, originalImage.Height);
        
            for (int i = 0; i < originalImage.Width; i++)
            {
                for (int j = 0; j < originalImage.Height; j++)
                {
                    Color originalColor = originalImage.GetPixel(i, j);
                    Color newColor = Color.FromArgb(255 - originalColor.R, 255 - originalColor.G, 255 - originalColor.B);
                    newImage.SetPixel(i, j, newColor);
                }
            }
        
            return newImage;
        }

        public static Bitmap Sepia(Bitmap originalImage)
        {
            Bitmap newImage = new Bitmap(originalImage.Width, originalImage.Height);

            for (int i = 0; i < originalImage.Width; i++)
            {
                for (int j = 0; j < originalImage.Height; j++)
                {
                    Color originalColor = originalImage.GetPixel(i, j);
                    int newR = (int)(originalColor.R * 0.393 + originalColor.G * 0.769 + originalColor.B * 0.189);
                    int newG = (int)(originalColor.R * 0.349 + originalColor.G * 0.686 + originalColor.B * 0.168);
                    int newB = (int)(originalColor.R * 0.272 + originalColor.G * 0.534 + originalColor.B * 0.131);

                    newR = Math.Min(255, Math.Max(0, newR));
                    newG = Math.Min(255, Math.Max(0, newG));
                    newB = Math.Min(255, Math.Max(0, newB));

                    Color newColor = Color.FromArgb(newR, newG, newB);
                    newImage.SetPixel(i, j, newColor);
                }
            }

            return newImage;
        }
        
        public static Bitmap Brighten(Bitmap originalImage, int value)
        {
            Bitmap newImage = new Bitmap(originalImage);

            for (int i = 0; i < newImage.Width; i++)
            {
                for (int j = 0; j < newImage.Height; j++)
                {
                    Color originalColor = originalImage.GetPixel(i, j);
                    int newR = originalColor.R + value;
                    int newG = originalColor.G + value;
                    int newB = originalColor.B + value;

                    newR = Math.Min(255, Math.Max(0, newR));
                    newG = Math.Min(255, Math.Max(0, newG));
                    newB = Math.Min(255, Math.Max(0, newB));

                    Color newColor = Color.FromArgb(newR, newG, newB);
                    newImage.SetPixel(i, j, newColor);
                }
            }

            return newImage;
        }
        
        public static Bitmap AdjustContrast(Bitmap originalImage, float value)
        {
            Bitmap newImage = new Bitmap(originalImage);

            float factor = (259f * (value + 255f)) / (255f * (259f - value));

            for (int i = 0; i < newImage.Width; i++)
            {
                for (int j = 0; j < newImage.Height; j++)
                {
                    Color originalColor = originalImage.GetPixel(i, j);
                    int newR = (int)(factor * (originalColor.R - 128) + 128);
                    int newG = (int)(factor * (originalColor.G - 128) + 128);
                    int newB = (int)(factor * (originalColor.B - 128) + 128);

                    newR = Math.Min(255, Math.Max(0, newR));
                    newG = Math.Min(255, Math.Max(0, newG));
                    newB = Math.Min(255, Math.Max(0, newB));

                    Color newColor = Color.FromArgb(newR, newG, newB);
                    newImage.SetPixel(i, j, newColor);
                }
            }

            return newImage;
        }
    }
}