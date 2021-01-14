using System;

namespace MyNotePad.Core.DataAccess.Results.Abstract
{
    public interface IDalResult
    {
        public bool IsCommited { get; }
        public Exception Exception { get; }
    }
}
