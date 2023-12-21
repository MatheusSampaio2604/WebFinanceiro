using Application.ViewModels;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IMensagemApp : IApp<MensagemViewModel, Mensagem>
    {
        Task<int> CreateMessage(MensagemViewModel mensagem);
        Task<MensagemViewModel> EditMessage(MensagemViewModel mensagem);
        Task<IEnumerable<MensagemViewModel>> FindAllMessages();
    }


}