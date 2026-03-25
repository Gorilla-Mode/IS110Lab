using System;
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
        const double expectedResult = 8;

        //Act
        var result = Calculator.AddNumbers(3, 5);

        //Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void TestSubtractNumbers()
    {
        //Arrange
        const double expectedResult = 2;
        
        //Act
        var result = Calculator.SubtractNumbers(5, 3);
        
        //Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void TestMultiplyNumbers()
    {
        //Arrange
        //Sjekker noen flere muligheter her
        const double expectedResult = 10;
        const double expectedResultMultByZero = 0;
        const double expectedResultMultByNegative = 10;

        //act
        var result = Calculator.MultiplyNumbers(2, 5);
        var resultMultByZero = Calculator.MultiplyNumbers(2, 0);
        var resultMultByNegative = Calculator.MultiplyNumbers(-2, -5);
           

        //assert
        Assert.Equal(expectedResult, result);
        Assert.Equal(expectedResultMultByZero, resultMultByZero);
        Assert.Equal(expectedResultMultByNegative, resultMultByNegative);
    }

    [Fact]
    public void TestDivideNumbers()
    {
        //Arrange
        const double expectedResult = 2;
        
        //act
        var result = Calculator.DivideNumbers(4, 2);
        
        //for å sjekke at en exception blir kastet, må den kastes inne i Asserten, hvis ikke har du bare en exception i programmet
        //definerer derfor en funsksjon slik at utføringen kan kjøres i asserten.
        void ResultDivByZero() => Calculator.DivideNumbers(4, 0);

        //assert
        Assert.Equal(expectedResult, result);
        Assert.Throws<DivideByZeroException>(ResultDivByZero);
    }
    
}