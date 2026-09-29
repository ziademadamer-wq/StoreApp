using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Contracts
{
    public interface IConverter<T> where T : new()
    {
        public string _Convert(List<T> Items);

        public List<T> ConvertBack(string fileData);
    }
}
