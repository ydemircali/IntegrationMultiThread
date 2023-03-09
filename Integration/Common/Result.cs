using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integration.Common
{
    public class Result
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }

        public Result(bool success, string message)
        {
            this.Success = success;
            this.Message = message;
        }

    }
}
