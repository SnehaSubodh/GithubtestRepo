namespace VehicleRentalAgency.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleId = c.Int(nullable: false, identity: true),
                        RegistrationNum = c.String(),
                        Category = c.String(),
                        Manufacturer = c.String(),
                        DailyRent = c.Double(nullable: false),
                        Milage = c.Int(nullable: false),
                        Description = c.String(),
                        FuelType = c.String(),
                        Imgpath = c.String(),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vehicles");
        }
    }
}
