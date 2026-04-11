using System;
using System.Collections.Generic;
using System.Text;

namespace Study.LabWork1.Features.Task1
{
    /// <summary>
    /// Класс, который представляет цвет в формате HSL
    /// </summary>
    public class HSL
    {
        
        public double Hue { get; }
        public double Saturation { get; }
        public double Lightness { get; }
        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="h"></param>
        /// <param name="s"></param>
        /// <param name="l"></param>
        public HSL(double h, double s, double l)
        {
            Hue = NormalizeHue(h);
            Saturation = Clamp(s, 0, 100);
            Lightness = Clamp(l, 0, 100);
        }
        /// <summary>
        /// метод для ограничения в диапозоне
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private static double Clamp(double value, double min, double max)
        {
            return Math.Max(min, Math.Min(max, value));
        }
        /// <summary>
        /// метод для HUE
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        private static double NormalizeHue(double h)
        {
            h = h % 360;
            if (h < 0) h += 360;
            return h;
        }

        public override string ToString()
        {
            return $"hsl({Hue}, {Saturation}%, {Lightness}%)";
        }

        /// <summary>
        /// перегрузка сложение
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static HSL operator +(HSL a, HSL b)
        {
            return new HSL(a.Hue + b.Hue,
                           a.Saturation + b.Saturation,
                           a.Lightness + b.Lightness);
        }
        /// <summary>
        /// преегрузка вычитание
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static HSL operator -(HSL a, HSL b)
        {
            return new HSL(a.Hue - b.Hue,
                           a.Saturation - b.Saturation,
                           a.Lightness - b.Lightness);
        }
        /// <summary>
        /// перегрузка умножение
        /// </summary>
        /// <param name="a"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static HSL operator *(HSL a, double k)
        {
            return new HSL(a.Hue * k,
                           a.Saturation * k,
                           a.Lightness * k);
        }
        /// <summary>
        /// перегрузка деления
        /// </summary>
        /// <param name="a"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static HSL operator /(HSL a, double k)
        {
            return new HSL(a.Hue / k,
                           a.Saturation / k,
                           a.Lightness / k);
        }
        /// <summary>
        /// перегрузка равенство
        ///</summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(HSL a, HSL b)
        {
            return a.Hue == b.Hue &&
                   a.Saturation == b.Saturation &&
                   a.Lightness == b.Lightness;
        }
        /// <summary>
        /// перегрузка неравенство
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(HSL a, HSL b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj is HSL other)
                return this == other;
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Hue, Saturation, Lightness);
        }
        /// <summary>
        /// из HSL в RGB
        /// </summary>
        /// <returns></returns>
        public (byte R, byte G, byte B) ToRGB()
        {
            double h = Hue / 360;
            double s = Saturation / 100;
            double l = Lightness / 100;

            double r, g, b;

            if (s == 0)
            {
                r = g = b = l;
            }
            else
            {
                double q = l < 0.5 ? l * (1 + s) : l + s - l * s;
                double p = 2 * l - q;

                r = HueToRGB(p, q, h + 1.0 / 3);
                g = HueToRGB(p, q, h);
                b = HueToRGB(p, q, h - 1.0 / 3);
            }

            return ((byte)(r * 255), (byte)(g * 255), (byte)(b * 255));
        }

        private double HueToRGB(double p, double q, double t)
        {
            if (t < 0) t += 1;
            if (t > 1) t -= 1;

            if (t < 1.0 / 6) return p + (q - p) * 6 * t;
            if (t < 1.0 / 2) return q;
            if (t < 2.0 / 3) return p + (q - p) * (2.0 / 3 - t) * 6;

            return p;
        }
        /// <summary>
        /// перевод в HEX
        /// </summary>
        /// <returns></returns>
        public string ToHEX()
        {
            var (r, g, b) = ToRGB();
            return $"#{r:X2}{g:X2}{b:X2}";
        }
    }
}
