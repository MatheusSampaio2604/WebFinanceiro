using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models
{
    [Table("Mensagem")]
    public class Mensagem : Notifies
    {
        public int Id { get; set; }
        public required string UserId { get; set; }
        public required string Titulo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public bool Ativo { get; set; }

    }
}