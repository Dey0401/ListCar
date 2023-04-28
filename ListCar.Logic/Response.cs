using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListCar.Logic
{
    public class Response
    {
        public bool IsScucced { get; set; }

        public string Message { get; set; }

        public Response()
        {
            IsScucced = false;
            Message = "Failed process\n";
        }

        public override string ToString()
        {
            if (IsScucced)
            {
                Message = "Succed process\n";
                return Message;
            }
            return Message;
        }
    }
}