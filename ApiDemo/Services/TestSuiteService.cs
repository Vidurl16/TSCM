using API.Interfaces.RepositoryInterfaces;
using API.Interfaces.ServiceInterfaces;
using API.Repository.Models;

namespace API.Services
{
    public class TestSuiteService : ITestSuiteService
    {
        private readonly ITestSuiteRepository _repository;

        public TestSuiteService(ITestSuiteRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TestSuite>> GetAllTestSuitesAsync()
        {
            return await _repository.GetAllTestSuitesAsync();
        }

        public async Task<TestSuite> GetTestSuiteByIdAsync(int id)
        {
            return await _repository.GetTestSuiteByIdAsync(id);
        }

        public async Task<int> AddTestSuiteAsync(TestSuite testSuite)
        {
            return await _repository.AddTestSuiteAsync(testSuite);
        }

        public async Task<bool> UpdateTestSuiteAsync(TestSuite testSuite)
        {
            return await _repository.UpdateTestSuiteAsync(testSuite);
        }

        public async Task<bool> DeleteTestSuiteAsync(int id)
        {
            return await _repository.DeleteTestSuiteAsync(id);
        }
    }

}
