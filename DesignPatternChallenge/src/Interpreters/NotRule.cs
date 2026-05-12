using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.src.Interpreters;

public class NotRule : IDiscountAccessRule
{
    private readonly IDiscountAccessRule _rule;

    public NotRule(IDiscountAccessRule rule)
    {
        _rule = rule;
    }

    public bool Interpret(ShoppingCart cart)
    {
        return !_rule.Interpret(cart);
    }
}
