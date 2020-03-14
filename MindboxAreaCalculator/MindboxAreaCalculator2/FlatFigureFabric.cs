using System;

namespace MindboxAreaCalculator2
{
    /// <summary>
    /// Flat figures fabric
    /// </summary>
    public static class FlatFigureFabric
    {
        /// <summary>
        /// Creates new circle
        /// </summary>
        /// <param name="radius">Radius of the circle</param>
        /// <returns>New circle</returns>
        /// <exception cref="ValidationException">
        /// Thrown when the radius is not valid
        /// </exception>
        public static Circle CreateCircle(double radius)
        { 
            var circle = new Circle(radius);
            var validator = new CircleValidator(circle);
            validator.Validate();
            return circle; 
        }

        /// <summary>
        /// Creates new triangle
        /// </summary>
        /// <param name="aSideLength">First side length</param>
        /// <param name="bSideLength">Second side length</param>
        /// <param name="cSideLength">Third side length</param>
        /// <returns>New triangle</returns>
        /// <exception cref="InvalidFigureValidationException">
        /// Thrown when combination of sides is not valid
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when one or more sides is not valid
        /// </exception>
        public static Triangle CreateTriangle(double aSideLength, double bSideLength, double cSideLength)
        {
            var triangle = new Triangle(aSideLength, bSideLength, cSideLength);
            var validator = new TriangleValidator(triangle);
            validator.Validate();
            return triangle;
        }

        /// <summary>
        /// Creates new figure depending on number of parameters
        /// </summary>
        /// <param name="dims">Sides length</param>
        /// <returns>New figure</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when argument is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when number of parameters is incorrect
        /// </exception>
        /// <exception cref="InvalidFigureValidationException">
        /// Thrown when combination of dimensions is not valid
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when one or more of dimensions are not valid
        /// </exception>
        public static FlatFigure CreateFigure(params double[] dims)
        { 
            if (dims == null) 
                throw new ArgumentNullException(nameof(dims));

            switch (dims.Length)
            {
                case 1: return CreateCircle(dims[0]);
                case 3: return CreateTriangle(dims[0], dims[1], dims[2]);
                default: throw new ArgumentException("You must pass 1 or 3 parameters", nameof(dims));
            }
        }
    }
}
