Here is a simple console application in C# that finds the lowest common ancestor of two nodes in a binary tree:

```C#
using System;

public class Node
{
    public int data;
    public Node left, right;

    public Node(int item)
    {
        data = item;
        left = right = null;
    }
}

public class BinaryTree
{
    public Node root;

    public Node FindLCA(int n1, int n2)
    {
        return FindLCA(root, n1, n2);
    }

    public Node FindLCA(Node node, int n1, int n2)
    {
        if (node == null)
            return null;

        if (node.data == n1 || node.data == n2)
            return node;

        Node left_lca = FindLCA(node.left, n1, n2);
        Node right_lca = FindLCA(node.right, n1, n2);

        if (left_lca != null && right_lca != null)
            return node;

        return (left_lca != null) ? left_lca : right_lca;
    }
}

class Program
{
    static void Main(string[] args)
    {
        BinaryTree tree = new BinaryTree();
        tree.root = new Node(1);
        tree.root.left = new Node(2);
        tree.root.right = new Node(3);
        tree.root.left.left = new Node(4);
        tree.root.left.right = new Node(5);
        tree.root.right.left = new Node(6);
        tree.root.right.right = new Node(7);

        Console.WriteLine("LCA(4, 5) = " +
                          tree.FindLCA(4, 5).data);
        Console.WriteLine("LCA(4, 6) = " +
                          tree.FindLCA(4, 6).data);
        Console.WriteLine("LCA(3, 4) = " +
                          tree.FindLCA(3, 4).data);
        Console.WriteLine("LCA(2, 4) = " +
                          tree.FindLCA(2, 4).data);
    }
}
```

This program creates a binary tree and then finds the lowest common ancestor of different pairs of nodes. The `FindLCA` method is used to find the lowest common ancestor of two nodes. It checks if the current node is one of the two nodes. If it is, it returns the current node. If not, it checks the left and right subtrees. If both subtrees return a non-null value, it means that one node is in one subtree and the other is in the other, so the current node is the LCA. If only one subtree returns a non-null value, it returns that value.