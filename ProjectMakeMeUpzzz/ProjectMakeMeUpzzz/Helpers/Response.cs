using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMakeMeUpzzz.Helpers
{
    public class Response<T>
    {
        public Boolean IsSuccess { get; set; }
        public string Message { get; set; }
        public T Payload { get; set; }
    }
}