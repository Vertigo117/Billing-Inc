using Billing_Inc.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Billing_Inc.ViewModels
{
    public class InvoicesViewModel : BaseViewModel
    {
        public ICollectionView DataGridSource { get; set; }

        
        

        public InvoicesViewModel()
        {
            DataGridSource = CollectionViewSource.GetDefaultView(Db.Invoices.ToList());
        }

        
    }
}
