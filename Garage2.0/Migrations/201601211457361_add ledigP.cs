namespace Garage2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addledigP : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "LedigPlatser", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "LedigPlatser");
        }
    }
}
