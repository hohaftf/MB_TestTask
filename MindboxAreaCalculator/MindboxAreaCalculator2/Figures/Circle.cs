using System;

namespace MindboxAreaCalculator2
{
    /// <summary>
    /// Circle model
    /// </summary>
    public class Circle:FlatFigure
    {
        /// <summary>
        /// Radius of the circle
        /// </summary>
        public double Radius { get; private set; }

        /// <summary>
        /// Creates new circle
        /// </summary>
        /// <param name="radius">Radius of the circle</param>
        internal Circle(double radius)
        {
            Radius = radius;
        }

        ///<inheritdoc />
        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
