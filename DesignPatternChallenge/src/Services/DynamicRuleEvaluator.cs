using System;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.Services
{
    // Tentativa alternativa: Eval dinâmico (perigoso e limitado)
    public class DynamicRuleEvaluator
    {
        public bool EvaluateRule(ShoppingCart cart, string expression)
        {
            // Substituir variáveis
            expression = expression
                .Replace("quantidade", cart.ItemQuantity.ToString())
                .Replace("valor", cart.TotalValue.ToString())
                .Replace("categoria", $"\"{cart.CustomerCategory}\"")
                .Replace("primeiraCompra", cart.IsFirstPurchase.ToString().ToLower());

            Console.WriteLine($"Expressão transformada: {expression}");

            // Problema: Usar eval/compilar código dinamicamente é perigoso
            // Problema: Difícil validar e debugar
            // Problema: Performance ruim (compilação em runtime)

            // Não implementado aqui por questões de segurança
            return false;
        }
    }
}
