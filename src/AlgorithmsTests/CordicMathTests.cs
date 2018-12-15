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
            Assert.That(CordicMath.Ln(x, 100), Is.EqualTo(Math.Log(x)).Within(1.0e-15));
        }

        [Test]
        public void Ln_TestInvalidArg()
        {
            Assert.Throws<ArgumentException>(() => CordicMath.Ln(0.0));
        }
    }
}
