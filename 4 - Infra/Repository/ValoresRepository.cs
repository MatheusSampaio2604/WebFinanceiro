using Domain.Interfaces;
using Domain.Models;
using Infra.Context;

namespace Infra.Repository
{
    public class ValoresRepository : Repository<Valores>, IValoresRepository
    {
        public ValoresRepository(DataContext context) : base(context)
        {

        }
    }
}
