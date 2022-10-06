namespace GeometryFigures
{
    public class Triangle : GeometryObject
    {
        private readonly double _lenghtA;
        private readonly double _lenghtB;
        private readonly double _lenghtC;
        private readonly double _perimeter;
        private readonly double[] _sides;
        private bool? _isTriangleRight;

        public bool IsTriangleRight
        {
            get
            {
                var a = _sides.Where(x => x != _sides.Max()).Sum(x => Math.Pow(x, 2));
                var b = Math.Pow(_sides.Max(), 2);
                if (!_isTriangleRight.HasValue)
                {

                    _isTriangleRight = Math.Pow(_sides.Max(), 2) - _sides.Where(x => x != _sides.Max()).Sum(x => Math.Pow(x, 2)) <= tolerance;
                }

                return _isTriangleRight.Value;
            }
        }

        public double LenghtA => _lenghtA;
        public double LenghtB => _lenghtB;
        public double LenghtC => _lenghtC;

        public Triangle(double lenghtA, double lenghtB, double lenghtC)
        {
            _lenghtA = lenghtA;
            _lenghtB = lenghtB;
            _lenghtC = lenghtC;

            _sides = new double[] { _lenghtA, _lenghtB, _lenghtC, };
            _perimeter = _sides.Sum();
            ValidateObject();
        }

        protected override void ValidateObject()
        {
            if (_sides.Any(x => double.IsNaN(x) || double.IsInfinity(x)))
            {
                throw new ArgumentException("Одна из сторон треугольника задана неверно");
            }

            if (_sides.Any(x => x < tolerance))
            {
                throw new ArgumentException("Стороны треугольника должны быть больше нуля");
            }

            var a = _perimeter - _sides.Max() - _sides.Max();

            if (_perimeter - _sides.Max() - _sides.Max() < tolerance)
            {
                throw new ArgumentException("Невозможно создать треугольник так как не выполняется правило суммы углов треугольника");
            }
        }

        public override double GetSquare()
        {
            double halfPerimeter = _perimeter / 2;

            return Math.Sqrt(halfPerimeter * (halfPerimeter - _lenghtA) * (halfPerimeter - _lenghtB) * (halfPerimeter - _lenghtC));
        }
    }
}
