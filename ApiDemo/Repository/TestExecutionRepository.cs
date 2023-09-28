using API.Interfaces.RepositoryInterfaces;
using API.Repository;
using API.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class TestExecutionRepository : ITestExecutionRepository
{
    private readonly KCP_DbContext _context;

    public TestExecutionRepository(KCP_DbContext context)
    {
        _context = context;
    }

    public async Task<List<TestExecution>> GetAllTestExecutionsAsync()
    {
        return await _context.TestExecutions.ToListAsync();
    }

    public async Task<TestExecution> GetTestExecutionByIdAsync(int id)
    {
        return await _context.TestExecutions.FindAsync(id);
    }

    public async Task<int> AddTestExecutionAsync(TestExecution testExecution)
    {
        _context.TestExecutions.Add(testExecution);
        await _context.SaveChangesAsync();
        return testExecution.ExecutionId;
    }

    public async Task<bool> UpdateTestExecutionAsync(TestExecution testExecution)
    {
        _context.Entry(testExecution).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteTestExecutionAsync(int id)
    {
        var testExecution = await _context.TestExecutions.FindAsync(id);
        if (testExecution == null) return false;
        _context.TestExecutions.Remove(testExecution);
        await _context.SaveChangesAsync();
        return true;
    }
}
