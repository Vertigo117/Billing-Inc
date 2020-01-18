using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Billing_Inc.Models
{
    public class InvoiceContext : DbContext
    {
        

        public DbSet<Invoice> Invoices { get; set; }
    }
}
