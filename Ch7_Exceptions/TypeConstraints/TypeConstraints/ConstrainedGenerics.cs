using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeConstraints
{
    // MyGenericClass derives from object, while
    // contained items must have adefault constructor,
    public class MyGenericClass<T> where T : new()
    {
        // ...
    }

    // MyGenericClass2<T> derives from object, while
    // contained items must be a class implementing IDrawable
    // and must support a default ctor
    public class MyGenericClass2<T> where T : class, IDrawable<T>, new()
    {

    }

    // <K> must extend SomeBaseClass and have a default ctor,
    // <T> must be a structure and implement the 
    // generic IComparable interface
    public class MyGenericClass3<K,T> where K : SomeBaseClass, new()
        where T : struct, IComparable<T>
    {

    }


    public interface IDrawable<T>
    { }

    public class SomeBaseClass
    {

    }
}
