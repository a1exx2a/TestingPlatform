using practice.Responses.Group;
using TestingPlatform.Domain.Enums;
using TestingPlatform.Responses.Course;
using TestingPlatform.Responses.Direction;
using TestingPlatform.Responses.Group;
using TestingPlatform.Responses.Project;
using TestingPlatform.Responses.Student;


namespace TestingPlatform.Responses.Test;

public class TestForManagerResponse
{
    ///
    /// Идентификатор
    ///
    public int Id { get; set; }

    /// Название теста
    /// </summary>
    public string Title { get; set; }

    ///
    /// Описание теста
    ///
    public string Description { get; set; }

    ///
    /// Можно ли тест пройти повторно или есть только одна попытка
    ///
    public bool IsRepeatable { get; set; }

    ///
    /// Тип теста - образовательный, дополнительные активности, другое
    ///
    public TestType Type { get; set; }

    ///
    /// Дата создания
    ///
    public DateTime CreatedAt { get; set; }

    ///
    /// Когда опубликован (стал доступен студентам)
    ///
    public DateTime PublishedAt { get; set; }

    ///
    /// Срок выполнения теста
    ///
    public DateTime Deadline { get; set; }

    ///
    /// Время на выполнение теста
    ///
    public int? DurationMinutes { get; set; }

    ///
    /// Опубликован ли (доступен студнтам для прохождения)
    ///
    public bool IsPublic { get; set; }

    ///
    /// Проходной балл (достигнув которого тест больше нельзя пройти)
    ///
    public int? PassingScore { get; set; }

    ///
    /// Максимальное количество попыток прохождения теста
    ///
    public int? MaxAttempts { get; set; }

    ///
    /// Список студентов, для которых доступен тест (напрямую)
    ///
    public List<StudentForTestResponse> Students { get; set; }

    ///
    /// Список проектов, для которых доступен тест
    ///
    public List<ProjectResponse> Projects { get; set; }

    ///
    /// Список курсов, для которых доступен тест
    ///
    public List<CourseResponse> Courses { get; set; }

    ///
    /// Список групп, для которых доступен тест
    ///
    public List<ShortGroupResponse> Groups { get; set; }

    ///
    /// Список направлений, для которых доступен тест
    ///
    public List<DirectionResponse> Directions { get; set; }
}