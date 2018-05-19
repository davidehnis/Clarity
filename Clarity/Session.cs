using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace Clarity
{
    public class Session : Noun, IDisposable
    {
        public Session()
        {
        }

        public Session(Client client)
        {
            Client = client;
        }

        public Client Client { get; }

        public Command Command { get; protected set; }

        public object Data { get; protected set; }

        public Server Server { get; protected set; }

        protected Type DataType { get; set; }

        protected Dictionary<Verb, Action<Verb>> Map { get; } = new Dictionary<Verb, Action<Verb>>();

        protected Dictionary<Server, Verb> Registry { get; } = new Dictionary<Server, Verb>();

        protected Dictionary<Server, Dictionary<Message, Response>> Trace { get; } = new Dictionary<Server, Dictionary<Message, Response>>();

        public void Dispose()
        {
        }

        public void Execute()
        {
        }

        public Request Request()
        {
            return new Request();
        }

        public void Respond(Server server, Status status)
        {
        }

        public void Reverberate<TVerb>(Server server)
        {
            Act(Registry[server]);
        }

        public void StartServerSession(Server server)
        {
            Server = server;
            Server.Session = this;
        }

        public Session To<TCommand, TData>(TData data) where TCommand : Command, new()
        {
            Command = new TCommand();
            Data = data;
            DataType = typeof(TData);
            return this;
        }

        public Status WhenServer<TVerb>() where TVerb : Verb
        {
            return new Status();
        }

        public Session With<T>() where T : Server, IDisposable, new()
        {
            Server = new T();
            return new Session();
        }

        protected void Act(Verb verb)
        {
        }

        protected void Register(Verb verb)
        {
            Registry.Add(Server, verb);
        }
    }
}