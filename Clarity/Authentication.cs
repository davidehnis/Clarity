using System;

namespace Clarity
{
    public class Authentication : Service, IDisposable
    {
        public void Dispose()
        {
        }

        public Session To<TCommand>(Subject sub)
        {
            return new Session();
        }
    }
}