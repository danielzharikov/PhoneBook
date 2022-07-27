using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.WebApi.Definitions.Base
{
    public interface IAppDefinition
    {
        void ConfigureServices(IServiceCollection services, IConfiguration configuration);
        void ConfigureApplication(WebApplication app, IWebHostEnvironment environment);
    }
}
