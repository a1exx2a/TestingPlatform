namespace practice.Responses.Student;

public class StudentResponse
{
    ///
    /// Идентификатор
    ///
    public int Id { get; set; }

    ///
    /// Логин
    ///
    public string Login { get; set; }

    ///
    /// Email
    ///
    public string Email { get; set; }

    ///
    /// Имя
    ///
    public string FirstName { get; set; }

    ///
    /// Отчество
    ///
    public string MiddleName { get; set; }

    ///
    /// Фамилия
    ///
    public string LastName { get; set; }

    ///
    /// Телефон
    ///
    public string Phone { get; set; }

    ///
    /// Ссылка на профиль VK
    ///
    public string VkProfileLink { get; set; }
}