namespace MyNotePad.Core.DataAccess.Results.Abstract
{
    public interface IDalDataResult<TData> : IDalResult
    {
        public TData Data { get; }
    }
}
