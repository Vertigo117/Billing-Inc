namespace Billing_Inc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BillTo = c.String(),
                        Description = c.String(),
                        UnitPrice = c.Double(nullable: false),
                        Amount = c.Int(nullable: false),
                        InvoiceDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Invoices");
        }
    }
}
