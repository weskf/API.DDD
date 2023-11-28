using API.Domain.DTOs;
using API.Domain.Entidades;
using API.Domain.Interfaces.Services.Users;
using API.Domain.Repository;

namespace API.Service.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository _repository;

        public LoginService(IUserRepository repository)
        {
            this._repository = repository;
        }

        public async Task<object> FindByLogin(LoginDTO user)
        {
            var baseUser = new UserEntity();
            if (user != null && !string.IsNullOrWhiteSpace(user.email))
                baseUser = await _repository.FindByLogin(user.email);
            if (baseUser != null)
                return baseUser;
            return null;
        }
    }
}
