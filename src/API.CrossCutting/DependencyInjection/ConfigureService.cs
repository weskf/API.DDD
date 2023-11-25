using API.Domain.Interfaces.Services.Users;
using API.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection service)
        {
            service.AddTransient<IUserService, UserService>();
        }
    }
}
