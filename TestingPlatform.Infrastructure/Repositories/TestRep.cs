using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestingPlatform.Application.Dtos;
using TestingPlatform.Application.Interfaces;
using TestingPlatform.Domain.Models;
using TestingPlatform.Infrastructure.Data;

namespace TestingPlatform.Infrastructure.Repositories;

public class TestRepository(AppDbContext appDbContext, IMapper mapper) :ITestRepository
{
    public async Task<IEnumerable<TestDto>> GetAllAsync(bool? isPublic, List<int> groupIds, List<int> studentIds)
    {
        var tests = appDbContext.Tests
            .OrderByDescending(t => t.PublishedAt)
            .ThenBy(t => t.Title)
            .AsNoTracking()
            .AsQueryable();

        if (isPublic is not null)
            tests = tests.Where(t => t.IsPublic == isPublic);

        if (groupIds.Any())
            tests = tests.Where(t => t.Groups.Any(g => groupIds.Contains(g.Id)));

        if (studentIds.Any())
            tests = tests.Where(t => t.Students.Any(s => studentIds.Contains(s.Id)));

        return mapper.Map<IEnumerable<TestDto>>(await tests.ToListAsync());
    }

    public async Task<TestDto> GetByIdAsync(int id)
    {
        var test = await appDbContext.Tests
            .Include(t => t.Courses)
            .Include(t => t.Groups)
            .Include(t => t.Directions)
            .Include(t => t.Students)
            .Include(t => t.Projects)
            .AsNoTracking()
            .FirstOrDefaultAsync(test => test.Id == id);

        if (test == null)
        {
            throw new Exception("Студент не найден.");
        }

        return mapper.Map<TestDto>(test);
    }

    public async Task<int> CreateAsync(TestDto testDto)
    {
        var test = mapper.Map<Test>(testDto);

        var testId = await appDbContext.AddAsync(test);
        await appDbContext.SaveChangesAsync();

        return testId.Entity.Id;
    }

    public async Task UpdateAsync(TestDto testDto)
    {
        var test = await appDbContext.Tests.FirstOrDefaultAsync(test => test.Id == testDto.Id);

        if (test == null)
        {
            throw new Exception("Тест не найден.");
        }
        await appDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var test = await appDbContext.Tests.FirstOrDefaultAsync(test => test.Id == id);

        if (test == null)
        {
            throw new Exception("Тест не найден.");
        }

        appDbContext.Tests.Remove(test);
        await appDbContext.SaveChangesAsync();
    }
}

