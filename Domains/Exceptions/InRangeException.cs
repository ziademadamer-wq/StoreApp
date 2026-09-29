using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public class InRangeException : Exception
    {
        public string CustomMessage { get; set; }
        public InRangeException(string customMessage)
        {
            CustomMessage = customMessage;
        }
        public InRangeException(string message, string customMessage) : base(message)
        {
            CustomMessage = customMessage;
        }
        public InRangeException(string message, string customMessage, Exception innerException) : base(message, innerException)
        {
            CustomMessage = customMessage;
        }
    }
}
