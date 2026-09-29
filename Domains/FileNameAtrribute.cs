using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class FileNameAttribute : Attribute
    {
        public string FileName { get; }
        public FileNameAttribute(string fileName)
        {
            FileName = (fileName);
        }
    
    }
}
