using ProgrammersBlog.Shared.Utilities.Result.Complex_Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Utilities.Result.Abstract
{
   public interface IResult
    {
        public ResultStatus ResultStatus { get; }
        public string Message { get;  }
        public Exception Exception { get;  }
    }
}
