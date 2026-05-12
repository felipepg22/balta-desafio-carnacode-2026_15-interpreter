using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.src.Interpreters;

public class OrRule : IDiscountAccessRule
{
    private readonly IDiscountAccessRule _firstRule;
    private readonly IDiscountAccessRule _secondRule;

    public OrRule(IDiscountAccessRule firstRule, IDiscountAccessRule secondRule)
    {
        _firstRule = firstRule;
        _secondRule = secondRule;
    }

    public bool Interpret(ShoppingCart cart)
    {
        return _firstRule.Interpret(cart) || _secondRule.Interpret(cart);
    }
}
