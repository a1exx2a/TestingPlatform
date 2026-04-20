using System.ComponentModel.DataAnnotations;

namespace TestingPlatform.Domain.Models;
public class Course
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public List<Groups> Groups { get; set; }
    public List<Test> Tests { get; set; }
}
