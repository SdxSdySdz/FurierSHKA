using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Sources.Model
{
    public struct Vector
    {
        public double X;
        public double Y;

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double Magnitude => Math.Sqrt(X * X + Y * Y);

        public static Vector Lerp(Vector a, Vector b, double t)
        {
            return new Vector(a.X + (b.X - a.X) * t, a.Y + (b.Y - a.Y) * t);
        }

        public static double Distance(Vector a, Vector b)
        {
            double num = a.X - b.X;
            double num2 = a.Y - b.Y;
            return Math.Sqrt(num * num + num2 * num2);
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y);
        }

        public static Vector operator *(Vector a, Vector b)
        {
            return new Vector(a.X * b.X, a.Y * b.Y);
        }

        public static Vector operator /(Vector a, Vector b)
        {
            return new Vector(a.X / b.X, a.Y / b.Y);
        }

        public static Vector operator -(Vector a)
        {
            return new Vector(0f - a.X, 0f - a.Y);
        }

        public static Vector operator *(Vector a, double d)
        {
            return new Vector(a.X * d, a.Y * d);
        }

        public static Vector operator *(double d, Vector a)
        {
            return new Vector(a.X * d, a.Y * d);
        }

        public static Vector operator /(Vector a, double d)
        {
            return new Vector(a.X / d, a.Y / d);
        }

        public static bool operator ==(Vector lhs, Vector rhs)
        {
            double num = lhs.X - rhs.X;
            double num2 = lhs.Y - rhs.Y;
            return num * num + num2 * num2 < 9.99999944E-11f;
        }

        public static bool operator !=(Vector lhs, Vector rhs)
        {
            return !(lhs == rhs);
        }

        public static implicit operator Complex(Vector vector)
        {
            return new Complex(vector.X, vector.Y);
        }

        public static implicit operator Vector(Complex complex)
        {
            return new Vector(complex.Real, complex.Imaginary);
        }

        public override string ToString()
        {
            return $"Vector[{X} {Y}]";
        }
    }
}
