using API.Repository.Models;

namespace API.Interfaces.ServiceInterfaces
{
    public interface ITestCasesService
    {
        Task<List<TestCases>> GetAllTestCasesAsync();
        Task<TestCases> GetTestCaseByIdAsync(int id);
        Task<int> AddTestCaseAsync(TestCases testCase);
        Task<bool> UpdateTestCaseAsync(TestCases testCase);
        Task<bool> DeleteTestCaseAsync(int id);
    }

}
