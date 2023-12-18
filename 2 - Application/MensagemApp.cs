using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;

namespace Application
{
    public class MensagemApp : App<MensagemViewModel, Mensagem>, IMensagemApp
    {
        public MensagemApp(IMapper mapper, IMensagemRepository mensagemRepository) : base(mapper, mensagemRepository)
        {

        }
    }
}
