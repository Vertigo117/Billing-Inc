using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Billing_Inc.Models
{
    public class BillingDbInitializer : DropCreateDatabaseAlways<InvoiceContext>
    {
        protected override void Seed(InvoiceContext db)
        {
            db.Invoices.Add(new Invoice { Id = 1, BillTo = "John Smith", Description = "Front and rear cables", UnitPrice = 100, Amount = 100, InvoiceDate = DateTime.Parse("17.01.2020") });
            db.Invoices.Add(new Invoice { Id = 1, BillTo = "John Smith", Description = "Reaper set", UnitPrice = 15, Amount = 30, InvoiceDate = DateTime.Parse("17.01.2020") });
            db.Invoices.Add(new Invoice { Id = 1, BillTo = "Mary Watson", Description = "Web hosting", UnitPrice = 1, Amount = 40, InvoiceDate = DateTime.Parse("17.01.2020") });
            db.Invoices.Add(new Invoice { Id = 1, BillTo = "John Smith", Description = "Labor 3hrs", UnitPrice = 5, Amount = 15, InvoiceDate = DateTime.Parse("17.01.2020") });

            base.Seed(db);
        }
    }
}
