using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SignalR.Validation
{
    [Serializable]
    public class ValidationException : Exception
    {
        public ValidationError Error { get; set; }

        public ValidationException() { }

        public ValidationException(string message)
            : base(message)
        { }

        public ValidationException(string message, Exception inner) : base(message, inner) { }

        protected ValidationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
