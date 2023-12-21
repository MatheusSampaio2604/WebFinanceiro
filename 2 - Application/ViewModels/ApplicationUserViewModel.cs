using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enum;


namespace Application.ViewModels
{
    public class ApplicationUserViewModel
    {
        public required string CPF { get; set; }

        public TypeUser? TipoUsuario { get; set; }

    }
}