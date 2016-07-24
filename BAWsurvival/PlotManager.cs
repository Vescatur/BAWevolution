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



    class PlotManager
    {
        Plot plotModelScore;
        Plot plotModelTime;
        public int NumberOfLines;

        public void Initialize (Plot plotScore,Plot plotScoreTime)
        {

            plotModelScore = plotScore;
            plotModelTime = plotScoreTime;
            Lines = plotModelScore.Series;
            DataPointList = new List<List<DataPoint>>();

            for (int i = 0; i<NumberOfLines;i++)
            {
                LineSeries line = new LineSeries();
                line.Name = "line" + i.ToString();
                DataPointList.Add(new List<DataPoint>());
                line.ItemsSource = DataPointList[i];
                Lines.Add(line);
               
            }


        }

        public PlotManager()
        {
            this.Title = "Score";
            this.PointsTime = new List<DataPoint>();

    }

    public string Title { get; private set; }

        public IList<Series> Lines { get; private set; }

        public List<List<DataPoint>> DataPointList;

        public IList<DataPoint> PointsTime { get; private set; }


        public void Tick(int generation,float[] data,float[] dataTime)
        {
            PointsTime.Clear();

            for (int i = 0; i < 100; i++)
            {
                PointsTime.Add(new DataPoint(i, dataTime[i]));
            }


            for (int i = 0; i < NumberOfLines; i++)
            {
                DataPointList[i].Add(new DataPoint(generation,(130-data[i])* (130 - data[i])));
            }
            plotModelTime.InvalidatePlot(true);
            plotModelScore.InvalidatePlot(true);
        }
    }
}
