using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleJwtAuth.Core.ActionResult;
public class ResultException : Exception
{
    public ResultException(string message) : base(message)
    {
    }

    public ResultException(string message, Exception e) : base(message, e)
    {

    }
}

public class ExceptionResult
{
    public string Message { get; set; }
}
