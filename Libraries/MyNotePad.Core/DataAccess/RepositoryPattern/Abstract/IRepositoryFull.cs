using MyNotePad.Core.DataAccess.Results.Abstract;
using MyNotePad.Core.Entities.Abstract;
using System.Threading.Tasks;

namespace MyNotePad.Core.DataAccess.RepositoryPattern.Abstract
{
    public interface IRepositoryFull<TEntity> : IRepositoryBase<TEntity>
       where TEntity : class, IBaseEntity, IErasableEntity, new()
    {
        Task<IDalResult> ChangeIsDeletedColumn(TEntity entity, bool isDeletedState);
    }
}
