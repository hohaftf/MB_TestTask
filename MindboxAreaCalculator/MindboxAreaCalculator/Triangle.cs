using System.Linq;
using System;

namespace MindboxAreaCalculator
{
    /// <summary>
    /// Triangle model
    /// </summary>
    public class Triangle:FlatFigure
    {
        /// <summary>
        /// First side length
        /// </summary>
        private readonly double _aSideLength;

        /// <summary>
        /// Second side length
        /// </summary>
        private readonly double _bSideLength;

        /// <summary>
        /// Third side length
        /// </summary>
        private readonly double _cSideLength;

        /// <summary>
        /// Array of sides sorted by length (asc)
        /// </summary>
        private double[] _orderedSides;

        /// <summary>
        /// Gets array of sides sorted by length (asc)
        /// </summary>
        private double[] OrderedSides 
        { 
            get
            {
                _orderedSides = _orderedSides 
                    ?? new[] { _aSideLength, _bSideLength, _cSideLength }
                        .OrderBy(x => x)
                        .ToArray();

                return _orderedSides;
            }
        }

        /// <summary>
        /// Checks if the triangle is right
        /// </summary>
        public bool IsRect 
        {
            get 
            { 
                return OrderedSides[2] * OrderedSides[2] == OrderedSides[1] * OrderedSides[1] + OrderedSides[0] * OrderedSides[0];
            } 
        }

        /// <summary>
        /// Creates new triangle
        /// </summary>
        /// <param name="aSideLength">First side length</param>
        /// <param name="bSideLength">Second side length</param>
        /// <param name="cSideLength">Third side length</param>
        /// <exception cref="InvalidFigureValidationException">
        /// Thrown when one of the sides or combination is not valid
        /// </exception>
        public Triangle(double aSideLength, double bSideLength, double cSideLength)
        {
            new DimensionValidator(aSideLength).Validate();
            new DimensionValidator(bSideLength).Validate();
            new DimensionValidator(cSideLength).Validate();

            _aSideLength = aSideLength;
            _bSideLength = bSideLength;
            _cSideLength = cSideLength;

            Validate();
        }

        ///<inheritdoc />
        public override double CalculateArea()
        {
            return IsRect
                ? CalculateAreaForRect()
                : CalculateAreaForDefault();
        }

        /// <summary>
        /// Calculates area of right triangle
        /// </summary>
        /// <returns>Area of the triangle</returns>
        private double CalculateAreaForRect()
        { 
            return 0.5 * OrderedSides[0] * OrderedSides [1];
        }

        /// <summary>
        /// Calculates area of any triangle
        /// </summary>
        /// <returns>Area of the triangle</returns>
        private double CalculateAreaForDefault()
        {
            var pp = (_aSideLength + _bSideLength + _cSideLength) / 2;
            return Math.Sqrt(pp * (pp - _aSideLength) * (pp - _bSideLength) * (pp - _cSideLength));
        }

        ///<inheritdoc />
        public override void Validate()
        {
            var orderedSides = new [] { _aSideLength, _bSideLength, _cSideLength }
                .OrderBy(x => x)
                .ToArray();

            if (orderedSides[2] >= orderedSides[1] + orderedSides[0])
            { 
                throw new InvalidFigureValidationException("Cannot construct a triangle with given sides");
            }
        }
    }
}
