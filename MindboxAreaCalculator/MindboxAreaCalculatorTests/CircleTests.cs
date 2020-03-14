using NUnit.Framework;
using MindboxAreaCalculator;
using System;

namespace MindboxAreaCalculatorTests
{
    [TestFixture]
    public class CircleTests
    {

        [Test]
        [TestCase(2.0)]
        [TestCase(3.0)]
        public void NewCircle_PositiveRadius_OK(double radius)
        {
            Assert.DoesNotThrow(() => new Circle(radius));
        }

        [Test]
        [TestCase(-2.0)]
        [TestCase(-3.0)]
        [TestCase(0.0)]
        public void NewCircle_NotPositiveRadius_Exception(double radius)
        {
            Assert.Throws<ValidationException>(() => new Circle(radius));
        }

        [Test]
        [TestCase(2.0, Math.PI * 4.0)]
        [TestCase(3.0, Math.PI * 9.0)]
        public void CalculateArea_Correct(double radius, double area)
        {
            var circle = new Circle(radius);
            var result = circle.CalculateArea();

            Assert.AreEqual(area, result);
        }
    }
}