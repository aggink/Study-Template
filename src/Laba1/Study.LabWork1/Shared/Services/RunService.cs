using Study.LabWork1.Shared.Abstractions;
using Study.LabWork1.Features.Task1;
using Study.LabWork1.Features.Task2;
using Study.LabWork1.Features.Task3;
using System;

namespace Study.LabWork1.Shared.Services;

/// <summary>
/// Реализация заданий Л/Р
/// </summary>
public class RunService : IRunService
{
    /// <summary>
    /// Задание 1
    /// </summary>
    public void RunTask1()
    {
        Console.WriteLine("=== Задание 1. HSL пиксель (Вариант 4) ===\n");

        var hsl1 = new HslPixel(210, 50, 60);
        var hsl2 = new HslPixel(120, 80, 40);
        var hsl3 = new HslPixel(210, 50, 60);

        Console.WriteLine($"hsl1: {hsl1}");
        Console.WriteLine($"hsl2: {hsl2}");
        Console.WriteLine($"hsl1 в RGB: ({hsl1.ToRgb().R}, {hsl1.ToRgb().G}, {hsl1.ToRgb().B})");
        Console.WriteLine($"hsl1 в HEX: {hsl1.ToHex()}\n");

        Console.WriteLine($"hsl1 + hsl2 = {hsl1 + hsl2}");
        Console.WriteLine($"hsl1 - hsl2 = {hsl1 - hsl2}");
        Console.WriteLine($"hsl1 * 2 = {hsl1 * 2}");
        Console.WriteLine($"hsl1 * hsl2 = {hsl1 * hsl2}");
        Console.WriteLine($"hsl1 / 2 = {hsl1 / 2}\n");

        Console.WriteLine($"hsl1 == hsl3: {hsl1 == hsl3}");
        Console.WriteLine($"hsl1 == hsl2: {hsl1 == hsl2}");
        Console.WriteLine($"hsl1 != hsl2: {hsl1 != hsl2}\n");

        var clamped = new HslPixel(500, 200, -50);
        Console.WriteLine($"Проверка ограничения значений (500, 200, -50): {clamped}");
    }

    /// <summary>
    /// Задание 2. Паттерн Фасад
    /// </summary>
    public void RunTask2()
    {
        Console.WriteLine("\n=== Задание 2. Паттерн Фасад (Оформление заказа) ===\n");

        var facade = new OrderFacade();

        var order1 = new Order
        {
            Id = 1,
            CustomerName = "Иван Петров",
            Products = new System.Collections.Generic.List<string> { "Ноутбук", "Мышь" },
            TotalPrice = 55000
        };

        var order2 = new Order
        {
            Id = 2,
            CustomerName = "Мария Сидорова",
            Products = new System.Collections.Generic.List<string> { "Телефон", "Чехол" },
            TotalPrice = 30000
        };

        facade.PlaceOrder(order1);
        facade.PlaceOrder(order2);
    }

    /// <summary>
    /// Задание 3. Дерево
    /// </summary>
    public void RunTask3()
    {
        Console.WriteLine("\n=== Задание 3. Реализация дерева ===\n");

        var root = new TreeNode<string>("Корень");

        var child1 = new TreeNode<string>("Потомок 1");
        var child2 = new TreeNode<string>("Потомок 2");
        var child3 = new TreeNode<string>("Потомок 3");

        root.AddChild(child1);
        root.AddChild(child2);
        root.AddChild(child3);

        var grandChild1 = new TreeNode<string>("Внук 1.1");
        var grandChild2 = new TreeNode<string>("Внук 1.2");
        child1.AddChild(grandChild1);
        child1.AddChild(grandChild2);

        var grandChild3 = new TreeNode<string>("Внук 2.1");
        child2.AddChild(grandChild3);

        Console.WriteLine("Структура дерева:");
        root.PrintTree();

        Console.WriteLine($"\nЗначение корня: {root.Value}");
        Console.WriteLine($"Количество потомков корня: {root.Children.Count}");
        Console.WriteLine($"Первый потомок: {child1.Value}, у него {child1.Children.Count} внуков");
    }
}
