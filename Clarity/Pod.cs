using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Clarity
{
    public class Act
    {
        public This<User> To<T>()
        {
            return new This<User>(message);
        }
    }

    public class Authenticate : Message
    {
        public void
    }

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

    public class Command
    {
    }

    public class Condition
    {
        public void Execute(Action action)
        {
        }

        public T For<T>()
        {
        }

        public Statement With<T>()
        {
        }
    }

    public class Host : Pod
    {
        public static Authentication Authentication { get; }

        public Session Session { get; }

        public void AuthenticateUser(User user)
        {
            using (var session = Start<Session>().With<Authentication>().To<Authenticate>(user))
            {
                When<Responded>(session).With<UserAuthenticated>().Execute(userAuthenticated);
                When<Responded>(session).With<UserNotAuthenticated>().Execute(userNotAuthenticated);

                If<ThrowsException>(session).Execute(handleException);
                session.Execute();
            }
        }

        public void Execute()
        {
            using (var session = Start.Session().With<Authentication>())
            {
                session.Request();
            }
        }

        public Condition If<T>(Session session)
        {
            return new Condition();
        }

        public With Start<T>()
        {
        }

        public Condition When<T>(Session session)
        {
            return new Condition();
        }

        private void handleException()
        {
        }

        private void userAuthenticated()
        {
        }

        private void userNotAuthenticated()
        {
        }
    }

    public class Message
    {
    }

    public class Pod
    {
        public Start Start { get; }
    }

    public class Purpose
    {
    }

    public class Push : Session
    {
    }

    public class Request : Command
    {
    }

    public class Responded : Condition
    {
        public Statement With<TResponse>()
        {
            return new Statement();
        }
    }

    public class Response
    {
    }

    public class Service : Pod
    {
    }

    public class Session : IDisposable
    {
        public void Dispose()
        {
        }

        public void Execute()
        {
        }

        public Request Request()
        {
            return new Request();
        }

        public Session With<T>() where T : IDisposable, new()
        {
            return new Session();
        }
    }

    public class Spawn : Command
    {
    }

    public class Start : Verb
    {
        public static Session Session()
        {
            return new Session();
        }
    }

    public class Statement
    {
        public void Execute(Action action)
        {
            action.Invoke();
        }
    }

    public class Subject
    {
    }

    public class This<T> : Purpose
    {
        public This()
        {
        }
    }

    public class ThrowsException : Condition
    {
        public void Execute(Action action)
        {
        }
    }

    public class Truth : Condition
    {
        public bool IsTrue()
        {
            return true;
        }
    }

    public class User : Subject
    {
    }

    public class UserAuthenticated : Response
    {
    }

    public class UserNotAuthenticated : Response
    {
    }

    public class Verb
    {
    }

    public class Wait : Command
    {
    }

    public class With
    {
        public T With<T>()
        {
        }
    }
}