using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTake
{
    class DFSDiagraph
    {
        public bool[] marked;
        public Stack<int> order;

        public DFSDiagraph(Digraph graph)
        {
            marked = new bool[graph.V];
            order = new Stack<int>(graph.V);

            for (int v = 0; v < graph.V; v++)
                if (!marked[v]) dfs(graph, v);
        }

        private void dfs(Digraph g, int v)
        {
            marked[v] = true;
            foreach (var w in g.getAdj(v))
            {
                if (!marked[w])
                    dfs(g, w);
            }

            order.Push(v);
        }

        public IEnumerable<int> sort()
        {
            return order;
        }
    }

    class DirectedCycle
    {
        private bool[] marked;
        private Stack<int> cycle;
        private int[] edgeTo;
        private bool[] onStack;

        public DirectedCycle(Digraph g)
        {
            marked = new bool[g.V];
            onStack = new bool[g.V];
            cycle = new Stack<int>(g.V);
            edgeTo = new int[g.V];

            for (int v = 0; v < g.V; v++)
                if (!marked[v])
                    dfs(g, v);
        }

        private void dfs(Digraph g, int v)
        {
            marked[v] = true;
            onStack[v] = true;

            foreach (int w in g.getAdj(v))
            {
                if(hasCycle()) return;
                else if (!marked[w])
                {
                    edgeTo[w] = v;
                    dfs(g, w);
                }
                else if (onStack[w])
                {
                    for (int x = v; x != w; x = edgeTo[x])
                        cycle.Push(x);

                    cycle.Push(w);
                    cycle.Push(v);
                }
            }

            onStack[v] = false;
        }

        public bool hasCycle() { return cycle.Count > 0;}
        public IEnumerable<int> getCycle() { return cycle; }

    }
}
