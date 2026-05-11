using System;
using System.Collections.Generic;
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

            // Regras definidas como strings (idealmente viriam de banco de dados)
            var rules = new List<string>
            {
                "quantidade>10 E valor>1000 ENTAO 15",
                "categoria=VIP ENTAO 20",
                "primeiraCompra=true ENTAO 10"
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
            Console.WriteLine("✗ Parsing manual limitado e frágil");
            Console.WriteLine("✗ Não suporta expressões complexas (parênteses, precedência)");
            Console.WriteLine("✗ Não suporta operadores lógicos compostos (E, OU, NÃO)");
            Console.WriteLine("✗ Adicionar nova operação requer modificar código");
            Console.WriteLine("✗ Difícil validar sintaxe das regras");
            Console.WriteLine("✗ Impossível criar DSL (Domain Specific Language) rica");
            Console.WriteLine("✗ Não há árvore de sintaxe para otimização");

            Console.WriteLine("\n=== Expressões Desejadas (não suportadas) ===");
            Console.WriteLine("• (quantidade > 10 OU valor > 500) E categoria = VIP");
            Console.WriteLine("• NÃO primeiraCompra E quantidade >= 5");
            Console.WriteLine("• (valor > 1000 E categoria = VIP) OU primeiraCompra");

            // Perguntas para reflexão:
            // - Como interpretar gramática de uma linguagem?
            // - Como representar expressões como árvore de sintaxe?
            // - Como avaliar expressões recursivamente?
            // - Como criar linguagem específica de domínio extensível?
        }
    }
}
