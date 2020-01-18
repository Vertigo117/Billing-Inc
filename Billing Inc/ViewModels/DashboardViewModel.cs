using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Billing_Inc.Models;

namespace Billing_Inc.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        

        

        public string TotalInvoices
        {
            get
            {
                return string.Format("Total invoices: {0}", Db.Invoices.Count().ToString());
            }
            set
            {
                OnPropertyChanged("TotalInvoices");
            }
        }
    }
}
