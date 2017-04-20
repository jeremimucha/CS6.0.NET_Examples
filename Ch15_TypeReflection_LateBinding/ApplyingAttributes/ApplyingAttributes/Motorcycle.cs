using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyingAttributes
{
    [Serializable]
    class Motorcycle
    {
        [NonSerialized] // not serialized field
        float weightOfCurrentPassengers;
        // These fields are still serialized
        bool hasRadioSystem;
        bool hasHeadSet;
        bool HasSissyBar;
    }

    [Serializable, Obsolete("Use another Vehicle class")]
    public class HorseAndBuggy
    {

    }

}
