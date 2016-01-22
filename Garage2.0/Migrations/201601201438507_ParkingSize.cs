namespace Garage2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParkingSize : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "ParkingLot", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicles", "ParkingSize", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "ParkingSize");
            DropColumn("dbo.Vehicles", "ParkingLot");
        }
    }
}
