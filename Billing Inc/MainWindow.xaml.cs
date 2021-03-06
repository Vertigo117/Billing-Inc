﻿using System;
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
using System.Data.Entity;
using Billing_Inc.Models;

namespace Billing_Inc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DashboardViewModel();
            Database.SetInitializer(new BillingDbInitializer());
        }

        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new DashboardViewModel();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new CreateInvoiceViewModel();
        }

        private void btnInvoices_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new InvoicesViewModel();
        }
    }
}
