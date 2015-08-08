using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Diagnostics;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BFSMaze
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        CompositeTransform x = new CompositeTransform();
        CompositeTransform y = new CompositeTransform();
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Set the input focus to ensure that keyboard events are raised.
            this.Loaded += delegate { this.Focus(FocusState.Programmatic); };
            this.IsTabStop = true;
            this.IsHitTestVisible = true;
            this.KeyDown += MainPage_KeyDown;
            x.SkewX = 0;
            x.SkewY = 0;
            x.Rotation = 0;
            g.RenderTransform = x;
            g.RenderTransformOrigin = new Point(0, 0);
            Global.g = g;

        }



        void MainPage_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.S)
            {
                x.TranslateY -= 10;
            }

            if (e.Key == VirtualKey.W)
                x.TranslateY += 10;
            if (e.Key == VirtualKey.A)
                x.TranslateX -= 10;
            if (e.Key == VirtualKey.D)
                x.TranslateX += 10;
            else
                Global.s.act(y, e.Key);
        }

        int w=Global.w = 20;
        int h = Global.h= 20;
        public MainPage()
        {
            this.InitializeComponent();
            program.h = h; program.w = w;
            program.main();
            
            
            for (int i = 0; i < h*w; i++)
            {
                Point n = new Point((i % w) * 100, 100 * (i / w));
                CompositeTransform x1 = new CompositeTransform();
                Global.Q.Add(n);
                x1.TranslateX = n.X-10;
                x1.TranslateY = n.Y-10;
                Rectangle r = new Rectangle() { Height = 20, Width = 20,StrokeThickness = 0,Fill = new SolidColorBrush(Colors.Blue), HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Left, VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Top, RenderTransform = x1, RenderTransformOrigin = new Point(0.5, 0.5) };
                g.Children.Add(r);
            }
           
            Point p;
            for (int i = 0; i < program.points.Count; i++)
            {
                p = program.points[i];
                CompositeTransform x = new CompositeTransform();
                x.TranslateX = p.X;
                x.TranslateY = p.Y;
                Line myLine1 = new Line();
                myLine1.Stroke = new SolidColorBrush(Colors.Blue);
                myLine1.X1 = Global.Q[(int)p.X - 1].X;
                myLine1.Y1 = Global.Q[(int)p.X - 1].Y;
                myLine1.X2 = Global.Q[(int)p.Y - 1].X;
                myLine1.Y2 = Global.Q[(int)p.Y-1].Y;
                //myLine1.RenderTransformOrigin = new Point(0, 0);
                //myLine1.RenderTransform = x;
                myLine1.HorizontalAlignment = HorizontalAlignment.Left;
                myLine1.VerticalAlignment = VerticalAlignment.Top;
                myLine1.StrokeThickness = 5;
                
                //Rectangle r = new Rectangle() { Height = 3, Width = 3, Fill = new SolidColorBrush(Colors.Violet), HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center, VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Center/*, RenderTransform = x, RenderTransformOrigin = new Point(0, 0) */};
                //g.Children.Add(r);
                g.Children.Add(myLine1);
            }
            Rectangle player = new Rectangle() { Height = 20, Width = 20, Fill = new SolidColorBrush(Colors.Violet), HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Left, VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Top, RenderTransform = y, RenderTransformOrigin = new Point(0, 0) };
            g.Children.Add(player);
            CompositeTransform k = new CompositeTransform();
            Random R = new Random();
            int l = R.Next(Global.Q.Count);
            k.TranslateX = Global.Q[l].X-10;
            k.TranslateY = Global.Q[l].Y-10;
            y.TranslateX = k.TranslateX;
            y.TranslateY = k.TranslateY;
            Global.s = Global.vcurrent;
            Global.defineRoutes(Global.vcurrent,l+1);
            Rectangle start = new Rectangle() { Height = 20, Width = 20, Fill = new SolidColorBrush(Colors.Red), HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Left, VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Top, RenderTransform = k, RenderTransformOrigin = new Point(0.5, 0.5) };
            CompositeTransform k1 = new CompositeTransform();
            g.Children.Add(start);
            l = R.Next(Global.Q.Count);
            Global.end = l+1;
            k1.TranslateX = Global.Q[l].X-10;
            k1.TranslateY = Global.Q[l].Y-10;
            Rectangle stop = new Rectangle() { Height = 20, Width = 20, Fill = new SolidColorBrush(Colors.Pink), HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Left, VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Top, RenderTransform = k1, RenderTransformOrigin = new Point(0.5, 0.5) };
            g.Children.Add(stop);
            
        }
       
    }
}
