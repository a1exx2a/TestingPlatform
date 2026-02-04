using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestingPlatform.Application.Dtos;
using TestingPlatform.Application.Interfaces;
using TestingPlatform.Domain.Models;
using TestingPlatform.Infrastructure.Data;

namespace TestingPlatform.Infrastructure.Repositories;

public class AnswerRepository(AppDbContext appDbContext, IMapper mapper) :IAnswerRepository
{
    public async Task<int> CreateAsync(AnswerDto answerDto)
    {
        var answer = mapper.Map<Answer>(answerDto);

        var QuestionId = await appDbContext.AddAsync(answer);
        await appDbContext.SaveChangesAsync();

        return QuestionId.Entity.Id;
    }

    public async Task UpdateAsync(AnswerDto answerDto)
    {
        var answer = await appDbContext.Answers.FirstOrDefaultAsync(answer => answer.Id == answerDto.Id);

        if (answer == null)
        {
            throw new Exception("Ответ не найден.");
        }

        await appDbContext.SaveChangesAsync();
    }

}

