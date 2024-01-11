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
        var figure = new CircleSquareCalculator(radius1);
        Assert.That(figure.CalculateSquare(), Is.EqualTo(expected1));

        figure.Radius = radius2;
        Assert.That(figure.CalculateSquare(), Is.EqualTo(expected2));
    }
    
    [Test]
    public void TestCircleSquareCalculator_NegativeOrZeroParameterValues()
    {
        // arrange
        const int radius1 = -2;
        CircleSquareCalculator? figure = null;
        
        // act + assert
        Assert.Throws<ZeroOrNegativeFieldException>(() => figure = new CircleSquareCalculator());
        Assert.That(figure, Is.Null);
        
        figure = new CircleSquareCalculator(2);
        
        Assert.Throws<ZeroOrNegativeFieldException>(() => figure.Radius = radius1);
        Assert.That(figure.Radius, Is.EqualTo(2));
    }
}