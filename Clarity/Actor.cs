using System;
using System.Collections.Generic;

namespace Clarity
{
    public class Actor : IActor
    {
        public Actor()
        {
        }

        public ISession Owner { get; set; }

        protected Dictionary<Type, Func<Request, object, Response>> Registrar { get; } = new Dictionary<Type, Func<Request, object, Response>>();

        protected Dictionary<Type, Action<object>> RegistrarHandles { get; } = new Dictionary<Type, Action<object>>();

        public Response Request(Request request, object data)
        {
            if (!Registrar.ContainsKey(request.GetType())) return null;
            var action = Registrar[request.GetType()];
            return InvokeRequest(action, request, data);
        }

        protected virtual Response InvokeRequest(Func<Request, object, Response> action, Request request, object data)
        {
            return action?.Invoke(request, data);
        }

        protected void Register<TRequest>(Func<Request, object, Response> action) where TRequest : Request, new()
        {
            Registrar.Add(typeof(TRequest), action);
        }

        protected void Register<T>(Action<T> action) where T : Request
        {
            RegistrarHandles.Add(typeof(T), (Action<object>)action);
        }
    }
}