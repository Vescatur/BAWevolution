using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BAWsurvival
{
    class CanvasRender
    {
        public Canvas myCanvas;
        public int xSize;
        public int ySize;
        Random randonGen = new Random();
        private Rectangle[,] map;
        private SolidColorBrush[,] colorMap;
        private SolidColorBrush BackgroundColor;
        public int FramesPerTick;

        public void Initialize ()
        {
            BackgroundColor = new SolidColorBrush(Colors.Blue);
            myCanvas.Background = BackgroundColor;

            map = new Rectangle[xSize, ySize];
            colorMap = new SolidColorBrush[xSize, ySize];
            for (int x = 0; x < xSize; x++)
            {
                for (int y = 0; y < ySize; y++)
                {
                    CreatePixel(x, y, Colors.Blue);
                }
            }
        }

        public void RandomColor()
        {
            for (int x = 0; x < xSize; x++)
            {
                for (int y = 0; y < ySize; y++)
                {
                    byte randomNumber = (byte)randonGen.Next(255);
                    ChangePixel(x, y, Color.FromArgb(255, randomNumber, randomNumber, randomNumber));
                }
            }
        }

        internal void UpdateScreen(int frameNumber)
        {
            float a = (float) frameNumber / (float)FramesPerTick;
            float b = a * 2 * (float) Math.PI;
            float c = (float)Math.Sin(b);
            byte d = (byte) (c * 126 + 255);
            byte BackColor = d;
            ChangeBackground(Color.FromArgb(255, BackColor, BackColor, BackColor));
        }

        internal Color GetColorCell(Coordinate coord)
        {
            return colorMap[coord.x, coord.y].Color;
        }

        public void RandomColorPixel(Coordinate coord)
        {
            byte randomNumber = (byte)randonGen.Next(255);
            ChangePixel(coord.x, coord.y, Color.FromArgb(255, randomNumber, randomNumber, randomNumber));
        }

        public void CreatePixel(int x, int y,Color color)
        {
            Rectangle rec = new Rectangle();
            Canvas.SetTop(rec, y * 20+1);
            Canvas.SetLeft(rec, x * 20+1);
            rec.Width = 18;
            rec.Height = 18;
            colorMap[x, y] = new SolidColorBrush(Colors.Red);
            rec.Fill = colorMap[x, y];
            myCanvas.Children.Add(rec);
            map[x, y] = rec;
            
        }

        public void ChangePixel (int x, int y, Color color)
        {
            colorMap[x, y].Color = color;
        }

        public void ChangeBackground(Color color)
        {
            BackgroundColor.Color = color;
        }
    }
}
