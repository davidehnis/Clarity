using System;
using System.Collections.Generic;

namespace Clarity
{
    public class Actor : IActor
    {
        public Actor()
        {
        }

        public ISession Owner { get; set; }

        protected Dictionary<Type, Func<Request, object, Response>> Registrar { get; } = new Dictionary<Type, Func<Request, object, Response>>();

        public Response Request(Request request, object data)
        {
            if (!Registrar.ContainsKey(request.GetType())) return null;
            var action = Registrar[request.GetType()];
            return InvokeRequest(action, request, data);
        }

        protected virtual Response InvokeRequest(Func<Request, object, Response> action, Request request, object data)
        {
            return action?.Invoke(request, data);
        }
    }

    public class Client : Actor
    {
        public Client()
        {
        }

        public static Authentication Authentication { get; }

        public void AuthenticateUser(User user)
        {
            // action server intention subject
            using (var session = Session.Start(this).With<Authentication>().To<Authenticate, User>(user))
            {
                session.WhenServerRespondsWith<UserAuthenticated>().ThenExecute(OnUserAuthenticated);
                session.WhenServerRespondsWith<UserNotAuthenticated>().ThenExecute(OnUserNotAuthenticated);
                session.If<ThrowsException>().ExecuteThis(handleException);

                session.Execute();
            }
        }

        private void handleException(object ex)
        {
        }

        private void OnUserAuthenticated()
        {
            Console.WriteLine("User Authenticated");
        }

        private void OnUserNotAuthenticated()
        {
            Console.WriteLine("User Not Authenticated");
        }
    }
}