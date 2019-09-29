using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer
{
    public class Result<T>
    {
        public string UserMessage { get; set; }
        public bool IsSucceeded { get; set; }
        public T ProcessResult { get; set; }

    }
}
