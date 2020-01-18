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
        Invoice invoice;
        Command deleteCommand;
        public ICollectionView DataGridSource { get; set; }

        public Command DeleteCommand
        {
            get
            {
                return deleteCommand ??
                    (deleteCommand = new Command(d =>
                    {
                        Db.Invoices.Remove(invoice);
                        Db.SaveChanges();
                    }));
            }

        }

        public Invoice SelectedInvoice
        {
            get
            {
                return invoice;
            }
            set
            {
                invoice = value;
                OnPropertyChanged("SelectedInvoice");
            }
        }
        

        public InvoicesViewModel()
        {
            DataGridSource = CollectionViewSource.GetDefaultView(Db.Invoices.ToList());
        }

        
    }
}
