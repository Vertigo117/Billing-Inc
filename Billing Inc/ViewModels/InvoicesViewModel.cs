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

namespace Billing_Inc.ViewModels
{
    public class InvoicesViewModel : INotifyPropertyChanged
    {
        InvoiceContext db = new InvoiceContext();
        public ICollectionView DataGridSource { get; set; }
        

        public InvoicesViewModel()
        {
            DataGridSource = CollectionViewSource.GetDefaultView(db.Invoices.ToList());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
