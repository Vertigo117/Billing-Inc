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
        Command removeCommand;
        BindingList<Invoice> datagridSource;
        public BindingList<Invoice> DataGridSource
        {
            get
            {
                return datagridSource;
            }
            set
            {
                datagridSource = value;
                OnPropertyChanged("DataGridSource");
            }
        }

        public Command RemoveCommand
        {
            get
            {
                return removeCommand ??
                    (removeCommand = new Command(d =>
                    {
                        if(invoice!=null)
                        {
                            Db.Invoices.Remove(invoice);
                            Db.SaveChanges();
                            datagridSource.Remove(invoice);
                            OnPropertyChanged("DataGridSource");
                        }
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
            datagridSource = new BindingList<Invoice>(Db.Invoices.ToList());
        }

        
    }
}
