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
        private Rectangle[,] map;
        private SolidColorBrush[,] colorMap;
        public SolidColorBrush BackgroundColor;
        public Grid grid;

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
            UpdateScreen(0.2f);
        }

        internal void UpdateScreen(float frame)
        {
            byte BackColor = (byte)(Math.Abs(Math.Sin(frame * 2 * (float)Math.PI) * 126 + 126));
            ChangeBackground(Color.FromArgb(255, BackColor, BackColor, BackColor));

            for (int x = 0; x < xSize; x++)
            {
                for (int y = 0; y < ySize; y++)
                {
                    Coordinate coord = new Coordinate();
                    coord.x = x;
                    coord.y = y;
                    colorMap[x,y].Color = grid.GetCell(coord).GetColor(frame);
                }
            }
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
