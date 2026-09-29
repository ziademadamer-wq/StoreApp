
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Xml.Schema;

namespace Utilities
{
    public static class Accessories
    {
        
        public static void PrintMessage(string message)
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine(message);
            Console.WriteLine("-------------------------------------");
        }
        public static void ReadIntNumber(string fieledName, out int number,int min =0 , int max=0)
        {    
            Console.WriteLine($"please enter {fieledName}");
          bool IsConverted = (int.TryParse(Console.ReadLine(), out number))&&((number>=min && number<=max)||(min==0&&max==0));
            while (!IsConverted)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                IsConverted = (int.TryParse(Console.ReadLine(), out number)) && ((number >= min && number <= max) || (min == 0 && max == 0));
            }
        }
        public static void ReadDateTime(string fieledName, out DateTime Date)
        {
            Console.WriteLine($"please enter {fieledName}");
            bool IsConverted = DateTime.TryParse(Console.ReadLine(), out Date);
            while (!IsConverted)
            {
                Console.WriteLine("Invalid input. Please enter a valid Date and Time.");
                IsConverted = DateTime.TryParse(Console.ReadLine(), out Date);
            }
        }
        public static string InputString(string message)
        {
            Console.WriteLine($"please enter {message}");
            string? input = string.Empty;
            while (string.IsNullOrWhiteSpace(input))
            {
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("String cannot be empty. Please enter a valid string.");
                }
            }
            return input.Trim();
        }
        public static void CharInput(string StringName, out char c)
        {
            Console.WriteLine($"please enter {StringName}");
            c = Console.ReadKey().KeyChar;
            Console.WriteLine();
        }
        public static bool ReadQuestion(string message)
        {
            PrintMessage($"{message} y=Yes  n=No");

            string? sChoice = Console.ReadLine()?.Trim().ToLower();
            while (sChoice != "y" && sChoice != "n")
            {
                PrintMessage("please enter a valid character"); 
                sChoice = Console.ReadLine()?.Trim().ToLower();
            }
             if (sChoice == "n") return false;

            return true;
        }
        public static void Rezise<T>(ref T[] array, int newSize)
        {
            T[] newArray = new T[newSize];
            int lengthToCopy = Math.Min(array.Length, newSize);

            for (int i = 0; i < lengthToCopy; i++)
            {
                newArray[i] = array[i];
            }
            array = newArray;
        }
        public static void PrintArray<T>(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
                Console.WriteLine(array[i]);
        }

       public static T EnterPropertiesValues<T>(T model,int modelId=0)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Model cannot be null.");
            }
            foreach (var property in model.GetType().GetProperties())
            {
                if (property.CanWrite)
                {
                    try
                    {
                        if(property.Name.Equals("Id", StringComparison.OrdinalIgnoreCase) && modelId !=0)
                        {
                            property.SetValue(model, modelId);
                        }
                        else
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
                                    property.SetValue(model, convertedValue);
                                }
                                catch
                                {
                                    IsConverted = false;
                                    Console.WriteLine("Invalid input, please try again.");                  
                                }
                            }
                            while (!IsConverted);
                            
                        }
                    }
                    catch (FormatException ex)
                   {
                        Console.WriteLine(ex.Message);
                   }
                }
            }
            return model;
        }

        public static void PrintPropertiesValues<T>(T model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Model cannot be null.");
            }
            foreach (var property in model.GetType().GetProperties())
            {
                var value = property.GetValue(model);

                if (property.Name!= "CustomerId" && property.Name != "ItemId")       
                Console.WriteLine($"{property.Name}: {value}");
            }
        }

        public static void ShowValuesOfModels<T> (List<T> models)
        {
           
            foreach(var model in models)
            {
                var properties = model?.GetType().GetProperties();

                if (properties != null)
                {
                    var values = properties.Where(a=>a.Name!="CustomerId"&&a.Name!="ItemId")
                           .Select(p => $"{p.Name}:{p.GetValue(model)}");

                    Console.WriteLine(string.Join(",", values));
                }
            }
        }
        public static void ShowValuesOfModel<T>(T model)
        {
                var properties = model?.GetType().GetProperties();
                if (properties != null)
                    foreach (var property in properties)
                    {
                        var propertyName = property.Name;
                        var Value = property.GetValue(model);

                    if(propertyName != "CustomerId" && propertyName != "ItemId")
                        Console.WriteLine($"{propertyName}:{Value}");
                    }
                Console.WriteLine();    
        }
    }
}
