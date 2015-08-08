using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.System;

namespace BFSMaze
{
    interface state
    {
        void act(CompositeTransform x, VirtualKey y);
    }
}
