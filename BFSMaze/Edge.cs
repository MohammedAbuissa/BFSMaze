using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.System;

namespace BFSMaze
{
    class Edge:state
    {
        public int icurr, inext;
        public bool type;
        public bool direction;
        public  void act(Windows.UI.Xaml.Media.CompositeTransform x, Windows.System.VirtualKey y)
        {
            if (type)
            {
                int d = direction ? icurr : inext;
                int d2 = direction ? inext : icurr;
                if (y == VirtualKey.Left)
                {
                    x.TranslateX -= 10;
                    if (x.TranslateX == Global.Q[d - 1].X-10)
                    {
                        Global.defineRoutes(Global.vcurrent, d);
                        Global.s = Global.vcurrent;
                    }
                }
                else if (y == VirtualKey.Right)
                {
                    x.TranslateX += 10;
                    if (x.TranslateX == Global.Q[d2 - 1].X-10)
                    {
                        Global.defineRoutes(Global.vcurrent, d2);
                        Global.s = Global.vcurrent;
                    }
                }
            }
            else
            {
                int d = direction ? icurr : inext;
                int d2 = direction ? inext : icurr;
                if (y == VirtualKey.Up)
                {
                    x.TranslateY -= 10;
                    if (x.TranslateY == Global.Q[d2 - 1].Y-10)
                    {
                        Global.defineRoutes(Global.vcurrent, d2);
                        Global.s = Global.vcurrent;
                    }
                }
                else if (y == VirtualKey.Down)
                {
                    x.TranslateY += 10;
                    if (x.TranslateY == Global.Q[d - 1].Y-10)
                    {
                        Global.defineRoutes(Global.vcurrent, d);
                        Global.s = Global.vcurrent;
                    }
                }
            }
        }
    }
}
