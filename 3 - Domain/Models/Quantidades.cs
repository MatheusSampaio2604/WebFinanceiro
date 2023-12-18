using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Quantidades")]
    public class Quantidades
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("ApplicationUser")]
        [Column(Order = 1)]
        public required string UserId { get; set; }


        [ForeignKey("Acoes")]
        [Column(Order = 1)]
        public int? AcaoId { get; set; }


        [ForeignKey("Fii")]
        [Column(Order = 1)]
        public int? FiiId { get; set; }

        public int Quantidade { get; set; }


        public required virtual IEnumerable<Valores> Valores { get; set; }
        public required virtual Acoes Acoes { get; set; }
        public required virtual Fii Fii { get; set; }

        public required virtual ApplicationUser ApplicationUser { get; set; }

    }
}