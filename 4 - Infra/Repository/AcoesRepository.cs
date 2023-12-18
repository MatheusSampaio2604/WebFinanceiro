using Domain.Interfaces;
using Domain.Models;
using Infra.Context;

namespace Infra.Repository
{
    public class AcoesRepository : Repository<Acoes>, IAcoesRepository
    {
        public AcoesRepository(DataContext context) : base(context)
        {

        }
    }
}
