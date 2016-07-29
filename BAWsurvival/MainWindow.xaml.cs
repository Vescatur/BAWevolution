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
using OxyPlot;
using OxyPlot.Series;

namespace BAWsurvival
{

    public partial class MainWindow : Window
    {
        CanvasRender canvasRender;
        Map map;
        Evolution evolution;
        Grid grid;
        public static Random randomGen = new Random();

        int xSize = 25;
        int ySize = 13;
        int generationCounter;

        public string Title { get; private set; }

        public IList<DataPoint> Points { get; private set; }

        public MainWindow()
        {
            InitializeComponent();

            generationCounter = 0;
            grid = new Grid();
            canvasRender = new CanvasRender();
            map = new Map();
            evolution = new Evolution();

            grid.xSize = xSize;
            grid.ySize = ySize;

            canvasRender.myCanvas = myCanvas;
            canvasRender.xSize = xSize;
            canvasRender.ySize = ySize;

            map.xSize = xSize;
            map.ySize = ySize;
            map.Backgroundcolor = canvasRender.BackgroundColor;

            evolution.DeathsPerTick = 20;
            evolution.FramesPerTick = 120;
            evolution.CellsPerSelection = 10;
            evolution.xSize = xSize;
            evolution.ySize = ySize;

            evolution.map = map;
            evolution.canvasRender = canvasRender;
            evolution.grid = grid;
            map.canvasRender = canvasRender;
            map.grid = grid;
            canvasRender.grid = grid;


            grid.Initialize(randomGen);
            canvasRender.Initialize();
            canvasRender.ChangeBackground(Colors.White);
            map.Initialize(randomGen);
            plotManager.NumberOfLines = 6;
            plotManager.Initialize(myPlot,myPlotTime);
        }

        private void NewTick_Click(object sender, RoutedEventArgs e)
        {
            evolution.Tick();
            generationCounter += 1;
            plotManager.Tick(generationCounter, map.GetMedianValues(plotManager.NumberOfLines));
            plotManager.UpdateTimeScore(grid.grid[randomGen.Next(0,xSize-1),randomGen.Next(0,ySize-1)]);
        }

        private void ShowAnimation_Click(object sender, RoutedEventArgs e)
        {
            evolution.Animate();
        }

        private void testButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i<50;i++)
            {
                evolution.Tick();
                generationCounter += 1;
                plotManager.Tick(generationCounter, map.GetMedianValues(plotManager.NumberOfLines));
            }
            plotManager.UpdateTimeScore(grid.grid[randomGen.Next(0, xSize - 1), randomGen.Next(0, ySize - 1)]);
        }
    }
}
