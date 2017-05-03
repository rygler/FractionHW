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
            new Fraction(3, 5).Should().Be(new Fraction(3, 5));

            new Fraction(3).Should().Be(new Fraction(3, 1));

            new Fraction(_fractionA).Should().Be(new Fraction(3, 5));
        }

        [Test]
        public void Reduce()
        {
            (new Fraction(2, 4)).Reduce().Should().Be(new Fraction(1, 2));
        }

        [Test]
        public void Add()
        {
            (_fractionA + _fractionB).Should().Be(new Fraction(37, 45));

            (new Fraction(2, 4) + new Fraction(2, 4)).Should().Be(new Fraction(1, 1));

            (new Fraction(1, 4) + new Fraction(1, 4)).Should().Be(new Fraction(1, 2));
        }

        [Test]
        public void Minus()
        {
            (_fractionA - _fractionB).Should().Be(new Fraction(17, 45));

            (new Fraction(4, 4) - new Fraction(2, 4)).Should().Be(new Fraction(1, 2));

            (new Fraction(1, 4) - new Fraction(1, 4)).Should().Be(new Fraction(0, 1));
        }

        [Test]
        public void Negate()
        {
            (-_fractionA).Should().Be(new Fraction(-_fractionA.Numerator, _fractionA.Denominator));
        }

        [Test]
        public void Multiply()
        {
            (_fractionA * _fractionB).Should().Be(new Fraction(2, 15));
        }

        [Test]
        public void Divide()
        {
            (_fractionA / _fractionB).Should().Be(new Fraction(27, 10));
        }

        [Test]
        public void CastToDouble()
        {
            ((double) _fractionA).Should().Be(.6);

            ((double) _fractionB).Should().Be(.222222222222222221);

            ((double) _fractionA + _fractionB).Should().Be(.82222222222222222);

            ((double) _fractionA - _fractionB).Should().Be(.37777777777777777);

            ((double) _fractionA * _fractionB).Should().Be(.133333333333333333);

            ((double) _fractionA / _fractionB).Should().Be(2.7);
        }

        [Test]
        public void CastToInt()
        {
            ((int) _fractionA).Should().Be(3);

            ((int) _fractionB).Should().Be(2);
        }

        [Test]
        public void LessThan()
        {
            (_fractionA < _fractionB).Should().Be(false);

            (_fractionB < _fractionA).Should().Be(true);
        }

        [Test]
        public void GreaterThan()
        {
            (_fractionA > _fractionB).Should().Be(true);

            (_fractionB > _fractionA).Should().Be(false);
        }

        [Test]
        public void Equals()
        {
            (_fractionA == _fractionA).Should().Be(true);

            (_fractionA == _fractionB).Should().Be(false);
        }

        [Test]
        public void NotEquals()
        {
            (_fractionA != _fractionA).Should().Be(false);

            (_fractionA != _fractionB).Should().Be(true);
        }

        [Test]
        public void LessThanOrEquals()
        {
            (_fractionA <= _fractionB).Should().Be(false);

            (_fractionA <= _fractionA).Should().Be(true);

            (_fractionB <= _fractionA).Should().Be(true);
        }

        [Test]
        public void GreaterThanOrEquals()
        {
            (_fractionA >= _fractionB).Should().Be(true);

            (_fractionA >= _fractionA).Should().Be(true);

            (_fractionB >= _fractionA).Should().Be(false);
        }

        [Test]
        public void Modulo()
        {
            (_fractionA % _fractionB).Should().Be(.15555555555555555555556);

            (-_fractionA % _fractionB).Should().Be(-.15555555555555555555556);
        }
    }
}