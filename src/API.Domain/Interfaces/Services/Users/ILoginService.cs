using API.Domain.DTOs;
using API.Domain.Entidades;

namespace API.Domain.Interfaces.Services.Users
{
    public interface ILoginService
    {
        Task<object> FindByLogin(LoginDTO user);
    }
}
