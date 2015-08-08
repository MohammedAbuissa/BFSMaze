using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace BFSMaze
{
    class Vertix:state
    {
        public bool w, a, s, d;
        public int i;
        public void act(Windows.UI.Xaml.Media.CompositeTransform x, Windows.System.VirtualKey y)
        {
            if (y == VirtualKey.Down&&s)
            {
                x.TranslateY += 10;
                Global.ecurrent.type = false;
                Global.ecurrent.direction = false;
                Global.ecurrent.icurr = i;
                Global.ecurrent.inext = i + Global.w;
                Global.s = Global.ecurrent;
                Global.vcurrent.reset();
            }
            if (y == VirtualKey.Up && w)
            {
                x.TranslateY -= 10;
                Global.ecurrent.type = false;
                Global.ecurrent.direction = true;
                Global.ecurrent.icurr = i;
                Global.ecurrent.inext = i - Global.w;
                Global.s = Global.ecurrent;
                Global.vcurrent.reset();
            }

            if (y == VirtualKey.Left && a)
            {
                x.TranslateX -= 10;
                Global.ecurrent.type = true;
                Global.ecurrent.direction = false;
                Global.ecurrent.icurr = i;
                Global.ecurrent.inext = i - 1;
                Global.s = Global.ecurrent;
                Global.vcurrent.reset();
            }

            if (y == VirtualKey.Right && d)
            {
                x.TranslateX += 10;
                Global.ecurrent.type = true;
                Global.ecurrent.direction = true;
                Global.ecurrent.icurr = i;
                Global.ecurrent.inext = i + 1;
                Global.s = Global.ecurrent;
                Global.vcurrent.reset();
            }
                
        }
        public void reset()
        {
            w = a = s = d = false;
        }
    }
}
