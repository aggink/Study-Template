using System;
using System.Collections.Generic;
using System.Text;

namespace Study.LabWork1.Features.Task1
{
    public class ComplexNumber
    {
        public double Real { get; }
        public double Imaginary { get; }

        public ComplexNumber(double R=0.0, double I=0.0)
        {
            Real = R;
            Imaginary = I;
        }

        public static ComplexNumber operator +(ComplexNumber c) => c;
        public static ComplexNumber operator -(ComplexNumber c) => new ComplexNumber(-c.Real, -c.Imaginary);

        
        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
            => new ComplexNumber(a.Real + b.Real, a.Imaginary + b.Imaginary);

        public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
            => new ComplexNumber(a.Real - b.Real, a.Imaginary - b.Imaginary);

        public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
        {
            double real = a.Real * b.Real - a.Imaginary * b.Imaginary;
            double imag = a.Real * b.Imaginary + a.Imaginary * b.Real;
            return new ComplexNumber(real, imag);
        }

        public static ComplexNumber operator /(ComplexNumber a, ComplexNumber b)
        {
            double denominator = b.Real * b.Real + b.Imaginary * b.Imaginary;
            if (denominator == 0)
                throw new DivideByZeroException("Деление на ноль в комплексных числах.");

            double real = (a.Real * b.Real + a.Imaginary * b.Imaginary) / denominator;
            double imag = (a.Imaginary * b.Real - a.Real * b.Imaginary) / denominator;
            return new ComplexNumber(real, imag);
        }

        
        public static bool operator ==(ComplexNumber a, ComplexNumber b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;
            return a.Real == b.Real && a.Imaginary == b.Imaginary;
        }

        public static bool operator !=(ComplexNumber a, ComplexNumber b) => !(a == b);

        public override bool Equals(object obj) => Equals(obj as ComplexNumber);

        public bool Equals(ComplexNumber other)
        {
            if (other is null) return false;
            return Real == other.Real && Imaginary == other.Imaginary;
        }

        public override int GetHashCode() => HashCode.Combine(Real, Imaginary);

        public override string ToString()
        {
            
            string realPart = Real.ToString(System.Globalization.CultureInfo.InvariantCulture);
            string imagPart = Math.Abs(Imaginary).ToString(System.Globalization.CultureInfo.InvariantCulture);

            if (Imaginary == 0)
                return realPart;                     // только действительная часть

            if (Real == 0)
                return $"{Imaginary.ToString(System.Globalization.CultureInfo.InvariantCulture)}i"; // только мнимая

            string sign = Imaginary > 0 ? "+" : "-";
            return $"{realPart}{sign}{imagPart}i";
        }
    }
}
