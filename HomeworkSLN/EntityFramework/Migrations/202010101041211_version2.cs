namespace EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CardNumber = c.Int(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        CardHolder = c.String(),
                        Employee_EmployeeID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeID)
                .Index(t => t.Employee_EmployeeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CreditCards", "Employee_EmployeeID", "dbo.Employees");
            DropIndex("dbo.CreditCards", new[] { "Employee_EmployeeID" });
            DropTable("dbo.CreditCards");
        }
    }
}
