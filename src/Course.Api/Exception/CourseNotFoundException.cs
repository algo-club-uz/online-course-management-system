namespace Course.Api.Exception;

public class CourseNotFoundException : System.Exception
{
    public CourseNotFoundException(string courseId) : base($"Course not found with id:{courseId}")
    {
        
    }
    
}