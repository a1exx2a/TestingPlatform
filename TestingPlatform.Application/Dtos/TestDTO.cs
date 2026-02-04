using System.ComponentModel.DataAnnotations;
using TestingPlatform.Application.Dtos;
using TestingPlatform.Domain.Enums;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Application.Dtos;

public class TestDto
{
    public int Id { get; set; } // Идентификатор
    public string Title { get; set; }// Название теста
    public string Description { get; set; } // Описание теста
    public bool IsRepeatable { get; set; } = false;// Можно ли тест пройти повторно или есть только одна попытка
    public TestType Type { get; set; }// Тип теста - образовательный, дополнительные активности, другое
    public AnswerType AnswerType { get; set; }// Тип ответа на вопрос
    public DateTimeOffset CreatedAt { get; set; } // Когда создан
    public DateTimeOffset PublishedAt { get; set; } // Когда опубликован (стал доступен студентам)
    public DateTimeOffset Deadline { get; set; } // Срок выполнения теста
    public int? DurationMinutes { get; set; } // Время на выполнение теста
    public bool IsPublic { get; set; } = false; // Опубликован ли (доступен студнтам для прохождения)
    public int? PassingScore { get; set; } // Проходной балл (достигнув которого тест больше нельзя пройти)
    public int? MaxAttempts { get; set; } // Максимальное количество попыток прохождения теста
    public List<Question> Questions { get; set; } // Список вопросов в тесте
    public List<Student> Students { get; set; } // Список студентов, для которых доступен тест
    public List<Project> Projects { get; set; } // Список проектов, для которых доступен тест
    public List<Course> Courses { get; set; } // Список курсов, для которых доступен тест
    public List<Group> Groups { get; set; } // Список групп, для которых доступен тест
    public List<Direction> Directions { get; set; } // Список направлений, для которых доступен тест
    public List<Attempt> Attempts { get; set; }
    public TestResult TestResult { get; set; }
}