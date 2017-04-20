using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShapes;
//using MyShapes3D;
// resolve the ambiguity using a custom alias
using Hexagon3D = Chapter14.MyShapes3D.Hexagon;
using Square3D = Chapter14.MyShapes3D.Square;
using Circle3D = Chapter14.MyShapes3D.Circle;

// namespace aliases
using BfHome = System.Runtime.Serialization.Formatters.Binary;

namespace CustomNamespaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Hexagon h = new Hexagon();
            Circle c = new Circle();
            Square s = new Square();
            Hexagon3D h3d = new Hexagon3D();
            Circle3D c3d = new Circle3D();
            Square3D s3d = new Square3D();

            BfHome.BinaryFormatter b = new BfHome.BinaryFormatter();
        }
    }
}
