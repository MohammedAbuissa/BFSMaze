using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Navigation;
namespace BFSMaze
{
    class program
    {
        public static List<Bubble> vertix;
        public static List<Point> points = new List<Point>();
        public static List<List<int>> adjList = new List<List<int>>();
        public static int w=0 , h=0;
        public static void main()
        {
            
            Random R = new Random();
            List<int> choices = new List<int>(4);
            vertix = new List<Bubble>(w * h);
            int choose;
            for (int i = 0; i < w * h; i++)
            {
                vertix.Add(new Bubble(i + 1));
                adjList.Add(new List<int>());
            }
                

            Bubble b;
            for (int i = 0; i < w * h; i++)
            {
                b = vertix[i];
                if (b.me - w > 0)
                    choices.Add(b.me - w);
                if (b.me + w <= w * h)
                    choices.Add(b.me + w);
                if (b.me - 1 > 0 && Math.Ceiling(b.me / (double)w) == Math.Ceiling((b.me - 1) / (double)w))
                    choices.Add(b.me - 1);
                if (b.me + 1 <= w * h && Math.Ceiling(b.me / (double)w) == Math.Ceiling((b.me + 1) / (double)w))
                    choices.Add(b.me + 1);

            k: if (choices.Count > 0)
                {
                    choose = R.Next(100) % choices.Count;
                    if (b.representative == vertix[choices[choose] - 1].representative)
                    {
                        choices.RemoveAt(choose);
                        goto k;
                    }
                    points.Add(new Point(vertix[choices[choose] - 1].me ,b.me));
                    adjList[b.me - 1].Add(vertix[choices[choose] - 1].me);
                    adjList[vertix[choices[choose] - 1].me - 1].Add(b.me );
                    vertix[choices[choose] - 1].parent = b.me;

                    union(b.representative, vertix[choices[choose] - 1].representative);
                    choices = new List<int>(4);
                }

            }
            //Console.ReadKey();
        }
         static void union(Bubble a, Bubble b)
        {

            Bubble C = smaller(a, b);
            Bubble D = Greater(a, b);
            C.representative = D;
            C.changeRepresentative();
            D.children.Add(C);
            D.children.AddRange(C.children);
        }
        static Bubble smaller(Bubble A, Bubble B)
        {
            return A.children.Count <= B.children.Count ? A : B;
        }
        static Bubble Greater(Bubble A, Bubble B)
        {
            return A.children.Count > B.children.Count ? A : B;
        }
    }
}
