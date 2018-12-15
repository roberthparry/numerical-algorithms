using System;

namespace Algorithms
{
    /// <summary>
    ///     Cordic math.
    /// </summary>
    public static class CordicMath
    {
        private static readonly double[] _a = new double[] {
            1.648721270700128, 1.284025416687742, 1.133148453066826, 1.064494458917859, 1.031743407499103,
            1.015747708586686, 1.007843097206488, 1.003913889338348, 1.001955033591003, 1.000977039492417,
            1.000488400478694, 1.000244170429748, 1.000122077763384, 1.000061037018933, 1.000030518043791,
            1.0000152589054785, 1.0000076294236351, 1.0000038147045416, 1.0000019073504518, 1.0000009536747712,
            1.0000004768372719, 1.0000002384186075, 1.0000001192092967, 1.0000000596046466, 1.0000000298023228
        };

        /// <summary>
        ///     Ln compules the Natural Logarithm of x using steps number of steps.
        /// </summary>
        /// <returns>The Natural Logarithm.</returns>
        /// <param name="x">The x value.</param>
        /// <param name="steps">Steps.</param>
        public static double Ln(double x, uint steps = 25)
        {
            if (x <= 0.0) throw new ArgumentException();

            if (steps > 100 || steps == 0) steps = 25;

            int k = 0;

            while (x >= Math.E)
            {
                k++;
                x /= Math.E;
            }

            while (x < 1.0)
            {
                k--;
                x *= Math.E;
            }

            //
            // Determine the weights.
            //
            var w = new double[steps];
            double ai = 0.0;

            for (int i = 0; i < steps; i++)
            {
                w[i] = 0.0;

                ai = i < _a.Length ? _a[i] : 1.0 + (ai - 1.0) / 2.0;

                if (ai < x)
                {
                    w[i] = 1.0;
                    x /= ai;
                }
            }

            x -= 1.0;
            x *= 1.0 - (x / 2.0) * (1.0 + (x / 3.0) * (1.0 - x / 4.0));

            //
            // Assemble
            //
            double poweroftwo = 0.5;

            for (int i = 0; i < steps; i++)
            {
                x += w[i] * poweroftwo;
                poweroftwo /= 2.0;
            }

            return x + (double)k;
        }

        /// <summary>
        ///     Compute the Exponent of the value x using steps Steps.
        /// </summary>
        /// <returns>The exponent.</returns>
        /// <param name="x">The x value.</param>
        /// <param name="steps">Steps.</param>
        public static double Exp(double x, int steps)
        {
            double z;

            int x_int = (int)Math.Floor(x);

            //
            // Determine the weights.
            //
            double poweroftwo = 0.5;
            z = x - (double)(x_int);

            var w = new double[steps];

            for (int i = 0; i < steps; i++)
            {
                w[i] = 0.0;
                if (poweroftwo < z)
                {
                    w[i] = 1.0; ;
                    z -= poweroftwo;
                }
                poweroftwo /= 2.0;
            }
            /*
              Calculate products.
            */
            double ai = 0.0;
            double fx = 1.0;

            for (int i = 0; i < steps; i++)
            {
                ai = i < _a.Length ? _a[i] : 1.0 + (ai - 1.0) / 2.0;
                if (0.0 < w[i]) fx *= ai;
            }

            //
            // Perform residual multiplication.
            //
            fx *= 1.0 + z * (1.0 + z / 2.0 * (1.0 + z / 3.0 * (1.0 + z / 4.0)));

            //
            // Account for factor EXP(X_INT).
            //

            if (x_int < 0)
            {
                for (int i = 1; i <= -x_int; i++) fx /= Math.E;
            }
            else
            {
                for (int i = 1; i <= x_int; i++) fx *= Math.E;
            }

            return fx;
        }
    }
}
