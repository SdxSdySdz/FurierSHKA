using System;

namespace Assets.Sources.Model
{
    public class Circle : Transformable
    {
        private const double PI2 = 2 * Math.PI;

        private Vector _startRadiusVector;
        
        public Circle(Vector radiusVector, double speed)
        {
            _startRadiusVector = radiusVector;
            RadiusVector = radiusVector;
            Speed = speed;
        }

        public Vector RadiusVector { get; private set; }
        public double Speed { get; private set; }

        public void SetState(double time)
        {
            double phi = PI2 * Speed * time;

            double sin_phi = Math.Sin(phi);
            double cos_phi = Math.Cos(phi);

            double a = _startRadiusVector.X;
            double b = _startRadiusVector.Y;

            double x = a * cos_phi - b * sin_phi;
            double y = a * sin_phi + b * cos_phi;

            RadiusVector = new Vector(x, y);
        }
    }
}
