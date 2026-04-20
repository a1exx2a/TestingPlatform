using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TestingPlatform.Domain.Enums;

namespace TestingPlatform.Responses.Test;

public class TestResponse : BaseResponse
{

    public bool? isPublic { get; set; }
    public List<int> groupIds { get; set; }
    public List<int> studentIds { get; set; }


    [Required]
    public string Title { get; set; }// Название теста ++
    [Required]
    public string Description { get; set; } // Описание теста ++
    public bool IsRepeatable { get; set; } = false;// Можно ли тест пройти повторно или есть только одна попытка ++
    public TestType Type { get; set; }// Тип теста - образовательный, дополнительные активности, другое ++
    public DateTime CreatedAt { get; set; } // Когда создан -- ++
    [Required]
    public DateTime Deadline { get; set; } // Срок выполнения теста ++
    public int? DurationMinutes { get; set; } // Время на выполнение теста ++
    public bool IsPublic { get; set; } = false; // Опубликован ли (доступен студентам для прохождения) -- ++
    public int? PassingScore { get; set; } // Проходной балл (достигнув которого тест больше нельзя пройти) ++
    public int? MaxAttempts { get; set; } // Максимальное количество попыток прохождения теста ++
}
