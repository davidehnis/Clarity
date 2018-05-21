using System;

namespace Clarity
{
    public class Condition
    {
        public Condition()
        {
        }

        public Condition(Func<bool> act)
        {
            Act = act;
        }

        public object Action { get; }

        public object Gate { get; }

        public object Subject { get; }

        protected Func<bool> Act { get; }

        public void Execute(Action<Session> action)
        {
        }

        public bool IsTrue()
        {
            if (Act == null) return false;
            return Act();
        }

        public Statement With<T>()
        {
            return new Statement();
        }
    }

    public class ConditionalRequest<T>
    {
        public ConditionalRequest(Func<T, bool> act)
        {
            Evaluator = act;
        }

        public Func<T, bool> Evaluator { get; }

        public bool IsTrue(T request)
        {
            if (Evaluator == null) return false;
            return Evaluator(request);
        }
    }

    public class Gate
    {
    }
}