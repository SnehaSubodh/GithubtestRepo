using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRentalAgency.Entities;

namespace VehicleRentalAgency.DataAccess
{
    
    
        public interface IVehicleRepository
        {
            List<Vehicle> GetAllVehicles();
            Vehicle GetVehicleById(int Id);
            List<Vehicle> GetVehicleByCategory(string category);
            List<string> GetCategory();

            //for admin
            void AddVehicle(Vehicle product);
            void DeleteVehicle(int vehicleid);
            void EditVehicle(Vehicle vehicle);

        }
    
}
