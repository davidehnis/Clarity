using System;

namespace Clarity
{
    /// <summary>
    /// A pre-defined action to take upon receiving a certain
    /// type of Response
    /// </summary>
    public class Operation
    {
        public Operation(Session session)
        {
            Session = session;
        }

        public Session Session { get; }

        protected Action<Response> Action { get; set; }

        public void Execute(Response response)
        {
            Action?.Invoke(response);
        }

        public void ThenExecute(Action<Response> action)
        {
            Action = action;
        }
    }
}