namespace Garage2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeparkingsize : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vehicles", "ParkingSize");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "ParkingSize", c => c.Int(nullable: false));
        }
    }
}
