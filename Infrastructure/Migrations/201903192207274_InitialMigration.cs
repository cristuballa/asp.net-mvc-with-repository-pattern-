namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        ContactPerson = c.String(),
                        EmailAdd = c.String(),
                        ContactInfo = c.String(),
                        Address_Id = c.Int(),
                        BillingAddress_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .ForeignKey("dbo.Addresses", t => t.BillingAddress_Id)
                .Index(t => t.Address_Id)
                .Index(t => t.BillingAddress_Id);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HouseNo = c.String(),
                        Street = c.String(),
                        Suburb = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ContactNo = c.String(),
                        Address_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateSold = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        Reference = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Barcode = c.String(),
                        StockNo = c.String(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Unit = c.String(),
                        WholesalePrice1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WholesalePrice2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductImage = c.String(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        ContactPerson = c.String(),
                        EmailAdd = c.String(),
                        ContactInfo = c.String(),
                        Address_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .Index(t => t.Address_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Suppliers", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Orders", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Employees", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Customers", "BillingAddress_Id", "dbo.Addresses");
            DropForeignKey("dbo.Customers", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.Suppliers", new[] { "Address_Id" });
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.Orders", new[] { "EmployeeId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.Employees", new[] { "Address_Id" });
            DropIndex("dbo.Customers", new[] { "BillingAddress_Id" });
            DropIndex("dbo.Customers", new[] { "Address_Id" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.Employees");
            DropTable("dbo.Addresses");
            DropTable("dbo.Customers");
        }
    }
}
