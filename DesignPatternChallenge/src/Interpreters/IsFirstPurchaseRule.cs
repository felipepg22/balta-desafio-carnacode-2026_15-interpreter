using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.src.Interpreters;

public class IsFirstPurchaseRule : IDiscountAccessRule
{
    public bool Interpret(ShoppingCart cart)
    {
        return cart.IsFirstPurchase;
    }
}
