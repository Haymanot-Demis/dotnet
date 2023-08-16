using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() 
        {
            throw new Exception("Object not found");
        }

        public NotFoundException(string message) : base(message)
        {

        }
    }
}
