using System;
using System.ComponentModel.DataAnnotations;

namespace App.Core.Entities
{
    public class ContactInfo : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressLine { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [DataType(DataType.PostalCode)]
        public string Zip { get; set; }
        [Display(Name = "Phone (Primary)")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Display(Name = "Phone (Secondary)")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumberOpt { get; set; }
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DoB { get; set; }
    }
}
