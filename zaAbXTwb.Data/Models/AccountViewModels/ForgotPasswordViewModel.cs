using System.ComponentModel.DataAnnotations;

namespace zaAbXTwb.Data.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
