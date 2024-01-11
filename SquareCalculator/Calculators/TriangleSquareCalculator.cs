using SquareCalculator.Exceptions;

namespace SquareCalculator.Calculators;

/// <summary>
/// Implement <see cref="ISquareCalculator"/> for triangle.
/// Main parameters are sides of triangle (A, B, C).
/// The square calculated by the following formula: sqrt(p * (p - A) * (p - B) * (p - C)),
/// where 'p' - is semiperimeter of triangle.
/// </summary>
public class TriangleSquareCalculator : ISquareCalculator
{
    public double A { set; get; }
    public double B { set; get; }
    public double C { set; get; }

    public TriangleSquareCalculator(double sideA = 0, double sideB = 0, double sideC = 0)
    {
        A = sideA;
        B = sideB;
        C = sideC;
    }

    public double CalculateSquare()
    {
        Validator.CheckForZeroOrNegativeValue(nameof(A), A);
        Validator.CheckForZeroOrNegativeValue(nameof(B), B);
        Validator.CheckForZeroOrNegativeValue(nameof(C), C);
        TriangleValidator.CheckTriangleSidesForCorrection(A, B, C);
        
        var p = (A + B + C) / 2;
        return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
    }
    
    /// <summary>
    /// Method that checks whether a triangle is right-angled
    /// </summary>
    /// <returns>True, if triangle is right-angled</returns>
    public bool IsRightAngledTriangle()
    {
        var squareA = A * A;
        var squareB = B * B;
        var squareC = C * C;
        return IsRightAngledTriangle(squareA, squareB, squareC) ||
               IsRightAngledTriangle(squareB, squareC, squareA) ||
               IsRightAngledTriangle(squareC, squareB, squareA);
    }

    private static bool IsRightAngledTriangle(double squareHypotenuse, double squareLeg1, double squareLeg2)
        => Math.Abs(squareHypotenuse - (squareLeg1 + squareLeg2)) < 0.000000001d;
}

file abstract class TriangleValidator
{
    internal static void CheckTriangleSidesForCorrection(double side1, double side2, double side3)
    {
        if (!IsCorrectSides(side1, side2, side3) || !IsCorrectSides(side3, side1, side2) ||
            !IsCorrectSides(side3, side2, side1))
            throw new IncorrectTriangleSidesException();
    }
    
    private static bool IsCorrectSides(double side1, double side2, double side3)
        => side1 + side2 > side3;
}