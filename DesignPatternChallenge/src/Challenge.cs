using System;
using System.Collections.Generic;
using DesignPatternChallenge.src.Interpreters;
using DesignPatternChallenge.Models;
using DesignPatternChallenge.Services;

namespace DesignPatternChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Regras de Desconto ===\n");

            var calculator = new DiscountCalculator();

            var cart1 = new ShoppingCart
            {
                TotalValue = 1500.00m,
                ItemQuantity = 15,
                CustomerCategory = "Regular",
                IsFirstPurchase = false
            };

            var cart2 = new ShoppingCart
            {
                TotalValue = 500.00m,
                ItemQuantity = 5,
                CustomerCategory = "VIP",
                IsFirstPurchase = false
            };

            var cart3 = new ShoppingCart
            {
                TotalValue = 200.00m,
                ItemQuantity = 2,
                CustomerCategory = "Regular",
                IsFirstPurchase = true
            };

            var rules = new List<DiscountRule>
            {
                new DiscountRule(
                    "Compra com quantidade e valor altos",
                    new AndRule(
                        new BiggerThanQuantityRule(10),
                        new BiggerThanValueRule(1000)),
                    15),
                new DiscountRule(
                    "Cliente VIP",
                    new IsFromCategoryRule("VIP"),
                    20),
                new DiscountRule(
                    "Primeira compra",
                    new IsFirstPurchaseRule(),
                    10),
                new DiscountRule(
                    "Cliente recorrente com carrinho relevante",
                    new AndRule(
                        new NotRule(new IsFirstPurchaseRule()),
                        new OrRule(
                            new BiggerThanQuantityRule(10),
                            new BiggerThanValueRule(1000))),
                    5)
            };

            Console.WriteLine("=== Carrinho 1 ===");
            foreach (var rule in rules)
            {
                calculator.CalculateDiscount(cart1, rule);
            }

            Console.WriteLine("\n=== Carrinho 2 ===");
            foreach (var rule in rules)
            {
                calculator.CalculateDiscount(cart2, rule);
            }

            Console.WriteLine("\n=== Carrinho 3 ===");
            foreach (var rule in rules)
            {
                calculator.CalculateDiscount(cart3, rule);
            }

            Console.WriteLine("\n=== PROBLEMAS ===");
            Console.WriteLine("✓ Regras representadas por objetos interpretadores");
            Console.WriteLine("✓ Composição com E, OU e NÃO sem parsing de strings");
            Console.WriteLine("✓ Calculadora avalia uma abstração, não condições hardcoded");

            Console.WriteLine("\n=== Regras Compostas ===");
            Console.WriteLine("• new AndRule(new BiggerThanQuantityRule(10), new BiggerThanValueRule(1000))");
            Console.WriteLine("• new OrRule(new BiggerThanQuantityRule(10), new BiggerThanValueRule(1000))");
            Console.WriteLine("• new NotRule(new IsFirstPurchaseRule())");

            // Perguntas para reflexão:
            // - Como interpretar gramática de uma linguagem?
            // - Como representar expressões como árvore de sintaxe?
            // - Como avaliar expressões recursivamente?
            // - Como criar linguagem específica de domínio extensível?
        }
    }
}
