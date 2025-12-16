using System.ComponentModel.DataAnnotations;

namespace TestingPlatform.Domain.Models;
public class Student
{
    public int Id { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required]
    public string VkProfileLink { get; set; }
    [Required]
    public int UserId { get; set; }
    public Users User { get; set; }
    public List<Test> Tests { get; set; }
    public List<Attempt> Attempts { get; set; }
    public List<TestResult> TestResults { get; set;} 
}
