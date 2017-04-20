using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape[] shapes = {new Hexagon(), new Circle(),
                new Triangle("Joe"), new Circle("JoJo"),
                new ThreeDCircle()};
            for(int i=0; i<shapes.Length; ++i )
            {
                shapes[i].Draw();
                if( shapes[i] is IPointy )
                    Console.WriteLine("-> Points: {0}", ((IPointy)shapes[i]).Points);
                else
                    Console.WriteLine("-> {0} is not IPointy", shapes[i].PetName);
                if( shapes[i] is IDraw3D )
                    DrawIn3D((IDraw3D)shapes[i]);
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        public static void DrawIn3D(IDraw3D i3d)
        {
            Console.WriteLine("-> Drawing IDraw3D compatible type");
            i3d.Draw3D();
        }

        public static IPointy FindFirstPointyShape(Shape[] shapes)
        {
            foreach(Shape s in shapes )
            {
                if(s is IPointy)
                    return s as IPointy
            }
            return null;
        }
    }
}
