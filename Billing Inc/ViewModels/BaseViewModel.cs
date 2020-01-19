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
    public class BaseViewModel : INotifyPropertyChanged
    {
        Connection connection;
        public InvoiceContext Db { get; set; }
        public Brush ConState
        {
            get
            {
                if (connection.Status)
                {
                    return new SolidColorBrush(Colors.Green);
                }
                else
                {
                    return new SolidColorBrush(Colors.Red);
                }
            }
        }

        public string ConStatus
        {
            get
            {
                if(connection.Status)
                {
                    return "Status: Active";
                }
                else
                {
                    return "Status: Unavailable";
                }
            }
        }

        public BaseViewModel()
        {
            Db = new InvoiceContext();
            connection = new Connection(Db);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
