namespace MyNotePad.Core.Business.Results.Abstract
{
    public interface IBusinessResult
    {
        public string Message { get; }
        public ProcessResultType ProcessResultType { get; }
        public ResultType ResultType { get; }
    }
}
