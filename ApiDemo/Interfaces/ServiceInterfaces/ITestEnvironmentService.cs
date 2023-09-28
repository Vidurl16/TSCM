using API.Repository.Models;

namespace API.Interfaces.ServiceInterfaces
{
    public interface ITestEnvironmentService
    {
        Task<List<TestEnvironment>> GetAllTestEnvironmentsAsync();
        Task<TestEnvironment> GetTestEnvironmentByIdAsync(int id);
        Task<int> AddTestEnvironmentAsync(TestEnvironment environment);
        Task<bool> UpdateTestEnvironmentAsync(TestEnvironment environment);
        Task<bool> DeleteTestEnvironmentAsync(int id);
    }
}
