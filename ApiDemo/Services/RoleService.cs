using API.Interfaces.RepositoryInterfaces;
using API.Interfaces.ServiceInterfaces;
using API.Repository.Models;

namespace API.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;

        public RoleService(IRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            return await _repository.GetAllRolesAsync();
        }

        public async Task<Role> GetRoleByIdAsync(int id)
        {
            return await _repository.GetRoleByIdAsync(id);
        }

        public async Task<int> AddRoleAsync(Role role)
        {
            return await _repository.AddRoleAsync(role);
        }

        public async Task<bool> UpdateRoleAsync(Role role)
        {
            return await _repository.UpdateRoleAsync(role);
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            return await _repository.DeleteRoleAsync(id);
        }
    }

}
