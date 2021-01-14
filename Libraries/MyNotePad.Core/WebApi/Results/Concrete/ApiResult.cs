using MyNotePad.Core.Business.Results.Abstract;
using MyNotePad.Core.Business.Results.Concrete;
using MyNotePad.Core.WebApi.Results.Abstract;

namespace MyNotePad.Core.WebApi.Results.Concrete
{
    public class ApiResult : BusinessResult, IApiResult
    {
        public ApiResult(string message, ProcessResultType processResultType, ResultType resultType) : base(message, processResultType, resultType)
        {

        }
    }
}
