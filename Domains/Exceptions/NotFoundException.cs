using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public class NotFoundException : Exception
    {
        public string CustomMessage { get; set; }
        public NotFoundException(string customMessage)
        {
            CustomMessage = customMessage;
        }
        public NotFoundException(string message, string customMessage) : base(message)
        {
            CustomMessage = customMessage;
        }
        public NotFoundException(string message, string customMessage, Exception innerException) : base(message, innerException)
        {
            CustomMessage = customMessage;
        }
    }
}
