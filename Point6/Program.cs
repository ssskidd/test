using System;

namespace Point6
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Drawing;
    using System.Threading;



    enum Direction
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }

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

        public void Move(int offset, Direction direction)
        {
            if (direction == Direction.RIGHT)
            {
                x = x + offset;
            }
            else if (direction == Direction.LEFT)
            {
                x = x - offset;
            }
            else if (direction == Direction.UP)
            {
                y = y - offset;
            }
            else if (direction == Direction.DOWN)
            {
                y = y + offset;
            }
        }

        public void Clear()
        {
            sym = ' ';
            Draw();
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
        public bool IsHit(Figure figure)
        {
            foreach (var p in pList)
            {
                if (figure.IsHit(p))
                    return true;
            }
            return false;
        }

        public bool IsHit(Point point)
        {
            foreach (var p in pList)
            {
                if (p.IsHit(point))
                    return true;
            }
            return false;
        }


    }

    class Snake : Figure
    {
        Direction direction;

        public Snake(Point tail, int length, Direction _direction)
        {
            direction = _direction;
            pList = new List<Point>();
            for (int i = 0; i < length; i++)
            {
                Point p = new Point(tail);
                p.Move(i, direction);
                pList.Add(p);
            }
        }
        public void Move()
        {
            Point tail = pList.First();
            pList.Remove(tail);
            Point head = GetNextPoint();
            pList.Add(head);

            tail.Clear();
            head.Draw();
        }

        private Point GetNextPoint()
        {
            Point head = pList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direction);
            return nextPoint;
        }
        public void Draw()
        {
            foreach (var snake in pList)
            {
                snake.Draw();
            }
        }
        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
                direction = Direction.LEFT;
            else if (key == ConsoleKey.RightArrow)
                direction = Direction.RIGHT;
            else if (key == ConsoleKey.DownArrow)
                direction = Direction.DOWN;
            else if (key == ConsoleKey.UpArrow)
                direction = Direction.UP;
        }
        public bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if (head.IsHit(food))
            {
                food.sym = head.sym;
                pList.Add(food);
                return true;
            }
            else
                return false;
        }
        public bool IsHit(Walls wall)
        {
            Point head = GetNextPoint();


            if (wall.IsHit(this))
            {
                return true;
            }
            else
                return false;
        }
        public bool Smert()
        {
            Point head = GetNextPoint();


            if (this.IsHit(head))
            {
                return true;
            }
            else
                return false;
        }

    }
    class Walls
    {
        List<Figure> wallList;

        public Walls(int mapWidth, int mapHeight)
        {
            wallList = new List<Figure>();


            HorizontalLine upLine = new HorizontalLine(0, mapWidth - 2, 0, '#');
            HorizontalLine downLine = new HorizontalLine(0, mapWidth - 2, mapHeight - 1, '#');
            VerticalLine leftLine = new VerticalLine(0, mapHeight - 1, 0, '#');
            VerticalLine rightLine = new VerticalLine(0, mapHeight - 1, mapWidth - 2, '#');

            wallList.Add(upLine);
            wallList.Add(downLine);
            wallList.Add(leftLine);
            wallList.Add(rightLine);
        }

        public bool IsHit(Figure figure)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }

        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Drow();
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

            Walls wall = new Walls(60, 30);
            wall.Draw();

            Point p = new Point(4, 3, '*');

            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();
            Point food = new Point(10, 5, '@');
            food.Draw();
           
            while (true)
            {

                if (snake.Eat(food))
                {
                    
                    food = new Point(food.x + 2, food.y + 3, '@');                
                    food.Draw();
                    
                }

                else
                {
                    snake.Move();
                }

                Thread.Sleep(75);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }

                if (snake.Smert())
                {
                    Console.Clear();
                    Console.WriteLine("GAME OVER");
                    
                    break;

                }

                if (snake.IsHit(wall))
                {
                    Console.Clear();
                    Console.WriteLine("GAME OVER");
                    
                    break;

                }

            }          

        }
    }
}