using System;
using System.Linq;

namespace MindboxAreaCalculator2
{
    /// <summary>
    /// Triangle model
    /// </summary>
    public class Triangle:FlatFigure
    {
        /// <summary>
        /// First side length
        /// </summary>
        public double ASideLength { get; private set;}

        /// <summary>
        /// Second side length
        /// </summary>
        public double BSideLength { get; private set; }

        /// <summary>
        /// Third side length
        /// </summary>
        public double CSideLength { get; private set; }

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
                    ?? new[] { ASideLength, BSideLength, CSideLength }
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
        internal Triangle(double aSideLength, double bSideLength, double cSideLength)
        {
            ASideLength = aSideLength;
            BSideLength = bSideLength;
            CSideLength = cSideLength;
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
            return 0.5 * OrderedSides[0] * OrderedSides[1];
        }

        /// <summary>
        /// Calculates area of any triangle
        /// </summary>
        /// <returns>Area of the triangle</returns>
        private double CalculateAreaForDefault()
        {
            var pp = (ASideLength + BSideLength + CSideLength) / 2;
            return Math.Sqrt(pp * (pp - ASideLength) * (pp - BSideLength) * (pp - CSideLength));
        }
    }
}
