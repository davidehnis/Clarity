using System;

namespace Clarity
{
    public interface ISession
    {
        IActor Client { get; }

        object Data { get; }

        Request Request { get; }

        IActor Server { get; }

        void Dispose();

        void Execute();

        DefferedAction If<T>();

        void RespondWith(Response response);

        //void Reverberate<TVerb>(Server server);
        //void StartServerSession(Server server);
        Session To<TRequest, TData>(TData data) where TRequest : Request, new();

        ResponseAction WhenServerRespondsWith<T>() where T : Response;

        Session With<T>() where T : Actor, IDisposable, new();
    }
}