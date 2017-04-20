using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    public interface IPointy
    {
        // implicitly public and abstract
        byte GetNumberOfPoints();

        // Property prototypes
        byte Points { get; }
    }
}
