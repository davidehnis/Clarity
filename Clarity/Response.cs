namespace Clarity
{
    /// <summary>Base class for all Response types</summary>
    public abstract class Response
    {
        protected Response()
        {
        }

        protected Response(string message)
        {
            Message = message;
        }

        public string Message { get; } = "";
    }
}