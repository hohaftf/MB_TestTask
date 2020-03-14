using System;

namespace MindboxAreaCalculator
{
    /// <summary>
    /// Circle model
    /// </summary>
    public class Circle:FlatFigure
    {
        /// <summary>
        /// Radius of the circle
        /// </summary>
        private readonly double _radius;

        /// <summary>
        /// Creates new circle
        /// </summary>
        /// <param name="radius">Radius of the circle</param>
        /// <exception cref="InvalidFigureValidationException">
        /// Thrown when the radius is not valid
        /// </exception>
        public Circle(double radius)
        {
            new DimensionValidator(radius).Validate();

            _radius = radius;

            Validate();
        }

        ///<inheritdoc />
        public override double CalculateArea()
        {
            return Math.PI * _radius * _radius;
        }

        ///<inheritdoc />
        public override void Validate()
        {
            ;//if radius is correct then no additional validation is needed
        }
    }
}
