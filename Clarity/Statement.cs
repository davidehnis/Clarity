using System;

namespace Clarity
{
    public class Statement
    {
        public void Execute(Action<Session> action, Session session)
        {
            action.Invoke(session);
        }
    }
}