using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    // A well-formed custom exception
    [Serializable]  // Needs to be Serializable
    public class CarIsDeadException : ApplicationException
    {
        public CarIsDeadException() { } // Needs a default constructor
        // Needs a constructor which passes the message to the base exception
        public CarIsDeadException(string message) : base(message) { }
        // Needs a constructor that handles "inner exceptions"
        public CarIsDeadException(string message, System.Exception inner)
            : base(message, inner) { }
        // Needs a constructor that handles serialization of the type
        protected CarIsDeadException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }

        // Any additional custom properties, constructors and data members
        public CarIsDeadException(string message, string cause, DateTime time)
            : base(message)
        {
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }

        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }
    }
}
