using Study.LabWork1.Features.Task3;
using System;
using System.Collections.Generic;
using System.Text;

namespace Study.LabWork1.UnitTests.Features.Task3
{
    public class TreeNodeTests
    {
        public static void Test()
        {
            Console.WriteLine("==== Тесты TreeNode ====");

            var root = new TreeNode("Корень");
            var child1 = new TreeNode("Потомок 1");
            var child2 = new TreeNode("Потомок 2");
            var grandChild1 = new TreeNode("Внук 1.1");

            root.AddChild(child1);
            root.AddChild(child2);
            child1.AddChild(grandChild1);

            Console.WriteLine("Результат вывода:");
            root.PrintAllValues();
        }
    }
}
