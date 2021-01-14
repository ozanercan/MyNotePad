using MyNotePad.Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace MyNotePad.Entities.DataTransferObjects
{
    public class NoteCreateDto : IDataTransferObject
    {
        [Required, MinLength(3)]
        public string NoteTitle { get; set; }

        [Required, MinLength(3)]
        public string NoteContent { get; set; }
    }
}
