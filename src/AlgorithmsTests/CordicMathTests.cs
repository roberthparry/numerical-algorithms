using System;
using NUnit.Framework;
using Algorithms;

namespace AlgorithmsTests
{
    [TestFixture]
    public class CordicMathTests
    {
        private const int _steps = 30;
        private const double _tolerance = 1.0e-14;

        [TestCase(10.0)]
        [TestCase(100.0)]
        [TestCase(1000.0)]
        [TestCase(10000.0)]
        [TestCase(2.0)]
        [TestCase(2.0e-6)]
        public void Ln_Test(double x)
        {
            Assert.That(CordicMath.Ln(x, _steps) / Math.Log(x), Is.EqualTo(1.0).Within(_tolerance));
        }

        [Test]
        public void Ln_TestInvalidArg()
        {
            Assert.Throws<ArgumentException>(() => CordicMath.Ln(0.0));
        }

        [TestCase(-100.0)]
        [TestCase(100.0)]
        [TestCase(-10.0)]
        [TestCase(10.0)]
        [TestCase(2.0)]
        [TestCase(-2.0)]
        public void Exp_Test(double x)
        {
            Assert.That(CordicMath.Exp(x, _steps) / Math.Exp(x), Is.EqualTo(1.0).Within(_tolerance));
        }
    }
}
