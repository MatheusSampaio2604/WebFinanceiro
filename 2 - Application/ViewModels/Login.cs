
namespace Application.ViewModels
{
    public class Login
    {
        public required string Email { get; set; }
        public required string Senha { get; set; }
        public string? CPF { get; set; }
    }
}