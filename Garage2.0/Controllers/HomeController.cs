using Garage2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage2._0.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //var dataList = new List<Object>();

            IQueryable<StatisticsViewModel> data = from vehicle in db.Vehicles
                                                   group vehicle by vehicle.Type into vehicleGroup 
                                                   select new StatisticsViewModel()
                                                   {
                                                       Type = vehicleGroup.Key,
                                                       TypeCount = vehicleGroup.Count(),
                                                   };

            //dataList.Add(data.ToList());

            //IQueryable<StatisticsViewModel> data2 = from vehicle in db.Vehicles
            //                                        group vehicle by vehicle.Colour into vehicleGroup2
            //                                        select new StatisticsViewModel()
            //                                        {
            //                                            Colour = vehicleGroup2.Key,
            //                                            ColourCount = vehicleGroup2.Count(),
            //                                        };
            //dataList.Add(data2.ToList());

            return View(data);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}