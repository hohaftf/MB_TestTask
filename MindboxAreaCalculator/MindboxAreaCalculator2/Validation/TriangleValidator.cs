using System.Linq;

namespace MindboxAreaCalculator2
{
    /// <summary>
    /// Triangle model validator
    /// </summary>
    internal class TriangleValidator : IValidator
    {
        /// <summary>
        /// Triangle model to validate
        /// </summary>
        private readonly Triangle _triangle;

        /// <summary>
        /// Creates triangle model validator
        /// </summary>
        /// <param name="triangle">Triangle model</param>
        public TriangleValidator(Triangle triangle)
        {
            _triangle = triangle;
        }

        ///<inheritdoc />
        public void Validate()
        {
            new DimensionValidator(_triangle.ASideLength).Validate();
            new DimensionValidator(_triangle.BSideLength).Validate();
            new DimensionValidator(_triangle.CSideLength).Validate();

            var orderedSides = new[] { _triangle.ASideLength, _triangle.BSideLength, _triangle.CSideLength }
                .OrderBy(x => x)
                .ToArray();

            if (orderedSides[2] >= orderedSides[1] + orderedSides[0])
            {
                throw new InvalidFigureValidationException("Cannot construct a triangle with given sides");
            }
        }
    }
}
