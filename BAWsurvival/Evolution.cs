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
        public Grid grid;

        public void Tick()
        {
            for(int i = 0;i<DeathsPerTick;i++)
            {
                Cell[] cells = map.GetRandomCellArray(CellsPerSelection);
                Cell WorstCell = map.GetWorstCell(cells);
                map.CellDie(WorstCell);
                canvasRender.UpdateScreen(0);
            }
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
