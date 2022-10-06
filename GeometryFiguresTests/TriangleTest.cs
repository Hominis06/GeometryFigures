using GeometryFigures;

namespace GeometryFiguresTests
{
    public class TriangleTest
    {
        [Theory]
        [InlineData(16.25, 5.89, 18.2)]
        [InlineData(12.0, 4.0, 9.3)]
        [InlineData(0.89d, 17.98d, 18.4d)]
        public void Ctor_WithCorrectSides_WorksFine(double a, double b, double c)
        {
            var exception = Record.Exception(() => new Triangle(a,b,c));
            Assert.Null(exception);
        }

        [Theory]
        [InlineData(double.NaN, 5.89, 18.2)]
        [InlineData(12.0, -18.0, 9.3)]
        [InlineData(0.89, 1.0, 18.4)]
        [InlineData(-9, 18.6, 16)]
        public void Ctor_WithWrongSides_ThrowsException(double a, double b, double c)
        {
            Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
        }

        [Fact]
        public void GetSquare_WithCorrectSides_CalculatedCorrect()
        {
            double a = 12d;
            double b = 4d;
            double c = 9.3;
            Triangle triangle = new(a, b, c);

            double halfPerimeter = (a + b + c) / 2;
            double square = Math.Sqrt(halfPerimeter * ((halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c)));

            Assert.Equal(square, triangle.GetSquare());
        }


        [Theory]
        [InlineData(16.25, 5.89, 18.2, false)]
        [InlineData(9.6, 4.0, 10.4, true)]
        [InlineData(0.89d, 17.98d, 18.4d, false)]
        [InlineData(12.0, 4.0, 12.649, true)]
        public void IsTriangleRight_WithCorrectSides_ThrowsException(double a, double b, double c, bool expectedResult)
        {
            Assert.Equal(new Triangle(a, b, c).IsTriangleRight, expectedResult);
        }
    }
}
