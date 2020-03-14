namespace MindboxAreaCalculator
{
    /// <summary>
    /// Linear size validator
    /// </summary>
    internal class DimensionValidator: IValidator
    {
        /// <summary>
        /// Linear size value
        /// </summary>
        private readonly double _length;

        /// <summary>
        /// Creates new linear size validator
        /// </summary>
        /// <param name="length">Linear size value</param>
        public DimensionValidator(double length)
        {
            _length = length;
        }

        /// <inheritdoc />
        public void Validate()
        {
            if (_length <= 0)
            {
                throw new ValidationException("The length must be positive");
            }
        }
    }
}
