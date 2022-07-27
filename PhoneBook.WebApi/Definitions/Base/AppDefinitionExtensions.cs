using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.WebApi.Definitions.Base
{
    public static class AppDefinitionExtensions
    {
        public static void AddDefinitions(this IServiceCollection source, WebApplicationBuilder builder,
            params Type[] entryPointsAssembly)
        {
            var definitions = new List<IAppDefinition>();

            foreach (var entryPoint in entryPointsAssembly)
            {
                var types = entryPoint.Assembly.ExportedTypes
                    .Where(t => !t.IsAbstract && typeof(IAppDefinition).IsAssignableFrom(t));
                var instances = types.Select(Activator.CreateInstance).Cast<IAppDefinition>();
                definitions.AddRange(instances);
            }

            definitions.ForEach(app => app.ConfigureServices(source, builder.Configuration));
            source.AddSingleton(definitions as IReadOnlyCollection<IAppDefinition>);
        }

        public static void UseDefinitions(this WebApplication application)
        {
            var definitions = application.Services.GetRequiredService<IReadOnlyCollection<IAppDefinition>>();
            var environment = application.Services.GetRequiredService<IWebHostEnvironment>();
            foreach (var endPoint in definitions)
            {
                endPoint.ConfigureApplication(application, environment);
            }
        }
    }
}
