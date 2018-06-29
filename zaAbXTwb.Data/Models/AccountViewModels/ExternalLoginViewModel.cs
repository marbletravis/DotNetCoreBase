using System.ComponentModel.DataAnnotations;

namespace zaAbXTwb.Data.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
