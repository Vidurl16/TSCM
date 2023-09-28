namespace API.Repository
{
    using API.Interfaces.RepositoryInterfaces;
    using API.Repository.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TestEnvironmentRepository : ITestEnvironmentRepository
    {
        private readonly KCP_DbContext _context;

        public TestEnvironmentRepository(KCP_DbContext context)
        {
            _context = context;
        }

        public async Task<List<TestEnvironment>> GetAllTestEnvironmentsAsync()
        {
            return await _context.TestEnvironments.ToListAsync();
        }

        public async Task<TestEnvironment> GetTestEnvironmentByIdAsync(int id)
        {
            return await _context.TestEnvironments.FindAsync(id);
        }

        public async Task<int> AddTestEnvironmentAsync(TestEnvironment environment)
        {
            _context.TestEnvironments.Add(environment);
            await _context.SaveChangesAsync();
            return environment.EnvironmentId;
        }

        public async Task<bool> UpdateTestEnvironmentAsync(TestEnvironment environment)
        {
            _context.Entry(environment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTestEnvironmentAsync(int id)
        {
            var environment = await _context.TestEnvironments.FindAsync(id);
            if (environment == null) return false;
            _context.TestEnvironments.Remove(environment);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
