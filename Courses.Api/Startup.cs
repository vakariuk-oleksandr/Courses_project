using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Data;
using System.Data.SqlClient;
using MassTransit;
using Courses.Data;
using Courses.BL;

namespace Courses.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            //    services.AddScoped<Value_Repository>();
            services.AddDbContext<AplContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });
            services.AddTransient<IDbConnection>(_ => new SqlConnection(connectionString));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICoursesrep, CoursesRepository>();
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddMassTransit(configuration =>
            {
                configuration.UsingRabbitMq((_, configurator) =>
                {
                    configurator.Host("amqp://guest:guest@localhost:5672");
                });
            });
            services.AddTransient<ICoursesServices, CoursesServices>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My courses api");
            });

            app.UseHttpsRedirection();

            app.UseRouting();
            //  app.UseAuthentication(); // аутентифікація
            //  app.UseAuthorization(); // авторизація

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}