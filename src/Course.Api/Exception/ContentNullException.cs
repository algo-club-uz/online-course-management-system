namespace Course.Api.Exception;

public class ContentNullException : System.Exception
{
    public ContentNullException(string content) : base(message:content)
    {
        
    }
    
}