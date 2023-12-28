using Domain.Interfaces;
using Domain.Models;
using Infra.Context;

namespace Infra.Repository
{
    public class FiiRepository : Repository<Fii>, IFiiRepository
    {
        public FiiRepository(DataContext context) : base(context)
        {

        }
    }
}
