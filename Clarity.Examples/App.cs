using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clarity.Examples
{
    public class App : IActor
    {
        public ISession Owner { get; set; }

        public void AuthenticateUser(Credential credential)
        {
            // action server intention subject
            using (var session = Session.Start(this).With<Authentication>().To<Authenticate, Credential>(credential))
            {
                session.WhenServerRespondsWith<UserAuthenticated>().ThenExecute(OnUserAuthenticated);
                session.WhenServerRespondsWith<UserNotAuthenticated>().ThenExecute(OnUserNotAuthenticated);
                session.If<ThrowsException>().ExecuteThis(HandleException);

                session.Execute();
            }
        }

        public Response Request(Request request, object data)
        {
            throw new NotImplementedException();
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