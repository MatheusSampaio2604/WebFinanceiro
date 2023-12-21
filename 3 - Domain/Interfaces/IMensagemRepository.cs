using System.Linq.Expressions;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IMensagemRepository : IRepository<Mensagem>
    {
        Task<IEnumerable<Mensagem>> FindAllMessages(Expression<Func<Mensagem, bool>> exMessage);
    }
}