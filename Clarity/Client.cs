using System;

namespace Clarity
{
    public class Client
    {
        public static Authentication Authentication { get; }

        public Session Session { get; }

        public void AuthenticateUser(User user)
        {
            // action server intention subject
            using (var session = Start<Session>().With<Authentication>().To<Authenticate, User>(user))
            {
                // Condition subject condition action target
                When<Responded>(session).With<UserAuthenticated>().Execute(userAuthenticated);
                When<Responded>(session).With<UserNotAuthenticated>().Execute(userNotAuthenticated);

                // subject condition status action target
                session.WhenServer<Responds>().With<UserAuthenticated>().Execute(userAuthenticated);

                If<ThrowsException>(session).Execute(handleException);
                session.Execute();
            }
        }

        public Condition If<T>(Session session)
        {
            return new Condition();
        }

        public Session Start<TService>() where TService : Noun
        {
            return new Session(this);
        }

        public Condition When<T>(Session session) where T : Condition
        {
            return new Condition();
        }

        private void handleException(Session session)
        {
        }

        private void userAuthenticated(Session session)
        {
            Console.WriteLine("User Authenticated");
        }

        private void userNotAuthenticated()
        {
            Console.WriteLine("User Not Authenticated");
        }
    }
}