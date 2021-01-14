using MyNotePad.Core.Business.Results.Abstract;
using MyNotePad.Core.WebApi.Results.Abstract;

namespace MyNotePad.Core.WebApi.Results.Concrete
{
    public class ApiDataResult<TData> : ApiResult, IApiDataResult<TData>
    {
        public ApiDataResult(string message, ProcessResultType processResultType, ResultType resultType, TData data) : base(message, processResultType, resultType)
        {
            Data = data;
        }

        public TData Data { get; }
    }
}
