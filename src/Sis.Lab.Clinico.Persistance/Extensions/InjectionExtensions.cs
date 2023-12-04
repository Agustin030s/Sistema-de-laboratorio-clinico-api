using Microsoft.Extensions.DependencyInjection;
using Sis.Lab.Clinico.Application.Interface;
using Sis.Lab.Clinico.Persistance.Context;
using Sis.Lab.Clinico.Persistance.Repositories;

namespace Sis.Lab.Clinico.Persistance.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionPersistance(this IServiceCollection services)
        {
            services.AddSingleton<ApplicationDbContext>();
            services.AddScoped<IAnalysisRepository, AnalysisRepository>();

            return services;
        }
    }
}
