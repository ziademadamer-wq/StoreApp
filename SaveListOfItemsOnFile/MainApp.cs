using System;
using System.Collections.Generic;
using System.Text;
using BL;
using ConsoleApp1;
using DAL;
using DAL.Contracts;
using Domains;
using StoreApp;
using Utilities;
namespace ConsoleApp1
{
    public class MainApp
    {
        //ui classes
        private readonly ItemMenu _ItemMenu;
        private readonly CustomerMenu _CustomerMenu;
        private readonly OrderMenu _OrderMenu;
        private readonly ReportsMenu _ReportsMenu;
        public MainApp()
        {
            Console.WriteLine("Choose the Data Source You want");
            Console.WriteLine($"1-Text File\n" +
                              $"2-Json File\n");
            Accessories.ReadIntNumber("Data Source", out int Choice, 1, 2);

            DAL.StorageType storageType;
            switch (Choice)
            {
                case 1:
                    storageType = DAL.StorageType.TextFile;
                    break;
                case 2:
                    storageType = DAL.StorageType.JsonFile;
                    break;
                default:
                    throw new ArgumentException("Invalid choice");
            }

                //Business layers
                var itemBL = new BusinessLayer<Item>(storageType);
                var customerBL = new BusinessLayer<Customer>(storageType);
                var orderBL = new BusinessLayer<Order>(storageType);
                var reportBL = new OrderReportsService(orderBL);
                //Menus 
                _ItemMenu = new ItemMenu(itemBL);
                _CustomerMenu = new CustomerMenu(customerBL);
                _OrderMenu = new OrderMenu(orderBL, customerBL, itemBL);
               _ReportsMenu = new ReportsMenu(reportBL);
        }
        #region main App
        public async Task MainProgram()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("=====================================");
                Console.WriteLine("Store Management System!");
                Console.WriteLine("=====================================");
                Console.WriteLine($"1-Items\n" +
                                  $"2-Customers\n" +
                                  $"3-Orders\n" +
                                  $"4-Reports\n" +
                                  $"5-Exit\n" );
                Console.WriteLine("--------------------------------------");

                Accessories.ReadIntNumber("your choise", out int nUserChoise);

                    switch (nUserChoise)
                    {
                        case 1: await _ItemMenu.SelectItemProgram(); break;
                        case 2: await _CustomerMenu.SelectCustomerProgram(); break;
                        case 3: await _OrderMenu.SelectOrderProgram(); break;
                        case 4: await _ReportsMenu.SelectReportProgram(); break;
                        case 5: Environment.Exit(0); break;
                        default:
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                            await Task.Delay(2000);
                            break;
                    }
            }
        }
        #endregion
    }
}
