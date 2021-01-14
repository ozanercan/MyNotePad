using System;

namespace MyNotePad.Entities.DataTransferObjects
{
    public class NoteDto
    {
        public string NoteTitle { get; set; }
        public string NoteContent { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
