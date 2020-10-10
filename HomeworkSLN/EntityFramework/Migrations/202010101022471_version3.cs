namespace EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Regions", c => c.String(maxLength: 15));
            AddColumn("dbo.Customers", "FoundationDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Customers", "Region");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Region", c => c.String(maxLength: 15));
            DropColumn("dbo.Customers", "FoundationDate");
            DropColumn("dbo.Customers", "Regions");
        }
    }
}
