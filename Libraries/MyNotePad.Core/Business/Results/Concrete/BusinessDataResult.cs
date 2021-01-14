using MyNotePad.Core.Business.Results.Abstract;

namespace MyNotePad.Core.Business.Results.Concrete
{
    public class BusinessDataResult<TData> : BusinessResult, IBusinessDataResult<TData>
    {
        public BusinessDataResult(string message, ProcessResultType processResultType, ResultType resultType, TData data) : base(message, processResultType, resultType)
        {
            Data = data;
        }

        public TData Data { get; }
    }
}
