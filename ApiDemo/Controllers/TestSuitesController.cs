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
    public class TestSuitesController : ControllerBase
    {
        private readonly ITestSuiteService _testSuiteService;

        public TestSuitesController(ITestSuiteService testSuiteService)
        {
            _testSuiteService = testSuiteService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TestSuite>>> GetAllTestSuites()
        {
            try
            {
                var testSuites = await _testSuiteService.GetAllTestSuitesAsync();
                return Ok(testSuites);
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or return an error response.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{SuiteId}")]
        public async Task<ActionResult<TestSuite>> GetTestSuite(int suiteId)
        {
            try
            {
                var testSuite = await _testSuiteService.GetTestSuiteByIdAsync(suiteId);

                if (testSuite == null)
                {
                    return NotFound();
                }

                return Ok(testSuite);
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or return an error response.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TestSuite>> CreateTestSuite(TestSuite testSuite)
        {
            try
            {
                var newSuiteId = await _testSuiteService.AddTestSuiteAsync(testSuite);

                // Generate the URL for the newly created resource
                var location = Url.Action("GetTestSuite", new { SuiteId = newSuiteId });
                return Created(location, testSuite);
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or return an error response.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{SuiteId}")]
        public async Task<IActionResult> UpdateTestSuite(int suiteId, TestSuite updatedTestSuite)
        {
            try
            {
                var success = await _testSuiteService.UpdateTestSuiteAsync(updatedTestSuite);

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

        [HttpDelete("{SuiteId}")]
        public async Task<IActionResult> DeleteTestSuite(int suiteId)
        {
            try
            {
                var success = await _testSuiteService.DeleteTestSuiteAsync(suiteId);

                if (!success)
                {
                    return NotFound
