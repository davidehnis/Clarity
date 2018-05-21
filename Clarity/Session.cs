using System;
using System.Collections.Generic;

namespace Clarity
{
    /// <summary>
    /// A session represents a pre-configured connection from
    /// one Actor to Another
    /// </summary>
    public class Session : ISession
    {
        public Session()
        {
        }

        public Session(IActor client)
        {
            Client = client;
        }

        public IActor Client { get; }

        public object Data { get; protected set; }

        public Request Request { get; protected set; }

        public IActor Server { get; protected set; }

        protected Dictionary<Type, Operation> ResponseRegistery { get; } = new Dictionary<Type, Operation>();

        public static Session Start(IActor requester)
        {
            return new Session(requester);
        }

        public void Dispose()
        {
            Client?.Dispose();
            Server?.Dispose();
        }

        public void Execute()
        {
            try
            {
                var response = Server.Request(Request, Data);
                if (response == null) return;

                var action = ResponseRegistery[response.GetType()];
                action.Execute(response);
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        public Operation IfServerRespondsWith<T>() where T : Response
        {
            var action = new Operation(this);
            ResponseRegistery.Add(typeof(T), action);

            return action;
        }

        public void RespondWith(Response response)
        {
        }

        public Session To<TRequest, TData>(TData data) where TRequest : Request, new()
        {
            Request = new TRequest();
            Data = data;
            return this;
        }

        public Session With<T>() where T : Actor, IDisposable, new()
        {
            Server = new T();
            Server.Owner = this;
            return this;
        }

        protected void ProcessException(Exception ex)
        {
            var act = ResponseRegistery[typeof(Error)];
            act?.Execute(new Error(ex));
        }

        /// <summary>
        /// if current status is ever in the X state, then
        /// execute the action
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private void Handle()
        {
            throw new NotImplementedException();
        }
    }
}