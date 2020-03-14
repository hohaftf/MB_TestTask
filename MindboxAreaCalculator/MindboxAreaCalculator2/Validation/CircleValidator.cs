namespace MindboxAreaCalculator2
{
    /// <summary>
    /// Circle model validator
    /// </summary>
    internal class CircleValidator : IValidator
    {
        /// <summary>
        /// Circle model to validate
        /// </summary>
        private readonly Circle _circle;

        /// <summary>
        /// Creates circle model validator
        /// </summary>
        /// <param name="circle">Circle model</param>
        public CircleValidator(Circle circle)
        { 
            _circle = circle;
        }

        ///<inheritdoc />
        public void Validate()
        {
            new DimensionValidator(_circle.Radius).Validate();
        }
    }
}
