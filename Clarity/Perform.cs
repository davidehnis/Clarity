namespace Clarity
{
    /// <summary>
    /// A delegate the represents the function pointer that
    /// is invoked when a request is received.
    /// </summary>
    /// <param name="request">The request made</param>
    /// <param name="data">   Associated data</param>
    /// <returns>A sub=class of Response</returns>
    public delegate Response Perform(Request request, object data);
}