using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace AreaCalculator.Tests
{
    public class AreaTests
    {
        private readonly ITestOutputHelper output;

        public AreaTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void CalculateCircleArea_ShouldBeSuccessful_IfRadiusIsPositiveNumber()
        {
            var circle = new Circle(10.0);
            var area = circle.Area();
            Assert.True(area.CompareTo(Math.PI * 100) == 0);
        }

        [Theory]
        [InlineData(0.0)]
        [InlineData(-10.0)]
        public void CalculateCircleArea_ShouldBeFailed_IfInvalidRadius(double radius)
        {
            Assert.Throws<ArgumentException>(() => new Circle(radius));
        }

        [Theory]
        [InlineData(3.0, 4.0, 5.0, 6.0)]
        [InlineData(6.0, 5.0, 5.0, 12.0)]
        [InlineData(8.0, 5.0, 5.0, 12.0)]
        public void CalculateTriangleArea_ShouldBeSuccessful_IfSidesAreValid(double firstSide, double secondSide, double thirdSide, double expectedResult)
        {
            var triangle = new Triangle(firstSide, secondSide, thirdSide);
            var area = triangle.Area();
            Assert.True(area.CompareTo(expectedResult) == 0);
        }

        [Theory]
        [InlineData(1.0, 2.0, 1.0)]
        [InlineData(0.0, 1.0, 2.0)]
        [InlineData(-1.0, 1.0, 2.0)]
        [InlineData(10.0, 6.0, 3.0)]
        public void CalculateTriangleArea_ShouldBeFailed_IfSidesAreInvalid(double firstSide, double secondSide, double thirdSide)
        {
            Assert.Throws<ArgumentException>(() => new Triangle(firstSide, secondSide, thirdSide));
        }

        [Fact]
        public void TestCalculateAreaMultipleDifferentFigures()
        {
            var figures = new List<IAreable>() { new Circle(10.0), new Triangle(10.0, 8.0, 6.0) };
            output.WriteLine("Площадь заданных фигур:");
            foreach (var figure in figures)
            {
                output.WriteLine(figure.Area().ToString());
            }
        }
    }
}
