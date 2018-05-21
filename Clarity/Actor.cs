using System;
using System.Collections.Generic;

namespace Clarity
{
    /// <summary>Participates in a Session</summary>
    public class Actor : IActor
    {
        /// <summary>The session containing this actor</summary>
        public ISession Owner { get; set; }

        protected Dictionary<Type, Perform> Registrar { get; } = new Dictionary<Type, Perform>();

        protected Dictionary<Type, Action<object>> RegistrarHandles { get; } = new Dictionary<Type, Action<object>>();

        public void Dispose()
        {
        }

        /// <summary>
        /// Processes a request with associated data
        /// </summary>
        /// <param name="request">The request to be processed</param>
        /// <param name="data">   the associated data</param>
        /// <returns>
        /// The actual response after processing request
        /// </returns>
        public Response Request(Request request, object data)
        {
            if (!Registrar.ContainsKey(request.GetType())) return null;
            var action = Registrar[request.GetType()];
            return InvokeRequest(action, request, data);
        }

        protected virtual Response InvokeRequest(Perform action, Request request, object data)
        {
            return action?.Invoke(request, data);
        }

        protected void Register<TRequest>(Perform action) where TRequest : Request, new()
        {
            Registrar.Add(typeof(TRequest), action);
        }
    }
}