using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Exceptions
{
    public class BusinessException : Exception
    {
        public string CustomMessage { get; set; } 
        public BusinessException(string customMessage)
        {
            CustomMessage = customMessage;
        }
        public BusinessException(string message,string customMessage) :base(message)
        {
            CustomMessage = customMessage;
        }
        public BusinessException(string message, string customMessage, Exception innerException):base(message, innerException)
        {
            CustomMessage = customMessage;
        }

    }
}
