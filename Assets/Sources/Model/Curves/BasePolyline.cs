using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Sources.Model
{
    public abstract class BasePolyline : ICurve
    {
        private Vector[] _vertices;
        private double[] _lengthSums;
        private double[] _distances;

        public BasePolyline(IEnumerable<Vector> vertices)
        {
            _vertices = ProcessVertices(vertices);
            CalculateInterpolationVariables();
        }

        public double Length => _lengthSums[_lengthSums.Length - 1];

        public Vector Interpolate(double time)
        {
            double scaledTime = (time % 1) * Length;

            for (int i = 0; i < _lengthSums.Length; i++)
            {
                if (scaledTime < _lengthSums[i])
                {
                    Vector a = _vertices[i - 1];
                    Vector b = _vertices[i];

                    double t = (scaledTime - _lengthSums[i - 1]) / _distances[i - 1];

                    return Vector.Lerp(a, b, t);
                }
            }

            return _vertices[_vertices.Length - 1];
        }

        protected abstract Vector[] ProcessVertices(IEnumerable<Vector> vertices);

        private void CalculateInterpolationVariables()
        {
            _lengthSums = new double[_vertices.Length];
            _distances = new double[_vertices.Length - 1];

            double distance = 0;
            double lengthSum = 0;

            _lengthSums[0] = 0;
            for (int i = 0; i < _vertices.Length - 1; i++)
            {
                distance = Vector.Distance(_vertices[i], _vertices[i + 1]);
                lengthSum += distance;

                _lengthSums[i + 1] = lengthSum;
                _distances[i] = distance;
            }
        }
    }
}
