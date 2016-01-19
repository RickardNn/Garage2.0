using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage2._0.Models;

namespace Garage2._0.Controllers
{
    public class GarageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Garage
        /*public ActionResult Index()
        {
            return View(db.Vehicles.ToList());
        }*/

        // Searchtest 1.0

        /* public ViewResult Index(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                var vehicles = from v in db.Vehicles
                               select v;
                vehicles = vehicles.Where(v => v.RegistrationNumber.Contains(searchString)
                                       || v.RegistrationNumber.Contains(searchString));
            }
            return View(db.Vehicles.ToList());
        }*/

        // Searchtest 2.0

       /* public ViewResult Index(string q)
        {
            var vehicles = from v in db.Vehicles select v;
            if (!string.IsNullOrWhiteSpace(q))
            {
                vehicles = vehicles.Where(v => v.RegistrationNumber.Contains(q));
            }
            return View(vehicles);
        }*/

        // Searhtest 3.0

        public ViewResult Index(string searchString, string sortOrder)
        {
            var vehicle = from v in db.Vehicles
                         select v;

            if (!String.IsNullOrEmpty(searchString))
            {
                vehicle = vehicle.Where(v => v.RegistrationNumber.Contains(searchString));
            }           
            
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Type_desc" : "";
            ViewBag.DateSortParm = sortOrder == "ParkTime" ? "ParkTime_desc" : "ParkTime";
           
            switch (sortOrder)
            {
                case "Type_desc":
                    vehicle = vehicle.OrderByDescending(v => v.Type);
                    break;               
                case "ParkTime":
                    vehicle = vehicle.OrderBy(v => v.ParkTime);
                    break;
                case "ParkTime_desc":
                     vehicle= vehicle.OrderByDescending(v => v.ParkTime);
                    break;                
                default:
                    vehicle = vehicle.OrderBy(v => v.Type);
                    break;
            }
            return View(vehicle.ToList());
        }

        public ActionResult Kvitto(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }
        // POST: Garage/Kvitto/5
        [HttpPost, ActionName("Kvitto")]
        [ValidateAntiForgeryToken]
        public ActionResult KvittoConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }   

        // GET: Garage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Garage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Garage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,RegistrationNumber,Colour,Brand,Model,WheelCount,ParkTime")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicle);
        }

        // GET: Garage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Garage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,RegistrationNumber,Colour,Brand,Model,WheelCount,ParkTime")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        // GET: Garage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Garage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
