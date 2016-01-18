using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2._0.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public Type Type { get; set; }
        public string RegistrationNumber { get; set; }
        public string Colour { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int WheelCount { get; set; }
        public DateTime ParkTime { get; set; }
    }
}