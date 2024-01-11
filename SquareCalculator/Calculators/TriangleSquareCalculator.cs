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
    private readonly bool _isInitialized;
    private double _a;
    private double _b;
    private double _c;
    public double A
    {
        set
        {
            CheckTriangleSidesCondition(nameof(A), value, _b, _c);
            _a = value;
        }
        get => _a;
    }

    public double B
    {
        set
        {
            CheckTriangleSidesCondition(nameof(B), value, _a, _c);
            _b = value;
        }
        get => _b;
    }

    public double C
    {
        set
        {
            CheckTriangleSidesCondition(nameof(C), value, _a, _b);
            _c = value;
        }
        get => _c;
    }

    public TriangleSquareCalculator(double sideA = 0, double sideB = 0, double sideC = 0)
    {
        A = sideA;
        B = sideB;
        
        _isInitialized = true;
        
        C = sideC;
    }

    public double CalculateSquare()
    {
        var p = (A + B + C) / 2;
        return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
    }
    
    /// <summary>
    /// Method that checks whether a triangle is right-angled
    /// </summary>
    /// <returns>True, if triangle is right-angled</returns>
    public bool IsRightAngledTriangle()
    {
        return IsRightAngledTriangle(A, B, C) ||
               IsRightAngledTriangle(B, C, A) ||
               IsRightAngledTriangle(C, B, A);
    }

    private static bool IsRightAngledTriangle(double hypotenuse, double leg1, double leg2)
        => Math.Abs(hypotenuse * hypotenuse - (leg1 * leg1 + leg2 * leg2)) < 0.000000001d;
    
    private static bool IsCorrectSides(double side1, double side2, double side3)
        => side1 + side2 > side3;
    
    private void CheckTriangleSidesCondition(string sideName, double newSideValue, double side2, double side3)
    {
        Validator.CheckForZeroOrNegativeValue(sideName, newSideValue);
        if (_isInitialized && (!IsCorrectSides(newSideValue, side2, side3) || !IsCorrectSides(side3, newSideValue, side2) ||
                              !IsCorrectSides(side3, side2, newSideValue)))
            throw new IncorrectTriangleSidesException();
    }
}