using API.Interfaces.RepositoryInterfaces;
using API.Interfaces.ServiceInterfaces;
using API.Repository.Models;

namespace API.Services
{
    public class TestExecutionService : ITestExecutionService
    {
        private readonly ITestExecutionRepository _repository;

        public TestExecutionService(ITestExecutionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TestExecution>> GetAllTestExecutionsAsync()
        {
            return await _repository.GetAllTestExecutionsAsync();
        }

        public async Task<TestExecution> GetTestExecutionByIdAsync(int id)
        {
            return await _repository.GetTestExecutionByIdAsync(id);
        }

        public async Task<int> AddTestExecutionAsync(TestExecution testExecution)
        {
            return await _repository.AddTestExecutionAsync(testExecution);
        }

        public async Task<bool> UpdateTestExecutionAsync(TestExecution testExecution)
        {
            return await _repository.UpdateTestExecutionAsync(testExecution);
        }

        public async Task<bool> DeleteTestExecutionAsync(int id)
        {
            return await _repository.DeleteTestExecutionAsync(id);
        }
    }

}
