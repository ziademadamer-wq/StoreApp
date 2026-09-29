using BL.Exceptions;
using DAL;
using DAL.Contracts;
using DAL.Exceptions;
using Domains;
using Domains.ValidationAttribute;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Utilities;
namespace BL
{
    public class BusinessLayer<A> : IBusinessLayer<A> where A : IHasId, new()
    {
        private readonly IRepository<A> _Repository;
        public BusinessLayer(StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.JsonFile:
                _Repository = new Repository<A>(new JsonSerializer<A>());
                break;
                case StorageType.TextFile:
                _Repository = new Repository<A>(new TextFileFormatConverter<A>());
                break;
            }
        }

 
            
        public async Task AddItem(A item)
        {
            try
            {
                if(!Validate(item))
                    throw new ValidationException("Validation failed", "The item did not pass validation.");
                
                await _Repository.AddItem(item);
            }
            catch (DataAccessException ex)
            {
                throw new BusinessException("Error adding item", "An error occurred while adding the item.", ex);
            }
        }

        public async Task<A?> GetById(int itemId)
        {
            try
            {
                if(itemId <= 0)
                    throw new ValidationException("Validation failed", "The item ID did not pass validation.");

                var model =  await _Repository.GetById(itemId);
                return model;
            }
            catch (DataAccessException ex)
            {
                throw new BusinessException("Error retrieving item", "An error occurred while retrieving the item.", ex);
            }
        }
        public async Task Update(A item)
        {
            try
            {
                if(!Validate(item))
                    throw new ValidationException("Validation failed", "The item did not pass validation.");
                await _Repository.Update(item);
            }
            catch (DataAccessException ex)
            {
                throw new BusinessException("Error updating item", "An error occurred while updating the item.", ex);
            }
        }
        public async Task Delete(int itemId)
        {
            try
            {
                if(itemId <= 0)
                    throw new ValidationException("Validation failed", "The item ID did not pass validation.");

                await _Repository.Delete(itemId);
            }
            catch (DataAccessException ex)
            {
                throw new BusinessException("Error deleting item", "An error occurred while deleting the item.", ex);
            }
        }

        public async Task<List<A>> GetData()
        {
            try
            {
                var models = await _Repository.GetData();
                if (models == null)
                    throw new NotFoundException("Error retrieving data", "No data found.");

                return models;
            }
            catch (DataAccessException ex)
            {
                throw new BusinessException("Error retrieving data", "An error occurred while retrieving the data.", ex);
            }
        }
        public bool Validate (A model)
        {
          IValidator<A> validator = new Validator<A>();
            return validator.Validate(model);
        }
    }
}


