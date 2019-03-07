using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRentalAgency.Entities;

namespace VehicleRentalAgency.DataAccess
{
    
    
        internal class VehicleDbContext : DbContext
        {
            public DbSet<Vehicle> Vehicles { get; set; }

        }

    
}
