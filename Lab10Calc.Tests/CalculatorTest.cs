using JetBrains.Annotations;
using Xunit;

namespace Lab10Calc.Tests;

[TestSubject(typeof(Calculator))]
public class CalculatorTest
{
    [Fact]
    public void TestAddNumbers()
    {
        //Arrange
        double expectedResult = 8;
        double result;

        //Act
        result = Calculator.AddNumbers(3, 5);

        //Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void TestSubtractNumbers()
    {
        //Arrange
        double expectedResult = 2;
        double result;
        
        //Act
        result = Calculator.SubtractNumbers(5, 3);
        
        //Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void TestMultiplyNumbers()
    {
        //Arrange
        double expectedResult = 10;
        double expectedResultMultByZero = 0;
        double expectedResultMultByNegative = -10;

        //act
        var result = Calculator.MultiplyNumbers(2, 5);
        var resultMultByZero = Calculator.MultiplyNumbers(2, 0);
        var resultMultByNegative = Calculator.MultiplyNumbers(2, -5);
           

        //assert
        Assert.Equal(expectedResult, result);
        Assert.Equal(expectedResultMultByZero, resultMultByZero);
        Assert.Equal(expectedResultMultByNegative, resultMultByNegative);
    }

    [Fact]
    public void TestDivideNumbers()
    {
        //Arrange
        double expectedResult = 2;
        
        //act
        var result = Calculator.DivideNumbers(4, 2);
        
        //assert
        Assert.Equal(expectedResult, result);
    }
    
}