using System;

using Xunit;
using Moq;

namespace SpaceBattle.Lib.Test;
public class AngleTests
{
    [Fact]
    public void ConstructorTest()
    {
        var a = new Fraction(4);

        Assert.Equal(new Fraction(4, 1), a);
    }


    [Fact]
    public void ReductionTest()
    {
        var a = new Fraction(4, 8);

        Assert.Equal(new Fraction(1, 2), a);
    }

    [Fact]
    public void AngleEqual()
    {
        var a = new Fraction(1, 2);

        Assert.Equal(new Fraction(1, 2), a);
    }

    [Fact]
    public void AngleEqualNull()
    {
        var a = new Fraction(1, 2);

        Assert.False(a.Equals(null));
    }

    [Fact]
    public void AngleGetHashCodeTest()
    {
        var a = new Fraction(1, 2).GetHashCode();
        var b = new Fraction(3, 2).GetHashCode();

        Assert.NotEqual(a, b);
    }

    [Fact]
    public void AdditiveAngleTest()
    {
        var a = new Fraction(1, 2);
        var b = new Fraction(3, 4);

        Assert.Equal(new Fraction(5, 4), a + b);
    }
}