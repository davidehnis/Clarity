using System;

namespace Clarity
{
    public interface ISession : IDisposable
    {
        IActor Client { get; }

        object Data { get; }

        Request Request { get; }

        IActor Server { get; }

        void Execute();

        Operation IfServerRespondsWith<T>() where T : Response;

        void RespondWith(Response response);

        //void Reverberate<TVerb>(Server server);
        //void StartServerSession(Server server);
        Session To<TRequest, TData>(TData data) where TRequest : Request, new();

        Session With<T>() where T : Actor, IDisposable, new();
    }
}