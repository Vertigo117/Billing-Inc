using Billing_Inc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Billing_Inc.ViewModels;

namespace Billing_Inc.Views
{
    /// <summary>
    /// Interaction logic for InvoicesView.xaml
    /// </summary>
    public partial class InvoicesView : UserControl
    {
        InvoiceContext db = new InvoiceContext();
        public InvoicesView()
        {
            InitializeComponent();
        }
    }
}
