namespace Garage2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "Type", c => c.String());
        }
    }
}
