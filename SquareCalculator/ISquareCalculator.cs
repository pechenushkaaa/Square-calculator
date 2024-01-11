namespace SquareCalculator;

/// <summary>
/// Represent base method to make square calculators for specific shapes  
/// </summary>
public interface ISquareCalculator
{ 
    /// <summary>
    /// Calculate square for shape
    /// </summary>
    /// <returns>Shape square</returns>
    double CalculateSquare();
}