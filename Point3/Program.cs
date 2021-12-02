using System;

namespace Point3
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


        public Point(int x, int y, char sym)
        {
            this.x = x;
            this.y = y;
            this.sym = sym;

        }
        public Point(Point p)
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }

        public bool IsHit(Point p)
        {
            return p.x == this.x && p.y == this.y;
        }
        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
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
        public  bool IsHit(Figure figure)
        {
            foreach (var p in pList)
            {
                if (figure.IsHit(p))
                    return true;
            }
            return false;
        }

        public  bool IsHit(Point point)
        {
            foreach (var p in pList)
            {
                if (p.IsHit(point))
                    return true;
            }
            return false;
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

            VerticalLine v1 = new VerticalLine(4, 5, 2, '*');
            v1.Drow();


            if (v1.IsHit(h1))
            {
                Console.WriteLine();
                Console.WriteLine("Линии совпадают");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Линии не совпадают");
            }

            Console.ReadKey();
        }
    }
}
