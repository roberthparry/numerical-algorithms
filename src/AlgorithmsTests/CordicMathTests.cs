using System;
using NUnit.Framework;
using Algorithms;

namespace AlgorithmsTests
{
    [TestFixture]
    public class CordicMathTests
    {
        [TestCase(10.0)]
        [TestCase(100.0)]
        [TestCase(1000.0)]
        [TestCase(10000.0)]
        [TestCase(2.0)]
        [TestCase(2.0e-6)]
        public void Ln_Test(double x)
        {
            Assert.That(CordicMath.Ln(x, 100)/Math.Log(x), Is.EqualTo(1.0).Within(1.0e-14));
        }

        [Test]
        public void Ln_TestInvalidArg()
        {
            Assert.Throws<ArgumentException>(() => CordicMath.Ln(0.0));
        }

        [TestCase(-10.0)]
        [TestCase(10.0)]
        [TestCase(2.0)]
        [TestCase(-2.0)]
        public void Exp_Test(double x)
        {
            Assert.That(CordicMath.Exp(x, 100)/Math.Exp(x), Is.EqualTo(1.0).Within(1.0e-14));
        }
    }
}
