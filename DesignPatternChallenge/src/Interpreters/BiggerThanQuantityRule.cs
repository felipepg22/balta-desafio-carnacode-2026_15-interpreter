using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.src.Interpreters;

public class BiggerThanQuantityRule : IDiscountAccessRule
{
    private readonly int _quantityToValidate;

    public BiggerThanQuantityRule(int quantityToValidate)
    {
        _quantityToValidate = quantityToValidate;
    }

    public bool Interpret(ShoppingCart cart)
    {
        return cart.ItemQuantity > _quantityToValidate;
    }
}
