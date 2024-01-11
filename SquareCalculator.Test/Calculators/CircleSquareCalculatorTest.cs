using SquareCalculator.Calculators;
using SquareCalculator.Exceptions;

namespace SquareCalculator.Test.Calculators;

public class CircleSquareCalculatorTest
{
    [Test]
    public void TestCircleSquareCalculator_CalculateSquare()
    {
        // arrange
        const int radius1 = 2;
        const int radius2 = 3;
        const double expected1 = Math.PI * radius1 * radius1;
        const double expected2 = Math.PI * radius2 * radius2;
        
        // act + assert
        var calculator = new CircleSquareCalculator(radius1);
        Assert.That(calculator.CalculateSquare(), Is.EqualTo(expected1));

        calculator.Radius = radius2;
        Assert.That(calculator.CalculateSquare(), Is.EqualTo(expected2));
    }
    
    [Test]
    public void TestCircleSquareCalculator_NegativeOrZeroParameterValues()
    {
        // arrange
        const int radius1 = -2;
        var calculator = new CircleSquareCalculator();
        
        // act + assert
        Assert.Throws<ZeroOrNegativeFieldException>(() => calculator.CalculateSquare());
        
        calculator.Radius = radius1;
        Assert.Throws<ZeroOrNegativeFieldException>(() => calculator.CalculateSquare());
    }
}