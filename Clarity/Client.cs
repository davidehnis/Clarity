using System;

namespace Clarity
{
    public class Client : Actor
    {
        public Client()
        {
        }

        //public static Authentication Authentication { get; }

        public void AuthenticateUser(User user)
        {
            // action server intention subject
            using (var session = Session.Start(this).With<Authentication>().To<Authenticate, User>(user))
            {
                session.WhenServerRespondsWith<UserAuthenticated>().ThenExecute(OnUserAuthenticated);
                session.WhenServerRespondsWith<UserNotAuthenticated>().ThenExecute(OnUserNotAuthenticated);
                session.If<ThrowsException>().ExecuteThis(HandleException);

                session.Execute();
            }
        }

        /// <summary></summary>
        /// <param name="ex">ThrowsException</param>
        private void HandleException(object ex)
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