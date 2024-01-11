namespace SquareCalculator.Calculators;

/// <summary>
/// Implement <see cref="ISquareCalculator"/> for circle.
/// Main parameter is radius. The square calculated by the following formula: π * R^2
/// </summary>
public class CircleSquareCalculator : ISquareCalculator
{
    public double Radius { set; get; }

    public CircleSquareCalculator(double radius = 0) => Radius = radius;

    public double CalculateSquare()
    {
        Validator.CheckForZeroOrNegativeValue(nameof(Radius), Radius);
        return Math.PI * Radius * Radius;
    }
}