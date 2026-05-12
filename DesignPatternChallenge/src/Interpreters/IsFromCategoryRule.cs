using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.src.Interpreters;

public class IsFromCategoryRule : IDiscountAccessRule
{
    private readonly string _category;

    public IsFromCategoryRule(string category)
    {
        _category = category;
    }

    public bool Interpret(ShoppingCart cart)
    {
        return cart.CustomerCategory.Equals(_category, StringComparison.OrdinalIgnoreCase);
    }
}
