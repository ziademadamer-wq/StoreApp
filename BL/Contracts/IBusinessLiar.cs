using DAL;
using DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public interface IBusinessLayer<T> where T :IHasId, new()
    {
     
        public Task AddItem(T item);

        public Task<T?> GetById(int itemId);
        public Task Update(T item);
        public Task Delete(int itemId);

        public Task<List<T>> GetData();
        public bool Validate(T model);
    }
}
