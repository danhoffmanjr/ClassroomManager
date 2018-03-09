using System.ComponentModel.DataAnnotations;

namespace ClassroomManager.Models
{
    public class HomeViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}