using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Quantidade")]
    public class Quantidades
    {
        public int Id { get; set; }
        public required string UserId { get; set; }
        public int Quantidade { get; set; }
        public int? AcaoId { get; set; }
        public int? FiiId { get; set; }


        public required virtual IEnumerable<Valores> Valores { get; set; }
        public virtual Acoes? Acoes { get; set; }
        public virtual Fii? Fii { get; set; }

    }
}