using GeometryFigures;

namespace GeometryFiguresTests
{
    public class CircleTest
    { 
        [Theory]
        [InlineData(5d)]
        [InlineData(10.25)]
        [InlineData(0.755)]
        public void Ctor_WithCorrectRadius_WorksFine(double radius)
        {
            var exception = Record.Exception(() => new Circle(radius));
            Assert.Null(exception);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-16.235)]
        [InlineData(double.PositiveInfinity)]
        [InlineData(double.NaN)]
        public void Ctor_WithWrongRadius_ThrowsException(double radius)
        {
            Assert.Throws<ArgumentException>(() => new Circle(radius));
        }

        [Fact]
        public void GetSquare_WithCorrectRadius_CalculatedCorrect()
        {
            double testRadius = 5.25;
            Circle circle = new(testRadius);

            double square = Math.PI * Math.Pow(testRadius, 2);

            Assert.Equal(square, circle.GetSquare());
        }
    }
}