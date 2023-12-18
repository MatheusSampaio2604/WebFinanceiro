using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;

namespace Application
{
    public class FiiApp : App<FiiViewModel, Fii>, IFiiApp
    {
        public FiiApp(IMapper mapper, IFiiRepository fiiRepository) : base(mapper, fiiRepository)
        {

        }
    }
}
