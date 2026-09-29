using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public class EmailAddressException : Exception
    {
        public string CustomMessage { get; set; }
        public EmailAddressException(string customMessage)
        {
            CustomMessage = customMessage;
        }
        public EmailAddressException(string message, string customMessage) : base(message)
        {
            CustomMessage = customMessage;
        }
        public EmailAddressException(string message, string customMessage, Exception innerException) : base(message, innerException)
        {
            CustomMessage = customMessage;
        }
    }
}
