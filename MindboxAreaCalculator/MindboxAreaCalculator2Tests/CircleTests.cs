using NUnit.Framework;
using MindboxAreaCalculator2;
using System;

namespace MindboxAreaCalculator2Tests
{
    [TestFixture]
    public class CircleTests
    {

        [Test]
        [TestCase(2.0, Math.PI * 4.0)]
        [TestCase(3.0, Math.PI * 9.0)]
        public void CalculateArea_Correct(double radius, double area)
        {
            var circle = FlatFigureFabric.CreateCircle(radius);
            var result = circle.CalculateArea();

            Assert.AreEqual(area, result);
        }
    }
}