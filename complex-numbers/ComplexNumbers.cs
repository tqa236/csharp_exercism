using System;

public struct ComplexNumber
{
    private readonly double real, imaginary;
    public ComplexNumber(double real, double imaginary)
    {
        this.real = real;
        this.imaginary = imaginary;
    }

    public double Real() => real;

    public double Imaginary() => imaginary;

    public ComplexNumber Mul(ComplexNumber other) => new ComplexNumber(real * other.real - imaginary * other.imaginary, imaginary * other.real + real * other.imaginary);

    public ComplexNumber Mul(int other) => new ComplexNumber(real * other, imaginary * other);


    public ComplexNumber Add(ComplexNumber other) => new ComplexNumber(real + other.real, imaginary + other.imaginary);

    public ComplexNumber Add(int other) => new ComplexNumber(real + other, imaginary);


    public ComplexNumber Sub(ComplexNumber other) => new ComplexNumber(real - other.real, imaginary - other.imaginary);

    public ComplexNumber Sub(int other) => new ComplexNumber(real - other, imaginary);


    public ComplexNumber Div(ComplexNumber other)
    {
        if (other.Abs() == 0)
            throw new DivideByZeroException("Cannot divide by zero in complex numbers.");
        var denominator = other.Abs() * other.Abs();
        return new ComplexNumber(
            (real * other.real + imaginary * other.imaginary) / denominator,
            (imaginary * other.real - real * other.imaginary) / denominator
        );
    }

    public ComplexNumber Div(int other) => new ComplexNumber(real / other, imaginary / other);


    public double Abs() => Math.Sqrt(real * real + imaginary * imaginary);

    public ComplexNumber Conjugate() => new ComplexNumber(real, -imaginary);

    public ComplexNumber Exp() => new ComplexNumber(Math.Exp(real) * Math.Cos(imaginary), Math.Exp(real) * Math.Sin(imaginary));
}