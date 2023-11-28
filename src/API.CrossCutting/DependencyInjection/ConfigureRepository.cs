using API.Data.Context;
using API.Data.Implementations;
using API.Data.Repository;
using API.Domain.Interfaces;
using API.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace API.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesService(IServiceCollection service)
        {
            service.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            service.AddScoped<IUserRepository, UserImplementation>();

            var connString = "Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=jedite94";

            service.AddDbContext<MyContext>(
                opt => opt.UseMySql(connString, ServerVersion.AutoDetect(connString))
            );
        }
    }
}
