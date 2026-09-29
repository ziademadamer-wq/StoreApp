using DAL;
using System;
using System.Collections.Generic;
using System.Text;
namespace Domains.ValidationAttribute
{
    public interface IValidator<T> where T : new()
    {
        public bool Validate(T model);
    }
    public class Validator<T> : IValidator<T> where T : IHasId, new()
    {
        public bool Validate(T model)
        {
            //1. Check if the model is null
            if (model == null)
                throw new NotFoundException($"Model of type {typeof(T).Name} is null.");

            //2. Check if the model is null
            if (model.Id <= 0)
                throw new ArgumentException($"Model of type {typeof(T).Name} has an invalid ID.");


            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                if (property.Name.Equals("Id", StringComparison.OrdinalIgnoreCase))
                    continue;

                var attributes = property.GetCustomAttributes(typeof(Attribute), true);
                foreach (var attribute in attributes)
                {
                    var value = property.GetValue(model);
                    if (attribute is IsRequired isRequiredAttribute)
                    {
                        if (!isRequiredAttribute.IsValid(value))
                            throw new IsRequiredException($"Property {property.Name} is required.");
                    }
                    else if (attribute is InRangeAttribute inRangeAttribute)
                    {
                        try
                        {
                            decimal numericValue = Convert.ToDecimal(value);

                            if (!inRangeAttribute.IsValid(numericValue))
                            {
                                throw new InRangeException($"Property {property.Name} is out of range. Expected between {inRangeAttribute.Min} and {inRangeAttribute.Max}.");
                            }
                        }
                        catch(FormatException)
                        {
                            throw new InvalidOperationException($"Property {property.Name} must be a numeric type to use InRangeAttribute.");
                        }
                    }
                    else if (attribute is LengthAttribute lengthAttribute)
                    {
                        if (value is string stringValue)
                        {
                            if (!lengthAttribute.IsValid(stringValue))
                                throw new LengthException($"Property {property.Name} has an invalid length.");
                        }
                        else
                        throw new InvalidOperationException($"Property {property.Name} is not a string.");
                    }
                    else if (attribute is MaxLengthAttribute maxLengthAttribute)
                    {
                        if (value is string stringValue)
                        {
                            if (!maxLengthAttribute.IsValid(stringValue))
                                throw new MaxLengthException($"Property {property.Name} exceeds the maximum length.");
                        }
                        else
                        throw new InvalidOperationException($"Property {property.Name} is not a string.");
                    }
                    else if (attribute is MinLengthAttribute minLengthAttribute)
                    {
                        if (value is string stringValue)
                        {
                            if (!minLengthAttribute.IsValid(stringValue))
                                throw new MinLengthException($"Property {property.Name} does not meet the minimum length.");
                        }
                        else
                        throw new InvalidOperationException($"Property {property.Name} is not a string.");
                    }
                    else if (attribute is EmailAttribute isEmailAttribute)
                    {
                        if (value is string stringValue)
                        {
                            if (!isEmailAttribute.IsValid(stringValue))
                                throw new EmailAddressException($"Property {property.Name} is not a valid email.");
                        }
                        else
                        throw new InvalidOperationException($"Property {property.Name} is not a string.");
                    }
                    else if (attribute is PhoneAttribute isPhoneAttribute)
                    {
                        if (value is string stringValue)
                        {
                            if (!isPhoneAttribute.IsValid(stringValue))
                                throw new PhoneException($"Property {property.Name} is not a valid phone number.");
                        }
                        else
                        throw new InvalidOperationException($"Property {property.Name} is not a string.");
                    }
                }        
            }
            return true;
        }
    }
}
