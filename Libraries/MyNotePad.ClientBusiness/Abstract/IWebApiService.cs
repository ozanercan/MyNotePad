using MyNotePad.Core.Business.Results.Abstract;
using MyNotePad.Core.WebApi.Results.Abstract;
using MyNotePad.Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyNotePad.ClientBusiness.Abstract
{
    public interface IWebApiService
    {
        Task<IBusinessDataResult<List<NoteDto>>> GetNoteDtosAsync();

        Task<IBusinessResult> CreateAsync(NoteCreateDto noteCreateDto);
    }
}
