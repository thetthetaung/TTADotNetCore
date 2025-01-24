namespace TTADotNetCore.ChartWebApp.Models
{
    public class ApexChartPieChartModel
    {
        
        public int[] Series { get; set; }
        public string[] Labels { get; set; }
    }

    public class ApexChartMixedChartModel
    {
        public List<SeriesData> Series { get; set; }
        public string[] Labels { get; set; }
    }

    public class SeriesData
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int[] Data { get; set; }
    }

    public class ApexChartBarChartModel
    {
        public int[] Series { get; set; }
        public string[] Categories { get; set; }
    }

    public class ApexChartBarWithGoalsModel
    {
        public List<BarWithGoalsData> Series { get; set; }
    }

    public class BarWithGoalsData
    {
        public string Name { get; set; }
        public List<BarDataPoint> Data { get; set; }
    }

    public class BarDataPoint
    {
        public string X { get; set; }
        public int Y { get; set; }
        public List<Goal> Goals { get; set; }
    }

    public class Goal
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public int StrokeWidth { get; set; }
        public int? StrokeHeight { get; set; }
        public int[] StrokeDashArray { get; set; }
        public string StrokeColor { get; set; }
        public string StrokeLineCap { get; set; }
    }
    public class ApexChartDonutModel
    {
        public int[] Series { get; set; }
        public string[] Labels { get; set; }
    }
    public class ApexChartRadarModel
    {
        public List<RadarSeries> Series { get; set; }
        public string[] Categories { get; set; }
    }

    public class RadarSeries
    {
        public string Name { get; set; }
        public int[] Data { get; set; }
    }
}
