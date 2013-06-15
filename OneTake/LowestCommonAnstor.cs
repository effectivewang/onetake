using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTake
{
    class Node
    {
        public int Value;
        public Node Left;
        public Node Right;
    }

    class BSTLowestCommonAnstor
    {
        public Node find(Node node, int value, int value2)
        {
            while (node != null)
            {
                if (value > node.Value && value2 > node.Value)
                    node = node.Right;
                else if (value < node.Value && value2 < node.Value)
                    node = node.Left;
                else
                    return node;
            }
            return null;
        }

        public void test()
        {
            Node node = new Node();
            node.Value = 5;
            node.Left = new Node();
            node.Left.Value = 1;
            node.Right = new Node();
            node.Right.Value = 6;

            Node res = find(node, 1, 6);

            AssertHelper.assert(res != null && res.Value == 5, "True");
        }
    }
}
