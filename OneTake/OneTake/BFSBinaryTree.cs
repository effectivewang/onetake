using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTake
{
    class BFSBinaryTree
    {
        List<Node>[] nodes;
        Queue<Node> queue = new Queue<Node>();

        public BFSBinaryTree(Node node)
        {
            int max = maxLevel(node, 0);
            nodes = new List<Node>[max];

            for (int i = 0; i < max; i++)
                nodes[i] = new List<Node>();

            queue.Enqueue(node);
            bfs(node, 0);
        }

        private int maxLevel(Node node, int level)
        {
            if (node == null) return level;

            int left = maxLevel(node.Left, level + 1);
            int right = maxLevel(node.Right, level + 1);

            return Math.Max(left, right);
        }

        private void bfs(Node node, int level)
        {
            if (node == null) return;

            while (queue.Count > 0)
            {
                Node n = queue.Dequeue();
                nodes[level].Add(node);
            }

            if (node.Left != null)
                queue.Enqueue(node.Left);

            if (node.Right != null)
                queue.Enqueue(node.Right);

            bfs(node.Left, level + 1);
            bfs(node.Right, level + 1);
        }

        public void bfs(Node node) {
            queue.Enqueue(node);
            while (queue.Count > 0) {
                Node n = queue.Dequeue();

                if (n.Left != null) {
                    queue.Enqueue(n.Left);
                }
                if (n.Right != null) {
                    queue.Enqueue(n.Right);
                }


                Console.Write(n.Value + " ");
            }
        }

        public List<Node>[] levels()
        {
            return nodes;
        }

        public static void test()
        {

            Node node = new Node();
            node.Value = 5;
            node.Left = new Node();
            node.Left.Value = 1;
            node.Left.Left = new Node();
            node.Left.Left.Value = 2;
            node.Left.Right = new Node();
            node.Left.Right.Value = 3;
            node.Right = new Node();
            node.Right.Value = 6;
            node.Right.Left = new Node();
            node.Right.Left.Value = 7;
            node.Right.Right = new Node();
            node.Right.Right.Value = 10;

            BFSBinaryTree bfs = new BFSBinaryTree(node);
            bfs.bfs(node);
            //var v = bfs.levels();
        }
    }
}
