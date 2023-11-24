using API.Domain.Entidades;
using API.Domain.Interfaces;
using API.Domain.Interfaces.Services.Users;

namespace API.Service.Services
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> _respository;

        public UserService(IRepository<UserEntity> repository)
        {
            this._respository = repository;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _respository.DeleteAsync(id);  
        }

        public async Task<UserEntity> Get(Guid id)
        {
            return await _respository.SelectAsync(id);
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            return await _respository.SelectAsync();
        }

        public async Task<UserEntity> Post(UserEntity user)
        {
            return await _respository.InsertAsync(user);
        }

        public async Task<UserEntity> Put(UserEntity user)
        {
            return await _respository.UpdateAsync(user);
        }
    }
}
