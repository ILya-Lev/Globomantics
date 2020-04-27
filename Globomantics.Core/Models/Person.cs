using Globomantics.Core.Validation;

namespace Globomantics.Models
{
    public class Person
    {
        // Person info
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [AgeValidator(MinAge = 18, MaxAge = 93)]
        public string Dob { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // Address Info
        public string Street { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
