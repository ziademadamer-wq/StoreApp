using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Exceptions
{
    public class DataAccessException : Exception
    {
        public string CustomMessage { get; set; } 
        public DataAccessException(string customMessage) : base() 
        {
            CustomMessage = customMessage;
        }

        public DataAccessException(string message, string customMessage) : base(message) 
        { 
            CustomMessage = customMessage;
        }
        public DataAccessException(string message , string customMessage, Exception ex):base(message, ex)
        {
            CustomMessage = customMessage;
        }
    }
}
