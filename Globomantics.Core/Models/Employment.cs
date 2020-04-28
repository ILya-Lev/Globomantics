using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Globomantics.Models
{
    public class Employment : IValidatableObject
    {
        public string CurrentType { get; set; }
        public string CurrentEmployerName { get; set; }
        public double? CurrentAnnualIncome { get; set; }
        public string CurrentDuration { get; set; }

        public string PreviousType { get; set; }
        public string PreviousEmployerName { get; set; }
        public double? PreviousAnnualIncome { get; set; }
        public string PreviousDuration { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (validationContext.ObjectInstance is Employment e)
            {
                if (e.CurrentDuration.Equals("1"))
                {
                    var vrs = new List<ValidationResult>();
                    if (string.IsNullOrWhiteSpace(e.PreviousType))
                        StoreError(vrs, $"{nameof(PreviousType)} value is missing");

                    if (string.IsNullOrWhiteSpace(e.PreviousEmployerName))
                        StoreError(vrs, $"{nameof(PreviousEmployerName)} value is missing");

                    if (string.IsNullOrWhiteSpace(e.PreviousDuration))
                        StoreError(vrs, $"{nameof(PreviousDuration)} value is missing");

                    if (e.PreviousAnnualIncome is null)
                        StoreError(vrs, $"{nameof(PreviousAnnualIncome)} value is missing");


                    return vrs;
                }
            }
            return new[] { ValidationResult.Success };
        }

        private static void StoreError(List<ValidationResult> vrs, string message)
        {
            vrs.Add(new ValidationResult(message));
        }
    }
}
