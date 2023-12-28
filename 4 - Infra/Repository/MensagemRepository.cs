using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Models;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public class MensagemRepository : Repository<Mensagem>, IMensagemRepository
    {
        public MensagemRepository(DataContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Mensagem>> FindAllMessages(Expression<Func<Mensagem, bool>> exMessage)
        {
            return await DbSet.Where(exMessage).AsNoTracking().ToListAsync();
        }
    }
}
 