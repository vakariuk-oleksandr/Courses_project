using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Courses.Data
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Server=DESKTOP-4D0AG7G\\SQLEXPRESS;Database=Courses_Base;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            services.AddTransient<IDbConnection>(_ => new SqlConnection(connectionString));
            services.AddDbContext<AplContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            return services;
        }
    }
}