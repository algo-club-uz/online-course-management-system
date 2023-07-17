namespace Course.Api.Exception;

public class ContentNotFoundException : System.Exception
{
    public ContentNotFoundException(string contentId): base($"Content not found with id:{contentId}")
    {
        
    }
    
}