using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace isp.platformb2b.web.entities
{
    public class ResultMessage<T>
    {
        public const int RESULT_CODE_OK = 0;
        public const int RESULT_CODE_ERROR = 1;

        public ResultMessage()
        {
        }

        public T Content { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
    }
}
