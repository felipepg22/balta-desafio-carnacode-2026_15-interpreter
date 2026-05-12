using System;
using DesignPatternChallenge.Models;
using DesignPatternChallenge.src.Interpreters;

namespace DesignPatternChallenge.Services
{
    // Problema: Regras de desconto hardcoded com condicionais complexas
    public class DiscountCalculator
    {
        public decimal CalculateDiscount(ShoppingCart cart, string ruleText)
        {
            // Problema: Parsing manual e limitado de regras
            // "quantidade>10 E valor>1000 ENTAO 15"
            // "categoria=VIP ENTAO 20"
            // "primeirCompra=true ENTAO 10"
            
            Console.WriteLine($"Avaliando regra: {ruleText}");

            // Tentativa ingênua de parsing
            if (ruleText.Contains("quantidade>10") && ruleText.Contains("valor>1000"))
            {
                if (cart.ItemQuantity > 10 && cart.TotalValue > 1000)
                {
                    // Extrair desconto do texto
                    var parts = ruleText.Split("ENTAO");
                    if (parts.Length > 1)
                    {
                        if (decimal.TryParse(parts[1].Trim(), out decimal discount))
                        {
                            Console.WriteLine($"✓ Regra aplicada: {discount}% desconto");
                            return discount;
                        }
                    }
                }
            }
            else if (ruleText.Contains("categoria=VIP"))
            {
                if (cart.CustomerCategory == "VIP")
                {
                    var parts = ruleText.Split("ENTAO");
                    if (parts.Length > 1 && decimal.TryParse(parts[1].Trim(), out decimal discount))
                    {
                        Console.WriteLine($"✓ Regra aplicada: {discount}% desconto");
                        return discount;
                    }
                }
            }
            else if (ruleText.Contains("primeiraCompra=true"))
            {
                if (cart.IsFirstPurchase)
                {
                    var parts = ruleText.Split("ENTAO");
                    if (parts.Length > 1 && decimal.TryParse(parts[1].Trim(), out decimal discount))
                    {
                        Console.WriteLine($"✓ Regra aplicada: {discount}% desconto");
                        return discount;
                    }
                }
            }

            Console.WriteLine("✗ Regra não aplicável");
            return 0;
        }

        // Problema: Adicionar nova regra = modificar código
        // Problema: Não suporta operadores complexos (OU, NÃO, parênteses)
        // Problema: Não valida sintaxe das regras
    }
}
