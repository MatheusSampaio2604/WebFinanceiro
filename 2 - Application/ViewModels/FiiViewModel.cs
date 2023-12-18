using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.ViewModels
{
  
    public class FiiViewModel
    {

        public int Id { get; set; }
        public required string Nome { get; set; }

        public required virtual IEnumerable<QuantidadesViewModel> Quantidades { get; set; }
    }
}