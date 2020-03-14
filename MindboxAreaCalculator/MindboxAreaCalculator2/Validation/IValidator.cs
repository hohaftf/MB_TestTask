namespace MindboxAreaCalculator2
{
    /// <summary>
    /// Entity or value validator
    /// </summary>
    internal interface IValidator
    {
        /// <summary>
        /// Check if the  model is valid
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown when the figure model is not valid
        /// </exception>
        void Validate();
    }
}
