using SquareCalculator.Calculators;
using SquareCalculator.Exceptions;

namespace SquareCalculator.Test.Calculators;

public class TriangleSquareCalculatorTest
{
    [Test]
    public void TestTriangleSquareCalculator_CalculateSquare()
    {
        // arrange
        double[] sides1 = {2d, 3d, 4d};
        double[] sides2 = {5d, 7d, 9d};
        var expected1 = CalculateExpectedSquare(sides1[0], sides1[1], sides1[2]);
        var expected2 = CalculateExpectedSquare(sides2[0], sides2[1], sides2[2]);
        
        // act + assert
        var calculator = new TriangleSquareCalculator(sides1[0], sides1[1], sides1[2]);
        Assert.That(calculator.CalculateSquare(), Is.EqualTo(expected1));

        calculator.A = sides2[0];
        calculator.B = sides2[1];
        calculator.C = sides2[2];
        Assert.That(calculator.CalculateSquare(), Is.EqualTo(expected2));
    }
    
    [Test]
    public void TestTriangleSquareCalculator_CheckRightTriangle()
    {
        // arrange
        var calculator = new TriangleSquareCalculator(3d, 4d, 5d);
        
        // act + assert
        Assert.That(calculator.IsRightAngledTriangle(), Is.True);

        calculator = new TriangleSquareCalculator(4d, 5d, 3d);
        Assert.That(calculator.IsRightAngledTriangle(), Is.True);
        
        calculator = new TriangleSquareCalculator( 5d, 3d, 4d);
        Assert.That(calculator.IsRightAngledTriangle(), Is.True);
        
        calculator = new TriangleSquareCalculator( 5d, 3d, 3d);
        Assert.That(calculator.IsRightAngledTriangle(), Is.False);
    }
    
    [Test]
    [TestCase(0d, 1d, 2d)]
    [TestCase(2d, 0d, 4d)]
    [TestCase(3d, 2d, 0d)]
    [TestCase(-3d, 4d, 5d)]
    [TestCase(3d, -4d, 5d)]
    [TestCase(3d, 4d, -5d)]
    public void TestTriangleSquareCalculator_CheckForZeroOrNegativeValue(double a, double b, double c)
    {
        // arrange 
        var calculator = new TriangleSquareCalculator(a, b, c);
        
        // act + assert
        Assert.Throws<ZeroOrNegativeFieldException>(() => calculator.CalculateSquare());
    }
    
    [Test]
    [TestCase(2d, 5d, 12d)]
    [TestCase(2d, 12d, 5d)]
    [TestCase(12d, 2d, 5d)]
    public void TestTriangle_CheckForCorrectTriangleSidesCondition(double a, double b, double c)
    {
        // arrange 
        var calculator = new TriangleSquareCalculator(a, b, c);
        
        // act + assert
        Assert.Throws<IncorrectTriangleSidesException>(() => calculator.CalculateSquare());
    }

    private static double CalculateExpectedSquare(double a, double b, double c)
    {
        var p = (a + b + c) / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }
}