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
    public class ItemMenu
    {
        BusinessLayer<Item> _BL;
        public ItemMenu(BusinessLayer<Item> BL)
        {
            _BL = BL;
        }
        public async Task SelectItemProgram()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("=====================================");
                Console.WriteLine("Item Menu");
                Console.WriteLine("=====================================");
                Console.WriteLine($"1-Add New model\n" +
                                  $"2-Get model by Id\n" +
                                  $"3-Update model\n" +
                                  $"4-Delete model\n" +
                                  $"5-Show Items\n" +
                                  $"6-Back to main menu\n" +
                                  $"7-Exit\n");
                Console.WriteLine("--------------------------------------");

               Accessories.ReadIntNumber("your choise", out int nUserChoise);
                switch (nUserChoise)
                {
                    case 1: await AddNewItem(); break;
                    case 2: await GetItemById(); break;
                    case 3: await UpdateItem();  break;
                    case 4: await DeleteItem(); break;
                    case 5: await ShowItems();  break;
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
        public async Task AddNewItem()
        {
            try
            {
                var NewItem = new Item();
                NewItem = Accessories.EnterPropertiesValues(NewItem);
                await _BL.AddItem(NewItem);
                Console.WriteLine("Item added successfully");
            }
            catch (BusinessException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async Task GetItemById()
        {
            try
            {
                Accessories.ReadIntNumber("Item Id that you want to retrieve", out int ItemGotId);

                var ItemGotById = new Item();
                   ItemGotById= await _BL.GetById(ItemGotId);
                if (ItemGotById != null)
                {
                    Accessories.PrintPropertiesValues(ItemGotById);
                }
            }
            catch (BusinessException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public async Task UpdateItem()
        {
            try
            {
                Accessories.ReadIntNumber("Item Id that you want to Update", out int UpdatedItemId);
               var OldItem = await _BL.GetById(UpdatedItemId);
               
                var UpdatedItem = new Item();
                foreach (var property in UpdatedItem.GetType().GetProperties())
                {
                    if (property.CanWrite)
                    {
                        try
                        {
                            if (property.Name.Equals("Id", StringComparison.OrdinalIgnoreCase))
                            {
                                property.SetValue(UpdatedItem, OldItem.Id);
                            }
                            else
                            {
                                var OldValue = property.GetValue(OldItem);
                                Console.WriteLine($"the value of {property.Name} ({OldValue})");
                                if(Accessories.ReadQuestion("Do you want to change the value?"))
                                {
                                    bool IsConverted;
                                    do
                                    {
                                        IsConverted = true;
                                        Console.Write($"please enter the value of {property.Name}: ");
                                        var input = Console.ReadLine();
                                        try
                                        {   
                                            var convertedValue = Convert.ChangeType(input, property.PropertyType);
                                            property.SetValue(UpdatedItem, convertedValue);
                                        }
                                        catch
                                        {
                                            IsConverted = false;
                                            Console.WriteLine("Invalid input, please try again.");
                                        }
                                    }
                                    while (!IsConverted);
                                  
                                }   
                                else
                                    property.SetValue(UpdatedItem, OldValue);

                            }
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }

                await _BL.Update(UpdatedItem);

                Console.WriteLine("Item has been updated successfully");
            }
            catch (BusinessException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async Task DeleteItem()
        {
            try
            {
                Accessories.ReadIntNumber("Item Id that you want to Delete", out int ItemToDeleteId);
                await _BL.Delete(ItemToDeleteId);
                Console.WriteLine("Item has been Deleted successfully");
            }
            catch (BusinessException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async Task ShowItems()
        {
            try
            {
              var Items=  await _BL.GetData();
                Accessories.ShowValuesOfModels(Items);
            }
            catch (BusinessException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
