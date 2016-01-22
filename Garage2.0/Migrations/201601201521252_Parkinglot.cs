namespace Garage2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Parkinglot : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "ParkingLot", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "ParkingLot");
        }
    }
}
