using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public class LengthException : Exception
    {
        public string CustomMessage { get; set; }
        public LengthException(string customMessage)
        {
            CustomMessage = customMessage;
        }
        public LengthException(string message, string customMessage) : base(message)
        {
            CustomMessage = customMessage;
        }
        public LengthException(string message, string customMessage, Exception innerException) : base(message, innerException)
        {
            CustomMessage = customMessage;
        }
    }
}
