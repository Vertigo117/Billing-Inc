using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billing_Inc.Models;

namespace Billing_Inc.ViewModels
{
    public class CreateInvoiceViewModel : BaseViewModel
    {
        string description;
        double unitPrice;
        string billTo;
        int amount;
        DateTime invoiceDate;

        Command createCommand;

        public CreateInvoiceViewModel()
        {
            invoiceDate = DateTime.Now;
        }

        public Command CreateCommand
        {
            get
            {
                return createCommand ??
                    (createCommand = new Command(command =>
                    {
                        Db.Invoices.Add(new Invoice { Amount = amount, BillTo = billTo, Description = description, InvoiceDate = invoiceDate, UnitPrice = unitPrice });
                        Db.SaveChanges();
                    }));
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        public string UnitPrice
        {
            get
            {
                return unitPrice.ToString();
            }
            set
            {
                unitPrice = Convert.ToDouble(value);
                OnPropertyChanged("UnitPrice");
            }
        }

        public string BillTo
        {
            get
            {
                return billTo;
            }
            set
            {
                billTo = value;
                OnPropertyChanged("BillTo");
            }
        }

        public string Amount
        {
            get
            {
                return amount.ToString();
            }
            set
            {
                amount = Convert.ToInt32(value);
                OnPropertyChanged("Amount");
            }
        }

        public DateTime InvoiceDate
        {
            get
            {
                return invoiceDate;
            }
            set
            {
                invoiceDate = value;
                OnPropertyChanged("InvoiceDate");
            }
        }
    }
}
