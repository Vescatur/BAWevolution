using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
    class Evolution
    {
        public Map map;
        public CanvasRender canvasRender;
        public int DeathsPerTick;
        public int CellsPerSelection;
        public int FramesPerTick;
        public int xSize;
        public int ySize;
        public Grid grid;

        /// <summary>
        /// 
        /// </summary>
        public void Tick()
        {
            List<Cell> cellList = new List<Cell>();

            for(int x = 0; x < xSize ; x++)
            {
                for (int y = 0; y < ySize; y++)
                {
                    cellList.Add(grid.grid[x,y]);
                }
            }
            Comparison<Cell> comparison = (x, y) => Cell.CompareScore(x, y);

            cellList.Sort(comparison);
            int NumberOfCells = cellList.Count;
            //int CellsSquared = (int) Math.Floor(Math.Sqrt((float)NumberOfCells));

            //for (int i = 0; i <CellsSquared; i++ )
            //{
            //    for(int o =0; (float)o<(float)i/2f;o++)
            //    {
            //        map.CellDie(cellList[CellsSquared * i + MainWindow.randomGen.Next(0, CellsSquared)]);
            //    }
            //}
            //
            //for (int i = CellsSquared^2; i<NumberOfCells;i++)
            //{
            //    map.CellDie(cellList[i]);
            //}

            for (int i = 0; (float)i < (float)NumberOfCells / 4f;i++)
            {
                map.CellDie(cellList[NumberOfCells - i - 1]);
            }

            for (int i = 0; (float)i < (float)NumberOfCells / 4f; i++)
            {
                map.CellDie(cellList[MainWindow.randomGen.Next(0,NumberOfCells)]);
            }

            canvasRender.UpdateScreen(0);
        }
        
        public void Animate()
        {
                Frame(0);
        }


        public void Frame(int FrameNumber)
        {
            var backgroundWorker = new BackgroundWorker();

            backgroundWorker.DoWork += (s, e) => {
                Thread.Sleep(50);
            };

            backgroundWorker.RunWorkerCompleted += (s, e) =>
            {
                canvasRender.UpdateScreen((float)FrameNumber/ (float)FramesPerTick);
                FrameNumber++;
                if (FrameNumber <FramesPerTick)
                {
                    Frame(FrameNumber);
                }
            };

            backgroundWorker.RunWorkerAsync();
        }

    }
}
