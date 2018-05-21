using System;

namespace Clarity
{
    /// <summary>
    /// A type of response that represents an Error
    /// </summary>
    public class Error : Response
    {
        public Error()
        {
        }

        public Error(Exception ex)
        {
            Exception = ex;
        }

        public Exception Exception { get; }
    }
}