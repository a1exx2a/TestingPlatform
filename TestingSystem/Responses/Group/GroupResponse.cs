using TestingPlatform.Responses.Project;
using TestingPlatform.Responses.Course;
using TestingPlatform.Responses.Direction;

namespace TestingPlatform.Responses.Group;

public class GroupResponse : BaseResponse 
{
    public DirectionResponse Direction { get; set; }
    public CourseResponse Course { get; set; }
    public ProjectResponse Project { get; set; }
}