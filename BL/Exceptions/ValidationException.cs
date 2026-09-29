using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public class ValidationException : Exception
    {
        public string CustomMessage { get; set; }
        public ValidationException(string customMessage)
        {
            CustomMessage = customMessage;
        }
        public ValidationException(string message, string customMessage) : base(message)
        {
            CustomMessage = customMessage;
        }
        public ValidationException(string message, string customMessage, Exception innerException) : base(message, innerException)
        {
            CustomMessage = customMessage;
        }
    }
}
