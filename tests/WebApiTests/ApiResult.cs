using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiTests
{
    public class ApiResult<T>
    {
        public int status { get; set; }
        public T data { get; set; }
    }
}
