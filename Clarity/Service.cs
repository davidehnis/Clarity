namespace Clarity
{
    public class Service : Server
    {
        public Session To<TCommand>(Subject sub)
        {
            return new Session();
        }
    }
}