using System;

namespace MindboxAreaCalculator
{
    /// <summary>
    /// Exception for invalid model or value 
    /// </summary>
    public class ValidationException : Exception
    {
        /// <summary>
        /// Creates new invalid model or value  exception
        /// </summary>
        public ValidationException():base()
        { }

        /// <summary>
        /// Creates new invalid model or value  exception
        /// </summary>
        /// <param name="message">The message that discribes the error</param>
        public ValidationException(string message):base(message)
        { }

        /// <summary>
        /// Creates new invalid model or value  exception
        /// </summary>
        /// <param name="message">The message that discribes the error</param>
        /// <param name="innerException">The exception that is the cause of the current exception</param>
        public ValidationException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
