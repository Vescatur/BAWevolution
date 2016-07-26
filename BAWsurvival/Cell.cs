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
    class Cell
    {
        public float score;
        int x;
        int y;
        public List<Point> PointList;



        public void Initialize (int Tx,int Ty,Random randomGen)
        {
            x = Tx;
            y = Ty;
            int NumberPoints = randomGen.Next(5)+3;
            PointList = new List<Point>();


            for (int i = 0; i<NumberPoints;i++)
            {
                PointList.Add(RandomPoint(randomGen));
            }

            PointList[0].frame = 0;
            PointList[1].frame = 1;

            CalculateScore();
        }

        public void CalculateScore()
        {
            score = 0;
            for (float frame = 0; frame <= 1; frame += 0.01f)
            {
                score += Math.Abs(GetScreenValue(frame) - GetBlue(frame));
            }

            score = score / 100;
        }


        public float GetScreenValue(float frame)
        {
            return (float) (Math.Abs(Math.Sin(frame * 2 * (float)Math.PI) * 126 + 126));
        }

        public Point RandomPoint(Random randonGen)
        {
            Point point = new Point();
            point.frame = (float)randonGen.Next(100) / 100;
            point.waarde = (byte)randonGen.Next(255);

            return point;
        }

        public Color GetColor(float Frame)
        {
            byte b = GetBlue(Frame);
            return Color.FromRgb(b, b, b);
        }

        public byte GetBlue(float Frame)
        {
            Point Onder = PointList[0];
            Point Boven = PointList[0];
            for (int i = 1; i < PointList.Count; i++)
            {


                if (Frame - Onder.frame > Frame - PointList[i].frame | Onder.frame > Frame)
                {
                    if (PointList[i].frame <= Frame)
                    {
                        Onder = PointList[i];
                    }
                }
                if (Boven.frame - Frame > PointList[i].frame - Frame | Boven.frame < Frame)
                {
                    if (PointList[i].frame >= Frame)
                    {
                        Boven = PointList[i];
                    }
                }
            }

            float start = Onder.waarde;
            float verschil = Boven.waarde - Onder.waarde;

            float afstand = (Frame - Onder.frame) / (Boven.frame - Onder.frame);

            if (Boven.frame == Onder.frame)
            {
                afstand = 0;
            }
            

            byte color = (byte)Math.Round(start + verschil * afstand);
            return color;
        }

    }
}
