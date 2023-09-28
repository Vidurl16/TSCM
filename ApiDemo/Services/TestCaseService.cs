using API.Interfaces.RepositoryInterfaces;
using API.Interfaces.ServiceInterfaces;
using API.Repository.Models;

namespace API.Services
{
    public class TestCasesService : ITestCasesService
    {
        private readonly ITestCasesRepository _repository;

        public TestCasesService(ITestCasesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TestCases>> GetAllTestCasesAsync()
        {
            return await _repository.GetAllTestCasesAsync();
        }

        public async Task<TestCases> GetTestCaseByIdAsync(int id)
        {
            return await _repository.GetTestCaseByIdAsync(id);
        }

        public async Task<int> AddTestCaseAsync(TestCases testCase)
        {
            return await _repository.AddTestCaseAsync(testCase);
        }

        public async Task<bool> UpdateTestCaseAsync(TestCases testCase)
        {
            return await _repository.UpdateTestCaseAsync(testCase);
        }

        public async Task<bool> DeleteTestCaseAsync(int id)
        {
            return await _repository.DeleteTestCaseAsync(id);
        }
    }

}
