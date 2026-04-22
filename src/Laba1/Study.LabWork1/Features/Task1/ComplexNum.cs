using System;

namespace Study.LabWork1.Features.Task1;

public class ComplexNum
{
    public double Real { get; }
    public double Imagine { get; }

    public ComplexNum(double real, double imagine)
    {
        Real = real;
        Imagine = imagine;
    }

    public static ComplexNum operator + (ComplexNum left, ComplexNum right)
    {
        return new ComplexNum(left.Real + right.Real, left.Imagine + right.Imagine);
    }

    public static ComplexNum operator - (ComplexNum left, ComplexNum right)
    {
        return new ComplexNum(left.Real - right.Real, left.Imagine - right.Imagine);
    }

    public static ComplexNum operator *(ComplexNum left, ComplexNum right)
    {
        var real = (left.Real * right.Real) - (left.Imagine * right.Imagine);
        var imagine = (left.Real * right.Imagine) + (left.Imagine * right.Real);

        return new ComplexNum(real, imagine);
    }

    public static double operator +(ComplexNum num)
    {
        return Math.Sqrt((num.Real * num.Real) + (num.Imagine * num.Imagine));
    }

    public static ComplexNum operator -(ComplexNum num)
    {
        return new ComplexNum(num.Real, -num.Imagine);
    }

    public static ComplexNum operator /(ComplexNum left, ComplexNum right)
    {
        var denominator = (right.Real * right.Real) + (right.Imagine * right.Imagine);
        if (denominator == 0)
            throw new DivideByZeroException("Cannot divide by zero complex number.");

        var real = ((left.Real * right.Real) + (left.Imagine * right.Imagine)) / denominator;
        var imagine = ((left.Imagine * right.Real) - (left.Real * right.Imagine)) / denominator;
        return new ComplexNum(real, imagine);
    }

    public static bool operator ==(ComplexNum left, ComplexNum right)
    {
        return left.Real == right.Real && left.Imagine == right.Imagine;
    }

    public static bool operator !=(ComplexNum left, ComplexNum right)
    {
        return !(left == right);
    }

    public override bool Equals(object obj)
    {
        if (obj is ComplexNum other)
            return this == other;
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Real, Imagine);
    }

    public override string ToString()
    {
        var invariantCulture = System.Globalization.CultureInfo.InvariantCulture;

        if (Real == 0 && Imagine == 0)
            return "0";

        if (Imagine == 0)
            return Real.ToString("F2", invariantCulture).TrimEnd('0').TrimEnd('.');

        if (Real == 0)
            return Imagine.ToString("F2", invariantCulture).TrimEnd('0').TrimEnd('.') + "i";

        var realPart = Real.ToString("F2", invariantCulture).TrimEnd('0').TrimEnd('.');
        var imagePart = Math.Abs(Imagine).ToString("F2", invariantCulture).TrimEnd('0').TrimEnd('.');
        var sign = Imagine > 0 ? "+" : "-";

        return $"{realPart} {sign} {imagePart}i";
    }

}
