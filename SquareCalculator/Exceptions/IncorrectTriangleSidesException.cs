namespace SquareCalculator.Exceptions;

public class IncorrectTriangleSidesException: Exception
{
    public IncorrectTriangleSidesException() : base("Any two sides of triangle must be greater than the third") { }
}