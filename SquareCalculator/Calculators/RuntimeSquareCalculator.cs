using SquareCalculator.Exceptions;

namespace SquareCalculator.Calculators;

/// <summary>
/// Implement <see cref="ISquareCalculator"/> for shapes based on number of input arguments.
/// </summary>
public class RuntimeSquareCalculator: ISquareCalculator
{
    private readonly double[] _args;
    
    public RuntimeSquareCalculator(params double[] args)
    {
        if (args.Length == 0)
            throw new NoArgumentsSetException();

        _args = args;
    }

    public double CalculateSquare()
    {
        return _args.Length switch
        {
            1 => new CircleSquareCalculator(_args[0]).CalculateSquare(),
            3 => new TriangleSquareCalculator(_args[0], _args[1], _args[2]).CalculateSquare(),
            _ => throw new UnexpectedSquareCalculatorException(_args.Length)
        };
    }
}