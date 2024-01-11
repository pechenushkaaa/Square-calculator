namespace SquareCalculator.Exceptions;

public class ZeroOrNegativeFieldException : Exception
{
    public ZeroOrNegativeFieldException(string field) : base($"Parameter: {field} should be greater than 0") { }
}