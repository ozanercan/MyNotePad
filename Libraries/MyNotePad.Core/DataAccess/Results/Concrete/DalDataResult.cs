using MyNotePad.Core.DataAccess.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNotePad.Core.DataAccess.Results.Concrete
{
    public class DalDataResult<TData> : DalResult, IDalDataResult<TData>
    {
        public DalDataResult(bool isCommited, Exception exception, TData data) : base(isCommited, exception)
        {
            Data = data;
        }

        public TData Data { get; }
    }
}
