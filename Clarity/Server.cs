using System;
using System.Collections.Generic;
using System.Threading;

namespace Clarity
{
    public class Server : IDisposable
    {
        public Session Session { get; set; }

        protected Dictionary<Type, Action<object>> Registrar { get; } = new Dictionary<Type, Action<object>>();

        public void Dispose()
        {
            Session?.Dispose();
        }

        protected void Register<T>(Action<T> action) where T : Request
        {
            Registrar.Add(typeof(T), (Action<object>)action);
        }
    }
}