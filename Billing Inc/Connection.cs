using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            try
            {
                db.Database.Connection.Open();
                db.Database.Connection.Close();
            }
            catch(SqlException)
            {
                Status = false;
            }
            Status = true;
        }
    }
}
