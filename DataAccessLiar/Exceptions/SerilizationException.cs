using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Exceptions
{
    public class SerilizationException:Exception
    {
        public string CustomMessage { get; set; }
        public SerilizationException(string customMessage) : base()
        {
            CustomMessage = customMessage;
        }

        public SerilizationException(string message, string customMessage) : base(message)
        {
            CustomMessage = customMessage;
        }
        public SerilizationException(string message, string customMessage, Exception ex) : base(message, ex)
        {
            CustomMessage = customMessage;
        }
    }
}
