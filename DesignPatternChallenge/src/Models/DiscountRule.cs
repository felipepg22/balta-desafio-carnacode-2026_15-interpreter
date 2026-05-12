using DesignPatternChallenge.src.Interpreters;

namespace DesignPatternChallenge.Models;

public class DiscountRule
{
    public DiscountRule(string name, IDiscountAccessRule accessRule, decimal percentage)
    {
        Name = name;
        AccessRule = accessRule;
        Percentage = percentage;
    }

    public string Name { get; }
    public IDiscountAccessRule AccessRule { get; }
    public decimal Percentage { get; }
}
