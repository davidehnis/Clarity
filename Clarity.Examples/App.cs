using System;

namespace Clarity.Examples
{
    /// <summary></summary>
    public class App : IActor
    {
        public ISession Owner { get; set; }

        public string Response { get; protected set; } = "";

        public void AuthenticateUser(Credential credential)
        {
            // action server intention subject
            using (var session = Session.Start(this).With<Authentication>().To<Authenticate, Credential>(credential))
            {
                session.IfServerRespondsWith<Authenticated>().ThenExecute(OnUserAuthenticated);
                session.IfServerRespondsWith<NotAuthenticated>().ThenExecute(OnUserNotAuthenticated);
                session.IfServerRespondsWith<Error>().ThenExecute(HandleException);

                session.Execute();
            }
        }

        public void Dispose()
        {
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

        private void OnUserAuthenticated(Response response)
        {
            var message = "User Authenticated";
            Console.WriteLine(message);
            Response = message;
        }

        private void OnUserNotAuthenticated(Response response)
        {
            var message = "User Not Authenticated";
            Console.WriteLine(message);
            Response = message;
        }
    }
}