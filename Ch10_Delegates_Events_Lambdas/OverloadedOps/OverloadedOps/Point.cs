using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverloadedOps
{
    class Point : IComparable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int xPos, int yPos)
        {
            X = xPos;
            Y = yPos;
        }

        public override string ToString()
        {
            return string.Format("[{0}, {1}]", this.X, this.Y);
        }

        // Binary operators
        // ----------------------------------------------------------
        public static Point operator+(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static Point operator+(Point p, int change)
        {
            return new Point(p.X + change, p.Y + change);
        }

        public static Point operator+(int change, Point p)
        {
            return new Point(p.X + change, p.Y + change);
        }

        public static Point operator-(Point a, Point b)
        {
            return new Point(a.X - b.X, a.Y - b.Y);
        }
        // ----------------------------------------------------------

        // Unary operators
        // ----------------------------------------------------------
        public static Point operator++(Point p)
        {
            return new Point(p.X + 1, p.Y + 1);
        }

        public static Point operator--(Point p)
        {
            return new Point(p.X - 1, p.Y - 1);
        }
        // ----------------------------------------------------------

        // Comparison operators
        // ----------------------------------------------------------
        public override bool Equals(object obj)
        {
            Point p = obj as Point;
            if( p == null )
                return false;

            return this.X == p.X
                && this.Y == p.Y;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public int CompareTo(Point other)
        {
            if( this.X > other.X && this.Y > other.Y )
                return 1;
            if( this.X < other.X && this.Y < other.Y )
                return -1;
            else
                return 0;
        }

        public static bool operator==(Point a, Point b)
        {
            return a.Equals(b);
        }
        public static bool operator!=(Point a, Point b)
        {
            return !a.Equals(b);
        }

        public static bool operator<(Point a, Point b)
        { return (a.CompareTo(b) < 0); }

        public static bool operator>(Point a, Point b)
        { return (a.CompareTo(b) > 0); }

        public static bool operator<=(Point a, Point b)
        { return (a.CompareTo(b) <= 0); }

        public static bool operator>=(Point a, Point b)
        { return (a.CompareTo(b) >= 0); }
        // ----------------------------------------------------------
    }
}
