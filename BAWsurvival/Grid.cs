using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAWsurvival
{
    class Grid
    {
        public int xSize;
        public int ySize;
        public Cell[,] grid;

        public void Initialize(Random randomGen)
        {
            grid = new Cell[xSize, ySize];
            for(int x = 0; x<xSize;x++)
            {
                for(int y = 0; y < ySize; y++)
                {
                    grid[x, y] = new Cell();
                    grid[x, y].Initialize(x, y,randomGen);
                }
            }
        }

        public Cell GetCell (Coordinate coordinate)
        {
            return grid[coordinate.x, coordinate.y];
        }

        public float average()
        {
            float avg = 0;
            for (int x = 0; x < xSize; x++)
            {
                for (int y = 0; y < ySize; y++)
                {
                   avg += (float)grid[x, y].score;
                }
            }
            return avg/xSize/ySize;
        }
    }
}
