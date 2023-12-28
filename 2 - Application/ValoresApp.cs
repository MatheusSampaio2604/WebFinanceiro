using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;

namespace Application
{
    public class ValoresApp : App<ValoresViewModel, Valores>, IValoresApp
    {
        public ValoresApp(IMapper mapper, IValoresRepository valoresRepository) : base(mapper, valoresRepository)
        {

        }
    }
}
