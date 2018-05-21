using System;

namespace Clarity
{
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
}