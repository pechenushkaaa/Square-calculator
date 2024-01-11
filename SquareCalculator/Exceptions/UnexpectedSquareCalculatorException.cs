namespace SquareCalculator.Exceptions;

public class UnexpectedSquareCalculatorException : Exception
{
    public UnexpectedSquareCalculatorException(int argsLength) : base($"Unexpected figure with {argsLength} parameters to calculate square") { }
}