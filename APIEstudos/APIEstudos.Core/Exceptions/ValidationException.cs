using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEstudos.Core.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : base() { }
        public ValidationException(string message) : base(message) { }
    }
}