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

        public MainWindow()
        {
            InitializeComponent();

            canvasRender = new CanvasRender();
            canvasRender.myCanvas = myCanvas;
            canvasRender.xSize =25;
            canvasRender.ySize =13;
            canvasRender.Initialize();
            canvasRender.RandomColor();
            canvasRender.ChangeBackground(Colors.Black);
            canvasRender.FramesPerTick = 20;

            map = new Map();
            map.canvasRender = canvasRender;
            map.xSize = canvasRender.xSize;
            map.ySize = canvasRender.ySize;
            map.Backgroundcolor = Colors.Black;

            evolution = new Evolution();
            evolution.map = map;
            evolution.canvasRender = canvasRender;
            evolution.DeathsPerTick = 20;
            evolution.FramesPerTick = canvasRender.FramesPerTick;
            evolution.CellsPerSelection = 5;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            evolution.Frame();
        }
    }
}
