using System;

namespace Study.LabWork1.Features.Task1
{
    public class HslPixel
    {
        private double hue;
        private double saturation;
        private double lightness;

        public double Hue
        {
            get => hue;
            private set => hue = Clamp(value, 0, 360);
        }

        public double Saturation
        {
            get => saturation;
            private set => saturation = Clamp(value, 0, 100);
        }

        public double Lightness
        {
            get => lightness;
            private set => lightness = Clamp(value, 0, 100);
        }

        public HslPixel(double hue, double saturation, double lightness)
        {
            Hue = hue;
            Saturation = saturation;
            Lightness = lightness;
        }

        private double Clamp(double value, double min, double max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        public (byte R, byte G, byte B) ToRgb()
        {
            double h = Hue / 360.0;
            double s = Saturation / 100.0;
            double l = Lightness / 100.0;

            double r, g, b;

            if (Math.Abs(s) < 0.001)
            {
                r = g = b = l;
            }
            else
            {
                double q = l < 0.5 ? l * (1 + s) : l + s - l * s;
                double p = 2 * l - q;
                r = HueToRgb(p, q, h + 1.0 / 3.0);
                g = HueToRgb(p, q, h);
                b = HueToRgb(p, q, h - 1.0 / 3.0);
            }

            return ((byte)(r * 255), (byte)(g * 255), (byte)(b * 255));
        }

        private double HueToRgb(double p, double q, double t)
        {
            if (t < 0) t += 1;
            if (t > 1) t -= 1;
            if (t < 1.0 / 6.0) return p + (q - p) * 6 * t;
            if (t < 1.0 / 2.0) return q;
            if (t < 2.0 / 3.0) return p + (q - p) * (2.0 / 3.0 - t) * 6;
            return p;
        }

        public string ToHex()
        {
            var rgb = ToRgb();
            return $"#{rgb.R:X2}{rgb.G:X2}{rgb.B:X2}";
        }

        public override string ToString()
        {
            return $"hsl({Hue:F0}, {Saturation:F0}%, {Lightness:F0}%)";
        }

        public static HslPixel operator +(HslPixel a, HslPixel b)
        {
            return new HslPixel(a.Hue + b.Hue, a.Saturation + b.Saturation, a.Lightness + b.Lightness);
        }

        public static HslPixel operator -(HslPixel a, HslPixel b)
        {
            return new HslPixel(a.Hue - b.Hue, a.Saturation - b.Saturation, a.Lightness - b.Lightness);
        }

        public static HslPixel operator *(HslPixel a, double scalar)
        {
            return new HslPixel(a.Hue * scalar, a.Saturation * scalar, a.Lightness * scalar);
        }

        public static HslPixel operator *(HslPixel a, HslPixel b)
        {
            return new HslPixel(
                a.Hue * b.Hue / 360,
                a.Saturation * b.Saturation / 100,
                a.Lightness * b.Lightness / 100
            );
        }

        public static HslPixel operator /(HslPixel a, double scalar)
        {
            if (scalar == 0)
                throw new DivideByZeroException();
            return new HslPixel(a.Hue / scalar, a.Saturation / scalar, a.Lightness / scalar);
        }

        public static bool operator ==(HslPixel a, HslPixel b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;
            return Math.Abs(a.Hue - b.Hue) < 0.001 &&
                   Math.Abs(a.Saturation - b.Saturation) < 0.001 &&
                   Math.Abs(a.Lightness - b.Lightness) < 0.001;
        }

        public static bool operator !=(HslPixel a, HslPixel b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            return obj is HslPixel other && this == other;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Hue, Saturation, Lightness);
        }
    }
}
