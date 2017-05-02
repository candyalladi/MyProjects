using System.ComponentModel.DataAnnotations;

namespace TweetnHash.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
