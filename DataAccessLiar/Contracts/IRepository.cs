using DAL.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities;

namespace DAL.Contracts
{
    public  interface IRepository<T> where T :IHasId ,new()
    {
        public Task AddItem(T item);

        public  Task<T?> GetById(int itemId);
        public  Task Update(T item);
        public  Task Delete(int itemId);

        public  Task<List<T>> GetData();
       
    }
}
