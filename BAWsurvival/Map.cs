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
    class Map
    {
        Random randomGen;
        public int xSize;
        public int ySize;
        public CanvasRender canvasRender;
        public SolidColorBrush Backgroundcolor;
        public Grid grid;

        public void Initialize(Random TrandomGen)
        {
            randomGen = TrandomGen;
        }


        internal void CellDie(Cell cell)
        {
            Cell NCell = GetRandomCell();
            
            
                   
            List<Point> NPointList = NCell.PointList;
            List<Point> PointList = new List<Point>();
            for(int i =0;i< NPointList.Count;i++)
            {
                Point p = new Point();
                p.frame = NPointList[i].frame;
                p.waarde = NPointList[i].waarde;
                PointList.Add(p);
            }
            cell.PointList = PointList;

            int SizeSpread = randomGen.Next(0, 5);


            int spread;

            if (SizeSpread == 0 || SizeSpread == 1)
            {
                spread = 25;
            }
            else if (SizeSpread == 2)
            {
                spread = 100;
            }
            else 
            {
                spread = 5;
            }

            for (int i = 0; i < PointList.Count; i++)
            {
                if (randomGen.Next(3) == 0 )
                {
                    PointList[i].waarde = (byte)Math.Min(Math.Max(PointList[i].waarde + (randomGen.Next(0, spread) - spread / 2), 0), 255);
                }
            }

            for (int i = 1; i < PointList.Count-1; i++)
            {
                
               
                if (randomGen.Next(3) == 0)
                {
                    PointList[i].frame = (float)Math.Min(Math.Max(PointList[i].frame + (randomGen.Next(0, spread) - spread / 2) / 100, 0f), 1f);
                }

                if (PointList[i].frame == 100 || PointList[i].frame == 0)
                {
                    PointList[i].frame = (float)randomGen.Next(1000000) / 1000000;
                }
            }

            cell.CalculateScore();
 


        }

        internal float[] GetScoreTime()
        {
            float[] scores = new float[100];

            for(float i = 0; i<=1;i+=0.01f)
            {
                float score = 0;
                for(int b = 0; b<xSize*ySize;b++)
                {
                    int x = (int) Math.Floor((float)b / (float)ySize);
                    int y = b - (x * ySize);

                    score += Math.Abs(grid.grid[0,0].GetScreenValue(i) - grid.grid[x,y].GetBlue(i));
                }
                scores[(int)(i*100)] = score / (float) (xSize * ySize);
            }
            return scores;
        }

        public Cell GetRandomCell()
        {
            Coordinate coord = new Coordinate();
            coord.x = randomGen.Next(xSize);
            coord.y = randomGen.Next(ySize);
            return grid.GetCell(coord);
        }

        internal float[] GetMedianValues(int numberOfLines)
        {
            float[] lineData = new float[numberOfLines];
            float[] score = grid.GetAllScore();
            Array.Sort(score);
            for (int i = 0; i< numberOfLines;i++)
            {
                float precentage = (float) i / (float) (numberOfLines-1);
                float DataPointIndex = precentage  * ((float)xSize * (float)ySize-1);
                int RoundedDataPoint = (int)Math.Round(DataPointIndex);

                lineData[i] = score[RoundedDataPoint];
            }
            return lineData;
        }



        public Cell[] GetRandomCellArray(int size)
        {
            Cell[] cells = new Cell[size];
            for (int i = 0; i < size; i++)
            {
                cells[i] = GetRandomCell();
            }
            return cells;
        }

        public Cell GetBestCell(Cell[] cells)
        {
            throw new NotImplementedException();
        }

        public Cell GetWorstCell(Cell[] cells)
        {
            Cell cell = cells[0];
            for (int i = 1; i < cells.Length; i++)
            {
                if (cell.score < cells[i].score)
                {
                    cell = cells[i];
                }
            }

            return cell;
        }
    }
}
