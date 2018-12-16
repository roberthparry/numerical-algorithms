using System;
using NUnit.Framework;
using System.Linq;
using Algorithms;

namespace AlgorithmsTests
{
    [TestFixture]
    public class ContinuedFractionTests
    {
        [TestCase(new double[] { 1 }, 1.0)]
        [TestCase(new double[] {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, 1.618033985017358)]
        public void Evaluate_Test(double[] a, double expected)
        {
            Assert.That(ContinuedFraction.Evaluate(a), Is.EqualTo(expected).Within(1.0e-14));
        }

        [Test]
        public void Evaluate_TestInvalidArg()
        {
            Assert.Throws<ArgumentException>(() => ContinuedFraction.Evaluate(new double[] { }));
            Assert.Throws<ArgumentException>(() => ContinuedFraction.Evaluate(null));
        }

        [Test]
        public void Evaluate_TestGoldenRatio()
        {
            Assert.That(ContinuedFraction.Evaluate(Enumerable.Repeat(1.0, 40).ToArray()),
                Is.EqualTo(0.5*(Math.Sqrt(5.0)+1.0)).Within(1.0e-16));
        }

        [TestCase(new double[] { }, new double[] { 1 }, 1.0)]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 2, 3, 4 }, 1.394736842105263157)]
        [TestCase(new double[] {1,1,1,1,1,1,1,1,1,1,1,1 }, new double[] {1,1,1,1,1,1,1,1,1,1,1,1,1}, 1.6180257510729614)]
        public void Generalized_Test(double[] a, double[] b, double expected)
        {
            Assert.That(ContinuedFraction.Generalized(a, b), Is.EqualTo(expected).Within(1.0e-14));
        }

        [Test]
        public void Generalized_TestInvalidArgs()
        {
            Assert.Throws<ArgumentException>(() => ContinuedFraction.Generalized(null, null));
            Assert.Throws<ArgumentException>(() => ContinuedFraction.Generalized(null, new double[] { }));
            Assert.Throws<ArgumentException>(() => ContinuedFraction.Generalized(new double[] { 1, 1 }, new double[] { }));
        }

    }
}
