using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public class IsRequiredException : Exception
    {
        public string CustomMessage { get; set; }
        public IsRequiredException(string customMessage)
        {
            CustomMessage = customMessage;
            PrintMessage(customMessage);
        }
        public IsRequiredException(string message, string customMessage) : base(message)
        {
            CustomMessage = customMessage;
            PrintMessage(customMessage); 
        }
        public IsRequiredException(string message, string customMessage, Exception innerException) : base(message, innerException)
        {
            CustomMessage = customMessage;
            PrintMessage(customMessage);
        }
        void PrintMessage (string customMessage)
        {
            Console.WriteLine(customMessage);
        }
    }
}
