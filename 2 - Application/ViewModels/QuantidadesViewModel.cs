using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.ViewModels
{
    public class QuantidadesViewModel
    {
        public int Id { get; set; }

        public required string UserId { get; set; }

        public int? AcaoId { get; set; }


        public int? FiiId { get; set; }

        public int Quantidade { get; set; }


        public required virtual IEnumerable<ValoresViewModel> Valores { get; set; }
        public required virtual AcoesViewModel Acoes { get; set; }
        public required virtual FiiViewModel Fii { get; set; }

    }
}