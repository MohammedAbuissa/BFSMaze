using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFSMaze
{
    class Bubble
    {
        public int parent;
        public int me;
        public List<Bubble> children;
        public Bubble representative;
        public Bubble(int me)
        {
            this.me = me;
            this.representative = this;
            this.children = new List<Bubble>();
        }
        public void changeRepresentative()
        {
            foreach (Bubble b in children)
                b.representative = this.representative;
        }
    }
}
