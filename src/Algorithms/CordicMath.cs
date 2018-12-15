using System;

namespace Algorithms
{
    public static class CordicMath
    {
        private static readonly double[] _a = new double[] {
            1.648721270700128, 1.284025416687742, 1.133148453066826, 1.064494458917859, 1.031743407499103,
            1.015747708586686, 1.007843097206488, 1.003913889338348, 1.001955033591003, 1.000977039492417,
            1.000488400478694, 1.000244170429748, 1.000122077763384, 1.000061037018933, 1.000030518043791,
            1.0000152589054785, 1.0000076294236351, 1.0000038147045416, 1.0000019073504518, 1.0000009536747712,
            1.0000004768372719, 1.0000002384186075, 1.0000001192092967, 1.0000000596046466, 1.0000000298023228
        };

        public static double Ln(double x, uint steps = 30)
        {
            if (x <= 0.0) throw new ArgumentException();

            if (steps > 100 || steps == 0) steps = 25;

            int k = 0;

            while (Math.E <= x) { k++; x /= Math.E; }
            while (x < 1.0) { k--; x *= Math.E; }

            var w = new double[steps];

            for (int i = 0;  i < steps; i++)
            {
                double ai = 0.0;
                ai = (i < _a.Length) ? _a[i] : 1.0 + (ai - 1.0) / 2.0;

                if (ai < x) { w[i] = 1.0; x /= ai; }
            }

            x -= 1.0;
            x *= (1.0 - (x / 2.0) * (1.0 + (x / 3.0) * (1.0 - x / 4.0)));

            double poweroftwo = 0.5;
            for (int i = 0; i < steps; i++) { x += w[i] * poweroftwo; poweroftwo /= 2.0; }

            return k + x;
        }
    }
}
