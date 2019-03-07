using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using VehicleRentalAgency.DataAccess;
using VehicleRentalAgency.Entities;

namespace VehicleRentalAgency.WebUI.Controllers
{
    public class VehicleController : Controller
    {
        // GET: Products
        private List<Vehicle> cart = new List<Vehicle>();
        IVehicleRepository repo = new EFVehicleRepository();

        //public ActionResult Search(string searchText = null, int page = 1)
        public ActionResult Search(string searchText = null)
        {
            //fetch all the products from data layer

            List<Vehicle> vehicles = null;
            if (string.IsNullOrEmpty(searchText))
            {
                vehicles = repo.GetAllVehicles();
            }
            //send the product to view     

            else
            {
                vehicles = repo.GetVehicleByCategory(searchText);
            }
            ViewBag.Categories = repo.GetCategory();
            ViewBag.SearchData = searchText;
            SelectList selectListItems = new SelectList(repo.GetCategory());
            //ViewBag.CategotyList = selectListItems;
            ViewBag.searchText = selectListItems;
            return View(vehicles);
            //return View(vehicles.ToPagedList(page, 2));
        }
        [ChildActionOnly]
        public ActionResult CategoryLinks()
        {

            return PartialView("categorypartial", repo.GetCategory());
        }

        public ActionResult Details(int Id)
        {

            //send the product to view 
            var details = repo.GetVehicleById(Id);
            return View(details);


        }
        public ActionResult DetailsPartial(int Id)
        {
            //send the product to view
            Thread.Sleep(5000);
            var details = repo.GetVehicleById(Id);
            return PartialView(details);


        }
        public ActionResult BookVehicles(int vehicleId, int quantity)
        {
            var vehicle = repo.GetVehicleById(vehicleId);
            vehicle.Quantity = quantity == 0 ? 1 : quantity;
            if (Session["cart"] == null)
                Session["cart"] = cart;
            else
                cart = Session["cart"] as List<Vehicle>;

            cart.Add(vehicle);
            return View(cart);

            //    if (HttpContext.Application["cart"] == null) //this is using application
            //         HttpContext.Application["cart"] = cart;
            //        else
            //        cart = HttpContext.Application["cart"] as List<Product>;
            //        cart.Add(product);
            //       return View();
            //}

        }
        public ActionResult Delete(int id)
        {
            //var cart = Session["cart"] as List<int>;
            //cart.Remove(productId);
            cart = GetCart();
            var v = cart.Where(vech => vech.VehicleId == id).FirstOrDefault();
            if (v != null)
            {
                cart.Remove(v);
                TempData["deleteMsg"] = string.Format($"Vehicle:{v.RegistrationNum}Removed from the Booked Items");
            }
            return View("BookVehicles", cart);

        }
        private List<Vehicle> GetCart()
        {
            if (Session["cart"] == null)
                Session["cart"] = cart;
            else
                cart = Session["cart"] as List<Vehicle>;

            return cart;
        }

        //public double GetRent()
        //{ 
        //    var TotalRent =repo.DailyRent * NumberOfDays;
        //}

    }
}


    
