using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Exceptions
{
    // Exception to be thrown when validation error occurs
    public class BadRequestException : Exception
    {
        public BadRequestException()
        {
            throw new Exception("Validation Error occured in the request");
        }

        public BadRequestException(string message) : base(message)
        {

        }
    }
}
