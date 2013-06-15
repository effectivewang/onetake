using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTake
{
    class Digraph
    {
        public int V { get; private set; }
        public int E { get; private set; }
        private List<int>[] adj;

        public Digraph(int V) { 
            this.V = V;
            this.E = 0;
            adj = new List<int>[V];

            for (int i = 0; i < V; i++)
                adj[i] = new List<int>();
        }
        public void addEdge(int v, int w)
        {
            adj[v].Add(w);
            E++;
        }

        public IEnumerable<int> getAdj(int v) {
            return adj[v];
        }

        public Digraph reverse() {
            Digraph R = new Digraph(V);
            for (int v = 0; v < V; v++)
                foreach (var w in getAdj(v))
                    R.addEdge(w, v);

            return R;
        }
    }
}
