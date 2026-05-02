using System;
using System.Collections.Generic;
using System.Text;

namespace Study.LabWork1.Features.task1
{
    public class Complex_
    {
        public double Real { get; }
        public double Imag { get; }

        public Complex_(double real = 0, double imag = 0)
        {
            Real = real;
            Imag = imag;
        }

        // Перегрузки
        public static Complex_ operator +(Complex_ a, Complex_ b)
        {
            return new Complex_(a.Real + b.Real, a.Imag + b.Imag);
        }

        public static Complex_ operator -(Complex_ a, Complex_ b)
        {
            return new Complex_(a.Real - b.Real, a.Imag - b.Imag);
        }

        public static Complex_ operator *(Complex_ a, Complex_ b)
        {
            // (a+bi)(c+di) = (ac-bd) + (ad+bc)i
            double realPart = a.Real * b.Real - a.Imag * b.Imag;
            double imagPart = a.Real * b.Imag + a.Imag * b.Real;
            return new Complex_(realPart, imagPart);
        }

        public static Complex_ operator /(Complex_ a, Complex_ b)
        {

            double denominator = b.Real * b.Real + b.Imag * b.Imag;
            if (denominator == 0)
                throw new DivideByZeroException("Деление на ноль в комплексных числах");

            double realPart = (a.Real * b.Real + a.Imag * b.Imag) / denominator;
            double imagPart = (a.Imag * b.Real - a.Real * b.Imag) / denominator;

            return new Complex_(realPart, imagPart);
        }

        public static bool operator ==(Complex_ a, Complex_ b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;

            return Math.Abs(a.Real - b.Real) < 1e-10 &&
                   Math.Abs(a.Imag - b.Imag) < 1e-10;
        }

        public static bool operator !=(Complex_ a, Complex_ b) => !(a == b);


        public static double operator +(Complex_ c)
        {
            return Math.Sqrt(c.Real * c.Real + c.Imag * c.Imag);
        }
        public static Complex_ operator -(Complex_ c)
        {
            return new Complex_(c.Real, -c.Imag);
        }

        public override string ToString()
        {
            const double epsilon = 1e-2;


            if (Math.Abs(Imag) < epsilon)
            {
                return Real.ToString("F2");
            }


            if (Math.Abs(Real) < epsilon)
            {
                double absImag = Math.Abs(Imag);
                return Imag > 0 ? $"{absImag:F2}i" : $"-{absImag:F2}i";

            }

            double absImag2 = Math.Abs(Imag);
            string sign = Imag > 0 ? " + " : " - ";

            return $"{Real:F2}{sign}{absImag2:F2}i";
        }



    }
}
