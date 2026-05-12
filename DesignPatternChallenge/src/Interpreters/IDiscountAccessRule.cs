using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.src.Interpreters;

public interface IDiscountAccessRule
{
    public bool Interpret(ShoppingCart cart);
}
