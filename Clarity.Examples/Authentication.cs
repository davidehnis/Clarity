using System;

namespace Clarity.Examples
{
    public class Authentication : Actor, IDisposable
    {
        public Authentication()
        {
            Register<Authenticate>(Handle);
        }

        public void Dispose()
        {
        }

        private bool CheckCredentials(Credential o)
        {
            if (o == null) return false;
            return o.Username == "bob" && o.Password == "bob123;";
        }

        private Response Handle(Request request, object data)
        {
            var credential = data as Credential;

            if (CheckCredentials(credential))
            {
                return new UserAuthenticated();
            }

            return new UserNotAuthenticated();
        }
    }
}