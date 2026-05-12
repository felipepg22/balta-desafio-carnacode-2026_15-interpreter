using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.src.Interpreters;

public class BiggerThanValueRule : IDiscountAccessRule
{
    private readonly decimal _valueToValidate;

    public BiggerThanValueRule(decimal valueToValidate)
    {
        _valueToValidate = valueToValidate;
    }

    public bool Interpret(ShoppingCart cart)
    {
        return cart.TotalValue > _valueToValidate;
    }
}
