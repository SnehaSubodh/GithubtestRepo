using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleRentalAgency.DataAccess;
using VehicleRentalAgency.Entities;

namespace VehicleRentalAgency.WebUI.Areas.Admin.Controllers
{
    [Authorize(Users = "Admin1@abc.com,Admin2@abc.com")]
    public class HomeController : Controller
    {
            // GET: Admin/Home
            private EFVehicleRepository repo = new EFVehicleRepository();
            [AllowAnonymous]
            public ActionResult Index()
            {
                return View(repo.GetAllVehicles());
            }
            [Authorize]
            public ActionResult Create()
            {
                return View();
            }
            [Authorize]
            [HttpPost]
            public ActionResult Create(Vehicle vehicle)
            {
                if (!ModelState.IsValid)
                    return View();
                repo.AddVehicle(vehicle);
                return RedirectToAction("Index");
            }
            [Authorize]

            public ActionResult Delete(int id)
            {
                repo.DeleteVehicle(id);
                TempData["msg"] = "item deleted...";
                return RedirectToAction("Index");

            }
            [Authorize]
            public ActionResult Edit(int id)
            {
                //getproduct by id
                var vehicle = repo.GetVehicleById(id);
                return View(vehicle);
            }
            [Authorize]
            [HttpPost]
            public ActionResult Edit(Vehicle vehicle)
            {
                if (!ModelState.IsValid)
                    return View();
                repo.EditVehicle(vehicle);
                TempData["msg"] = "item updated...";
                return RedirectToAction("Index");

            }



        }
    }