using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Globomantics.Core.Validation
{
    public class AgeValidator : ValidationAttribute
    {
        private static readonly string[] _formats = new[]
        {
            "yyyy-MM-dd",
            "yyyy.MM.dd",
            "yyyy/MM/dd",
            "dd/MM/yyyy",
            "dd-MM-yyyy",
            "dd.MM.yyyy",
            "dd/MM/yy",
            "dd-MM-yy",
            "dd.MM.yy",
        };
        public int MinAge { get; set; }
        public int MaxAge { get; set; }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (MinAge == 0 && MaxAge == 0)
                throw new Exception($"No limits are setup in {nameof(AgeValidator)}");
            if (MinAge > MaxAge)
                throw new Exception($"Min age {MinAge} is greater than max age {MaxAge}");

            var rawDob = value as string;

            var ageDouble = DateTime
                .TryParseExact(rawDob, _formats, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out var dob)
                ? DateTime.UtcNow.Subtract(dob).TotalDays / 365.2425
                : default(double?);

            if (!ageDouble.HasValue)
                return new ValidationResult($"Cannot parse {rawDob} as a date");

            var age = (int)ageDouble;
            if (age < MinAge)
                return new ValidationResult($"Age {age} is too small, lower limit is {MinAge}");
            if (MaxAge != 0 && age > MaxAge)
                return new ValidationResult($"Age {age} is too high, upper limit is {MaxAge}");

            return ValidationResult.Success;
        }
    }
}
