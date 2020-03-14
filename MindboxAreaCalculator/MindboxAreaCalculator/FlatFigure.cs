namespace MindboxAreaCalculator
{
    /// <summary>
    /// Flat figure bae class
    /// </summary>
    public abstract class FlatFigure: IValidator
    {
        /// <summary>
        /// Check if the figure model is valid
        /// </summary>
        /// <exception cref="InvalidFigureValidationException">
        /// Thrown when the figure model is not valid
        /// </exception>
        public abstract void Validate();

        /// <summary>
        /// Calculates the area of the figure
        /// </summary>
        /// <returns>Area of the figure</returns>
        public abstract double CalculateArea();
    }
}
