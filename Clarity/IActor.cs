namespace Clarity
{
    public interface IActor
    {
        ISession Owner { get; set; }

        Response Request(Request request, object data);
    }
}