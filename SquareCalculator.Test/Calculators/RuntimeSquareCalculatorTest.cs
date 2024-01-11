using SquareCalculator.Calculators;
using SquareCalculator.Exceptions;

namespace SquareCalculator.Test.Calculators;

public class RuntimeSquareCalculatorTest
{
    [Test]
    public void TestRuntimeSquareCalculator_CalculateCircleSquare()
    {
        // arrange
        var args = new[] { 2d };
        var expected1 = Math.PI * args[0] * args[0];
        
        // act
        ISquareCalculator calculator = new RuntimeSquareCalculator(args);
        
        // assert
        Assert.That(calculator.CalculateSquare(), Is.EqualTo(expected1));
    }
    
    [Test]
    public void TestRuntimeSquareCalculator_CalculateTriangleSquare()
    {
        // arrange
        var args = new[] { 2d, 3d, 4d };
        var p = (args[0] + args[1] + args[2]) / 2;
        var expected =  Math.Sqrt(p * (p - args[0]) * (p - args[1]) * (p - args[2]));
        
        // act
        ISquareCalculator calculator = new RuntimeSquareCalculator(args);
        
        // assert
        Assert.That(calculator.CalculateSquare(), Is.EqualTo(expected));

    }
    
    [Test]
    public void TestRuntimeSquareCalculator_NoArgumentsSet()
    {
        // act + assert
        Assert.Throws<NoArgumentsSetException>(() => { _ = new RuntimeSquareCalculator(); });
    }
    
    [Test]
    [TestCase(new double[]{1, 2})]
    [TestCase(new double[]{1, 2, 3, 4})]
    public void TestRuntimeSquareCalculator_UnexpectedCalculator(double[] args)
    {
        // act + assert
        Assert.Throws<UnexpectedSquareCalculatorException>(() =>
        {
            var calculator = new RuntimeSquareCalculator(args);
            calculator.CalculateSquare();
        });
    }
}