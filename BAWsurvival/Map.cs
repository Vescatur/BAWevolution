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
        public Color Backgroundcolor;

        internal void CellDie(Coordinate coord)
        {
            Coordinate coordN = getRandomCell();
            canvasRender.ChangePixel(coord.x,coord.y,canvasRender.GetColorCell(coordN));
        }

        internal Coordinate getRandomCell()
        {
            Coordinate coord = new Coordinate();
            coord.x = Math.Abs(randonGen.Next(xSize-1) + randonGen.Next(xSize-1) - xSize+1);
            Console.Write(coord.x);
            coord.y = randonGen.Next(ySize) ;
            return coord;
        }

        internal int getCellScore(Coordinate coord)
        {
            Color color = canvasRender.GetColorCell(coord);
            int score = Math.Abs(color.R - Backgroundcolor.R) + Math.Abs(color.B - Backgroundcolor.B) + Math.Abs(color.G - Backgroundcolor.G);
            return score;
        }

        internal Coordinate getWorst(Coordinate[] coordList)
        {
            Coordinate coord = coordList[0];
            for (int i = 1;i<coordList.Length;i++)
            {
                if (getCellScore(coord) < getCellScore(coordList[i]))
                {
                    coord = coordList[i];
                }
            }

            return coord;
        }


        internal Coordinate[] getRandomCellArray(int Size)
        {
            Coordinate[] coordList = new Coordinate[Size];
            for (int i = 0; i < Size; i++)
            {
                coordList[i] = getRandomCell();
            }
            return coordList;
        }




    }
}
