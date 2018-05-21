using System;

namespace Clarity
{
    /// <summary>Participates in a Session</summary>
    public interface IActor : IDisposable
    {
        /// <summary>The session containing this actor</summary>
        ISession Owner { get; set; }

        /// <summary>
        /// Processes a request with associated data
        /// </summary>
        /// <param name="request">The request to be processed</param>
        /// <param name="data">   the associated data</param>
        /// <returns>
        /// The actual response after processing request
        /// </returns>
        Response Request(Request request, object data);
    }
}