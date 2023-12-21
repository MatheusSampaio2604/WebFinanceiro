using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enum;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        public required string CPF { get; set; }
        public TypeUser? TipoUsuario { get; set; }

    }
}