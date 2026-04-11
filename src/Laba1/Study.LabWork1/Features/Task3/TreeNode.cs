using System;
using System.Collections.Generic;

namespace Study.LabWork1.Features.Task3
{
    public class TreeNode<T>
    {
        public T Value { get; set; }
        public List<TreeNode<T>> Children { get; set; }

        public TreeNode(T value)
        {
            Value = value;
            Children = new List<TreeNode<T>>();
        }

        public void AddChild(TreeNode<T> child)
        {
            Children.Add(child);
        }

        public void PrintTree(int level = 0)
        {
            string indent = new string(' ', level * 2);
            Console.WriteLine($"{indent}└─ {Value}");

            foreach (var child in Children)
            {
                child.PrintTree(level + 1);
            }
        }
    }
}
