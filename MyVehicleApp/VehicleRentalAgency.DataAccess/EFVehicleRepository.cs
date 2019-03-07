using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRentalAgency.Entities;

namespace VehicleRentalAgency.DataAccess
{
    public class EFVehicleRepository : IVehicleRepository
    {
        private VehicleDbContext db = new VehicleDbContext();

        public void AddVehicle(Vehicle vehicle)
        {
            db.Vehicles.Add(vehicle);
            db.SaveChanges();
        }

        public void DeleteVehicle(int Vehicleid)
        {
            db.Vehicles.Remove(db.Vehicles.Find(Vehicleid));
            db.SaveChanges();
        }


        public void EditVehicle(Vehicle vehicle)
        {
            db.Entry(vehicle).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

        }

        public List<Vehicle> GetAllVehicles()
        {
            return db.Vehicles.ToList();

        }

        public List<string> GetCategory()
        {
            return db.Vehicles.Select(p => p.Category).Distinct().ToList();
        }

        public List<Vehicle> GetVehicleByCategory(string category)
        {
            return db.Vehicles.Where(p => p.Category.ToLower().Contains(category.ToLower())).ToList();
        }

        public Vehicle GetVehicleById(int Id)
        {
            return db.Vehicles.FirstOrDefault(p => p.VehicleId == Id);
        }
    }
}

