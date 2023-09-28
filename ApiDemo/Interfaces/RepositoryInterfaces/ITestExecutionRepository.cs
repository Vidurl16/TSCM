using API.Repository.Models;

namespace API.Interfaces.RepositoryInterfaces
{
    public interface ITestExecutionRepository
    {
        Task<List<TestExecution>> GetAllTestExecutionsAsync();
        Task<TestExecution> GetTestExecutionByIdAsync(int id);
        Task<int> AddTestExecutionAsync(TestExecution testExecution);
        Task<bool> UpdateTestExecutionAsync(TestExecution testExecution);
        Task<bool> DeleteTestExecutionAsync(int id);
    }
}
