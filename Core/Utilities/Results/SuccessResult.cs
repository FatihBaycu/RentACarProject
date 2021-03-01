using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Results
{
   public class SuccessResult:Result
    {
        public SuccessResult(string message) : base(true)
        {
        }

        public SuccessResult() : base(true)
        {
        }
    }
}
