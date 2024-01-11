namespace SquareCalculator.Calculators;

/// <summary>
/// Implement <see cref="ISquareCalculator"/> for circle.
/// Main parameter is radius. The square calculated by the following formula: π * R^2
/// </summary>
public class CircleSquareCalculator : ISquareCalculator
{
    private double _radius;

    public double Radius
    {
        set
        {
            Validator.CheckForZeroOrNegativeValue(nameof(Radius), value);
            _radius = value;
        }
        get => _radius;
    }

    public CircleSquareCalculator(double radius = 0) => Radius = radius;

    public double CalculateSquare() => Math.PI * _radius * _radius;
}