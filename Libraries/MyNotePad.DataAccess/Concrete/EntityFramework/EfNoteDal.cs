using MyNotePad.Core.DataAccess.RepositoryPattern.Concrete;
using MyNotePad.DataAccess.Abstract;
using MyNotePad.DataAccess.Concrete.EntityFramework.DataContexts;
using MyNotePad.Entities.Entities;

namespace MyNotePad.DataAccess.Concrete.EntityFramework
{
    public class EfNoteDal : RepositoryFull<Note, MyNotePadContext>, INoteDal
    {
    }
}
