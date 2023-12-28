using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;

namespace Application
{
    public class QuantidadesApp : App<QuantidadesViewModel, Quantidades>, IQuantidadesApp
    {
        public QuantidadesApp(IMapper mapper, IQuantidadeRepository quantidadesRepository) : base(mapper, quantidadesRepository)
        {

        }
    }
}
