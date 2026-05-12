using System;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.Services
{
    public class DiscountCalculator
    {
        public decimal CalculateDiscount(ShoppingCart cart, DiscountRule rule)
        {
            Console.WriteLine($"Avaliando regra: {rule.Name}");

            if (rule.AccessRule.Interpret(cart))
            {
                Console.WriteLine($"✓ Regra aplicada: {rule.Percentage}% desconto");
                return rule.Percentage;
            }

            Console.WriteLine("✗ Regra não aplicável");
            return 0;
        }
    }
}
