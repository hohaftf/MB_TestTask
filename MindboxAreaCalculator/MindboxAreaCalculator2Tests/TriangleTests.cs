using NUnit.Framework;
using MindboxAreaCalculator2;

namespace MindboxAreaCalculator2Tests
{
    [TestFixture]
    public class TriangleTests
    {

        [Test]
        [TestCase(2.0, 4.0, 3.0, 2.904738)]
        [TestCase(5.0, 4.0, 3.0, 6.0)] //rect
        public void CalculateArea_Correct(double a, double b, double c, double area)
        {
            var triangle = FlatFigureFabric.CreateTriangle(a, b, c);
            var result = triangle.CalculateArea();

            Assert.AreEqual(area, result, 0.000001);
        }
    }
}