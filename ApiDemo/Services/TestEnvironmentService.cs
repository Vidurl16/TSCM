using API.Interfaces.RepositoryInterfaces;
using API.Interfaces.ServiceInterfaces;
using API.Repository.Models;

namespace API.Services
{
    public class TestEnvironmentService : ITestEnvironmentService
    {
        private readonly ITestEnvironmentRepository _repository;

        public TestEnvironmentService(ITestEnvironmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TestEnvironment>> GetAllTestEnvironmentsAsync()
        {
            return await _repository.GetAllTestEnvironmentsAsync();
        }

        public async Task<TestEnvironment> GetTestEnvironmentByIdAsync(int id)
        {
            return await _repository.GetTestEnvironmentByIdAsync(id);
        }

        public async Task<int> AddTestEnvironmentAsync(TestEnvironment environment)
        {
            return await _repository.AddTestEnvironmentAsync(environment);
        }

        public async Task<bool> UpdateTestEnvironmentAsync(TestEnvironment environment)
        {
            return await _repository.UpdateTestEnvironmentAsync(environment);
        }

        public async Task<bool> DeleteTestEnvironmentAsync(int id)
        {
            return await _repository.DeleteTestEnvironmentAsync(id);
        }
    }

}
