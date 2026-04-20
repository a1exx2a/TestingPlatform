using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TestingPlatform.Application.Dtos;
using TestingPlatform.Application.Interfaces;
using TestingPlatform.Requests.Test;
using TestingPlatform.Responses.Test;
using TestingPlatform.Infrastructure.Exceptions;


namespace TestingPlatform.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestsController(ITestRepository testRepository, IMapper mapper) : ControllerBase
{
    [HttpGet("manage")]
    [ProducesResponseType(typeof(IEnumerable<TestResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTestsForManager([FromQuery] bool? isPublic, [FromQuery] List<int> groupIds, [FromQuery] List<int> studentIds)
    {
        var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        var tests = await testRepository.GetAllAsync(isPublic, groupIds, studentIds);

        return Ok(mapper.Map<IEnumerable<TestResponse>>(tests));
    }

    [HttpGet("{id:int}/manage")]
    [ProducesResponseType(typeof(TestResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTestForManagerById(int id)
    {
        var test = await testRepository.GetByIdAsync(id);
        return Ok(mapper.Map<TestResponse>(test));
    }


    [HttpGet("{id:int}/available")]
    [ProducesResponseType(typeof(IEnumerable<TestResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTestsForStudent(int id)
    {
        var tests = await testRepository.GetAllForStudent(id);
        return Ok(mapper.Map<IEnumerable<TestResponse>>(tests));
    }


    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(TestResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTestForStudentById(int id)
    {
        var test = await testRepository.GetByIdAsync(id);
        return Ok(mapper.Map<TestResponse>(test));
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateTest(CreateTestRequest test)
    {
        var testId = await testRepository.CreateAsync(mapper.Map<TestDto>(test));
        return StatusCode(StatusCodes.Status201Created, new { id = testId });
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateTest(UpdateTestRequest test)
    {
        await testRepository.UpdateAsync(mapper.Map<TestDto>(test));
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        await testRepository.DeleteAsync(id);
        return NoContent();
    }
}