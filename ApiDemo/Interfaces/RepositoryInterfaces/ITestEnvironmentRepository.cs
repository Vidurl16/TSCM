using API.Repository.Models;

namespace API.Interfaces.RepositoryInterfaces
{
    public interface ITestEnvironmentRepository
    {
        Task<List<TestEnvironment>> GetAllTestEnvironmentsAsync();
        Task<TestEnvironment> GetTestEnvironmentByIdAsync(int id);
        Task<int> AddTestEnvironmentAsync(TestEnvironment environment);
        Task<bool> UpdateTestEnvironmentAsync(TestEnvironment environment);
        Task<bool> DeleteTestEnvironmentAsync(int id);
    }

}
