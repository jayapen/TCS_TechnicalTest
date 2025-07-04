using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcsTest.Utilities.Validators
{
    public class DateTimeValidator
    {
        public class DateGreaterThanAttribute : ValidationAttribute
        {
            private readonly string _comparisonProperty;

            public DateGreaterThanAttribute(string comparisonProperty)
            {
                _comparisonProperty = comparisonProperty;
            }

            protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
            {
                var currentValue = (DateTime?)value;

                var property = validationContext.ObjectType.GetProperty(_comparisonProperty);
                if (property == null)
                    return new ValidationResult($"Invalid property: {_comparisonProperty}");

                var comparisonValue = (DateTime?)property.GetValue(validationContext.ObjectInstance);

                if (currentValue <= comparisonValue)
                    return new ValidationResult(ErrorMessage ?? $"{validationContext.MemberName} must be greater than {_comparisonProperty}");

                return ValidationResult.Success;
            }
        }
    }
}
