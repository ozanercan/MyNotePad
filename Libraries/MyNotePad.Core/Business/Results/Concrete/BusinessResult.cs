using MyNotePad.Core.Business.Results.Abstract;

namespace MyNotePad.Core.Business.Results.Concrete
{
    public class BusinessResult : IBusinessResult
    {
        public BusinessResult(string message, ProcessResultType processResultType, ResultType resultType)
        {
            Message = message;
            ProcessResultType = processResultType;
            ResultType = resultType;
        }

        public string Message { get; }

        public ProcessResultType ProcessResultType { get; }

        public ResultType ResultType { get; }
    }
}
