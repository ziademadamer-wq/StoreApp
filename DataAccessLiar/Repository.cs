using DAL.Contracts;
using DAL.Exceptions;
using Domains;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Utilities;

namespace DAL
{
    public class Repository<T>: IRepository<T> where T : IHasId , new()
    {
        private readonly IConverter<T> _ItemConverter;
        private readonly string? FileName;
        public Repository(IConverter<T> itemConverter)
        {
            _ItemConverter = itemConverter;
           
            var attr = typeof(T).GetCustomAttribute<FileNameAttribute>();
            switch (itemConverter)
            {
                case TextFileFormatConverter<T>:
                    FileName = (attr?.FileName+".txt")?? $"{typeof(T).Name.ToLower()}.txt";
                    break;
                case JsonSerializer<T>:
                    FileName = (attr?.FileName + ".json") ?? $"{typeof(T).Name.ToLower()}.json";
                    break;
           
            }
                
        }

        public async Task AddItem(T item)
        {
            try
            {
                var Items = await GetData();
                Items.Add(item);

                string TextContent = _ItemConverter._Convert(Items);

                await FileHelper.WriteToFile(FileName, TextContent);
            }
            catch (Exception ex)
            {
                throw new DataAccessException("An error occurred while adding the item.", "Failed to add item", ex);
            }
        }

        public async Task<T?> GetById(int itemId)
        {
            try
            {
                var Items = await GetData();
                var item = Items.Where(i => i.Id == itemId).FirstOrDefault();
                if (item == null)
                    throw new NotFoundException(nameof(item), "Item cannot be null.");

                return item;
            }
            catch (SerilizationException ex)
            {
                return new T();
            }
            catch
            {
                throw new DataAccessException($"An error occurred while finding an item with id {itemId}.", "Item Not Found");
            }
        }
        public async Task Update(T item)
        {
          
            try
            {
                //get all
                var Items = await GetData();
                    
                //get item by id
                var existingItem = Items.Where(i => i.Id == item.Id).FirstOrDefault();

                    //remove item from list
                    foreach (var property in existingItem.GetType().GetProperties())
                    {
                        if (property.CanWrite && property.Name != nameof(item.Id))
                        {
                          var UpdatedValue = property.GetValue(item);
                          property.SetValue(existingItem, UpdatedValue);        
                        }
                    }
                    //update the file
                    var ItemString = _ItemConverter._Convert(Items);
                    await FileHelper.WriteToFile(FileName, ItemString);
            }
            catch (Exception ex)
            {
                throw new DataAccessException($"An error occurred while updating the item with id {item.Id}.", "Failed to update item", ex);
            }
        }
        public async Task Delete(int itemId)
        {
            try
            {
                //get all
                var Items = await GetData();

                //get item by id
                var item = Items.FirstOrDefault(i => i.Id == itemId);
                if (item == null)
                    throw new NotFoundException($"model {itemId} is Not Found !");
                    //remove item from list
                    Items.Remove(item);

                    //update the file
                    var ItemString = _ItemConverter._Convert(Items);
                    await FileHelper.WriteToFile(FileName, ItemString);
             
            }
            catch (Exception ex)
            {
                throw new DataAccessException($"An error occurred while deleting the item with id {itemId}.", "Failed to delete item", ex);
            }

        }

        public async Task<List<T>> GetData()
        {
            try
            {
                string FileData = await FileHelper.ReadFile(FileName);
                return _ItemConverter.ConvertBack(FileData);
            }
            catch(SerilizationException ex)
            {
                return new List<T>();
            }
            catch (Exception ex)
            {
                throw new DataAccessException("An error occurred while extracting items from data source.", "Failed to extract items from data source.", ex);
            }
        }

    }
}
