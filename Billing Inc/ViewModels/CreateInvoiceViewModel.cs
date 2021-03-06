﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billing_Inc.Models;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Text.RegularExpressions;

namespace Billing_Inc.ViewModels
{
    public class CreateInvoiceViewModel : BaseViewModel
    {
        string description;
        double unitPrice;
        string billTo;
        int amount;
        DateTime invoiceDate;
        OpenFileDialog openFileDialog;
        string filePath;
        string filePathText;
        Regex regex;

        Command createCommand;
        Command openFileCommand;
        Command loadFromFileCommand;

        public CreateInvoiceViewModel()
        {
            invoiceDate = DateTime.Now;
            filePath = "-";
            filePathText = "File: ";
            regex = new Regex("^[0-9]*$");
        }

        public Command LoadFromFileCommand
        {
            get
            {
                return loadFromFileCommand ??
                    (loadFromFileCommand = new Command(command =>
                    {
                        try
                        {
                            LoadFromFileAsync();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }));
            }
        }

        public string FilePath
        {
            get
            {
                return filePathText + filePath;
            }
            set
            {
                filePath = value;
                OnPropertyChanged("FilePath");
            }
        }

        public Command OpenFileCommand
        {
            get
            {
                return openFileCommand ??
                    (openFileCommand = new Command(command =>
                    {
                        openFileDialog = new OpenFileDialog();
                        openFileDialog.Filter = "Csv Files|*.csv";
                        if(openFileDialog.ShowDialog()==true)
                        {
                            filePath = openFileDialog.FileName;
                            OnPropertyChanged("FilePath");
                        }
                    }));
            }
        }

        public Command CreateCommand
        {
            get
            {
                return createCommand ??
                    (createCommand = new Command(command =>
                    {
                        try
                        {
                            Invoice invoice = new Invoice()
                            {
                                Amount = amount,
                                BillTo = billTo,
                                Description = description,
                                InvoiceDate = invoiceDate,
                                UnitPrice = unitPrice
                            };

                            Db.Invoices.Add(invoice);
                            Db.SaveChanges();
                            MessageBox.Show("New invoice added");
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
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
                
                if(regex.IsMatch(value))
                {
                    unitPrice = Convert.ToDouble(value);
                    OnPropertyChanged("UnitPrice");
                }
                else
                {
                    MessageBox.Show("Only numeric characters are allowed!");
                }
                
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
                if(regex.IsMatch(value))
                {
                    amount = Convert.ToInt32(value);
                    OnPropertyChanged("Amount");
                }
                else
                {
                    MessageBox.Show("Only numeric characters are allowed!");
                }
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

        public async void LoadFromFileAsync()
        {
            await Task.Run(() =>
            {
                var textArray = File.ReadAllLines(filePath);
                for(int i=1; i<textArray.Length;i++)
                {
                    var invoiceTxt = textArray[i].Split(';');
                    Invoice invoice = new Invoice
                    {
                        Id = Convert.ToInt32(invoiceTxt[0]),
                        BillTo = invoiceTxt[1],
                        Description = invoiceTxt[2],
                        UnitPrice = Convert.ToDouble(invoiceTxt[3]),
                        Amount = Convert.ToInt32(invoiceTxt[4]),
                        InvoiceDate = DateTime.Parse(invoiceTxt[5])
                    };

                    Db.Invoices.Add(invoice);
                    Db.SaveChanges();
                }
            });

            MessageBox.Show("DataFile was sucsessfully uploaded!");
        }
    }
}
