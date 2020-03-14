using NUnit.Framework;
using MindboxAreaCalculator;

namespace MindboxAreaCalculatorTests
{
    [TestFixture]
    public class TriangleTests
    {

        [Test]
        [TestCase(2.0, 4.0, 3.0)]
        [TestCase(10.0, 4.0, 8.0)]
        public void NewTriangle_PositiveSides_OK(double a, double b, double c)
        {
            Assert.DoesNotThrow(() => new Triangle(a, b, c));
        }

        [Test]
        [TestCase(-2.0, 4.0, 3.0)]
        [TestCase(2.0, -4.0, 3.0)]
        [TestCase(2.0, 4.0, -3.0)]
        [TestCase(2.0, -4.0, -3.0)]
        [TestCase(-2.0, 4.0, -3.0)]
        [TestCase(-2.0, -4.0, 3.0)]
        [TestCase(-2.0, -4.0, -3.0)]
        [TestCase(0.0, 4.0, 3.0)]
        [TestCase(2.0, 0.0, 3.0)]
        [TestCase(2.0, 4.0, 0.0)]
        [TestCase(2.0, 0.0, 0.0)]
        [TestCase(0.0, 4.0, 0.0)]
        [TestCase(0.0, 0.0, 3.0)]
        [TestCase(0.0, 0.0, 0.0)]
        public void NewTriangle_NotPositiveSide_Exception(double a, double b, double c)
        {
            Assert.Throws<ValidationException>(() => new Triangle(a, b, c));
        }

        [Test]
        [TestCase(2.0, 4.0, 8.0)]
        [TestCase(2.0, 4.0, 6.0)]
        [TestCase(2.0, 6.0, 3.0)]
        [TestCase(2.0, 5.0, 3.0)]
        [TestCase(12.0, 4.0, 8.0)]
        [TestCase(20.0, 4.0, 8.0)]
        public void NewTriangle_NotATriangle_Exception(double a, double b, double c)
        {
            Assert.Throws<InvalidFigureValidationException>(() => new Triangle(a, b, c));
        }

        [Test]
        [TestCase(2.0, 4.0, 3.0, 2.904738)]
        [TestCase(5.0, 4.0, 3.0, 6.0)] //rect
        public void CalculateArea_Correct(double a, double b, double c, double area)
        {
            var triangle = new Triangle(a, b, c);
            var result = triangle.CalculateArea();

            Assert.AreEqual(area, result, 0.000001);
        }
    }
}