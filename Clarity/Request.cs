namespace Clarity
{
    public class Messages
    {
        public static string RequestNotFound { get; } = "The server does not accept this particular request.";

        public static string RequestUnhandled { get; } = "The server could not handle this particular request.";
    }

    public class Request : Command
    {
        public Session Session { get; }
    }

    public class Responses
    {
        public static Response Bad { get; } = new Response(Messages.RequestNotFound);

        public static Response Unhandled { get; } = new Response(Messages.RequestUnhandled);
    }
}