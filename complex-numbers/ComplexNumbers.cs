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

    public ComplexNumber Add(ComplexNumber other) => new ComplexNumber(real + other.real, imaginary + other.imaginary);

    public ComplexNumber Sub(ComplexNumber other) => new ComplexNumber(real - other.real, imaginary - other.imaginary);

    public ComplexNumber Div(ComplexNumber other) => new ComplexNumber((real * other.real + imaginary * other.imaginary) / (other.Abs() * other.Abs()), (imaginary * other.real - real * other.imaginary) / (other.Abs() * other.Abs()));

    public double Abs() => Math.Sqrt(real * real + imaginary * imaginary);

    public ComplexNumber Conjugate() => new ComplexNumber(real, -imaginary);

    public ComplexNumber Exp() => new ComplexNumber(Math.Exp(real) * Math.Cos(imaginary), Math.Exp(real) * Math.Sin(imaginary));
}