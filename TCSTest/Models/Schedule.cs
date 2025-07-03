using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TCSTest.Models
{
    public class Schedule
    {
        [JsonPropertyName("channelId")]
        [Required(ErrorMessage = "ChannelId is required.")]
        public Guid ChannelId { get; set; }

        [JsonPropertyName("contentId")]
        [Required(ErrorMessage = "ContentId is required.")]
        public Guid ContentId { get; set; }

        [JsonPropertyName("airTime")]
        [Required(ErrorMessage = "AirTime is required.")]
        public DateTime AirTime { get; set; }

        [JsonPropertyName("endTime")]
        [Required(ErrorMessage = "EndTime is required.")]
        [DateGreaterThan(nameof(AirTime), ErrorMessage = "EndTime must be after AirTime.")]
        public DateTime EndTime { get; set; }
    }

    /// <summary>
    /// Custom validation attribute to ensure EndTime is greater than AirTime.
    /// </summary>
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
                return new ValidationResult($"Unknown property: {_comparisonProperty}");

            var comparisonValue = (DateTime?)property.GetValue(validationContext.ObjectInstance);

            if (currentValue.HasValue && comparisonValue.HasValue && currentValue <= comparisonValue)
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }
    }
}
