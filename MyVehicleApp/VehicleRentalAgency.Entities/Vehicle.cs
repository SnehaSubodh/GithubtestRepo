using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRentalAgency.Entities
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string RegistrationNum { get; set; }
        public string Category { get; set; }
        public string Manufacturer { get; set; }
        public double DailyRent { get; set; }
        public int Milage { get; set; }
        public string Description { get; set; }
        public string FuelType { get; set; }
        public string Imgpath { get; set; }
        public int Quantity { get; set; }
        public int NumberOfDays { get; set; }
        


    }
}
