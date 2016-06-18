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
        Random randonGen = new Random();
        public int xSize;
        public int ySize;
        public CanvasRender canvasRender;
        public SolidColorBrush Backgroundcolor;
        public Grid grid;

        internal void CellDie(Cell cell)
        {
            cell.score = GetRandomCell().score;
        }

        public Cell GetRandomCell()
        {
            Coordinate coord = new Coordinate();
            coord.x = randonGen.Next(xSize);
            coord.y = randonGen.Next(ySize);
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
                if (cell.score > cells[i].score)
                {
                    cell = cells[i];
                }
            }

            return cell;
        }
    }
}
