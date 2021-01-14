using System;
using MyNotePad.Core.Entities.Abstract;
namespace MyNotePad.Entities.Entities
{
    public class Note : IBaseEntity, IDateEntity, IErasableEntity
    {
        public Guid Id { get; set; }

        public string NoteTitle { get; set; }
        public string NoteContent { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
