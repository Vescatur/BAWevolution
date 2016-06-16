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
    class Evolution
    {
        public Map map;
        public CanvasRender canvasRender;
        public int DeathsPerTick;
        public int CellsPerSelection;
        public int FramesPerTick;
        public int FrameNumber = 0;
        public bool Animate = true;


        public void Tick()
        {
            for (int i = 0; i < FramesPerTick; i++)
            {
                Frame();
            }
        }

        public void Frame()
        {
            if (Animate == true)
            {
                canvasRender.UpdateScreen(FrameNumber);
            }

            for (int i = 0; i < DeathsPerTick; i++)
            {

                Coordinate[] coordList = map.getRandomCellArray(CellsPerSelection);
                Coordinate WorstCell = map.getWorst(coordList);
                map.CellDie(WorstCell);
            }
            if (FrameNumber >= FramesPerTick)
            {
                FrameNumber = 0;
            }
            FrameNumber++;
        }

    }
}
