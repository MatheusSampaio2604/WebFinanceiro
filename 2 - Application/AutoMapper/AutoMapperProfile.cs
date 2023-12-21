using Application.ViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Acoes, AcoesViewModel>();
            CreateMap<Fii, FiiViewModel>();
            CreateMap<Mensagem, MensagemViewModel>();
            CreateMap<Valores, ValoresViewModel>();
            CreateMap<Quantidades, QuantidadesViewModel>();
            CreateMap<ApplicationUser, ApplicationUserViewModel>();

            CreateMap<AcoesViewModel, Acoes>();
            CreateMap<FiiViewModel, Fii>();
            CreateMap<MensagemViewModel, Mensagem>();
            CreateMap<ValoresViewModel, Valores>();
            CreateMap<QuantidadesViewModel, Quantidades>();
            CreateMap<ApplicationUserViewModel, ApplicationUser>();
        }
    }
}