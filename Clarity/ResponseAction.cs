using System;

namespace Clarity
{
    public class ResponseAction
    {
        public ResponseAction(Session session)
        {
            Session = session;
        }

        public Session Session { get; }

        protected Action Action { get; set; }

        public void Execute()
        {
            Action?.Invoke();
        }

        public void ThenExecute(Action action)
        {
            Action = action;
        }
    }
}