namespace Clarity
{
    public class Failed : Response
    {
    }

    public class Response
    {
        public Response()
        {
        }

        public Response(string message)
        {
            Message = message;
        }

        public string Message { get; } = "";
    }

    public class Success : Response
    {
    }
}