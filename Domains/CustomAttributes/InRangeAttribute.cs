using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;
namespace Domains
{
    [AttributeUsage(AttributeTargets.Property)]
    public class InRangeAttribute:Attribute
    {
        public InRangeAttribute(double min, double max)
        {
            Min = min;
            Max = max;
        }

        public double Min { get; set; }
        public double Max { get; set; }

       public bool IsValid(object value)
        {
            if (value == null) return false;

            try
            {
                decimal numericValue = Convert.ToDecimal(value);
                return (double)numericValue >= Min && (double)numericValue <= Max;
            }
            catch
            {
                // Not a numeric type
                return false;
            }
        }

    }
    [AttributeUsage(AttributeTargets.Property)]
    public class LengthAttribute : Attribute
    {
        public LengthAttribute(int minLength, int maxLength)
        {
            MinLength = minLength;
            MaxLength = maxLength;
        }
        public int MaxLength { get; set; }
        public int MinLength { get; set; }

      public bool IsValid(string value)
        {
            if (value.Length < MinLength || value.Length > MaxLength)
                return false;

            return true;
        }

    }

    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLengthAttribute : Attribute
    {
        public MaxLengthAttribute(int maxLength)
        {
            MaxLength = maxLength;
        }
        public int MaxLength { get; set; }

      public  bool IsValid(string value)
        {
            if (value.Length > MaxLength)
                return false;
            return true;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class MinLengthAttribute : Attribute
    {
        public MinLengthAttribute(int minLength)
        {
            MinLength = minLength;
        }
        public int MinLength { get; set; }

       public bool IsValid(string value)
        {
            if (value.Length < MinLength)
                return false;
            return true;
        }

    }
    [AttributeUsage(AttributeTargets.Property)]
    public class IsRequired : Attribute
    {
       public bool IsValid(object? value)
        {

            if (value == null)
                return false;

            switch (value)
            {
                case int intValue:
                    return intValue > 0;

                case long longValue:
                    return longValue > 0;

                case decimal decimalValue:
                    return decimalValue > 0;

                case double doubleValue:
                    return doubleValue > 0;

                case string stringValue:
                    return !string.IsNullOrWhiteSpace(stringValue);

                default:
                    return true;
            }
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class PhoneAttribute : Attribute
    {
      public  bool IsValid(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            if(!value.All(char.IsDigit))
                return false;

            if (value.Length != 11|| value[0] != '0'||value [1] != '1' || !long.TryParse(value, out _))
                return false;

            return true;
        }

    }
    [AttributeUsage(AttributeTargets.Property)]
    public class EmailAttribute : Attribute
    {
        // Simple regex for email validation
        private const string EmailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        public bool IsValid(object? value)
        {
            if (value == null)
                return false;

            string? email = value.ToString();

            if (Regex.IsMatch(email, EmailPattern))
            {
                return true;
            }

            return false;
        }
    }
    
}
