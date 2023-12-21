using Application;
using Application.Interfaces;
using Domain.Interfaces;
using Infra.Context;
using Infra.Repository;

namespace WebApi.Areas
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection DependenciesConfig(this IServiceCollection services)
        {
            services.AddScoped<DataContext>();
            services.AddScoped<IFiiRepository, FiiRepository>();
            services.AddScoped<IAcoesRepository, AcoesRepository>();
            services.AddScoped<IValoresRepository, ValoresRepository>();
            services.AddScoped<IMensagemRepository, MensagemRepository>();
            services.AddScoped<IQuantidadeRepository, QuantidadesRepository>();

            services.AddScoped<IFiiApp, FiiApp>();
            services.AddScoped<IAcoesApp, AcoesApp>();
            services.AddScoped<IValoresApp, ValoresApp>();
            services.AddScoped<IMensagemApp, MensagemApp>();
            services.AddScoped<IQuantidadesApp, QuantidadesApp>();

            return services;
        }

    }
}