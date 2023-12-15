using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Message")]
    public class Message
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Titulo")]
        [MaxLength(255)]
        public required string Titulo { get; set; }

        [Column("Ativo")]
        public bool Ativo { get; set; }

        [Column("DataCadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("DataAlteracao")]
        public DateTime DataAlteracao { get; set; }

        [ForeignKey("UsuarioIdentity")]
        [Column(Order = 1)]
        public string UserId { get; set; }
        public virtual UsuarioIdentity UsuarioIdentity { get; set; }
    }
}