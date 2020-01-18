using Billing_Inc.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Billing_Inc.ViewModels
{
    public class InvoicesViewModel : INotifyPropertyChanged
    {
        InvoiceContext db = new InvoiceContext();
        BindingList<Invoice> DataGridSource { get; set; }
        

        public InvoicesViewModel()
        {
            IEnumerable<Invoice> invoices = db.Invoices.ToList();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
