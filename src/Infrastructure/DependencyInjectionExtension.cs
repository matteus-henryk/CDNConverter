using Microsoft.Extensions.DependencyInjection;
using CDNConverter.API.Domain.Interfaces.Repositories;
using CDNConverter.API.Infrastructure.DataAccess;
using CDNConverter.API.Infrastructure.DataAccess.Repositories;

namespace CDNConverter.API.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            AddRepositories(services);
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<ILogReadOnlyRepository, LogRepository>();
            services.AddScoped<ILogWriteOnlyRepository, LogRepository>();
            services.AddScoped<ILogDirectoryReadOnlyRepository, LogDirectoryRepository>();
            services.AddScoped<ILogDirectoryWriteOnlyRepository, LogDirectoryRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
