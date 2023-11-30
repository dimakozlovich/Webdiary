using System.ComponentModel.DataAnnotations;

namespace WebDiaryVersion1.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public bool RememberMe { get; set; }
    }
}
