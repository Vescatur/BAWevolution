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
        Random randonGen = new Random();

        public void Initialize()
        {
            grid = new Cell[xSize, ySize];
            for(int x = 0; x<xSize;x++)
            {
                for(int y = 0; y < ySize; y++)
                {
                    grid[x, y] = new Cell();
                    grid[x, y].Initialize(x, y, randonGen.Next(255));
                }
            }
        }

        public Cell GetCell (Coordinate coordinate)
        {
            return grid[coordinate.x, coordinate.y];
        }

        
    }
}
