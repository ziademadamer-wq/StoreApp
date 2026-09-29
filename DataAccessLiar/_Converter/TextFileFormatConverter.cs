using DAL.Contracts;
using DAL.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities;

namespace DAL
{
    public class TextFileFormatConverter<T>:IConverter<T> where T : new ()
    {
        public string _Convert(List<T> models)
        {
            StringBuilder content = new StringBuilder();
            foreach (var model in models)
            {
                foreach (var prop in typeof(T).GetProperties())
                {
                    content.AppendLine($"{prop.Name}#{prop.GetValue(model)}");
                }
                content.AppendLine("");
            }
            
            return content.ToString();
        }
        public List<T> ConvertBack(string fileData)
        {
            try
            {
                var list = new List<T>();
                if (string.IsNullOrWhiteSpace(fileData))
                    return list;

                var model = new T();

                using var Reader = new StringReader(fileData);
                string? line;

                while ((line = Reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        list.Add(model);
                        model = new T();
                        continue;
                    }


                    int separatorIndex = line.IndexOf('#');
                    if (separatorIndex == -1)
                    {
                        continue;
                    }

                    string key = line[..separatorIndex];
                    string value = line[(separatorIndex+1)..];

                    var PropOfmodel = typeof(T).GetProperty(key);
                    if (PropOfmodel != null && value != null)
                    {
                        object convertedValue = Convert.ChangeType(value, PropOfmodel.PropertyType);
                        PropOfmodel.SetValue(model, convertedValue);
                    }

                }
                if (model!=null)
                {
                    list.Add(model);
                } // precaution for the last model 
                return list;
            }
            catch(Exception ex)
            {
                throw new SerilizationException("Error parsing text file content", "",ex);
            }
           
        }
    }
}
