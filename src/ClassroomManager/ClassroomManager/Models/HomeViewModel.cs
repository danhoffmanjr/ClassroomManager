using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ClassroomManager.Models
{
    public class HomeViewModel
    {
        [Required]
        [EmailAddress]
        [Remote("UserAlreadyExistsAsync", "Home")]
        [Display(Name = "e-mail")]
        public string Email { get; set; }
    }
}