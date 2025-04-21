using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsApp.SERVICE.Exceptions
{
    public abstract class PetsAppException : Exception
    {
        public string? ErroCode { get; }

        protected PetsAppException(string message, string? errorCode = null) : base(message)
        {
            ErroCode = errorCode;
        }
    }
}
