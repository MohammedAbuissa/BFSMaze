using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
namespace BFSMaze
{
   static class Global
    {
       public static Grid g;
       public static int end;
       public static int w;
       public static int h;
       public static Vertix vcurrent= new Vertix();
       public static Edge ecurrent = new Edge();
       public static state s;
       public static List<Point> Q = new List<Point>(16);
       public static void defineRoutes(Vertix v, int i)
       {
           if (i != end)
           {
               List<int> c = program.adjList[i - 1];
               Debug.WriteLine(i);
               Debug.WriteLine(c.Count);

               v.i = i;
               foreach (int k in c)
               {
                   Debug.WriteLine(k);
               }
               if (c.Contains(i - w))
                   v.w = true;
               if (c.Contains(i + w))
                   v.s = true;
               if (c.Contains(i - 1))
                   v.a = true;
               if (c.Contains(i + 1))
                   v.d = true;
               Debug.WriteLine(v.w + " " + v.s + " " + v.d + " " + v.a);
           }
           else
               g.Background =new SolidColorBrush(Colors.YellowGreen);
           
       }
    }
}
