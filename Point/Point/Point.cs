using System;

namespace Point
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Point
    {
        public int x;
        public int y;
        public char sym;

        public void X(int x)
        {
            if (x >= 0)
                this.x = x;
            else
                throw new Exception("Значение x не может быть отрицательным");
        }
        public void Y(int y)
        {
            if (y >= 0)
                this.y = y;
            else
                throw new Exception("Значение y не может быть отрицательным");
        }
        public void Sym(char symbol)
        {
            sym = symbol;
        }
        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }
    }



class Program
    {
        static void Main(string[] args)
        {
            Point p = new Point();
            p.x = 1;
            p.y = 1;
            p.sym = '-';
            p.Draw();

            Point p2 = new Point();
            p2.x = 2;
            p2.y = 1;
            p2.sym = '-';
            p2.Draw();

            Point p3 = new Point();
            p3.x = 3;
            p3.y = 1;
            p3.sym = '-';
            p3.Draw();

            Point p4 = new Point();
            p4.x = 4;
            p4.y = 1;
            p4.sym = '-';
            p4.Draw();

            Point p5 = new Point();
            p5.x = 1;
            p5.y = 2;
            p5.sym = ' ';
            p5.Draw();

            Point p6 = new Point();
            p6.x = 2;
            p6.y = 2;
            p6.sym = '#';
            p6.Draw();

            Point p7 = new Point();
            p7.x = 3;
            p7.y = 2;
            p7.sym = '#';
            p7.Draw();

            Point p8 = new Point();
            p8.x = 4;
            p8.y = 2;
            p8.sym = '-';
            p8.Draw();

            Point p9 = new Point();
            p9.x = 5;
            p9.y = 2;
            p9.sym = '-';
            p9.Draw();

            Point p10 = new Point();
            p10.x = 1;
            p10.y = 3;
            p10.sym = '-';
            p10.Draw();

            Point p11 = new Point();
            p11.x = 2;
            p11.y = 3;
            p11.sym = '-';
            p11.Draw();

            Point p12 = new Point();
            p12.x = 3;
            p12.y = 3;
            p12.sym = '-';
            p12.Draw();

            Point p13 = new Point();
            p13.x = 4;
            p13.y = 3;
            p13.sym = '-';
            p13.Draw();

        }
    }
}
