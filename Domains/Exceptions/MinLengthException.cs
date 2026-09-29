using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public class MinLengthException : Exception
    {
        public string CustomMessage { get; set; }
        public MinLengthException(string customMessage)
        {
            CustomMessage = customMessage;
        }
        public MinLengthException(string message, string customMessage) : base(message)
        {
            CustomMessage = customMessage;
        }
        public MinLengthException(string message, string customMessage, Exception innerException) : base(message, innerException)
        {
            CustomMessage = customMessage;
        }
    }
}
