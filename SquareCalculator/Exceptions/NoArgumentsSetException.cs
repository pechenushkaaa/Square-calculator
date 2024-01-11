namespace SquareCalculator.Exceptions;

public class NoArgumentsSetException : Exception
{
    public NoArgumentsSetException(): base("No arguments set to square calculation") { }
}