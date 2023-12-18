using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enum;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Column("Cpf")]
        public required string CPF { get; set; }

        [Column("TypeUser")]
        public TypeUser? TipoUsuario { get; set; }

        
    }
}