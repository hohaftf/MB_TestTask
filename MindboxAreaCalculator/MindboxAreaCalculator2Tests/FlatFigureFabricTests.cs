using MindboxAreaCalculator2;
using NUnit.Framework;
using System;

namespace MindboxAreaCalculator2Tests
{
    [TestFixture]
    public class FlatFigureFabricTests
    {

        #region CreateCircle

        [Test]
        [TestCase(2.0)]
        [TestCase(3.0)]
        public void NewCircle_PositiveRadius_OK(double radius)
        {
            Assert.DoesNotThrow(() => FlatFigureFabric.CreateCircle(radius));
        }

        [Test]
        [TestCase(-2.0)]
        [TestCase(-3.0)]
        [TestCase(0.0)]
        public void NewCircle_NotPositiveRadius_Exception(double radius)
        {
            Assert.Throws<ValidationException>(() => FlatFigureFabric.CreateCircle(radius));
        }

        #endregion

        #region CreateTriangle

        [Test]
        [TestCase(2.0, 4.0, 3.0)]
        [TestCase(10.0, 4.0, 8.0)]
        public void NewTriangle_PositiveSides_OK(double a, double b, double c)
        {
            Assert.DoesNotThrow(() => FlatFigureFabric.CreateTriangle(a, b, c));
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
            Assert.Throws<ValidationException>(() => FlatFigureFabric.CreateTriangle(a, b, c));
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
            Assert.Throws<InvalidFigureValidationException>(() => FlatFigureFabric.CreateTriangle(a, b, c));
        }

        #endregion

        #region CreateFigure

        [Test]
        public void NewFigure_Null_Exception()
        { 
            Assert.Throws<ArgumentNullException>(() => FlatFigureFabric.CreateFigure(null));
        }

        [Test]
        public void NewFigure_1Param_Circle()
        {
            var figure = FlatFigureFabric.CreateFigure(5);
            Assert.IsInstanceOf<Circle>(figure);
        }

        [Test]
        public void NewFigure_3Param_Triangle()
        {
            var figure = FlatFigureFabric.CreateFigure(5,4,8);
            Assert.IsInstanceOf<Triangle>(figure);
        }

        [TestCase(0)]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(10)]
        public void NewFigure_WrongParam_Exception(int size)
        {
            var arr = new double[size];
            Assert.Throws<ArgumentException>(() => FlatFigureFabric.CreateFigure(arr));
        }

        #endregion
    }
}
