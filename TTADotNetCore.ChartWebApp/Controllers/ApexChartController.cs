using Microsoft.AspNetCore.Mvc;
using TTADotNetCore.ChartWebApp.Models;

namespace TTADotNetCore.ChartWebApp.Controllers
{
    public class ApexChartController : Controller
    {
        
        public IActionResult PieChart()
        {
            ApexChartPieChartModel model = new ApexChartPieChartModel();
            model.Series = new int[] { 44, 55, 13, 43, 22 };
            model.Labels = new string[] { "Apple", "Mango", "Orange", "Banana", "Grapes" };
            return View(model);
        }

        public IActionResult MixedChart()
        {
            var model = new ApexChartMixedChartModel
            {
                Series = new List<SeriesData>
            {
                new SeriesData
                {
                    Name = "TEAM A",
                    Type = "column",
                    Data = new int[] { 23, 11, 22, 27, 13, 22, 37, 21, 44, 22, 30 }
                },
                new SeriesData
                {
                    Name = "TEAM B",
                    Type = "area",
                    Data = new int[] { 44, 55, 41, 67, 22, 43, 21, 41, 56, 27, 43 }
                },
                new SeriesData
                {
                    Name = "TEAM C",
                    Type = "line",
                    Data = new int[] { 30, 25, 36, 30, 45, 35, 64, 52, 59, 36, 39 }
                }
            },
                Labels = new string[] { "01/01/2003", "02/01/2003", "03/01/2003", "04/01/2003", "05/01/2003", "06/01/2003", "07/01/2003", "08/01/2003", "09/01/2003", "10/01/2003", "11/01/2003" }
            };

            return View(model);
        }

        public IActionResult BarChart()
        {
            var model = new ApexChartBarChartModel
            {
                Series = new int[] { 400, 430, 448, 470, 540, 580, 690, 1100, 1200, 1380 },
                Categories = new string[] { "South Korea", "Canada", "United Kingdom", "Netherlands", "Italy", "France", "Japan", "United States", "China", "Germany" }
            };

            return View(model);
        }

        public IActionResult BarWithGoals()
        {
            var model = new ApexChartBarWithGoalsModel
            {
                Series = new List<BarWithGoalsData>
            {
                new BarWithGoalsData
                {
                    Name = "Actual",
                    Data = new List<BarDataPoint>
                    {
                        new BarDataPoint
                        {
                            X = "2011",
                            Y = 12,
                            Goals = new List<Goal>
                            {
                                new Goal
                                {
                                    Name = "Expected",
                                    Value = 14,
                                    StrokeWidth = 2,
                                    StrokeDashArray = new int[] { 2 },
                                    StrokeColor = "#775DD0"
                                }
                            }
                        },
                        new BarDataPoint
                        {
                            X = "2012",
                            Y = 44,
                            Goals = new List<Goal>
                            {
                                new Goal
                                {
                                    Name = "Expected",
                                    Value = 54,
                                    StrokeWidth = 5,
                                    StrokeHeight = 10,
                                    StrokeColor = "#775DD0"
                                }
                            }
                        },
                        new BarDataPoint
                        {
                            X = "2013",
                            Y = 54,
                            Goals = new List<Goal>
                            {
                                new Goal
                                {
                                    Name = "Expected",
                                    Value = 52,
                                    StrokeWidth = 10,
                                    StrokeHeight = 0,
                                    StrokeLineCap = "round",
                                    StrokeColor = "#775DD0"
                                }
                            }
                        },
                        new BarDataPoint
                        {
                            X = "2014",
                            Y = 66,
                            Goals = new List<Goal>
                            {
                                new Goal
                                {
                                    Name = "Expected",
                                    Value = 61,
                                    StrokeWidth = 10,
                                    StrokeHeight = 0,
                                    StrokeLineCap = "round",
                                    StrokeColor = "#775DD0"
                                }
                            }
                        },
                        new BarDataPoint
                        {
                            X = "2015",
                            Y = 81,
                            Goals = new List<Goal>
                            {
                                new Goal
                                {
                                    Name = "Expected",
                                    Value = 66,
                                    StrokeWidth = 10,
                                    StrokeHeight = 0,
                                    StrokeLineCap = "round",
                                    StrokeColor = "#775DD0"
                                }
                            }
                        },
                        new BarDataPoint
                        {
                            X = "2016",
                            Y = 67,
                            Goals = new List<Goal>
                            {
                                new Goal
                                {
                                    Name = "Expected",
                                    Value = 70,
                                    StrokeWidth = 5,
                                    StrokeHeight = 10,
                                    StrokeColor = "#775DD0"
                                }
                            }
                        }
                    }
                }
            }
            };

            return View(model);
        }

        public IActionResult DonutChart()
        {
            var model = new ApexChartDonutModel
            {
                Series = new int[] { 44, 55, 41, 17, 15 },
                Labels = new string[] { "Apple", "Mango", "Orange", "Banana", "Grapes" }
            };

            return View(model);
        }

        public IActionResult RadarChart()
        {
            var model = new ApexChartRadarModel
            {
                Series = new List<RadarSeries>
            {
                new RadarSeries
                {
                    Name = "Series 1",
                    Data = new int[] { 80, 50, 30, 40, 100, 20 }
                }
            },
                Categories = new string[] { "January", "February", "March", "April", "May", "June" }
            };

            return View(model);
        }
    }
}
