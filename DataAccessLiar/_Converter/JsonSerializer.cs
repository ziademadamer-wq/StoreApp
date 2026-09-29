using DAL.Contracts;
using DAL.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
namespace DAL
{
    public class JsonSerializer<T> : IConverter<T> where T : new()
    {
        public string _Convert(List<T> Models)
        {

          return JsonSerializer.Serialize(Models);
        }
        public List<T> ConvertBack(string fileData)
        {
            try
            {
                return JsonSerializer.Deserialize<List<T>>(fileData);
            }
           catch(Exception ex)
           {
                throw new SerilizationException("Error converting Data from JSON", "File is not found", ex);
           }
        }

    }
}
