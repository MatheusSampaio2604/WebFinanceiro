using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Acoes")]
    public class Acoes
    {
        public int Id { get; set; }
        public required string Nome { get; set; }

        public virtual IEnumerable<Quantidades>? Quantidades { get; set; }
    }
}