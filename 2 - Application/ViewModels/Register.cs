
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class Register
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [PasswordPropertyText]
        [Required]
        [MinLength(8)]
        public required string Senha { get; set; }
        public string? CPF { get; set; }
        public string? Phone { get; set; }
    }
}