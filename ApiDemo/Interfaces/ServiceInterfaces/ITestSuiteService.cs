using API.Repository.Models;

namespace API.Interfaces.ServiceInterfaces
{
    public interface ITestSuiteService
    {
        Task<List<TestSuite>> GetAllTestSuitesAsync();
        Task<TestSuite> GetTestSuiteByIdAsync(int id);
        Task<int> AddTestSuiteAsync(TestSuite testSuite);
        Task<bool> UpdateTestSuiteAsync(TestSuite testSuite);
        Task<bool> DeleteTestSuiteAsync(int id);
    }
}
