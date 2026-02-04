using TestingPlatform.Application.Dtos;
namespace TestingPlatform.Application.Interfaces;

public interface IAnswerRepository
{
    Task<int> CreateAsync(AnswerDto answerDto);
    Task UpdateAsync(AnswerDto answerDto);
}