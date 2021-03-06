﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
    public class Fraction
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentOutOfRangeException($"message", "Denominator may not be 0");
            }

            Numerator = numerator;
            Denominator = denominator;
        }

        public Fraction(int numerator) : this(numerator, 1)
        {
        }

        public Fraction(Fraction otherFraction) : this(otherFraction.Numerator, otherFraction.Denominator)
        {
        }

        public Fraction Reduce()
        {
            var gcd = GetGcd(Math.Abs(Numerator), Denominator);

            if (gcd == 1) return this;

            Numerator = Numerator / gcd;
            Denominator = Denominator / gcd;

            return this;
        }


        private static int GetGcd(int a, int b)
        {
            while (true)
            {
                if (b == 0)
                {
                    return a;
                }

                var a1 = a;
                a = b;
                b = a1 % b;
            }
        }

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            var numerator = (f1.Numerator * f2.Denominator) + (f2.Numerator * f1.Denominator);
            var denominator = f1.Denominator * f2.Denominator;

            return new Fraction(numerator, denominator).Reduce();
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            var numerator = (f1.Numerator * f2.Denominator) - (f2.Numerator * f1.Denominator);
            var denominator = f1.Denominator * f2.Denominator;

            return new Fraction(numerator, denominator).Reduce();
        }

        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            var numerator = f1.Numerator * f2.Numerator;
            var denominator = f1.Denominator * f2.Denominator;

            return new Fraction(numerator, denominator).Reduce();
        }

        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            var numerator = f1.Numerator * f2.Denominator;
            var denominator = f1.Denominator * f2.Numerator;

            return new Fraction(numerator, denominator).Reduce();
        }

        public static Fraction operator -(Fraction f)
        {
            return new Fraction(-f.Numerator, f.Denominator);
        }

        public static implicit operator double(Fraction f)
        {
            return (double) f.Numerator / f.Denominator;
        }

        public static explicit operator int(Fraction f)
        {
            return f.Numerator;
        }

        public static bool operator <(Fraction f1, Fraction f2)
        {
            return (double) f1 < f2;
        }

        public static bool operator >(Fraction f1, Fraction f2)
        {
            return !(f1 < f2);
        }

        public static bool operator ==(Fraction f1, Fraction f2)
        {
            return f1.Numerator.Equals(f2.Numerator) && f2.Denominator.Equals(f2.Denominator);
        }

        public static bool operator !=(Fraction f1, Fraction f2)
        {
            return !(f1 == f2);
        }

        public static bool operator <=(Fraction f1, Fraction f2)
        {
            return f1 < f2 || f1 == f2;
        }

        public static bool operator >=(Fraction f1, Fraction f2)
        {
            return f1 > f2 || f1 == f2;
        }

        public static double operator %(Fraction f1, Fraction f2)
        {
            return (double) f1 %  f2;
        }

        public bool IsNegative()
        {
            return Numerator < 0 || Denominator < 0;
        }

        protected bool Equals(Fraction other)
        {
            return Numerator == other.Numerator && Denominator == other.Denominator;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Fraction) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Numerator * 397) ^ Denominator;
            }
        }
    }
}