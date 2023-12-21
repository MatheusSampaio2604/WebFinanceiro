using Application.AutoMapper;
using AutoMapper;

namespace FinanceiroWeb.Areas{
    public static class AutoMapperConfig{
        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services){
            MapperConfiguration mapperConfiguration = new(mc => { mc.AddProfile(new AutoMapperProfile()); });
            IMapper mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}