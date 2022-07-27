using PhoneBook.WebApi.Definitions.Base;
using PhoneBook.WebApi.Middleware;

namespace PhoneBook.WebApi.Definitions
{
    public class CustomExceptionsDefinition : AppDefinition
    {
        public override void ConfigureApplication(WebApplication app, IWebHostEnvironment environment)
        {
            app.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}
