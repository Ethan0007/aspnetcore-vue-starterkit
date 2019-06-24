namespace server.Helpers.Errors
{
    public class ErrorException : System.Exception
    {
         public int StatusCode = 500;
    }
}