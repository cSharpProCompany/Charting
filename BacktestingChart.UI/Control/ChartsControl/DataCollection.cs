﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BacktestingChart.UI.Control.ChartsControl
{
    class DataCollection
    {
        private List<DataSeries> dataList;
        public DataCollection()
        {
            dataList = new List<DataSeries>();
        }
        public List<DataSeries> DataList
        {
            get { return dataList; }
            set { dataList = value; }
        }
        public void AddLines(Canvas canvas, ChartStyle cs)
        {
            int j = 0;
            foreach (DataSeries ds in DataList)
            {
                if (ds.SeriesName == "Default Name")
                {
                    ds.SeriesName = "DataSeries" +
                    j.ToString();
                }
                ds.AddLinePattern();
                for (int i = 0; i <ds.LineSeries.Points.Count; i++)
                {
                    ds.LineSeries.Points[i] =cs.NormalizePoint(
                    ds.LineSeries.Points[i]);
                }
                canvas.Children.Add(ds.LineSeries);
                j++;
            }
        }
    }
}
