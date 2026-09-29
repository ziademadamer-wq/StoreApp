using BL;
using BL.Exceptions;
using ConsoleApp1;
using Domains;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Utilities;
namespace StoreApp
{
    public class OrderMenu
    {
      private readonly  BusinessLayer<Order> _OrderBL;
        private readonly BusinessLayer<Customer> _CustomerBL;
        private readonly BusinessLayer<Item> _ItemBL;

        public OrderMenu(BusinessLayer<Order> OrderBL,
             BusinessLayer<Customer> CustomerBL,
             BusinessLayer<Item> ItemBL)
        {
            _OrderBL = OrderBL;
            _CustomerBL = CustomerBL;
            _ItemBL = ItemBL;
        }
        public async Task SelectOrderProgram()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("=====================================");
                Console.WriteLine("Orders Menu");
                Console.WriteLine("=====================================");
                Console.WriteLine($"1-Add New model\n" +
                                  $"2-Get model by Id\n" +
                                  $"3-Update model\n" +
                                  $"4-Delete model\n" +
                                  $"5-Show Orders\n" +
                                  $"6-Back to main menu\n" +
                                  $"7-Exit\n");
                Console.WriteLine("--------------------------------------");

                Accessories.ReadIntNumber("your choise", out int nUserChoise);
                    switch (nUserChoise)
                    {
                        case 1: await AddNewOrder(); break;
                        case 2: await GetOrderById(); break;
                        case 3: await UpdateOrder(); break;
                        case 4: await DeleteOrder(); break;
                        case 5: await ShowOrders(); break;
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
        public async Task AddNewOrder()
        {
            try
            {
                var NewOrder = new Order();

                Accessories.ReadIntNumber("the Order Id: ", out int _OrderId);
                NewOrder.Id = _OrderId;

                //Choose Customer and Item
                bool IsFilled = await FillCustomerAndItem(NewOrder);

               
                //save the Order Info
                if(IsFilled)
                { 
                  await _OrderBL.AddItem(NewOrder);
                  Console.WriteLine("Order added successfully");
                }
            }
            catch (BusinessException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async Task<bool> UpdateCustomerAndItem(Order order)
        {
            bool IsUpdated = false;
            Console.WriteLine($"the value of CustomerName ({order.CustomerName})");
            if (Accessories.ReadQuestion("Do you want to change the value?"))
            {
                //Customers To Choose
                var Customers = await _CustomerBL.GetData();
                Console.Clear();
                Console.WriteLine("---------------------------------");
                Accessories.ShowValuesOfModels(Customers);
                Console.WriteLine("---------------------------------");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("");

                //choose the customer
                Accessories.ReadIntNumber("The ID of the Customer you want ", out int CustomerId);

                //select the customer
                var Customer = Customers.FirstOrDefault(s => s.Id == CustomerId);

                if (Customer != null)
                {
                    order.CustomerName = Customer.Name;
                    IsUpdated = true;
                }
                else
                {
                    Console.WriteLine("That Order is not Found!");
                    return false;
                }
            }
           Console.WriteLine($"the Name of Item ({order.Name})");
            if (Accessories.ReadQuestion("Do you want to change the value?"))
            {
                //Items To Choose
                var Items = await _ItemBL.GetData();
                Console.Clear();
                Console.WriteLine("There is a list of Items");
                Console.WriteLine("---------------------------------");
                Accessories.ShowValuesOfModels(Items);
                Console.WriteLine("---------------------------------");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("");

                Accessories.ReadIntNumber("The ID of The Item you want ", out int ItemId);


                var Item = Items.FirstOrDefault(a => a.Id == ItemId);
                if (Item != null)
                {
                    order.Name = Item.Name;
                    IsUpdated = true;
                }
                else
                {
                    Console.WriteLine("Item is not Found");
                    return false;
                }
                order.Price = Item.Price;
                //Quantity of Order
                Accessories.ReadIntNumber("the Quantity: ", out int _Quantity);
                order.Quantity = _Quantity;

                //Price of order
                order.TotalPrice = Item.Price * _Quantity;
            }
            else
            {
                Console.WriteLine($"the Quantity of Item ({order.Quantity})");
                if (Accessories.ReadQuestion("Do you want to change the value?"))
                {
                    Accessories.ReadIntNumber("the Quantity: ", out int _Quantity);
                    order.Quantity = _Quantity;
                    //Price of order
                    order.TotalPrice = order.Price * _Quantity;
                    IsUpdated = true;
                }
            }
            return IsUpdated;
        }
        
        public async Task<bool> FillCustomerAndItem(Order order)
        {
                //Customers To Choose
                var Customers = await _CustomerBL.GetData();
                Console.Clear();
                Console.WriteLine("---------------------------------");
                Accessories.ShowValuesOfModels(Customers);
                Console.WriteLine("---------------------------------");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("");

                //choose the customer
                Accessories.ReadIntNumber("The ID of the Customer you want ", out int CustomerId);

                //select the customer
                var Customer = Customers.FirstOrDefault(s => s.Id == CustomerId);

                if (Customer != null)
                {
                    order.CustomerId = CustomerId;
                    order.CustomerName = Customer.Name;
                }
                else
                {
                    Console.WriteLine("That Order is not Found!");
                    return false;
                }
            
           
                //Items To Choose
                var Items = await _ItemBL.GetData();
                Console.Clear();
                Console.WriteLine("There is a list of Items");
                Console.WriteLine("---------------------------------");
                Accessories.ShowValuesOfModels(Items);
                Console.WriteLine("---------------------------------");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("");

                Accessories.ReadIntNumber("The ID of The Item you want ", out int ItemId);


                var Item = Items.FirstOrDefault(a => a.Id == ItemId);
                if (Item != null)
                {
                order.ItemId = ItemId;
                order.Name = Item.Name;
                }           
                else
                {
                    Console.WriteLine("Item is not Found");
                    return false;
                }
                //Quantity of Order
                Accessories.ReadIntNumber("the Quantity: ", out int _Quantity);
                order.Quantity = _Quantity;

            //Price of order
            order.Price = Item.Price;
            order.TotalPrice = Item.Price * _Quantity;
            
            return true;
        }
        public async Task GetOrderById()
        {
            try
            {
                Accessories.ReadIntNumber("Order Id that you want to retrieve", out int OrderGotId);

                var OrderGotById = new Order();
                 OrderGotById = await _OrderBL.GetById(OrderGotId);
                if (OrderGotById != null)
                {
                    Accessories.PrintPropertiesValues(OrderGotById);
                }
            }
            catch (BusinessException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public async Task UpdateOrder()
        {
            try
            {
                Accessories.ReadIntNumber("Order Id that you want to Update", out int UpdatedOrderId);
                var OldOrder = await _OrderBL.GetById(UpdatedOrderId);
                
               bool IsSuccessed = await UpdateCustomerAndItem(OldOrder);
               
                if(IsSuccessed)
                {
                  OldOrder.OrderDate = DateTime.Now;  
                  await _OrderBL.Update(OldOrder);
                  Console.WriteLine("Order has been updated successfully");
                }
            }
               catch (BusinessException ex)
               {
                 Console.WriteLine(ex.Message);
               }
}
        public async Task DeleteOrder()
        {
            try
            {
                Accessories.ReadIntNumber("Order Id that you want to Delete", out int orderToDeleteId);
                await _OrderBL.Delete(orderToDeleteId);
                Console.WriteLine("Order has been Deleted successfully");
            }
            catch (BusinessException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async Task ShowOrders()
        {
            try
            {
               var Orders = await _OrderBL.GetData();
                Accessories.ShowValuesOfModels(Orders);
            }
            catch (BusinessException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
