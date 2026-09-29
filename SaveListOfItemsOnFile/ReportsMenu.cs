using BL;
using BL.Exceptions;
using Domains;
using Domains.Reports_Class;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities;
namespace StoreApp
{
    public class ReportsMenu
    {
       private readonly IOrderReportsService _OrderReportsService;

        public ReportsMenu(IOrderReportsService orderReportsService)
        {
            _OrderReportsService = orderReportsService;
        }
        public async Task SelectReportProgram()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("============= REPORTS MENU ================");
                Console.WriteLine($"1) Total Sales Summary\n" +
                                  $"2) Sales By Customer\n" +
                                  $"3) Sales By Item\n" +
                                  $"4) Top Customers (Top 5)\n" +
                                  $"5) Top Items (Top 5)\n" +
                                  $"6) Back to main menu\n");
                Console.WriteLine("--------------------------------------");

                Accessories.ReadIntNumber("your choise", out int nUserChoise);
                switch (nUserChoise)
                {
                    case 1:
                        await TotalSalesSummary();
                        break;
                    case 2:
                        await SalesByCustomer();
                        break;
                    case 3:
                        await SalesByItem();
                        break;
                    case 4:
                        await TopCustomers();
                        break;
                    case 5:
                        await TopItems();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                        await Task.Delay(2000); // Wait for 2 seconds before re-prompting
                        break;
                }
                await Task.Delay(2000);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        public async Task TotalSalesSummary()
        {
            try
            {
                Console.WriteLine("============= Total Sales Summary ================");
                var TotalSales = await _OrderReportsService.TotalSalesSummary();
                Console.WriteLine($"CountOrder: {TotalSales.CountOrder} TotalPrice: {TotalSales.TotalPrice}");
            }
            catch (BusinessException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async Task SalesByCustomer()
        {
            try
            {
                Console.WriteLine("============= Sales By Customer ================");
                var Result = await  _OrderReportsService.SalesByCustomer();
              
                foreach (var customer in Result)
                    Console.WriteLine($"id: {customer.Id} Name: {customer.Name} OrderCount: {customer.OrderCount} TotalPrice: {customer.TotalPrice}");
            }
            catch (BusinessException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public async Task SalesByItem()
        {
            try
            {
                Console.WriteLine("============= Sales By Item ================");
                var Result = await _OrderReportsService.SalesByItem();

                foreach (var Item in Result)
                    Console.WriteLine($"id: {Item.Id} Name: {Item.Name} OrderCount: {Item.OrderCount} TotalPrice: {Item.TotalPrice}");
            }
            catch (BusinessException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async Task TopCustomers()
        {
            try
            {
                Console.WriteLine("============= Top Customers ================");
                Accessories.ReadIntNumber("the number of Customers you want to show",out int Count);
                var Result = await _OrderReportsService.TopCustomers(Count);

                foreach (var Item in Result)
                    Console.WriteLine($"id: {Item.Id} Name: {Item.Name} OrderCount: {Item.OrderCount} TotalPrice: {Item.TotalPrice}");
            }
            catch (BusinessException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async Task TopItems()
        {
            try
            {
                Console.WriteLine("============= Top Items ================");
                Accessories.ReadIntNumber("the number of Items you want to show", out int Count);
                var Result = await _OrderReportsService.TopItems(Count);

                foreach (var Item in Result)
                    Console.WriteLine($"id: {Item.Id} Name: {Item.Name} OrderCount: {Item.OrderCount} TotalPrice: {Item.TotalPrice}");
            }
            catch (BusinessException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
