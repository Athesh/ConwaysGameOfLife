using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife {
    public class BadFormatException : System.ApplicationException {
        public BadFormatException() {
        }
        public BadFormatException(string message) : base(message) {
        }
        protected BadFormatException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }
        public BadFormatException(string message, Exception innerException)
            : base(message, innerException) {
        }

    }
}
