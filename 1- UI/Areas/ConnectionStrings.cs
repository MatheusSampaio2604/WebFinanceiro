
using Domain.Models;
using Infra.Context;
using Infra.IdentityContext;
using Microsoft.EntityFrameworkCore;

namespace FinanceiroWeb.Areas
{
    public static class ConnectionContext
    {
        public static IServiceCollection ConnectionStrings(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionIdentity = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            var connectionData = configuration.GetConnectionString("DataConnection") ?? throw new InvalidOperationException("Connection string 'DataConnection' not found.");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionIdentity));
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(connectionData));


            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }

    }

}
