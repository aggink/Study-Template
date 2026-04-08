using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text;

namespace Study.LabWork1.Features.Task1
{
    public class Pixel
    {
        public byte Red { get; }
        public byte Green { get; }
        public byte Blue { get; }
        public float Alpha { get; }

        public Pixel() : this(0, 0, 0, 0) {}
        public Pixel(int Red, int Green, int Blue) : this(Red, Green, Blue, 1f) {}
        public Pixel(int Red, int Green, int Blue, float Alpha)
        {
            this.Red = toByte(Red);
            this.Green = toByte(Green);
            this.Blue = toByte(Blue);
            this.Alpha = toByte(Alpha);
        }

        public static byte toByte(int value)
        {
            return (byte)Math.Clamp(value, 0, 255);
        }
        public static float toByte(float value)
        {
            return Math.Clamp(value, 0f, 1f);
        }
        public override string ToString()
        {
            string strA = Alpha == 1f ? "1" : Alpha.ToString("F1");
            return $"rgba({Red}, {Green}, {Blue}, {strA})";
        }
        public string PixelToHex()
        {
            return $"#{Red:X2}{Green:X2}{Blue:X2}{(byte)(Alpha * 255):X2}";
        }
        public static Pixel operator +(Pixel x, Pixel y)
        {
            return new Pixel(
            x.Red + y.Red,
            x.Green + y.Green,
            x.Blue + y.Blue,
            x.Alpha + y.Alpha);
        }
        public static Pixel operator -(Pixel x, Pixel y)
        {
            return new Pixel(
            x.Red - y.Red,
            x.Green - y.Green,
            x.Blue - y.Blue,
            x.Alpha - y.Alpha);
        }
        public static Pixel operator *(Pixel x, float num)
        {
            return new Pixel(
            (int)(x.Red * num),
            (int)(x.Green * num),
            (int)(x.Blue * num),
            x.Alpha * num);
        }
        public static Pixel operator /(Pixel x, float num)
        {
            return new Pixel(
            (int)(x.Red / num),
            (int)(x.Green / num),
            (int)(x.Blue / num),
            x.Alpha / num);
        }
        public static bool operator ==(Pixel x, Pixel y)
        {
            return x.Red == y.Red && x.Green == y.Green && x.Blue == y.Blue && x.Alpha == y.Alpha;
        }
        public static bool operator !=(Pixel x, Pixel y)
        {
            return x.Red != y.Red || x.Green != y.Green || x.Blue != y.Blue || x.Alpha != y.Alpha;
        }
    }
}
