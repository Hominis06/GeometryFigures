
namespace GeometryFigures
{
    public abstract class GeometryObject : IGeometryObject
    {
        protected const double tolerance = 1e-7;
        public abstract double GetSquare();

        protected abstract void ValidateObject();
    }
}
