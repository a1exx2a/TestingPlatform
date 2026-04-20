using TestingPlatform.Application.Dtos;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Application.Interfaces;

public interface ITestRepository
{
    Task<IEnumerable<TestDto>> GetAllAsync(bool? isPublic, List<int> groupIds, List<int> studentIds);
    Task<TestDto> GetByIdAsync(int id);
    Task<int> CreateAsync(TestDto testDto);
    Task UpdateAsync(TestDto testDto);
    Task DeleteAsync(int id);
    Task<IEnumerable<TestDto>> GetAllForStudent(int studentId);
    Task<IEnumerable<TestDto>> GetTopRecentAsync(int count = 5);

}