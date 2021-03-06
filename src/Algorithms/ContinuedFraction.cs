﻿using System;

namespace Algorithms
{
    /// <summary>
    ///     Continued fraction evaluation.
    /// </summary>
    public static class ContinuedFraction
    {
        /// <summary>
        ///     Evaluate the continued fraction represented by a0+1/(a1+1/(a2...
        /// </summary>
        /// <returns>The evaluated continued fraction.</returns>
        /// <param name="a">The coefficients of the continued fraction.</param>
        public static double Evaluate(params double[] a)
        {
            if (a == null || a.Length < 1) throw new ArgumentException();

            double h_ = a[0];
            double k_ = 1.0;

            if (a.Length == 1) return h_;

            double h = a[1] * h_ + 1.0;
            double k = a[1] * k_;

            for (int j = 2; j < a.Length; j++)
            {
                double htemp = h;
                double ktemp = k;
                h = a[j] * h + h_;
                k = a[j] * k + k_;
                h_ = htemp;
                k_ = ktemp;
            }

            return h / k;
        }

        /// <summary>
        ///     Evaluate the generalized continued fraction represented by b0 + a0/(b1 + a1/(b2 + a2/(b3...
        /// </summary>
        /// <returns>The evaluated continued fraction.</returns>
        /// <param name="a">The a coefficients.</param>
        /// <param name="b">The b coefficients.</param>
        public static double Generalized(double[] a, double[] b)
        {
            if (a == null || b == null || b.Length < 1) throw new ArgumentException();
            if (b.Length != a.Length + 1) throw new ArgumentException();

            double h_ = 1.0;
            double k_ = 0.0;
            double h = b[0];
            double k = 1.0;

            for (int j = 1; j < b.Length; j++)
            {
                double htemp = h;
                double ktemp = k;
                h = b[j] * h + a[j - 1] * h_;
                k = b[j] * k + a[j - 1] * k_;
                h_ = htemp;
                k_ = ktemp;
            }

            return h / k;
        }
    }
}
