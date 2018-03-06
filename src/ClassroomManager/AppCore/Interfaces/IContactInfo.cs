using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Core.Entities
{
    public interface IContactInfo
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string AddressLine { get; set; }
        string AddressLine2 { get; set; }
        string City { get; set; }
        string State { get; set; }
        [DataType(DataType.PostalCode)]
        string Zip { get; set; }
        [Display(Name = "Phone (Primary)")]
        [DataType(DataType.PhoneNumber)]
        string PhoneNumber { get; set; }
        [Display(Name = "Phone (Secondary)")]
        [DataType(DataType.PhoneNumber)]
        string PhoneNumberOpt { get; set; }
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        string Email { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        string DoB { get; set; }
    }
}