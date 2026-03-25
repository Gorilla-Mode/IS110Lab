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
        double result;

        //Act
        result = Calculator.AddNumbers(3, 5);

        //Assert
        Assert.Equal(8, result);
    }
}