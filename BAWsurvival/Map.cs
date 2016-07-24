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
            
            
                   
            Point[] NPointList = NCell.PointList;

            Point[] PointList = new Point[NPointList.Length];
            for(int i =0;i< PointList.Length;i++)
            {
                Point p = new Point();
                p.frame = NPointList[i].frame;
                p.waarde = NPointList[i].waarde;
                PointList[i] = p;
            }
            cell.PointList = PointList;

            if (randomGen.Next(30) == 0)
            {
                int spread = randomGen.Next(0,25)/5;
                if (spread == 0)
                {
                    spread = 50;
                }
                for (int i = 0; i < PointList.Length; i++)
                {
                    PointList[i].waarde = (byte) Math.Min(Math.Max(PointList[i].waarde + (randomGen.Next(0, spread)-2.5),0),255);
                }

                for (int i = 2; i < PointList.Length; i++)
                {
                    PointList[i].frame = (float)Math.Min(Math.Max(PointList[i].frame + randomGen.Next(0, spread)/250 - 0.01, 0f), 1f);
                }

                cell.CalculateScore();
            }
            else
            {
                cell.score = NCell.score;
            }


        }

        public Cell GetRandomCell()
        {
            Coordinate coord = new Coordinate();
            coord.x = randomGen.Next(xSize);
            coord.y = randomGen.Next(ySize);
            return grid.GetCell(coord);
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
