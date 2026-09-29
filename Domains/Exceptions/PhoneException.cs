using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public class PhoneException : Exception
    {
        public string CustomMessage { get; set; }
        public PhoneException(string customMessage)
        {
            CustomMessage = customMessage;
        }
        public PhoneException(string message, string customMessage) : base(message)
        {
            CustomMessage = customMessage;
        }
        public PhoneException(string message, string customMessage, Exception innerException) : base(message, innerException)
        {
            CustomMessage = customMessage;
        }
    }
}
