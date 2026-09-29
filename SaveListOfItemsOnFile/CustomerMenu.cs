using BL;
using BL.Exceptions;
using ConsoleApp1;
using Domains;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities;
namespace StoreApp
{
    public class CustomerMenu
    {
        BusinessLayer<Customer> _BL;
        public CustomerMenu(BusinessLayer<Customer> BL)
        {
            _BL = BL;
        }
        public async Task SelectCustomerProgram()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("=====================================");
                Console.WriteLine("Customers Menu");
                Console.WriteLine("=====================================");
                Console.WriteLine($"1-Add New model\n" +
                                  $"2-Get model by Id\n" +
                                  $"3-Update model\n" +
                                  $"4-Delete model\n" +
                                  $"5-Show Customers\n" +
                                  $"6-Back to main menu\n" +
                                  $"7-Exit\n");
                Console.WriteLine("--------------------------------------");

                Accessories.ReadIntNumber("your choise", out int nUserChoise);
                switch (nUserChoise)
                {
                    case 1: await AddNewCustomer(); break;
                    case 2: await GetCustomerById(); break;
                    case 3: await UpdateCustomer(); break;
                    case 4: await DeleteCustomer(); break;
                    case 5: await ShowCustomers(); break;
                    case 6: return;
                    case 7: Environment.Exit(0); break;
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

        public async Task AddNewCustomer()
        {
            try
            {
                var NewCustomer = new Customer();
                NewCustomer = Accessories.EnterPropertiesValues(NewCustomer);
               await _BL.AddItem(NewCustomer);
                Console.WriteLine("Customer added successfully");
            }
            catch (BusinessException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async Task GetCustomerById()
        {
            try
            {
                Accessories.ReadIntNumber("Customer Id that you want to retrieve", out int CustomerGotId);
                var CustomerGotById = new Customer();
                   CustomerGotById = await _BL.GetById(CustomerGotId);
                if (CustomerGotById != null)
                {
                    Accessories.PrintPropertiesValues(CustomerGotById);
                }
            }
            catch (BusinessException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public async Task UpdateCustomer()
        {
            try
            {
                Accessories.ReadIntNumber("Customer Id that you want to Update", out int UpdatedCustomerId);
                var OldCustomer = await _BL.GetById(UpdatedCustomerId);

                var UpdatedCustomer = new Customer();
                foreach (var property in UpdatedCustomer.GetType().GetProperties())
                {
                    if (property.CanWrite)
                    {
                        try
                        {
                            if (property.Name.Equals("Id", StringComparison.OrdinalIgnoreCase))
                            {
                                property.SetValue(UpdatedCustomer, OldCustomer.Id);
                            }
                            else
                            {
                                var OldValue = property.GetValue(OldCustomer);
                                Console.WriteLine($"the value of {property.Name} ({OldValue})");
                                if (Accessories.ReadQuestion("Do you want to change the value?"))
                                {
                                    Console.Write($"please enter the value of {property.Name}");
                                    var input = Console.ReadLine();
                                    var convertedValue = Convert.ChangeType(input, property.PropertyType);
                                    property.SetValue(UpdatedCustomer, convertedValue);
                                }
                                else
                                    property.SetValue(UpdatedCustomer, OldValue);
                            }
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    
                }
                await _BL.Update(UpdatedCustomer);
                Console.WriteLine("Customer has been updated successfully");
            }         
            catch (BusinessException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async Task DeleteCustomer()
        {
            try
            {
                Accessories.ReadIntNumber("Customer Id that you want to Delete", out int customerToDeleteId);
                await _BL.Delete(customerToDeleteId);
                Console.WriteLine("Customer has been Deleted successfully");
            }
            catch (BusinessException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async Task ShowCustomers ()
        {
            try
            {
                var Customers = await _BL.GetData();
                Accessories.ShowValuesOfModels(Customers);
            }
            catch (BusinessException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}
    