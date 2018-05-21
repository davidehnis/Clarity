using System;
using System.Collections.Generic;

namespace Clarity
{
    /// <summary>
    /// A session represents a pre-configured connection from
    /// the 'client' to the 'server'
    /// </summary>
    public class Session : IDisposable, ISession
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

        protected Dictionary<Type, Action<object>> Registrar { get; } = new Dictionary<Type, Action<object>>();

        protected Dictionary<Type, ResponseAction> ResponseRegistery { get; } = new Dictionary<Type, ResponseAction>();

        protected Dictionary<Type, DefferedAction> States { get; } = new Dictionary<Type, DefferedAction>();

        public static Session Start(IActor requester)
        {
            return new Session(requester);
        }

        public void Dispose()
        {
        }

        public void Execute()
        {
            try
            {
                var response = Server.Request(Request, Data);
                var action = ResponseRegistery[response.GetType()];
                action.Execute();
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        public DefferedAction If<T>()
        {
            var act = new DefferedAction(typeof(T));
            States.Add(typeof(T), act);

            return act;
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

        public ResponseAction WhenServerRespondsWith<T>() where T : Response
        {
            var action = new ResponseAction(this);
            ResponseRegistery.Add(typeof(T), action);

            return action;
        }

        public Session With<T>() where T : Actor, IDisposable, new()
        {
            Server = new T();
            Server.Owner = this;
            return this;
        }

        protected void ProcessException(Exception ex)
        {
            var act = Registrar[typeof(ThrowsException)];
            act.Invoke(ex);
        }

        protected void Register<TStatus>(Action<object> action)
        {
            Registrar.Add(typeof(TStatus), action);
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