using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomConversions
{
    public struct Rectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int w, int h) : this()
        {
            Width = w; Height = h;
        }

        public void Draw()
        {
            for(int i=0; i<Height; ++i )
            {
                for(int j=0; j < Width; ++j )
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        public override string ToString()
        {
            return string.Format("[Width = {0}; Height = {1}]",
                Width, Height);
        }

        // implicit conversion from Square to Rectangle
        public static implicit operator Rectangle(Square s)
        {
            // Assumes the length of the new Rectangle 
            // to be Length * 2
            return new Rectangle(s.Length * 2, s.Length);
        }
    }

    public struct Square
    {
        public int Length { get; set; }
        public Square(int l) : this()
        {
            Length = l;
        }

        public void Draw()
        {
            for(int i=0; i < Length; ++i )
            {
                for(int j = 0; j < Length; ++j )
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        public override string ToString()
        {
            return string.Format("[Length = {0}]", Length);
        }

        // Rectangles can be explicitly converted into Squares
        public static explicit operator Square(Rectangle r)
        {
            return new Square(r.Height);
        }

        // Convert int to a Square
        public static explicit operator Square(int sideLength)
        {
            return new Square(sideLength);
        }

        // Convert Square to an int
        public static explicit operator int(Square s)
        {
            return s.Length;
        }
    }
}
