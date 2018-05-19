using System;
using System.Collections.Generic;

namespace Clarity
{
    public class Sample : Server
    {
        public Sample()
        {
            var success = new Condition();
            var failed = new Condition();
            Authenticated = new ConditionalRequest<Authenticate>(CheckCredentials);
        }

        protected ConditionalRequest<Authenticate> Authenticated { get; }

        protected override Response CalculateResponse(Request request)
        {
            if (Authenticated.IsTrue(request as Authenticate))
            {
                return new UserAuthenticated();
            }

            return new UserNotAuthenticated();
        }

        private bool CheckCredentials(Authenticate o)
        {
            return o.Username == "bob" && o.Password == "bob123;";
        }
    }

    public class Server
    {
        public Session Session { get; set; }

        protected List<Type> AcceptsMessages { get; } = new List<Type>();

        protected Dictionary<Request, Condition> RequestConditionMap { get; } = new Dictionary<Request, Condition>();

        public Response Post(Request request)
        {
            if (!AcceptsMessages.Contains(request.GetType())) return Responses.Bad;

            return CalculateResponse(request);
        }

        protected void Accepts<TMessage>()
        {
            AcceptsMessages.Add(typeof(TMessage));
        }

        protected virtual Response CalculateResponse(Request request)
        {
            return new Response();
        }
    }
}