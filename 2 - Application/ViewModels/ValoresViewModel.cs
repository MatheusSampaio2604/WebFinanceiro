using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.ViewModels
{

    public class ValoresViewModel
    {
        public int Id { get; set; }


        public int QuantidadeId { get; set; }


        public decimal Valor { get; set; }


        public DateTime DataCompra { get; set; }


        public required virtual IEnumerable<QuantidadesViewModel> Quantidades { get; set; }
    }
}