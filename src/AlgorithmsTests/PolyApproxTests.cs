using System;
using NUnit.Framework;
using Algorithms;

namespace AlgorithmsTests
{
    [TestFixture]
    public class PolyApproxTests
    {
        private const double _tolerance = 1.0e-13;

        [TestCase(10.0)]
        [TestCase(100.0)]
        [TestCase(1000.0)]
        [TestCase(10000.0)]
        [TestCase(2.0)]
        [TestCase(2.0e-6)]
        public void Ln_Test(double x)
        {
            Assert.That(PolyApprox.Ln(x) / Math.Log(x), Is.EqualTo(1.0).Within(_tolerance));
        }

        [Test]
        public void Ln_TestInvalidArg()
        {
            Assert.Throws<ArgumentException>(() => PolyApprox.Ln(0.0));
        }
    }
}
