using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;


namespace BAWsurvival
{

    using System.Collections.Generic;
    using OxyPlot.Wpf;
    using OxyPlot;


    class PlotManager
    {
        Plot plotModel;

        public void Initialize (Plot plot)
        {
            plotModel = plot;
        }

        public PlotManager()
        {
            this.Title = "Score";
            this.Points = new List<DataPoint>
                              {
                              };
            
        }

        public string Title { get; private set; }

        public IList<DataPoint> Points { get; private set; }

        public void Tick(int generation,float average)
        {
            this.Points.Add(new DataPoint(generation,average));
            plotModel.InvalidatePlot(true); 
        }
    }
}
