namespace API.Repository
{
    using API.Interfaces.RepositoryInterfaces;
    using API.Repository.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TestSuiteRepository : ITestSuiteRepository
    {
        private readonly ApplicationDbContext _context;

        public TestSuiteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TestSuite>> GetAllTestSuitesAsync()
        {
            return await _context.TestSuites.ToListAsync();
        }

        public async Task<TestSuite> GetTestSuiteByIdAsync(int id)
        {
            return await _context.TestSuites.FindAsync(id);
        }

        public async Task<int> AddTestSuiteAsync(TestSuite testSuite)
        {
            _context.TestSuites.Add(testSuite);
            await _context.SaveChangesAsync();
            return testSuite.SuiteId;
        }

        public async Task<bool> UpdateTestSuiteAsync(TestSuite testSuite)
        {
            _context.Entry(testSuite).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTestSuiteAsync(int id)
        {
            var testSuite = await _context.TestSuites.FindAsync(id);
            if (testSuite == null) return false;
            _context.TestSuites.Remove(testSuite);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
