using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billing_Inc.Models;

namespace Billing_Inc
{
    public class Connection
    {
        public bool Status { get; set; }

        public Connection(InvoiceContext db)
        {
            Status = db.Database.Exists();
        }
    }
}
