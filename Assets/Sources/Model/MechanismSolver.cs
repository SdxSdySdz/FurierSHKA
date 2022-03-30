using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Sources.Model
{
    public class MechanismSolver
    {
        private const double PI2 = Math.PI * 2;

        private ICurve _curve;

        public MechanismSolver(ICurve curve)
        {
            _curve = curve;
        }

        public Mechanism Solve(int clockwiseCirclesCount, int intergrationPointsCount)
        {
            Mechanism mechanism = new Mechanism();

            Complex[] values = new Complex[intergrationPointsCount];
            for (int i = 0; i < intergrationPointsCount; i++)
            {
                double t = (double)i / (intergrationPointsCount - 1);
                values[i] = _curve.Interpolate(t);
            }

            Complex[] expValues = new Complex[values.Length];
            for (int k = -clockwiseCirclesCount; k <= clockwiseCirclesCount; k++)
            {
                for (int i = 0; i < expValues.Length; i++)
                {
                    double t = (double)i / (intergrationPointsCount - 1);
                    expValues[i] = values[i] * Complex.Exp(PI2 * Complex.ImaginaryOne * k * t);
                }

                Complex radiusVector = Integrate01(expValues);
                double speed = PI2 * k;

                var circle = new Circle(radiusVector, speed);

                mechanism.Add(circle);
            }

            return mechanism;
        }

        private Complex Integrate01(Complex[] values)
        {
            int n = values.Length - 1;
            double step = 1.0 / n;

            Complex sum = (values[0] + values[n]) / 2;

            for (int i = 1; i < n; i++)
            {
                sum += values[i];
            }

            return sum * step;
        }
    }
}
