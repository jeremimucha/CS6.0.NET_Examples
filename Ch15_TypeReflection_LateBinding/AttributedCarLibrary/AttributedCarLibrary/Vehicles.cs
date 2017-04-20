using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributedCarLibrary
{
    [Serializable]
    [VehicleDescription(Description = "My rocking Harley")]
    public class Motorcycle
    {

    }

    [Serializable]
    [Obsolete("Use another Vehicle!")]
    [VehicleDescription("The old gray mare, she ain't what she used to be...")]
    public class HorseAndBuggy
    {

    }

    [VehicleDescription("A very long, slow, but feature-rich auto")]
    public class Winnebago
    { }
}
