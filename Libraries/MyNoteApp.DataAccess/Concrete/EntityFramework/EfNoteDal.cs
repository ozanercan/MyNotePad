using MyNoteApp.DataAccess.Abstract;
using MyNoteApp.DataAccess.Concrete.EntityFramework.DataContexts;
using MyNotePad.Core.DataAccess.RepositoryPattern.Concrete;
using MyNotePad.Entities.Entities;

namespace MyNoteApp.DataAccess.Concrete.EntityFramework
{
    public class EfNoteDal : RepositoryFull<Note, MyNoteAppContext>, INoteDal
    {
    }
}
