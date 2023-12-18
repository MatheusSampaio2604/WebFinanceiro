using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;

namespace Application
{
    public class AcoesApp : App<AcoesViewModel, Acoes>, IAcoesApp
    {
        public AcoesApp(IMapper mapper, IAcoesRepository acoesRepository) : base(mapper, acoesRepository)
        {

        }
    }
}
