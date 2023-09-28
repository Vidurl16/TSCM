using API.Interfaces.ServiceInterfaces;
using API.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestExecutionsController : ControllerBase
    {
        private readonly ITestExecutionService _testExecutionService;

        public TestExecutionsController(ITestExecutionService testExecutionService)
        {
            _testExecutionService = testExecutionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TestExecution>>> GetAllTestExecutions()
        {
            try
            {
                var testExecutions = await _testExecutionService.GetAllTestExecutionsAsync();
                return Ok(testExecutions);
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or return an error response.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{ExecutionId}")]
        public async Task<ActionResult<TestExecution>> GetTestExecution(int executionId)
        {
            try
            {
                var testExecution = await _testExecutionService.GetTestExecutionByIdAsync(executionId);

                if (testExecution == null)
                {
                    return NotFound();
                }

                return Ok(testExecution);
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or return an error response.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TestExecution>> CreateTestExecution(TestExecution testExecution)
        {
            try
            {
                var newExecutionId = await _testExecutionService.AddTestExecutionAsync(testExecution);

                // Generate the URL for the newly created resource
                var location = Url.Action("GetTestExecution", new { ExecutionId = newExecutionId });
                return Created(location, testExecution);
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or return an error response.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{ExecutionId}")]
        public async Task<IActionResult> UpdateTestExecution(int executionId, TestExecution updatedTestExecution)
        {
            try
            {
                var success = await _testExecutionService.UpdateTestExecutionAsync(updatedTestExecution);

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

        [HttpDelete("{ExecutionId}")]
        public async Task<IActionResult> DeleteTestExecution(int executionId)
        {
            try
            {
                var success = await _testExecutionService.DeleteTestExecutionAsync(executionId);

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
