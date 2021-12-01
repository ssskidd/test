using System;

namespace Point2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Drawing;

    class Point
    {
        public int x;
        public int y;
        public char sym;
        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }

        public Point(int _x, int _y, char _sym)
        {
            x = _x;
            y = _y;
            sym = _sym;
 
            
        }

    }

    class Figure
    {
        protected List<Point> pList;

        public void Drow()
        {
            foreach (Point p in pList)
            {

                p.Draw();

            }
        }
    }

    class VerticalLine : Figure
    {
        public VerticalLine(int yUp, int yDown, int x, char sym)
        {
            pList = new List<Point>();
            for (int y = yUp; y <= yDown; y++)
            {
                Point p = new Point(x, y, sym);
                pList.Add(p);
            }
        }
    }

    class HorizontalLine : Figure
    {
        public HorizontalLine(int xLeft, int xRight, int y, char sym)
        {
            pList = new List<Point>();
            for (int x = xLeft; x <= xRight; x++)
            {
                Point p = new Point(x, y, sym);
                pList.Add(p);
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            HorizontalLine h1 = new HorizontalLine(1, 10, 1, '*');
            h1.Drow();
            HorizontalLine h2 = new HorizontalLine(1, 10, 4, '*');
            h2.Drow();
            HorizontalLine h3 = new HorizontalLine(0, 0, 0, ' ');
            h3.Drow();
            VerticalLine v1 = new VerticalLine(1, 3, 1, '*');
            v1.Drow();
            VerticalLine v2 = new VerticalLine(1, 3, 10, '*');
            v2.Drow();
            VerticalLine v3 = new VerticalLine(0, 0, 0, ' ');
            v3.Drow();

            Console.ReadKey();
        }
    }
}   