using API.Repository.Models;

namespace API.Interfaces.RepositoryInterfaces
{
    public interface ITestSuiteRepository
    {
        Task<List<TestSuite>> GetAllTestSuitesAsync();
        Task<TestSuite> GetTestSuiteByIdAsync(int id);
        Task<int> AddTestSuiteAsync(TestSuite testSuite);
        Task<bool> UpdateTestSuiteAsync(TestSuite testSuite);
        Task<bool> DeleteTestSuiteAsync(int id);
    }
}
