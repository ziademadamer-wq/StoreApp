using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public class MaxLengthException : Exception
    {
        public string CustomMessage { get; set; }
        public MaxLengthException(string customMessage)
        {
            CustomMessage = customMessage;
        }
        public MaxLengthException(string message, string customMessage) : base(message)
        {
            CustomMessage = customMessage;
        }
        public MaxLengthException(string message, string customMessage, Exception innerException) : base(message, innerException)
        {
            CustomMessage = customMessage;
        }
    }
}
