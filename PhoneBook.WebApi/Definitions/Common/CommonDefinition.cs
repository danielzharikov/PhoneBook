using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Application;
using PhoneBook.Application.Common.Mappings;
using PhoneBook.Application.Interfaces;
using PhoneBook.Persistence;
using PhoneBook.WebApi.Definitions.Base;

namespace PhoneBook.WebApi.Definitions.Common
{
    public class CommonDefinition : AppDefinition
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IPersonsDbContext).Assembly));
            });

            services.AddApplication();
            services.AddPersistence(configuration);

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });
        }

        public override void ConfigureApplication(WebApplication app, IWebHostEnvironment environment)
        {
            InitializeDb(app);

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers();
            });

            app.Run();
        }

        /// <summary>
        /// Initialize PersonDbContext via first request to the "PersonsDbContext" service 
        /// </summary>
        /// <param name="app"></param>
        private static void InitializeDb(IHost app)
        {
            using var scope = app.Services.CreateScope();
            var servicesProvider = scope.ServiceProvider;
            try
            {
                var context = servicesProvider.GetRequiredService<PersonsDbContext>();
                DbInitializer.Initialize(context);
            }
            catch (Exception exception)
            {
                // todo: create an exception
            }
        }
    }
}
