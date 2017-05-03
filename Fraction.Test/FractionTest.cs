using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace Fraction.Test
{
    public class FractionTest
    {
        private Fraction _fractionA;
        private Fraction _fractionB;

        [SetUp]
        public void Setup()
        {
            _fractionA = new Fraction(3, 5);
            _fractionB = new Fraction(2, 9);
        }

        [Test]
        public void FractionConstructor()
        {
            var f1 = new Fraction(3, 5);
            f1.Numerator.Should().Be(3);
            f1.Denominator.Should().Be(5);

            f1 = new Fraction(3);
            f1.Numerator.Should().Be(3);
            f1.Denominator.Should().Be(1);

            var f2 = new Fraction(f1);
            f2.Numerator.Should().Be(3);
            f2.Denominator.Should().Be(1);
        }

        [Test]
        public void Reduce()
        {
            var f = new Fraction(2, 4);
            f.Reduce();
            f.Numerator.Should().Be(1);
            f.Denominator.Should().Be(2);
        }

        [Test]
        public void Add()
        {
            var fraction = _fractionA + _fractionB;
            fraction.Numerator.Should().Be(37);
            fraction.Denominator.Should().Be(45);

            fraction = new Fraction(2, 4) + new Fraction(2, 4);
            fraction.Numerator.Should().Be(1);
            fraction.Denominator.Should().Be(1);

            fraction = new Fraction(1, 4) + new Fraction(1, 4);
            fraction.Numerator.Should().Be(1);
            fraction.Denominator.Should().Be(2);
        }

        [Test]
        public void Minus()
        {
            var fraction = _fractionA - _fractionB;
            fraction.Numerator.Should().Be(17);
            fraction.Denominator.Should().Be(45);

            fraction = new Fraction(4, 4) - new Fraction(2, 4);
            fraction.Numerator.Should().Be(1);
            fraction.Denominator.Should().Be(2);

            fraction = new Fraction(1, 4) - new Fraction(1, 4);
            fraction.Numerator.Should().Be(0);
            fraction.Denominator.Should().Be(1);
        }

        [Test]
        public void Negate()
        {
            var fraction = -_fractionA;
            fraction.Numerator.Should().Be(-_fractionA.Numerator);
            fraction.Denominator.Should().Be(_fractionA.Denominator);
        }

        [Test]
        public void Multiply()
        {
            var fraction = _fractionA * _fractionB;
            fraction.Numerator.Should().Be(2);
            fraction.Denominator.Should().Be(15);
        }

        [Test]
        public void Divide()
        {
            var fraction = _fractionA / _fractionB;
            fraction.Numerator.Should().Be(27);
            fraction.Denominator.Should().Be(10);
        }

        [Test]
        public void CastToDouble()
        {
            double d = _fractionA;
            d.Should().Be(.6);

            d = _fractionB;
            d.Should().Be(.222222222222222221);

            d = _fractionA + _fractionB;
            d.Should().Be(.82222222222222222);

            d = _fractionA - _fractionB;
            d.Should().Be(.37777777777777777);

            d = _fractionA * _fractionB;
            d.Should().Be(.133333333333333333);

            d = _fractionA / _fractionB;
            d.Should().Be(2.7);
        }

        [Test]
        public void CastToInt()
        {
            var i = (int) _fractionA;
            i.Should().Be(3);

            i = (int) _fractionB;
            i.Should().Be(2);
        }

        [Test]
        public void LessThan()
        {
            var b = _fractionA < _fractionB;
            b.Should().Be(false);

            b = _fractionB < _fractionA;
            b.Should().Be(true);
        }

        [Test]
        public void GreaterThan()
        {
            var b = _fractionA > _fractionB;
            b.Should().Be(true);

            b = _fractionB > _fractionA;
            b.Should().Be(false);
        }

        [Test]
        public void Equals()
        {
            var b = _fractionA == _fractionA;
            b.Should().Be(true);

            b = _fractionA == _fractionB;
            b.Should().Be(false);
        }

        [Test]
        public void NotEquals()
        {
            var b = _fractionA != _fractionA;
            b.Should().Be(false);

            b = _fractionA != _fractionB;
            b.Should().Be(true);
        }

        [Test]
        public void LessThanOrEquals()
        {
            var b = _fractionA <= _fractionB;
            b.Should().Be(false);

            b = _fractionA <= _fractionA;
            b.Should().Be(true);

            b = _fractionB <= _fractionA;
            b.Should().Be(true);
        }

        [Test]
        public void GreaterThanOrEquals()
        {
            var b = _fractionA >= _fractionB;
            b.Should().Be(true);

            b = _fractionA >= _fractionA;
            b.Should().Be(true);

            b = _fractionB >= _fractionA;
            b.Should().Be(false);
        }

        [Test]
        public void Modulo()
        {
            var remainder = _fractionA % _fractionB;
            remainder.Should().Be(.15555555555555555555556);

            remainder = -_fractionA % _fractionB;
            remainder.Should().Be(-.15555555555555555555556);

        }
    }
}