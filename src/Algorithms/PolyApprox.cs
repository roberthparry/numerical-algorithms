using System;
using System.Linq;

namespace Algorithms
{
    public static class PolyApprox
    {
        private static readonly double[] _lnCoeffs = new double[] { 
             };

        private static double Polynomial(double x, params double[] coefficients)
            => coefficients.Reverse().Aggregate((acc, a) => acc * x + a);

        public static double Ln(double x)
        {
            if (x <= 0.0) throw new ArgumentException();

            int k = 0;
            while (x > 2.0) { k++; x /= Math.E; }
            while (x < 1.0) { k--; x *= Math.E; }
            Console.WriteLine($"x = {x}");
            x -= 1.0;
            return Polynomial(x, 0.9999964239, -0.4998741238, 0.3317990258, -0.2407338084,
                                 0.1676540711, -0.0953293897, 0.0360884937, -0.0064535442) * x + (double)k;
        }
    }
}
