using System;

namespace MindboxAreaCalculator2
{
    /// <summary>
    /// Exception for invalid figure 
    /// </summary>
    public class InvalidFigureValidationException : ValidationException
    {
        /// <summary>
        /// Creates new invalid figure exception
        /// </summary>
        public InvalidFigureValidationException():base()
        { }

        /// <summary>
        /// Creates new invalid figure exception
        /// </summary>
        /// <param name="message">The message that discribes the error</param>
        public InvalidFigureValidationException(string message):base(message)
        { }

        /// <summary>
        /// Creates new invalid figure exception
        /// </summary>
        /// <param name="message">The message that discribes the error</param>
        /// <param name="innerException">The exception that is the cause of the current exception</param>
        public InvalidFigureValidationException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
