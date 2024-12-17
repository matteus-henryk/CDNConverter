using CDNConverter.API.Application.Services;
using CDNConverter.API.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CDNConverter.API.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddServices(services);
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IGetConvertedAndOriginalLogByIdService, GetConvertedAndOriginalLogByIdService>();
            services.AddScoped<IGetAllConvertedAndOriginalLogsService, GetAllConvertedAndOriginalLogsService>();
            services.AddScoped<IGetAllConvertedLogsFilesService, GetAllConvertedLogsFilesService>();
            services.AddScoped<IGetAllOriginalLogsService, GetAllOriginalLogsService>();
            services.AddScoped<IGetOriginalLogByIdService, GetOriginalLogByIdService>();
            services.AddScoped<ICreateOriginalLogService, CreateOriginalLogService>();
            services.AddScoped<IGetAllOriginalLogsFileZipService, GetAllOriginalLogsFileZipService>();
            services.AddScoped<IGetOriginalLogFileByIdService, GetOriginalLogFileByIdService>();
            services.AddScoped<IConvertOriginalLogByFileService, ConvertOriginalLogByFileService>();
            services.AddScoped<IConvertOriginalLogByIdService, ConvertOriginalLogByIdService>();
            services.AddScoped<IConvertOriginalLogByFileReturnService, ConvertOriginalLogByFileReturnService>();
            services.AddScoped<IConvertOriginalLogByIdFileReturnService, ConvertOriginalLogByIdFileReturnService>();
        }
    }
}
