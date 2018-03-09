using System;
using System.ComponentModel.DataAnnotations;

namespace App.Core.Entities
{
    public class ContactInfo : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string AddressLine { get; set; }

        [Required]
        [StringLength(50)]
        public string AddressLine2 { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(15)]
        public string State { get; set; }

        [Required]
        [StringLength(15)]
        [DataType(DataType.PostalCode)]
        public string Zip { get; set; }

        [Required]
        [StringLength(32)]
        [Display(Name = "Phone (Primary)")]
        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(DataFormatString = "{0:(###) ###-####}", ApplyFormatInEditMode = true)]
        public string PhoneNumber { get; set; }

        [StringLength(32)]
        [Display(Name = "Phone (Secondary)")]
        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(DataFormatString = "{0:(###) ###-####}", ApplyFormatInEditMode = true)]
        public string PhoneNumberOpt { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DoB { get; set; }
    }
}