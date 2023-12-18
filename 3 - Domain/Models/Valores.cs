using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{

    [Table("Valores")]
    public class Valores
    {
        [Key()]
        public int Id { get; set; }


        [ForeignKey("Quantidades")]
        [Column(Order = 1)]
        public int QuantidadeId { get; set; }


        public decimal Valor { get; set; }


        public DateTime DataCompra { get; set; }


        public required virtual IEnumerable<Quantidades> Quantidades { get; set; }
    }
}