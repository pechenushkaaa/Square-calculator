using SquareCalculator.Exceptions;

namespace SquareCalculator;

/// <summary>
/// Represent methods which validates input params of
/// square calculators (which implements <see cref="ISquareCalculator"/>)
/// </summary>
public abstract class Validator
{
    public static void CheckForZeroOrNegativeValue(string paramName, double value)
    {
        if (value <= 0)
            throw new ZeroOrNegativeFieldException(paramName);
    }
}