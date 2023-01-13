using Microsoft.Extensions.DependencyInjection;

namespace Courses.Data
{
    public static class DataExtensions
    {
        public static IServiceCollection AddData(this IServiceCollection services)
        {
            //services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICoursesrep, CoursesRepository>();
            return services;
        }
    }
}