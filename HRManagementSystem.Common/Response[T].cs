using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.Common
{
    public class Response<T> : Response
    {
        public Response(ResponseType responseType) : base(responseType)
        {
        }
    }
}
