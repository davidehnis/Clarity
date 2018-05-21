using System;

namespace Clarity
{
    public class DefferedAction
    {
        public DefferedAction(Type stateType)
        {
            Type = stateType;
        }

        public Action<object> Action { get; protected set; }

        public Type Type { get; }

        public void ExecuteThis(Action<object> action)
        {
            Action = action;
        }
    }
}