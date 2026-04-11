using System;
using System.Collections.Generic;
using System.Text;

namespace Study.LabWork1.Features.Task3
{
    public class TreeNode
    {
        public object Value { get; set; }

        public List<TreeNode> Children { get; set; }

        public TreeNode(object value)
        {
            Value = value;
            Children = new List<TreeNode>();
        }

        public void AddChild(TreeNode child)
        {
            Children.Add(child);
        }

        public void PrintAllValues()
        {
            Console.WriteLine(Value);

            if (Children.Count == 0) return;

            foreach (var child in Children)
            {
                child.PrintAllValues();
            }
        }
    }
}
