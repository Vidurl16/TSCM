using API.Interfaces;
using API.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class TestCasesRepository : ITestCasesRepository
    {
        private readonly KCP_DbContext _context;

        public TestCasesRepository(KCP_DbContext context)
        {
            _context = context;
        }

        public async Task<List<TestCases>> GetAllTestCasesAsync()
        {
            return await _context.TestCases.ToListAsync();
        }

        public async Task<TestCases> GetTestCaseByIdAsync(int id)
        {
            return await _context.TestCases.FindAsync(id);
        }

        public async Task<int> AddTestCaseAsync(TestCases testCase)
        {
            _context.TestCases.Add(testCase);
            await _context.SaveChangesAsync();
            return testCase.CaseId;
        }

        public async Task<bool> UpdateTestCaseAsync(TestCases testCase)
        {
            _context.Entry(testCase).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTestCaseAsync(int id)
        {
            var testCase = await _context.TestCases.FindAsync(id);
            if (testCase == null) return false;
            _context.TestCases.Remove(testCase);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
