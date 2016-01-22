using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2._0.Models
{
    public class StatisticsViewModel
    {
        public Type Type { get; set; }
        public string Colour { get; set; }
        public int TypeCount { get; set; }
        public int ColourCount { get; set; }
        public int WheelCount { get; set; }
        public DateTime LongestParkTime { get; set; }
    }
}