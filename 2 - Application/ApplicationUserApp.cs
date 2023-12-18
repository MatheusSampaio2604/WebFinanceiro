using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;

namespace Application
{
    public class ApplicationUserApp : App<ApplicationUserViewModel, ApplicationUser>, IApplicationUserApp
    {
        public ApplicationUserApp(IMapper mapper, IApplicationUserRepository applicationUserRepository) : base(mapper, applicationUserRepository)
        {

        }
    }
}
