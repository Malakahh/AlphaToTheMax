using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AlphaToTheMax
{
    class Program
    {
        static void Main(string[] args)
        {
            Bitmap bmp = new Bitmap(args[0]);

            int lastPercent = -1;
            int numPixels = bmp.Width * bmp.Height;

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color c = bmp.GetPixel(x, y);

                    if (c.A < 255)
                    {
                        bmp.SetPixel(x, y, Color.FromArgb(0, 0, 0, 0));

                        int percent = (int)((x + (y * bmp.Width)) / (double)numPixels * 100 + 0.5);
                        if (percent > lastPercent)
                        {
                            lastPercent = percent;
                            Console.WriteLine("Complete: " + percent + "%");
                        }
                    }
                }
            }

            bmp.Save("new.png");
        }
    }
}
