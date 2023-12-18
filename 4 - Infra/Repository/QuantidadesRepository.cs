using Domain.Interfaces;
using Domain.Models;
using Infra.Context;

namespace Infra.Repository
{
    public class QuantidadesRepository : Repository<Quantidades>, IQuantidadeRepository
    {
        public QuantidadesRepository(DataContext context) : base(context)
        {

        }
    }
}
