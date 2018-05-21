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

        public string Response { get; protected set; } = "";

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
            if (ex is Exception exception) Response = exception.Message;
        }

        private void OnUserAuthenticated()
        {
            var message = "User Authenticated";
            Console.WriteLine(message);
            Response = message;
        }

        private void OnUserNotAuthenticated()
        {
            var message = "User Not Authenticated";
            Console.WriteLine(message);
            Response = message;
        }
    }
}