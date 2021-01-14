using MyNotePad.Core.Business.Results.Abstract;
using MyNotePad.Entities.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyNotePad.Business.Abstract
{
    public interface INoteService
    {
        Task<IBusinessResult> CreateNoteAsync(NoteCreateDto noteCreateDto);
        Task<IBusinessDataResult<List<NoteDto>>> GetNoteDtosAsync();
        Task<IBusinessDataResult<NoteDto>> GetDtoByNoteTitleAsync(string noteTitle);


    }
}
