using TestingPlatform.Domain.Enums;

namespace TestingPlatform.Responses.Test;

public class TestForStudentResponse
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
    /// Проходной балл (достигнув которого тест больше нельзя пройти)
    ///
    public int? PassingScore { get; set; }

    ///
    /// Максимальное количество попыток прохождения теста
    ///
    public int? MaxAttempts { get; set; }
}