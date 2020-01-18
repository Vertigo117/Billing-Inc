using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing_Inc.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string BillTo { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
        public int Amount { get; set; }
        public DateTime InvoiceDate { get; set; }
    }
}
