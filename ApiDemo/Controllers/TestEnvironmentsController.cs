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
    public class TestEnvironmentsController : ControllerBase
    {
        private readonly ITestEnvironmentService _testEnvironmentService;

        public TestEnvironmentsController(ITestEnvironmentService testEnvironmentService)
        {
            _testEnvironmentService = testEnvironmentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TestEnvironment>>> GetAllTestEnvironments()
        {
            try
            {
                var environments = await _testEnvironmentService.GetAllTestEnvironmentsAsync();
                return Ok(environments);
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or return an error response.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{EnvironmentId}")]
        public async Task<ActionResult<TestEnvironment>> GetTestEnvironment(int environmentId)
        {
            try
            {
                var environment = await _testEnvironmentService.GetTestEnvironmentByIdAsync(environmentId);

                if (environment == null)
                {
                    return NotFound();
                }

                return Ok(environment);
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or return an error response.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TestEnvironment>> CreateTestEnvironment(TestEnvironment environment)
        {
            try
            {
                var newEnvironmentId = await _testEnvironmentService.AddTestEnvironmentAsync(environment);

                // Generate the URL for the newly created resource
                var location = Url.Action("GetTestEnvironment", new { EnvironmentId = newEnvironmentId });
                return Created(location, environment);
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or return an error response.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{EnvironmentId}")]
        public async Task<IActionResult> UpdateTestEnvironment(int environmentId, TestEnvironment updatedEnvironment)
        {
            try
            {
                var success = await _testEnvironmentService.UpdateTestEnvironmentAsync(updatedEnvironment);

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

        [HttpDelete("{EnvironmentId}")]
        public async Task<IActionResult> DeleteTestEnvironment(int environmentId)
        {
            try
            {
                var success = await _testEnvironmentService.DeleteTestEnvironmentAsync(environmentId);

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
