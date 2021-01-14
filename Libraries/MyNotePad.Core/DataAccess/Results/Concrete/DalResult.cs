using MyNotePad.Core.DataAccess.Results.Abstract;
using System;

namespace MyNotePad.Core.DataAccess.Results.Concrete
{
    public class DalResult : IDalResult
    {
        public DalResult(bool isCommited, Exception exception)
        {
            IsCommited = isCommited;
            Exception = exception;
        }
        public bool IsCommited { get; }
        public Exception Exception { get; }
    }
}
