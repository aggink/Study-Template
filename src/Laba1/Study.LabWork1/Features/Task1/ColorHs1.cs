using System;
using System.Collections.Generic;
using System.Text;
namespace Study.LabWork1.Features.Task1
{
    public class ColorHsl
    {
        public double H { get; }
        public double S { get; }
        public double L { get; }

        public ColorHsl(double h, double s, double l)
        {
            H = FixHue(h);
            S = Limit(s, 0, 100);
            L = Limit(l, 0, 100);
        }

        private static double Limit(double value, double min, double max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        private static double FixHue(double h)
        {
            h %= 360;
            if (h < 0) h += 360;
            return h;
        }

        public override string ToString()
        {
            return $"HSL({H}, {S}%, {L}%)";
        }

        // Операторы

        public static ColorHsl operator +(ColorHsl a, ColorHsl b)
        {
            return new ColorHsl(a.H + b.H, a.S + b.S, a.L + b.L);
        }

        public static ColorHsl operator -(ColorHsl a, ColorHsl b)
        {
            return new ColorHsl(a.H - b.H, a.S - b.S, a.L - b.L);
        }

        public static ColorHsl operator *(ColorHsl a, double k)
        {
            return new ColorHsl(a.H * k, a.S * k, a.L * k);
        }

        public static ColorHsl operator /(ColorHsl a, double k)
        {
            return new ColorHsl(a.H / k, a.S / k, a.L / k);
        }

        public static bool operator ==(ColorHsl a, ColorHsl b)
        {
            return a.H == b.H && a.S == b.S && a.L == b.L;
        }

        public static bool operator !=(ColorHsl a, ColorHsl b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj is ColorHsl other)
                return this == other;
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(H, S, L);
        }

        // Перевод в RGB
        public (byte r, byte g, byte b) ConvertToRgb()
        {
            double h = H / 360;
            double s = S / 100;
            double l = L / 100;

            double r, g, b;

            if (s == 0)
            {
                r = g = b = l;
            }
            else
            {
                double q = l < 0.5 ? l * (1 + s) : l + s - l * s;
                double p = 2 * l - q;

                r = CalcColor(p, q, h + 1.0 / 3);
                g = CalcColor(p, q, h);
                b = CalcColor(p, q, h - 1.0 / 3);
            }

            return ((byte)(r * 255), (byte)(g * 255), (byte)(b * 255));
        }

        private double CalcColor(double p, double q, double t)
        {
            if (t < 0) t += 1;
            if (t > 1) t -= 1;

            if (t < 1.0 / 6) return p + (q - p) * 6 * t;
            if (t < 0.5) return q;
            if (t < 2.0 / 3) return p + (q - p) * (2.0 / 3 - t) * 6;

            return p;
        }

        public string ConvertToHex()
        {
            var (r, g, b) = ConvertToRgb();
            return $"#{r:X2}{g:X2}{b:X2}";
        }
    }
}
