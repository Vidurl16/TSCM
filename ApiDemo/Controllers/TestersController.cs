using API.Interfaces.ServiceInterfaces;
using API.Repository.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestCasesController : ControllerBase
    {
        private readonly ITestCasesService _testCasesService;

        public TestCasesController(ITestCasesService testCasesService)
        {
            _testCasesService = testCasesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TestCases>>> GetAllTestCases()
        {
            try
            {
                var testCases = await _testCasesService.GetAllTestCasesAsync();
                return Ok(testCases);
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or return an error response.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{CaseId}")]
        public async Task<ActionResult<TestCases>> GetTestCase(int caseId)
        {
            try
            {
                var testCase = await _testCasesService.GetTestCaseByIdAsync(caseId);

                if (testCase == null)
                {
                    return NotFound();
                }

                return Ok(testCase);
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or return an error response.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TestCases>> CreateTestCase(TestCases testCase)
        {
            try
            {
                var newCaseId = await _testCasesService.AddTestCaseAsync(testCase);

                // Generate the URL for the newly created resource
                var location = Url.Action("GetTestCase", new { CaseId = newCaseId });
                return Created(location, testCase);
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or return an error response.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{CaseId}")]
        public async Task<IActionResult> UpdateTestCase(int caseId, TestCases updatedTestCase)
        {
            try
            {
                var success = await _testCasesService.UpdateTestCaseAsync(updatedTestCase);

                if (!success)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or return an error response.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{CaseId}")]
        public async Task<IActionResult> DeleteTestCase(int caseId)
        {
            try
            {
                var success = await _testCasesService.DeleteTestCaseAsync(caseId);

                if (!success)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or return an error response.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
