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
            LinesTime = plotModelTime.Series;

            DataPointList = new List<List<DataPoint>>();
            PointsTime = new List<List<DataPoint>>();

            for (int i = 0; i<NumberOfLines;i++)
            {
                LineSeries line = new LineSeries();
                line.Name = "line" + i.ToString();
                DataPointList.Add(new List<DataPoint>());
                line.ItemsSource = DataPointList[i];
                Lines.Add(line);
               
            }

            for (int i = 0; i < 4; i++)
            {
                LineSeries line = new LineSeries();
                line.Name = "line" + i.ToString();
                PointsTime.Add(new List<DataPoint>());
                line.ItemsSource = PointsTime[i];
                LinesTime.Add(line);
            }
        }

        public PlotManager()
        {
            this.Title = "Score";
    }

    public string Title { get; private set; }

        public IList<Series> Lines { get; private set; }

        public IList<Series> LinesTime { get; private set; }

        public List<List<DataPoint>> DataPointList;

        public List<List<DataPoint>> PointsTime;


        public void Tick(int generation,float[] data)
        {
            for (int i = 0; i < NumberOfLines; i++)
            {
                DataPointList[i].Add(new DataPoint(generation,(130-data[i])* (130 - data[i])));
            }
            plotModelScore.InvalidatePlot(true);
        }

        public void UpdateTimeScore(Cell cell)
        {
            PointsTime[0].Clear();
            PointsTime[1].Clear();
            PointsTime[2].Clear();
            PointsTime[3].Clear();

            for (int i = 0; i < 101; i++)
            {
                PointsTime[0].Add(new DataPoint(i, cell.GetBlue((float)i/100)));
            }

            for (int i = 0; i < 101; i++)
            {
                PointsTime[1].Add(new DataPoint(i, cell.GetScreenValue((float)i / 100)));
            }
            Comparison<Point> comparison = (x, y) => (int) ( ComparePoint(x,y));
            cell.PointList.Sort(comparison);

            for (int i = 0; i < cell.PointList.Count; i++)
            {
                PointsTime[2].Add(new DataPoint(cell.PointList[i].frame*100, cell.PointList[i].waarde));
            }

            plotModelTime.InvalidatePlot(true);
        }

        public int ComparePoint( Point x, Point y) 
        {
            if (x.frame == y.frame)
            {
                return 0;
            }
            else if (x.frame >= y.frame)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
