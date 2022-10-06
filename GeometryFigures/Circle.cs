namespace GeometryFigures
{
    public class Circle : GeometryObject
    {
        private readonly double _radius;

        public double Radius => _radius;

        public Circle(double radius)
        {
            _radius = radius;
            ValidateObject();
        }

        public override double GetSquare()
        {
            return Math.PI * Math.Pow(_radius, 2);
        }

        protected override void ValidateObject()
        {
            if (double.IsNaN(_radius) || double.IsInfinity(_radius))
            {
                throw new ArgumentException("Неккоректный радиус окружности");
            }

            if (_radius <= tolerance)
            {
                throw new ArgumentException("Радиус окружности должен быть больше нуля");
            }
        }
    }
}