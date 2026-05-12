![CO-3](https://github.com/user-attachments/assets/ba8139b5-0c16-48dc-8185-a6f0cd2f0005)

## CarnaCode 2026 - Challenge 15 - Interpreter

Hi, I am Felipe Parizzi Galli, and this is the place where I share my learning journey during the **CarnaCode 2026** challenge, created by [balta.io](https://balta.io).

Here you will find projects, exercises, and code I am building throughout the challenge. The goal is to get hands-on practice, test ideas, and document my progress in software development.

### About This Challenge

In the **Interpreter** challenge, I had to solve a real-world problem by implementing this specific **Design Pattern**.

During this process, I practiced:

* Good software practices
* Clean Code
* SOLID
* Design Patterns

## Problem

An e-commerce system needs to evaluate discount rules without relying on hardcoded conditional logic.

The original code used several `if/else` statements inside the discount calculator. That approach made the rules difficult to compose, extend, and reuse because each new rule required changes directly in the calculator.

## About CarnaCode 2026

The **CarnaCode 2026** challenge consists of implementing all 23 design patterns in real-world scenarios. During the 23 challenges in this journey, participants practice identifying code that does not scale well and solving those problems with established design patterns.

### eBook - Design Patterns Fundamentals

My main learning resource during this challenge was the free eBook [Design Patterns Fundamentals](https://lp.balta.io/ebook-fundamentos-design-patterns).

## Interpreter Pattern Implementation

To implement the Interpreter pattern, the discount rules were moved out of `DiscountCalculator` and represented as dedicated interpreter objects.

What was done:

* Created the `IDiscountAccessRule` abstraction to define how every discount rule is interpreted against a `ShoppingCart`.
* Implemented concrete rules such as `BiggerThanQuantityRule`, `BiggerThanValueRule`, `IsFromCategoryRule`, and `IsFirstPurchaseRule`.
* Added composite rules with `AndRule`, `OrRule`, and `NotRule`, allowing complex business rules to be built by combining smaller rules.
* Added `DiscountRule` to pair an interpreted access rule with its discount percentage.
* Refactored `DiscountCalculator` so it no longer parses strings or validates rule keywords. It now only receives a typed `DiscountRule`, interprets it, and returns the configured discount when applicable.
* Updated the console challenge example to compose discount rules directly in code instead of using rule strings like `ENTAO` or other text-based operators.

This keeps the calculator focused on applying discounts while the rule objects are responsible for expressing and evaluating the business conditions.
