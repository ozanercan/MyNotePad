using MyNoteApp.DataAccess.Abstract;
using MyNoteApp.DataAccess.Concrete.EntityFramework.DataContexts;
using MyNotePad.Core.DataAccess.RepositoryPattern.Concrete;
using MyNotePad.Entities.Entities;

namespace MyNoteApp.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : RepositoryFull<User, MyNoteAppContext>, IUserDal
    {
    }
}
