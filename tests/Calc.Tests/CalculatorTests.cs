using Calc;

namespace Calc.Tests;

public class CalculatorTests
{
    [Fact]
    public void Add_ReturnsSum() => Assert.Equal(5, Calculator.Add(2, 3));

    [Fact]
    public void Subtract_ReturnsDifference() => Assert.Equal(1, Calculator.Subtract(3, 2));
}
