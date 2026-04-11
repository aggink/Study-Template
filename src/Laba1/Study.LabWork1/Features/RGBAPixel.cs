namespace Study.LabWork1.Features
{

    public class RGBAPixel
    {
        public byte Red;
        public byte Green;
        public byte Blue;
        public double Alpha;

        public RGBAPixel(double R = 0, double G = 0, double B = 0, double A = 0)
        {
            set(1, R);
            set(2, G);
            set(3, B);
            set(4, A);
        }

        override public String ToString()
        {

            var o = new String("rgba( ");
            o += Red;
            o += ", ";
            o += Green;
            o += ", ";
            o += Blue;
            o += ", ";
            o += Alpha;
            o += " )";
            return o;
        }

        public String HexString(byte b)
        {
            byte[] colors = new byte[]{ Red, Green, Blue };
            return Convert.ToHexString(colors);

        }

        public int set(int type, double value)
        {

            switch (type)
            {
                case 1:
                    Red = Convert.ToByte(Math.Clamp(value, 0, 255));
                    break;
                case 2:
                    Green = Convert.ToByte(Math.Clamp(value, 0, 255));
                    break;
                case 3:
                    Blue = Convert.ToByte(Math.Clamp(value, 0, 255));
                    break;
                case 4:
                    Alpha = Math.Clamp(value, 0, 1);
                    break;
                default:
                    return -1;
            }

            return 0;
        }

        public static RGBAPixel operator +(RGBAPixel Pixel1, RGBAPixel Pixel2)
        {
            double A0 = Pixel1.Alpha + Pixel2.Alpha * (1 - Pixel1.Alpha);

            double R0 = (Pixel1.Red * Pixel1.Alpha + Pixel2.Red * Pixel1.Alpha * (1 - Pixel1.Alpha)) / A0;
            double G0 = (Pixel1.Green * Pixel1.Alpha + Pixel2.Green * Pixel1.Alpha * (1 - Pixel1.Alpha)) / A0;
            double B0 = (Pixel1.Blue * Pixel1.Alpha + Pixel2.Blue * Pixel1.Alpha * (1 - Pixel1.Alpha)) / A0;

            return new RGBAPixel(R0, G0, B0, A0);
        }
        public static RGBAPixel operator -(RGBAPixel Pixel1, RGBAPixel Pixel2)
        {
            double A0 = Pixel1.Alpha + Pixel2.Alpha * (1 - Pixel1.Alpha);

            double R0 = (Pixel1.Red * Pixel1.Alpha - Pixel2.Red * Pixel1.Alpha * (1 - Pixel1.Alpha)) / A0;
            double G0 = (Pixel1.Green * Pixel1.Alpha - Pixel2.Green * Pixel1.Alpha * (1 - Pixel1.Alpha)) / A0;
            double B0 = (Pixel1.Blue * Pixel1.Alpha - Pixel2.Blue * Pixel1.Alpha * (1 - Pixel1.Alpha)) / A0;

            return new RGBAPixel(R0, G0, B0, A0);
        }
        public static RGBAPixel operator *(RGBAPixel Pixel1, RGBAPixel Pixel2)
        {
            double R0 = Pixel1.Red * Pixel2.Red / 255;
            double G0 = Pixel1.Green * Pixel2.Green / 255;
            double B0 = Pixel1.Blue * Pixel2.Blue / 255;
            double A0 = Pixel1.Alpha * Pixel2.Alpha;

            return new RGBAPixel(R0, G0, B0, A0);
        }
        public static RGBAPixel operator *(RGBAPixel Pixel1, double Pixel2)
        {
            double R0 = Pixel1.Red * Pixel2 / 255;
            double G0 = Pixel1.Green * Pixel2 / 255;
            double B0 = Pixel1.Blue * Pixel2 / 255;
            double A0 = Pixel1.Alpha;

            return new RGBAPixel(R0, G0, B0, A0); ;
        }
        public static RGBAPixel operator *(double Pixel2, RGBAPixel Pixel1)
        {
            double R0 = Pixel1.Red * Pixel2 / 255;
            double G0 = Pixel1.Green * Pixel2 / 255;
            double B0 = Pixel1.Blue * Pixel2 / 255;
            double A0 = Pixel1.Alpha;

            return new RGBAPixel(R0, G0, B0, A0);
        }
        public static RGBAPixel operator /(RGBAPixel Pixel1, double Pixel2)
        {
            double R0 = Pixel1.Red / Pixel2;
            double G0 = Pixel1.Green / Pixel2;
            double B0 = Pixel1.Blue / Pixel2;
            double A0 = Pixel1.Alpha;

            return new RGBAPixel(R0, G0, B0, A0);
        }
        public static bool operator ==(RGBAPixel Pixel1, RGBAPixel Pixel2)
        {
            return
                (Pixel1.Red == Pixel2.Red) &&
                (Pixel1.Green == Pixel2.Green) &&
                (Pixel1.Blue == Pixel2.Blue) &&
                (Pixel1.Alpha == Pixel2.Alpha);
        }
        public static bool operator !=(RGBAPixel Pixel1, RGBAPixel Pixel2)
        {
            return
                !((Pixel1.Red == Pixel2.Red) &&
                (Pixel1.Green == Pixel2.Green) &&
                (Pixel1.Blue == Pixel2.Blue) &&
                (Pixel1.Alpha == Pixel2.Alpha));
        }
        public override bool Equals(object obj) {
            return obj is RGBAPixel other && this == other;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Red, Green, Blue, Alpha);
        }

    }

}
