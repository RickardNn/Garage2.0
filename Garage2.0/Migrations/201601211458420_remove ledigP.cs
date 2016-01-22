namespace Garage2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeledigP : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vehicles", "LedigPlatser");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "LedigPlatser", c => c.Int(nullable: false));
        }
    }
}
