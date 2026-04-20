using System.ComponentModel.DataAnnotations;
using TestingPlatform.Domain.Enums;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Requests.Test
{
    public class CreateTestRequest
    {
        [Required]
        public string Title { get; set; }// Название теста
        [Required]
        public string Description { get; set; } // Описание теста
        public bool IsRepeatable { get; set; } = false;// Можно ли тест пройти повторно или есть только одна попытка
        public TestType Type { get; set; }// Тип теста - образовательный, дополнительные активности, другое
        public AnswerType AnswerType { get; set; }// Тип ответа на вопрос
        //[Required]
        public DateTime PublishedAt { get; set; } // Когда опубликован (стал доступен студентам)
        //[Required]
        public DateTime Deadline { get; set; } // Срок выполнения теста
        public int? DurationMinutes { get; set; } // Время на выполнение теста
        public int? PassingScore { get; set; } // Проходной балл (достигнув которого тест больше нельзя пройти)
        public int? MaxAttempts { get; set; } // Максимальное количество попыток прохождения теста
        public List<Question> Questions { get; set; } // Список вопросов в тесте
        public List<Students> Students { get; set; } // Список студентов, для которых доступен тест 
        public List<Project> Projects { get; set; } // Список проектов, для которых доступен тест
        public List<Course> Courses { get; set; } // Список курсов, для которых доступен тест
        public List<Groups> Groups { get; set; } // Список групп, для которых доступен тест
        public List<Direction> Directions { get; set; } // Список направлений, для которых доступен тест

    }
}
