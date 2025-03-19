using CDNConverter.API.Application.UseCases;
using CDNConverter.API.Domain.Interfaces.UseCases;
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
            services.AddScoped<IGetConvertedAndOriginalLogByIdUseCase, GetConvertedAndOriginalLogByIdUseCase>();
            services.AddScoped<IGetAllConvertedAndOriginalLogsUseCase, GetAllConvertedAndOriginalLogsUseCase>();
            services.AddScoped<IGetAllConvertedLogsFilesUseCase, GetAllConvertedLogsFilesUseCase>();
            services.AddScoped<IGetAllOriginalLogsUseCase, GetAllOriginalLogsUseCase>();
            services.AddScoped<IGetOriginalLogByIdUseCase, GetOriginalLogByIdUseCase>();
            services.AddScoped<ICreateOriginalLogUseCase, CreateOriginalLogUseCase>();
            services.AddScoped<IGetAllOriginalLogsFileZipUseCase, GetAllOriginalLogsFileZipUseCase>();
            services.AddScoped<IGetOriginalLogFileByIdUseCase, GetOriginalLogFileByIdUseCase>();
            services.AddScoped<IConvertOriginalLogByFileUseCase, ConvertOriginalLogByFileUseCase>();
            services.AddScoped<IConvertOriginalLogByIdUseCase, ConvertOriginalLogByIdUseCase>();
            services.AddScoped<IConvertOriginalLogByFileReturnUseCase, ConvertOriginalLogByFileReturnUseCase>();
            services.AddScoped<IConvertOriginalLogByIdFileReturnUseCase, ConvertOriginalLogByIdFileReturnUseCase>();
            services.AddScoped<IGetConvertedLogFileByIdUseCase, GetConvertedLogFileByIdUseCase>();
        }
    }
}
