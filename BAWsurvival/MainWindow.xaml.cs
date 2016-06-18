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

    public partial class MainWindow : Window
    {
        CanvasRender canvasRender;
        Map map;
        Evolution evolution;
        Grid grid;

        int xSize = 25;
        int ySize = 13;

        public MainWindow()
        {
            InitializeComponent();

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
            evolution.FramesPerTick = 100;
            evolution.CellsPerSelection = 5;


            evolution.map = map;
            evolution.canvasRender = canvasRender;
            evolution.grid = grid;
            map.canvasRender = canvasRender;
            map.grid = grid;
            canvasRender.grid = grid;


            grid.Initialize();
            canvasRender.Initialize();
            canvasRender.ChangeBackground(Colors.White);

        }

        private void NewTick_Click(object sender, RoutedEventArgs e)
        {
            evolution.Tick();
        }

        private void ShowAnimation_Click(object sender, RoutedEventArgs e)
        {
            evolution.Animate();
        }
    }
}
