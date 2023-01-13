using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Course.Persistence;
using Models.Application;

namespace Course.Persistant
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddScoped<ITeacherDbContext, TeacherDbContext>();
            return services;
        }
    }
}
